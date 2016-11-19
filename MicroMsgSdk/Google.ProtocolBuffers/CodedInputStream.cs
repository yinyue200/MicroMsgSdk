using Google.ProtocolBuffers.Descriptors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Google.ProtocolBuffers
{
	public sealed class CodedInputStream : ICodedInputStream
	{
		internal const int DefaultRecursionLimit = 64;

		internal const int DefaultSizeLimit = 67108864;

		public const int BufferSize = 4096;

		private readonly byte[] buffer;

		private int bufferSize;

		private int bufferSizeAfterLimit;

		private int bufferPos;

		private readonly Stream input;

		private uint lastTag;

		private uint nextTag;

		private bool hasNextTag;

		private int totalBytesRetired;

		private int currentLimit = 2147483647;

		private int recursionDepth;

		private int recursionLimit = 64;

		private int sizeLimit = 67108864;

		public bool ReachedLimit
		{
			get
			{
				if (this.currentLimit == 2147483647)
				{
					return false;
				}
				int num = this.totalBytesRetired + this.bufferPos;
				return num >= this.currentLimit;
			}
		}

		public bool IsAtEnd
		{
			get
			{
				return this.bufferPos == this.bufferSize && !this.RefillBuffer(false);
			}
		}

		public static CodedInputStream CreateInstance(Stream input)
		{
			return new CodedInputStream(input);
		}

		public static CodedInputStream CreateInstance(byte[] buf)
		{
			return new CodedInputStream(buf, 0, buf.Length);
		}

		public static CodedInputStream CreateInstance(byte[] buf, int offset, int length)
		{
			return new CodedInputStream(buf, offset, length);
		}

		private CodedInputStream(byte[] buffer, int offset, int length)
		{
			this.buffer = buffer;
			this.bufferPos = offset;
			this.bufferSize = offset + length;
			this.input = null;
		}

		private CodedInputStream(Stream input)
		{
			this.buffer = new byte[4096];
			this.bufferSize = 0;
			this.input = input;
		}

		void ICodedInputStream.ReadMessageStart()
		{
		}

		void ICodedInputStream.ReadMessageEnd()
		{
		}

		
		public void CheckLastTagWas(uint value)
		{
			if (this.lastTag != value)
			{
				throw InvalidProtocolBufferException.InvalidEndTag();
			}
		}

		
		public bool PeekNextTag(out uint fieldTag, out string fieldName)
		{
			if (this.hasNextTag)
			{
				fieldName = null;
				fieldTag = this.nextTag;
				return true;
			}
			uint num = this.lastTag;
			this.hasNextTag = this.ReadTag(out this.nextTag, out fieldName);
			this.lastTag = num;
			fieldTag = this.nextTag;
			return this.hasNextTag;
		}

		
		public bool ReadTag(out uint fieldTag, out string fieldName)
		{
			fieldName = null;
			if (this.hasNextTag)
			{
				fieldTag = this.nextTag;
				this.lastTag = fieldTag;
				this.hasNextTag = false;
				return true;
			}
			if (this.IsAtEnd)
			{
				fieldTag = 0u;
				this.lastTag = fieldTag;
				return false;
			}
			fieldTag = this.ReadRawVarint32();
			this.lastTag = fieldTag;
			if (this.lastTag == 0u)
			{
				throw InvalidProtocolBufferException.InvalidTag();
			}
			return true;
		}

		public bool ReadDouble(ref double value)
		{
			if (BitConverter.IsLittleEndian && 8 <= this.bufferSize - this.bufferPos)
			{
				value = BitConverter.ToDouble(this.buffer, this.bufferPos);
				this.bufferPos += 8;
			}
			else
			{
				byte[] array = this.ReadRawBytes(8);
				if (!BitConverter.IsLittleEndian)
				{
					ByteArray.Reverse(array);
				}
				value = BitConverter.ToDouble(array, 0);
			}
			return true;
		}

		public bool ReadFloat(ref float value)
		{
			if (BitConverter.IsLittleEndian && 4 <= this.bufferSize - this.bufferPos)
			{
				value = BitConverter.ToSingle(this.buffer, this.bufferPos);
				this.bufferPos += 4;
			}
			else
			{
				byte[] array = this.ReadRawBytes(4);
				if (!BitConverter.IsLittleEndian)
				{
					ByteArray.Reverse(array);
				}
				value = BitConverter.ToSingle(array, 0);
			}
			return true;
		}

		
		public bool ReadUInt64(ref ulong value)
		{
			value = this.ReadRawVarint64();
			return true;
		}

		public bool ReadInt64(ref long value)
		{
			value = (long)this.ReadRawVarint64();
			return true;
		}

		public bool ReadInt32(ref int value)
		{
			value = (int)this.ReadRawVarint32();
			return true;
		}

		
		public bool ReadFixed64(ref ulong value)
		{
			value = this.ReadRawLittleEndian64();
			return true;
		}

		
		public bool ReadFixed32(ref uint value)
		{
			value = this.ReadRawLittleEndian32();
			return true;
		}

		public bool ReadBool(ref bool value)
		{
			value = (this.ReadRawVarint32() != 0u);
			return true;
		}

		public bool ReadString(ref string value)
		{
			int num = (int)this.ReadRawVarint32();
			if (num == 0)
			{
				value = "";
				return true;
			}
			if (num <= this.bufferSize - this.bufferPos)
			{
				string @string = Encoding.UTF8.GetString(this.buffer, this.bufferPos, num);
				this.bufferPos += num;
				value = @string;
				return true;
			}
			value = Encoding.UTF8.GetString(this.ReadRawBytes(num), 0, num);
			return true;
		}

		public void ReadGroup(int fieldNumber, IBuilderLite builder, ExtensionRegistry extensionRegistry)
		{
			if (this.recursionDepth >= this.recursionLimit)
			{
				throw InvalidProtocolBufferException.RecursionLimitExceeded();
			}
			this.recursionDepth++;
			builder.WeakMergeFrom(this, extensionRegistry);
			this.CheckLastTagWas(WireFormat.MakeTag(fieldNumber, WireFormat.WireType.EndGroup));
			this.recursionDepth--;
		}

		[Obsolete]
		public void ReadUnknownGroup(int fieldNumber, IBuilderLite builder)
		{
			if (this.recursionDepth >= this.recursionLimit)
			{
				throw InvalidProtocolBufferException.RecursionLimitExceeded();
			}
			this.recursionDepth++;
			builder.WeakMergeFrom(this);
			this.CheckLastTagWas(WireFormat.MakeTag(fieldNumber, WireFormat.WireType.EndGroup));
			this.recursionDepth--;
		}

		public void ReadMessage(IBuilderLite builder, ExtensionRegistry extensionRegistry)
		{
			int byteLimit = (int)this.ReadRawVarint32();
			if (this.recursionDepth >= this.recursionLimit)
			{
				throw InvalidProtocolBufferException.RecursionLimitExceeded();
			}
			int oldLimit = this.PushLimit(byteLimit);
			this.recursionDepth++;
			builder.WeakMergeFrom(this, extensionRegistry);
			this.CheckLastTagWas(0u);
			this.recursionDepth--;
			this.PopLimit(oldLimit);
		}

		public bool ReadBytes(ref ByteString value)
		{
			int num = (int)this.ReadRawVarint32();
			if (num < this.bufferSize - this.bufferPos && num > 0)
			{
				ByteString byteString = ByteString.CopyFrom(this.buffer, this.bufferPos, num);
				this.bufferPos += num;
				value = byteString;
				return true;
			}
			value = ByteString.AttachBytes(this.ReadRawBytes(num));
			return true;
		}

		
		public bool ReadUInt32(ref uint value)
		{
			value = this.ReadRawVarint32();
			return true;
		}

		public bool ReadEnum(ref IEnumLite value, out object unknown, IEnumLiteMap mapping)
		{
			int num = (int)this.ReadRawVarint32();
			value = mapping.FindValueByNumber(num);
			if (value != null)
			{
				unknown = null;
				return true;
			}
			unknown = num;
			return false;
		}

		
		public bool ReadEnum<T>(ref T value, out object unknown) where T : struct, IComparable, IFormattable, IConvertible
		{
			int num = (int)this.ReadRawVarint32();
			if (Enum.IsDefined(typeof(T), num))
			{
				unknown = null;
				value = (T)((object)num);
				return true;
			}
			unknown = num;
			return false;
		}

		public bool ReadSFixed32(ref int value)
		{
			value = (int)this.ReadRawLittleEndian32();
			return true;
		}

		public bool ReadSFixed64(ref long value)
		{
			value = (long)this.ReadRawLittleEndian64();
			return true;
		}

		public bool ReadSInt32(ref int value)
		{
			value = CodedInputStream.DecodeZigZag32(this.ReadRawVarint32());
			return true;
		}

		public bool ReadSInt64(ref long value)
		{
			value = CodedInputStream.DecodeZigZag64(this.ReadRawVarint64());
			return true;
		}

		private bool BeginArray(uint fieldTag, out bool isPacked, out int oldLimit)
		{
			isPacked = (WireFormat.GetTagWireType(fieldTag) == WireFormat.WireType.LengthDelimited);
			if (!isPacked)
			{
				oldLimit = -1;
				return true;
			}
			int num = (int)(this.ReadRawVarint32() & 2147483647u);
			if (num > 0)
			{
				oldLimit = this.PushLimit(num);
				return true;
			}
			oldLimit = -1;
			return false;
		}

		private bool ContinueArray(uint currentTag)
		{
			uint num;
			string text;
			if (this.PeekNextTag(out num, out text) && num == currentTag)
			{
				this.hasNextTag = false;
				return true;
			}
			return false;
		}

		private bool ContinueArray(uint currentTag, bool packed, int oldLimit)
		{
			if (packed)
			{
				if (this.ReachedLimit)
				{
					this.PopLimit(oldLimit);
					return false;
				}
				return true;
			}
			else
			{
				uint num;
				string text;
				if (this.PeekNextTag(out num, out text) && num == currentTag)
				{
					this.hasNextTag = false;
					return true;
				}
				return false;
			}
		}

		
		public void ReadPrimitiveArray(FieldType fieldType, uint fieldTag, string fieldName, ICollection<object> list)
		{
			WireFormat.WireType wireType = WireFormat.GetWireType(fieldType);
			WireFormat.WireType tagWireType = WireFormat.GetTagWireType(fieldTag);
			if (wireType != tagWireType && tagWireType == WireFormat.WireType.LengthDelimited)
			{
				int byteLimit = (int)(this.ReadRawVarint32() & 2147483647u);
				int oldLimit = this.PushLimit(byteLimit);
				while (!this.ReachedLimit)
				{
					object obj = null;
					if (this.ReadPrimitiveField(fieldType, ref obj))
					{
						list.Add(obj);
					}
				}
				this.PopLimit(oldLimit);
				return;
			}
			object obj2 = null;
			do
			{
				if (this.ReadPrimitiveField(fieldType, ref obj2))
				{
					list.Add(obj2);
				}
			}
			while (this.ContinueArray(fieldTag));
		}

		
		public void ReadStringArray(uint fieldTag, string fieldName, ICollection<string> list)
		{
			string text = null;
			do
			{
				this.ReadString(ref text);
				list.Add(text);
			}
			while (this.ContinueArray(fieldTag));
		}

		
		public void ReadBytesArray(uint fieldTag, string fieldName, ICollection<ByteString> list)
		{
			ByteString byteString = null;
			do
			{
				this.ReadBytes(ref byteString);
				list.Add(byteString);
			}
			while (this.ContinueArray(fieldTag));
		}

		
		public void ReadBoolArray(uint fieldTag, string fieldName, ICollection<bool> list)
		{
			bool packed;
			int oldLimit;
			if (this.BeginArray(fieldTag, out packed, out oldLimit))
			{
				bool flag = false;
				do
				{
					this.ReadBool(ref flag);
					list.Add(flag);
				}
				while (this.ContinueArray(fieldTag, packed, oldLimit));
			}
		}

		
		public void ReadInt32Array(uint fieldTag, string fieldName, ICollection<int> list)
		{
			bool packed;
			int oldLimit;
			if (this.BeginArray(fieldTag, out packed, out oldLimit))
			{
				int num = 0;
				do
				{
					this.ReadInt32(ref num);
					list.Add(num);
				}
				while (this.ContinueArray(fieldTag, packed, oldLimit));
			}
		}

		
		public void ReadSInt32Array(uint fieldTag, string fieldName, ICollection<int> list)
		{
			bool packed;
			int oldLimit;
			if (this.BeginArray(fieldTag, out packed, out oldLimit))
			{
				int num = 0;
				do
				{
					this.ReadSInt32(ref num);
					list.Add(num);
				}
				while (this.ContinueArray(fieldTag, packed, oldLimit));
			}
		}

		
		public void ReadUInt32Array(uint fieldTag, string fieldName, ICollection<uint> list)
		{
			bool packed;
			int oldLimit;
			if (this.BeginArray(fieldTag, out packed, out oldLimit))
			{
				uint num = 0u;
				do
				{
					this.ReadUInt32(ref num);
					list.Add(num);
				}
				while (this.ContinueArray(fieldTag, packed, oldLimit));
			}
		}

		
		public void ReadFixed32Array(uint fieldTag, string fieldName, ICollection<uint> list)
		{
			bool packed;
			int oldLimit;
			if (this.BeginArray(fieldTag, out packed, out oldLimit))
			{
				uint num = 0u;
				do
				{
					this.ReadFixed32(ref num);
					list.Add(num);
				}
				while (this.ContinueArray(fieldTag, packed, oldLimit));
			}
		}

		
		public void ReadSFixed32Array(uint fieldTag, string fieldName, ICollection<int> list)
		{
			bool packed;
			int oldLimit;
			if (this.BeginArray(fieldTag, out packed, out oldLimit))
			{
				int num = 0;
				do
				{
					this.ReadSFixed32(ref num);
					list.Add(num);
				}
				while (this.ContinueArray(fieldTag, packed, oldLimit));
			}
		}

		
		public void ReadInt64Array(uint fieldTag, string fieldName, ICollection<long> list)
		{
			bool packed;
			int oldLimit;
			if (this.BeginArray(fieldTag, out packed, out oldLimit))
			{
				long num = 0L;
				do
				{
					this.ReadInt64(ref num);
					list.Add(num);
				}
				while (this.ContinueArray(fieldTag, packed, oldLimit));
			}
		}

		
		public void ReadSInt64Array(uint fieldTag, string fieldName, ICollection<long> list)
		{
			bool packed;
			int oldLimit;
			if (this.BeginArray(fieldTag, out packed, out oldLimit))
			{
				long num = 0L;
				do
				{
					this.ReadSInt64(ref num);
					list.Add(num);
				}
				while (this.ContinueArray(fieldTag, packed, oldLimit));
			}
		}

		
		public void ReadUInt64Array(uint fieldTag, string fieldName, ICollection<ulong> list)
		{
			bool packed;
			int oldLimit;
			if (this.BeginArray(fieldTag, out packed, out oldLimit))
			{
				ulong num = 0uL;
				do
				{
					this.ReadUInt64(ref num);
					list.Add(num);
				}
				while (this.ContinueArray(fieldTag, packed, oldLimit));
			}
		}

		
		public void ReadFixed64Array(uint fieldTag, string fieldName, ICollection<ulong> list)
		{
			bool packed;
			int oldLimit;
			if (this.BeginArray(fieldTag, out packed, out oldLimit))
			{
				ulong num = 0uL;
				do
				{
					this.ReadFixed64(ref num);
					list.Add(num);
				}
				while (this.ContinueArray(fieldTag, packed, oldLimit));
			}
		}

		
		public void ReadSFixed64Array(uint fieldTag, string fieldName, ICollection<long> list)
		{
			bool packed;
			int oldLimit;
			if (this.BeginArray(fieldTag, out packed, out oldLimit))
			{
				long num = 0L;
				do
				{
					this.ReadSFixed64(ref num);
					list.Add(num);
				}
				while (this.ContinueArray(fieldTag, packed, oldLimit));
			}
		}

		
		public void ReadDoubleArray(uint fieldTag, string fieldName, ICollection<double> list)
		{
			bool packed;
			int oldLimit;
			if (this.BeginArray(fieldTag, out packed, out oldLimit))
			{
				double num = 0.0;
				do
				{
					this.ReadDouble(ref num);
					list.Add(num);
				}
				while (this.ContinueArray(fieldTag, packed, oldLimit));
			}
		}

		
		public void ReadFloatArray(uint fieldTag, string fieldName, ICollection<float> list)
		{
			bool packed;
			int oldLimit;
			if (this.BeginArray(fieldTag, out packed, out oldLimit))
			{
				float num = 0f;
				do
				{
					this.ReadFloat(ref num);
					list.Add(num);
				}
				while (this.ContinueArray(fieldTag, packed, oldLimit));
			}
		}

		
		public void ReadEnumArray(uint fieldTag, string fieldName, ICollection<IEnumLite> list, out ICollection<object> unknown, IEnumLiteMap mapping)
		{
			unknown = null;
			IEnumLite enumLite = null;
			WireFormat.WireType tagWireType = WireFormat.GetTagWireType(fieldTag);
			if (tagWireType == WireFormat.WireType.LengthDelimited)
			{
				int byteLimit = (int)(this.ReadRawVarint32() & 2147483647u);
				int oldLimit = this.PushLimit(byteLimit);
				while (!this.ReachedLimit)
				{
					object obj;
					if (this.ReadEnum(ref enumLite, out obj, mapping))
					{
						list.Add(enumLite);
					}
					else
					{
						if (unknown == null)
						{
							unknown = new List<object>();
						}
						unknown.Add(obj);
					}
				}
				this.PopLimit(oldLimit);
				return;
			}
			do
			{
				object obj;
				if (this.ReadEnum(ref enumLite, out obj, mapping))
				{
					list.Add(enumLite);
				}
				else
				{
					if (unknown == null)
					{
						unknown = new List<object>();
					}
					unknown.Add(obj);
				}
			}
			while (this.ContinueArray(fieldTag));
		}

		
		public void ReadEnumArray<T>(uint fieldTag, string fieldName, ICollection<T> list, out ICollection<object> unknown) where T : struct, IComparable, IFormattable, IConvertible
		{
			unknown = null;
			T t = default(T);
			WireFormat.WireType tagWireType = WireFormat.GetTagWireType(fieldTag);
			if (tagWireType == WireFormat.WireType.LengthDelimited)
			{
				int byteLimit = (int)(this.ReadRawVarint32() & 2147483647u);
				int oldLimit = this.PushLimit(byteLimit);
				while (!this.ReachedLimit)
				{
					object obj;
					if (this.ReadEnum<T>(ref t, out obj))
					{
						list.Add(t);
					}
					else
					{
						if (unknown == null)
						{
							unknown = new List<object>();
						}
						unknown.Add(obj);
					}
				}
				this.PopLimit(oldLimit);
				return;
			}
			do
			{
				object obj;
				if (this.ReadEnum<T>(ref t, out obj))
				{
					list.Add(t);
				}
				else
				{
					if (unknown == null)
					{
						unknown = new List<object>();
					}
					unknown.Add(obj);
				}
			}
			while (this.ContinueArray(fieldTag));
		}

		
		public void ReadMessageArray<T>(uint fieldTag, string fieldName, ICollection<T> list, T messageType, ExtensionRegistry registry) where T : IMessageLite
		{
			do
			{
				IBuilderLite builderLite = messageType.WeakCreateBuilderForType();
				this.ReadMessage(builderLite, registry);
				list.Add((T)((object)builderLite.WeakBuildPartial()));
			}
			while (this.ContinueArray(fieldTag));
		}

		
		public void ReadGroupArray<T>(uint fieldTag, string fieldName, ICollection<T> list, T messageType, ExtensionRegistry registry) where T : IMessageLite
		{
			do
			{
				IBuilderLite builderLite = messageType.WeakCreateBuilderForType();
				this.ReadGroup(WireFormat.GetTagFieldNumber(fieldTag), builderLite, registry);
				list.Add((T)((object)builderLite.WeakBuildPartial()));
			}
			while (this.ContinueArray(fieldTag));
		}

		public bool ReadPrimitiveField(FieldType fieldType, ref object value)
		{
			switch (fieldType)
			{
			case FieldType.Double:
			{
				double num = 0.0;
				if (this.ReadDouble(ref num))
				{
					value = num;
					return true;
				}
				return false;
			}
			case FieldType.Float:
			{
				float num2 = 0f;
				if (this.ReadFloat(ref num2))
				{
					value = num2;
					return true;
				}
				return false;
			}
			case FieldType.Int64:
			{
				long num3 = 0L;
				if (this.ReadInt64(ref num3))
				{
					value = num3;
					return true;
				}
				return false;
			}
			case FieldType.UInt64:
			{
				ulong num4 = 0uL;
				if (this.ReadUInt64(ref num4))
				{
					value = num4;
					return true;
				}
				return false;
			}
			case FieldType.Int32:
			{
				int num5 = 0;
				if (this.ReadInt32(ref num5))
				{
					value = num5;
					return true;
				}
				return false;
			}
			case FieldType.Fixed64:
			{
				ulong num6 = 0uL;
				if (this.ReadFixed64(ref num6))
				{
					value = num6;
					return true;
				}
				return false;
			}
			case FieldType.Fixed32:
			{
				uint num7 = 0u;
				if (this.ReadFixed32(ref num7))
				{
					value = num7;
					return true;
				}
				return false;
			}
			case FieldType.Bool:
			{
				bool flag = false;
				if (this.ReadBool(ref flag))
				{
					value = flag;
					return true;
				}
				return false;
			}
			case FieldType.String:
			{
				string text = null;
				if (this.ReadString(ref text))
				{
					value = text;
					return true;
				}
				return false;
			}
			case FieldType.Group:
				throw new ArgumentException("ReadPrimitiveField() cannot handle nested groups.");
			case FieldType.Message:
				throw new ArgumentException("ReadPrimitiveField() cannot handle embedded messages.");
			case FieldType.Bytes:
			{
				ByteString byteString = null;
				if (this.ReadBytes(ref byteString))
				{
					value = byteString;
					return true;
				}
				return false;
			}
			case FieldType.UInt32:
			{
				uint num8 = 0u;
				if (this.ReadUInt32(ref num8))
				{
					value = num8;
					return true;
				}
				return false;
			}
			case FieldType.SFixed32:
			{
				int num9 = 0;
				if (this.ReadSFixed32(ref num9))
				{
					value = num9;
					return true;
				}
				return false;
			}
			case FieldType.SFixed64:
			{
				long num10 = 0L;
				if (this.ReadSFixed64(ref num10))
				{
					value = num10;
					return true;
				}
				return false;
			}
			case FieldType.SInt32:
			{
				int num11 = 0;
				if (this.ReadSInt32(ref num11))
				{
					value = num11;
					return true;
				}
				return false;
			}
			case FieldType.SInt64:
			{
				long num12 = 0L;
				if (this.ReadSInt64(ref num12))
				{
					value = num12;
					return true;
				}
				return false;
			}
			case FieldType.Enum:
				throw new ArgumentException("ReadPrimitiveField() cannot handle enums.");
			default:
				throw new ArgumentOutOfRangeException("Invalid field type " + fieldType);
			}
		}

		private uint SlowReadRawVarint32()
		{
			int num = (int)this.ReadRawByte();
			if (num < 128)
			{
				return (uint)num;
			}
			int num2 = num & 127;
			if ((num = (int)this.ReadRawByte()) < 128)
			{
				num2 |= num << 7;
			}
			else
			{
				num2 |= (num & 127) << 7;
				if ((num = (int)this.ReadRawByte()) < 128)
				{
					num2 |= num << 14;
				}
				else
				{
					num2 |= (num & 127) << 14;
					if ((num = (int)this.ReadRawByte()) < 128)
					{
						num2 |= num << 21;
					}
					else
					{
						num2 |= (num & 127) << 21;
						num2 |= (num = (int)this.ReadRawByte()) << 28;
						if (num >= 128)
						{
							for (int i = 0; i < 5; i++)
							{
								if (this.ReadRawByte() < 128)
								{
									return (uint)num2;
								}
							}
							throw InvalidProtocolBufferException.MalformedVarint();
						}
					}
				}
			}
			return (uint)num2;
		}

		
		public uint ReadRawVarint32()
		{
			if (this.bufferPos + 5 > this.bufferSize)
			{
				return this.SlowReadRawVarint32();
			}
			int num = (int)this.buffer[this.bufferPos++];
			if (num < 128)
			{
				return (uint)num;
			}
			int num2 = num & 127;
			if ((num = (int)this.buffer[this.bufferPos++]) < 128)
			{
				num2 |= num << 7;
			}
			else
			{
				num2 |= (num & 127) << 7;
				if ((num = (int)this.buffer[this.bufferPos++]) < 128)
				{
					num2 |= num << 14;
				}
				else
				{
					num2 |= (num & 127) << 14;
					if ((num = (int)this.buffer[this.bufferPos++]) < 128)
					{
						num2 |= num << 21;
					}
					else
					{
						num2 |= (num & 127) << 21;
						num2 |= (num = (int)this.buffer[this.bufferPos++]) << 28;
						if (num >= 128)
						{
							for (int i = 0; i < 5; i++)
							{
								if (this.ReadRawByte() < 128)
								{
									return (uint)num2;
								}
							}
							throw InvalidProtocolBufferException.MalformedVarint();
						}
					}
				}
			}
			return (uint)num2;
		}

		
		public static uint ReadRawVarint32(Stream input)
		{
			int num = 0;
			int i;
			for (i = 0; i < 32; i += 7)
			{
				int num2 = input.ReadByte();
				if (num2 == -1)
				{
					throw InvalidProtocolBufferException.TruncatedMessage();
				}
				num |= (num2 & 127) << i;
				if ((num2 & 128) == 0)
				{
					return (uint)num;
				}
			}
			while (i < 64)
			{
				int num3 = input.ReadByte();
				if (num3 == -1)
				{
					throw InvalidProtocolBufferException.TruncatedMessage();
				}
				if ((num3 & 128) == 0)
				{
					return (uint)num;
				}
				i += 7;
			}
			throw InvalidProtocolBufferException.MalformedVarint();
		}

		
		public ulong ReadRawVarint64()
		{
			int i = 0;
			ulong num = 0uL;
			while (i < 64)
			{
				byte b = this.ReadRawByte();
				num |= (ulong)((ulong)((long)(b & 127)) << i);
				if ((b & 128) == 0)
				{
					return num;
				}
				i += 7;
			}
			throw InvalidProtocolBufferException.MalformedVarint();
		}

		
		public uint ReadRawLittleEndian32()
		{
			uint num = (uint)this.ReadRawByte();
			uint num2 = (uint)this.ReadRawByte();
			uint num3 = (uint)this.ReadRawByte();
			uint num4 = (uint)this.ReadRawByte();
			return num | num2 << 8 | num3 << 16 | num4 << 24;
		}

		
		public ulong ReadRawLittleEndian64()
		{
			ulong num = (ulong)this.ReadRawByte();
			ulong num2 = (ulong)this.ReadRawByte();
			ulong num3 = (ulong)this.ReadRawByte();
			ulong num4 = (ulong)this.ReadRawByte();
			ulong num5 = (ulong)this.ReadRawByte();
			ulong num6 = (ulong)this.ReadRawByte();
			ulong num7 = (ulong)this.ReadRawByte();
			ulong num8 = (ulong)this.ReadRawByte();
			return num | num2 << 8 | num3 << 16 | num4 << 24 | num5 << 32 | num6 << 40 | num7 << 48 | num8 << 56;
		}

		
		public static int DecodeZigZag32(uint n)
		{
			return (int)(n >> 1 ^ -(int)(n & 1u));
		}

		
		public static long DecodeZigZag64(ulong n)
		{
            //return (long)(n >> 1 ^ -(long)(n & 1uL));//yfWarning:
            return ((long)n >> 1 ^ -(long)(n & 1uL));
        }

        public int SetRecursionLimit(int limit)
		{
			if (limit < 0)
			{
				throw new ArgumentOutOfRangeException("Recursion limit cannot be negative: " + limit);
			}
			int result = this.recursionLimit;
			this.recursionLimit = limit;
			return result;
		}

		public int SetSizeLimit(int limit)
		{
			if (limit < 0)
			{
				throw new ArgumentOutOfRangeException("Size limit cannot be negative: " + limit);
			}
			int result = this.sizeLimit;
			this.sizeLimit = limit;
			return result;
		}

		public void ResetSizeCounter()
		{
			this.totalBytesRetired = 0;
		}

		public int PushLimit(int byteLimit)
		{
			if (byteLimit < 0)
			{
				throw InvalidProtocolBufferException.NegativeSize();
			}
			byteLimit += this.totalBytesRetired + this.bufferPos;
			int num = this.currentLimit;
			if (byteLimit > num)
			{
				throw InvalidProtocolBufferException.TruncatedMessage();
			}
			this.currentLimit = byteLimit;
			this.RecomputeBufferSizeAfterLimit();
			return num;
		}

		private void RecomputeBufferSizeAfterLimit()
		{
			this.bufferSize += this.bufferSizeAfterLimit;
			int num = this.totalBytesRetired + this.bufferSize;
			if (num > this.currentLimit)
			{
				this.bufferSizeAfterLimit = num - this.currentLimit;
				this.bufferSize -= this.bufferSizeAfterLimit;
				return;
			}
			this.bufferSizeAfterLimit = 0;
		}

		public void PopLimit(int oldLimit)
		{
			this.currentLimit = oldLimit;
			this.RecomputeBufferSizeAfterLimit();
		}

		private bool RefillBuffer(bool mustSucceed)
		{
			if (this.bufferPos < this.bufferSize)
			{
				throw new InvalidOperationException("RefillBuffer() called when buffer wasn't empty.");
			}
			if (this.totalBytesRetired + this.bufferSize == this.currentLimit)
			{
				if (mustSucceed)
				{
					throw InvalidProtocolBufferException.TruncatedMessage();
				}
				return false;
			}
			else
			{
				this.totalBytesRetired += this.bufferSize;
				this.bufferPos = 0;
				this.bufferSize = ((this.input == null) ? 0 : this.input.Read(this.buffer, 0, this.buffer.Length));
				if (this.bufferSize < 0)
				{
					throw new InvalidOperationException("Stream.Read returned a negative count");
				}
				if (this.bufferSize == 0)
				{
					if (mustSucceed)
					{
						throw InvalidProtocolBufferException.TruncatedMessage();
					}
					return false;
				}
				else
				{
					this.RecomputeBufferSizeAfterLimit();
					int num = this.totalBytesRetired + this.bufferSize + this.bufferSizeAfterLimit;
					if (num > this.sizeLimit || num < 0)
					{
						throw InvalidProtocolBufferException.SizeLimitExceeded();
					}
					return true;
				}
			}
		}

		public byte ReadRawByte()
		{
			if (this.bufferPos == this.bufferSize)
			{
				this.RefillBuffer(true);
			}
			return this.buffer[this.bufferPos++];
		}

		public byte[] ReadRawBytes(int size)
		{
			if (size < 0)
			{
				throw InvalidProtocolBufferException.NegativeSize();
			}
			if (this.totalBytesRetired + this.bufferPos + size > this.currentLimit)
			{
				this.SkipRawBytes(this.currentLimit - this.totalBytesRetired - this.bufferPos);
				throw InvalidProtocolBufferException.TruncatedMessage();
			}
			if (size <= this.bufferSize - this.bufferPos)
			{
				byte[] array = new byte[size];
				ByteArray.Copy(this.buffer, this.bufferPos, array, 0, size);
				this.bufferPos += size;
				return array;
			}
			if (size < 4096)
			{
				byte[] array2 = new byte[size];
				int num = this.bufferSize - this.bufferPos;
				ByteArray.Copy(this.buffer, this.bufferPos, array2, 0, num);
				this.bufferPos = this.bufferSize;
				this.RefillBuffer(true);
				while (size - num > this.bufferSize)
				{
					Buffer.BlockCopy(this.buffer, 0, array2, num, this.bufferSize);
					num += this.bufferSize;
					this.bufferPos = this.bufferSize;
					this.RefillBuffer(true);
				}
				ByteArray.Copy(this.buffer, 0, array2, num, size - num);
				this.bufferPos = size - num;
				return array2;
			}
			int num2 = this.bufferPos;
			int num3 = this.bufferSize;
			this.totalBytesRetired += this.bufferSize;
			this.bufferPos = 0;
			this.bufferSize = 0;
			int i = size - (num3 - num2);
			List<byte[]> list = new List<byte[]>();
			while (i > 0)
			{
				byte[] array3 = new byte[Math.Min(i, 4096)];
				int num4;
				for (int j = 0; j < array3.Length; j += num4)
				{
					num4 = ((this.input == null) ? -1 : this.input.Read(array3, j, array3.Length - j));
					if (num4 <= 0)
					{
						throw InvalidProtocolBufferException.TruncatedMessage();
					}
					this.totalBytesRetired += num4;
				}
				i -= array3.Length;
				list.Add(array3);
			}
			byte[] array4 = new byte[size];
			int num5 = num3 - num2;
			ByteArray.Copy(this.buffer, num2, array4, 0, num5);
			using (List<byte[]>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					byte[] current = enumerator.Current;
					Buffer.BlockCopy(current, 0, array4, num5, current.Length);
					num5 += current.Length;
				}
			}
			return array4;
		}

		
		public bool SkipField()
		{
			uint tag = this.lastTag;
			switch (WireFormat.GetTagWireType(tag))
			{
			case WireFormat.WireType.Varint:
				this.ReadRawVarint64();
				return true;
			case WireFormat.WireType.Fixed64:
				this.ReadRawLittleEndian64();
				return true;
			case WireFormat.WireType.LengthDelimited:
				this.SkipRawBytes((int)this.ReadRawVarint32());
				return true;
			case WireFormat.WireType.StartGroup:
				this.SkipMessage();
				this.CheckLastTagWas(WireFormat.MakeTag(WireFormat.GetTagFieldNumber(tag), WireFormat.WireType.EndGroup));
				return true;
			case WireFormat.WireType.EndGroup:
				return false;
			case WireFormat.WireType.Fixed32:
				this.ReadRawLittleEndian32();
				return true;
			default:
				throw InvalidProtocolBufferException.InvalidWireType();
			}
		}

		public void SkipMessage()
		{
			uint num;
			string text;
			while (this.ReadTag(out num, out text))
			{
				if (!this.SkipField())
				{
					return;
				}
			}
		}

		public void SkipRawBytes(int size)
		{
			if (size < 0)
			{
				throw InvalidProtocolBufferException.NegativeSize();
			}
			if (this.totalBytesRetired + this.bufferPos + size > this.currentLimit)
			{
				this.SkipRawBytes(this.currentLimit - this.totalBytesRetired - this.bufferPos);
				throw InvalidProtocolBufferException.TruncatedMessage();
			}
			if (size <= this.bufferSize - this.bufferPos)
			{
				this.bufferPos += size;
				return;
			}
			int num = this.bufferSize - this.bufferPos;
			this.totalBytesRetired += num;
			this.bufferPos = 0;
			this.bufferSize = 0;
			if (num < size)
			{
				if (this.input == null)
				{
					throw InvalidProtocolBufferException.TruncatedMessage();
				}
				this.SkipImpl(size - num);
				this.totalBytesRetired += size - num;
			}
		}

		private void SkipImpl(int amountToSkip)
		{
			if (this.input.CanSeek)
			{
				long position = this.input.Position;
				Stream expr_1F = this.input;
				expr_1F.Position =(expr_1F.Position + (long)amountToSkip);
				if (this.input.Position != position + (long)amountToSkip)
				{
					throw InvalidProtocolBufferException.TruncatedMessage();
				}
			}
			else
			{
				byte[] array = new byte[1024];
				while (amountToSkip > 0)
				{
					int num = this.input.Read(array, 0, array.Length);
					if (num <= 0)
					{
						throw InvalidProtocolBufferException.TruncatedMessage();
					}
					amountToSkip -= num;
				}
			}
		}
	}
}
