using Google.ProtocolBuffers.Collections;
using Google.ProtocolBuffers.Descriptors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Google.ProtocolBuffers
{
	public sealed class CodedOutputStream : ICodedOutputStream
	{
		public sealed class OutOfSpaceException : IOException
		{
			internal OutOfSpaceException() : base("CodedOutputStream was writing to a flat byte array and ran out of space.")
			{
			}
		}

		private const int LittleEndian64Size = 8;

		private const int LittleEndian32Size = 4;

		public static readonly int DefaultBufferSize = 4096;

		private readonly byte[] buffer;

		private readonly int limit;

		private int position;

		private readonly Stream output;

		public int SpaceLeft
		{
			get
			{
				if (this.output == null)
				{
					return this.limit - this.position;
				}
				throw new InvalidOperationException("SpaceLeft can only be called on CodedOutputStreams that are writing to a flat array.");
			}
		}

		public static int ComputeDoubleSize(int fieldNumber, double value)
		{
			return CodedOutputStream.ComputeTagSize(fieldNumber) + 8;
		}

		public static int ComputeFloatSize(int fieldNumber, float value)
		{
			return CodedOutputStream.ComputeTagSize(fieldNumber) + 4;
		}

		
		public static int ComputeUInt64Size(int fieldNumber, ulong value)
		{
			return CodedOutputStream.ComputeTagSize(fieldNumber) + CodedOutputStream.ComputeRawVarint64Size(value);
		}

		public static int ComputeInt64Size(int fieldNumber, long value)
		{
			return CodedOutputStream.ComputeTagSize(fieldNumber) + CodedOutputStream.ComputeRawVarint64Size((ulong)value);
		}

		public static int ComputeInt32Size(int fieldNumber, int value)
		{
			if (value >= 0)
			{
				return CodedOutputStream.ComputeTagSize(fieldNumber) + CodedOutputStream.ComputeRawVarint32Size((uint)value);
			}
			return CodedOutputStream.ComputeTagSize(fieldNumber) + 10;
		}

		
		public static int ComputeFixed64Size(int fieldNumber, ulong value)
		{
			return CodedOutputStream.ComputeTagSize(fieldNumber) + 8;
		}

		
		public static int ComputeFixed32Size(int fieldNumber, uint value)
		{
			return CodedOutputStream.ComputeTagSize(fieldNumber) + 4;
		}

		public static int ComputeBoolSize(int fieldNumber, bool value)
		{
			return CodedOutputStream.ComputeTagSize(fieldNumber) + 1;
		}

		public static int ComputeStringSize(int fieldNumber, string value)
		{
			int byteCount = Encoding.UTF8.GetByteCount(value);
			return CodedOutputStream.ComputeTagSize(fieldNumber) + CodedOutputStream.ComputeRawVarint32Size((uint)byteCount) + byteCount;
		}

		public static int ComputeGroupSize(int fieldNumber, IMessageLite value)
		{
			return CodedOutputStream.ComputeTagSize(fieldNumber) * 2 + value.SerializedSize;
		}

		[Obsolete]
		public static int ComputeUnknownGroupSize(int fieldNumber, IMessageLite value)
		{
			return CodedOutputStream.ComputeTagSize(fieldNumber) * 2 + value.SerializedSize;
		}

		public static int ComputeMessageSize(int fieldNumber, IMessageLite value)
		{
			int serializedSize = value.SerializedSize;
			return CodedOutputStream.ComputeTagSize(fieldNumber) + CodedOutputStream.ComputeRawVarint32Size((uint)serializedSize) + serializedSize;
		}

		public static int ComputeBytesSize(int fieldNumber, ByteString value)
		{
			return CodedOutputStream.ComputeTagSize(fieldNumber) + CodedOutputStream.ComputeRawVarint32Size((uint)value.Length) + value.Length;
		}

		
		public static int ComputeUInt32Size(int fieldNumber, uint value)
		{
			return CodedOutputStream.ComputeTagSize(fieldNumber) + CodedOutputStream.ComputeRawVarint32Size(value);
		}

		public static int ComputeEnumSize(int fieldNumber, int value)
		{
			return CodedOutputStream.ComputeTagSize(fieldNumber) + CodedOutputStream.ComputeEnumSizeNoTag(value);
		}

		public static int ComputeSFixed32Size(int fieldNumber, int value)
		{
			return CodedOutputStream.ComputeTagSize(fieldNumber) + 4;
		}

		public static int ComputeSFixed64Size(int fieldNumber, long value)
		{
			return CodedOutputStream.ComputeTagSize(fieldNumber) + 8;
		}

		public static int ComputeSInt32Size(int fieldNumber, int value)
		{
			return CodedOutputStream.ComputeTagSize(fieldNumber) + CodedOutputStream.ComputeRawVarint32Size(CodedOutputStream.EncodeZigZag32(value));
		}

		public static int ComputeSInt64Size(int fieldNumber, long value)
		{
			return CodedOutputStream.ComputeTagSize(fieldNumber) + CodedOutputStream.ComputeRawVarint64Size(CodedOutputStream.EncodeZigZag64(value));
		}

		public static int ComputeDoubleSizeNoTag(double value)
		{
			return 8;
		}

		public static int ComputeFloatSizeNoTag(float value)
		{
			return 4;
		}

		
		public static int ComputeUInt64SizeNoTag(ulong value)
		{
			return CodedOutputStream.ComputeRawVarint64Size(value);
		}

		public static int ComputeInt64SizeNoTag(long value)
		{
			return CodedOutputStream.ComputeRawVarint64Size((ulong)value);
		}

		public static int ComputeInt32SizeNoTag(int value)
		{
			if (value >= 0)
			{
				return CodedOutputStream.ComputeRawVarint32Size((uint)value);
			}
			return 10;
		}

		
		public static int ComputeFixed64SizeNoTag(ulong value)
		{
			return 8;
		}

		
		public static int ComputeFixed32SizeNoTag(uint value)
		{
			return 4;
		}

		public static int ComputeBoolSizeNoTag(bool value)
		{
			return 1;
		}

		public static int ComputeStringSizeNoTag(string value)
		{
			int byteCount = Encoding.UTF8.GetByteCount(value);
			return CodedOutputStream.ComputeRawVarint32Size((uint)byteCount) + byteCount;
		}

		public static int ComputeGroupSizeNoTag(IMessageLite value)
		{
			return value.SerializedSize;
		}

		[Obsolete]
		public static int ComputeUnknownGroupSizeNoTag(IMessageLite value)
		{
			return value.SerializedSize;
		}

		public static int ComputeMessageSizeNoTag(IMessageLite value)
		{
			int serializedSize = value.SerializedSize;
			return CodedOutputStream.ComputeRawVarint32Size((uint)serializedSize) + serializedSize;
		}

		public static int ComputeBytesSizeNoTag(ByteString value)
		{
			return CodedOutputStream.ComputeRawVarint32Size((uint)value.Length) + value.Length;
		}

		
		public static int ComputeUInt32SizeNoTag(uint value)
		{
			return CodedOutputStream.ComputeRawVarint32Size(value);
		}

		public static int ComputeEnumSizeNoTag(int value)
		{
			return CodedOutputStream.ComputeInt32SizeNoTag(value);
		}

		public static int ComputeSFixed32SizeNoTag(int value)
		{
			return 4;
		}

		public static int ComputeSFixed64SizeNoTag(long value)
		{
			return 8;
		}

		public static int ComputeSInt32SizeNoTag(int value)
		{
			return CodedOutputStream.ComputeRawVarint32Size(CodedOutputStream.EncodeZigZag32(value));
		}

		public static int ComputeSInt64SizeNoTag(long value)
		{
			return CodedOutputStream.ComputeRawVarint64Size(CodedOutputStream.EncodeZigZag64(value));
		}

		public static int ComputeMessageSetExtensionSize(int fieldNumber, IMessageLite value)
		{
			return CodedOutputStream.ComputeTagSize(1) * 2 + CodedOutputStream.ComputeUInt32Size(2, (uint)fieldNumber) + CodedOutputStream.ComputeMessageSize(3, value);
		}

		public static int ComputeRawMessageSetExtensionSize(int fieldNumber, ByteString value)
		{
			return CodedOutputStream.ComputeTagSize(1) * 2 + CodedOutputStream.ComputeUInt32Size(2, (uint)fieldNumber) + CodedOutputStream.ComputeBytesSize(3, value);
		}

		
		public static int ComputeRawVarint32Size(uint value)
		{
			if ((value & 4294967168u) == 0u)
			{
				return 1;
			}
			if ((value & 4294950912u) == 0u)
			{
				return 2;
			}
			if ((value & 4292870144u) == 0u)
			{
				return 3;
			}
			if ((value & 4026531840u) == 0u)
			{
				return 4;
			}
			return 5;
		}

		
		public static int ComputeRawVarint64Size(ulong value)
		{
			if ((value & 18446744073709551488uL) == 0uL)
			{
				return 1;
			}
			if ((value & 18446744073709535232uL) == 0uL)
			{
				return 2;
			}
			if ((value & 18446744073707454464uL) == 0uL)
			{
				return 3;
			}
			if ((value & 18446744073441116160uL) == 0uL)
			{
				return 4;
			}
			if ((value & 18446744039349813248uL) == 0uL)
			{
				return 5;
			}
			if ((value & 18446739675663040512uL) == 0uL)
			{
				return 6;
			}
			if ((value & 18446181123756130304uL) == 0uL)
			{
				return 7;
			}
			if ((value & 18374686479671623680uL) == 0uL)
			{
				return 8;
			}
			if ((value & 9223372036854775808uL) == 0uL)
			{
				return 9;
			}
			return 10;
		}

		public static int ComputeFieldSize(FieldType fieldType, int fieldNumber, object value)
		{
			switch (fieldType)
			{
			case FieldType.Double:
				return CodedOutputStream.ComputeDoubleSize(fieldNumber, (double)value);
			case FieldType.Float:
				return CodedOutputStream.ComputeFloatSize(fieldNumber, (float)value);
			case FieldType.Int64:
				return CodedOutputStream.ComputeInt64Size(fieldNumber, (long)value);
			case FieldType.UInt64:
				return CodedOutputStream.ComputeUInt64Size(fieldNumber, (ulong)value);
			case FieldType.Int32:
				return CodedOutputStream.ComputeInt32Size(fieldNumber, (int)value);
			case FieldType.Fixed64:
				return CodedOutputStream.ComputeFixed64Size(fieldNumber, (ulong)value);
			case FieldType.Fixed32:
				return CodedOutputStream.ComputeFixed32Size(fieldNumber, (uint)value);
			case FieldType.Bool:
				return CodedOutputStream.ComputeBoolSize(fieldNumber, (bool)value);
			case FieldType.String:
				return CodedOutputStream.ComputeStringSize(fieldNumber, (string)value);
			case FieldType.Group:
				return CodedOutputStream.ComputeGroupSize(fieldNumber, (IMessageLite)value);
			case FieldType.Message:
				return CodedOutputStream.ComputeMessageSize(fieldNumber, (IMessageLite)value);
			case FieldType.Bytes:
				return CodedOutputStream.ComputeBytesSize(fieldNumber, (ByteString)value);
			case FieldType.UInt32:
				return CodedOutputStream.ComputeUInt32Size(fieldNumber, (uint)value);
			case FieldType.SFixed32:
				return CodedOutputStream.ComputeSFixed32Size(fieldNumber, (int)value);
			case FieldType.SFixed64:
				return CodedOutputStream.ComputeSFixed64Size(fieldNumber, (long)value);
			case FieldType.SInt32:
				return CodedOutputStream.ComputeSInt32Size(fieldNumber, (int)value);
			case FieldType.SInt64:
				return CodedOutputStream.ComputeSInt64Size(fieldNumber, (long)value);
			case FieldType.Enum:
				if (value is Enum)
				{
					return CodedOutputStream.ComputeEnumSize(fieldNumber, ((IConvertible)value).ToInt32(CultureInfo.InvariantCulture));
				}
				return CodedOutputStream.ComputeEnumSize(fieldNumber, ((IEnumLite)value).Number);
			default:
				throw new ArgumentOutOfRangeException("Invalid field type " + fieldType);
			}
		}

		public static int ComputeFieldSizeNoTag(FieldType fieldType, object value)
		{
			switch (fieldType)
			{
			case FieldType.Double:
				return CodedOutputStream.ComputeDoubleSizeNoTag((double)value);
			case FieldType.Float:
				return CodedOutputStream.ComputeFloatSizeNoTag((float)value);
			case FieldType.Int64:
				return CodedOutputStream.ComputeInt64SizeNoTag((long)value);
			case FieldType.UInt64:
				return CodedOutputStream.ComputeUInt64SizeNoTag((ulong)value);
			case FieldType.Int32:
				return CodedOutputStream.ComputeInt32SizeNoTag((int)value);
			case FieldType.Fixed64:
				return CodedOutputStream.ComputeFixed64SizeNoTag((ulong)value);
			case FieldType.Fixed32:
				return CodedOutputStream.ComputeFixed32SizeNoTag((uint)value);
			case FieldType.Bool:
				return CodedOutputStream.ComputeBoolSizeNoTag((bool)value);
			case FieldType.String:
				return CodedOutputStream.ComputeStringSizeNoTag((string)value);
			case FieldType.Group:
				return CodedOutputStream.ComputeGroupSizeNoTag((IMessageLite)value);
			case FieldType.Message:
				return CodedOutputStream.ComputeMessageSizeNoTag((IMessageLite)value);
			case FieldType.Bytes:
				return CodedOutputStream.ComputeBytesSizeNoTag((ByteString)value);
			case FieldType.UInt32:
				return CodedOutputStream.ComputeUInt32SizeNoTag((uint)value);
			case FieldType.SFixed32:
				return CodedOutputStream.ComputeSFixed32SizeNoTag((int)value);
			case FieldType.SFixed64:
				return CodedOutputStream.ComputeSFixed64SizeNoTag((long)value);
			case FieldType.SInt32:
				return CodedOutputStream.ComputeSInt32SizeNoTag((int)value);
			case FieldType.SInt64:
				return CodedOutputStream.ComputeSInt64SizeNoTag((long)value);
			case FieldType.Enum:
				if (value is Enum)
				{
					return CodedOutputStream.ComputeEnumSizeNoTag(((IConvertible)value).ToInt32(CultureInfo.InvariantCulture));
				}
				return CodedOutputStream.ComputeEnumSizeNoTag(((IEnumLite)value).Number);
			default:
				throw new ArgumentOutOfRangeException("Invalid field type " + fieldType);
			}
		}

		public static int ComputeTagSize(int fieldNumber)
		{
			return CodedOutputStream.ComputeRawVarint32Size(WireFormat.MakeTag(fieldNumber, WireFormat.WireType.Varint));
		}

		private CodedOutputStream(byte[] buffer, int offset, int length)
		{
			this.output = null;
			this.buffer = buffer;
			this.position = offset;
			this.limit = offset + length;
		}

		private CodedOutputStream(Stream output, byte[] buffer)
		{
			this.output = output;
			this.buffer = buffer;
			this.position = 0;
			this.limit = buffer.Length;
		}

		public static CodedOutputStream CreateInstance(Stream output)
		{
			return CodedOutputStream.CreateInstance(output, CodedOutputStream.DefaultBufferSize);
		}

		public static CodedOutputStream CreateInstance(Stream output, int bufferSize)
		{
			return new CodedOutputStream(output, new byte[bufferSize]);
		}

		public static CodedOutputStream CreateInstance(byte[] flatArray)
		{
			return CodedOutputStream.CreateInstance(flatArray, 0, flatArray.Length);
		}

		public static CodedOutputStream CreateInstance(byte[] flatArray, int offset, int length)
		{
			return new CodedOutputStream(flatArray, offset, length);
		}

		void ICodedOutputStream.WriteMessageStart()
		{
		}

		void ICodedOutputStream.WriteMessageEnd()
		{
			this.Flush();
		}

		[Obsolete]
		public void WriteUnknownGroup(int fieldNumber, IMessageLite value)
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.StartGroup);
			value.WriteTo(this);
			this.WriteTag(fieldNumber, WireFormat.WireType.EndGroup);
		}

		public void WriteUnknownBytes(int fieldNumber, ByteString value)
		{
			this.WriteBytes(fieldNumber, null, value);
		}

		
		public void WriteUnknownField(int fieldNumber, WireFormat.WireType wireType, ulong value)
		{
			if (wireType == WireFormat.WireType.Varint)
			{
				this.WriteUInt64(fieldNumber, null, value);
				return;
			}
			if (wireType == WireFormat.WireType.Fixed32)
			{
				this.WriteFixed32(fieldNumber, null, (uint)value);
				return;
			}
			if (wireType == WireFormat.WireType.Fixed64)
			{
				this.WriteFixed64(fieldNumber, null, value);
				return;
			}
			throw InvalidProtocolBufferException.InvalidWireType();
		}

		public void WriteField(FieldType fieldType, int fieldNumber, string fieldName, object value)
		{
			switch (fieldType)
			{
			case FieldType.Double:
				this.WriteDouble(fieldNumber, fieldName, (double)value);
				return;
			case FieldType.Float:
				this.WriteFloat(fieldNumber, fieldName, (float)value);
				return;
			case FieldType.Int64:
				this.WriteInt64(fieldNumber, fieldName, (long)value);
				return;
			case FieldType.UInt64:
				this.WriteUInt64(fieldNumber, fieldName, (ulong)value);
				return;
			case FieldType.Int32:
				this.WriteInt32(fieldNumber, fieldName, (int)value);
				return;
			case FieldType.Fixed64:
				this.WriteFixed64(fieldNumber, fieldName, (ulong)value);
				return;
			case FieldType.Fixed32:
				this.WriteFixed32(fieldNumber, fieldName, (uint)value);
				return;
			case FieldType.Bool:
				this.WriteBool(fieldNumber, fieldName, (bool)value);
				return;
			case FieldType.String:
				this.WriteString(fieldNumber, fieldName, (string)value);
				return;
			case FieldType.Group:
				this.WriteGroup(fieldNumber, fieldName, (IMessageLite)value);
				return;
			case FieldType.Message:
				this.WriteMessage(fieldNumber, fieldName, (IMessageLite)value);
				return;
			case FieldType.Bytes:
				this.WriteBytes(fieldNumber, fieldName, (ByteString)value);
				return;
			case FieldType.UInt32:
				this.WriteUInt32(fieldNumber, fieldName, (uint)value);
				return;
			case FieldType.SFixed32:
				this.WriteSFixed32(fieldNumber, fieldName, (int)value);
				return;
			case FieldType.SFixed64:
				this.WriteSFixed64(fieldNumber, fieldName, (long)value);
				return;
			case FieldType.SInt32:
				this.WriteSInt32(fieldNumber, fieldName, (int)value);
				return;
			case FieldType.SInt64:
				this.WriteSInt64(fieldNumber, fieldName, (long)value);
				return;
			case FieldType.Enum:
				if (value is Enum)
				{
					this.WriteEnum(fieldNumber, fieldName, (int)value, null);
					return;
				}
				this.WriteEnum(fieldNumber, fieldName, ((IEnumLite)value).Number, null);
				return;
			default:
				return;
			}
		}

		public void WriteDouble(int fieldNumber, string fieldName, double value)
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.Fixed64);
			this.WriteDoubleNoTag(value);
		}

		public void WriteFloat(int fieldNumber, string fieldName, float value)
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.Fixed32);
			this.WriteFloatNoTag(value);
		}

		
		public void WriteUInt64(int fieldNumber, string fieldName, ulong value)
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.Varint);
			this.WriteRawVarint64(value);
		}

		public void WriteInt64(int fieldNumber, string fieldName, long value)
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.Varint);
			this.WriteRawVarint64((ulong)value);
		}

		public void WriteInt32(int fieldNumber, string fieldName, int value)
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.Varint);
			if (value >= 0)
			{
				this.WriteRawVarint32((uint)value);
				return;
			}
			this.WriteRawVarint64((ulong)((long)value));
		}

		
		public void WriteFixed64(int fieldNumber, string fieldName, ulong value)
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.Fixed64);
			this.WriteRawLittleEndian64(value);
		}

		
		public void WriteFixed32(int fieldNumber, string fieldName, uint value)
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.Fixed32);
			this.WriteRawLittleEndian32(value);
		}

		public void WriteBool(int fieldNumber, string fieldName, bool value)
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.Varint);
			this.WriteRawByte(value ? (byte)1 : (byte)0);//yfWarning:
		}

		public void WriteString(int fieldNumber, string fieldName, string value)
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.LengthDelimited);
			int byteCount = Encoding.UTF8.GetByteCount(value);
			this.WriteRawVarint32((uint)byteCount);
			if (this.limit - this.position >= byteCount)
			{
				Encoding.UTF8.GetBytes(value, 0, value.Length, this.buffer, this.position);
				this.position += byteCount;
				return;
			}
			byte[] bytes = Encoding.UTF8.GetBytes(value);
			this.WriteRawBytes(bytes);
		}

		public void WriteGroup(int fieldNumber, string fieldName, IMessageLite value)
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.StartGroup);
			value.WriteTo(this);
			this.WriteTag(fieldNumber, WireFormat.WireType.EndGroup);
		}

		public void WriteMessage(int fieldNumber, string fieldName, IMessageLite value)
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.LengthDelimited);
			this.WriteRawVarint32((uint)value.SerializedSize);
			value.WriteTo(this);
		}

		public void WriteBytes(int fieldNumber, string fieldName, ByteString value)
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.LengthDelimited);
			this.WriteRawVarint32((uint)value.Length);
			value.WriteRawBytesTo(this);
		}

		
		public void WriteUInt32(int fieldNumber, string fieldName, uint value)
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.Varint);
			this.WriteRawVarint32(value);
		}

		public void WriteEnum(int fieldNumber, string fieldName, int value, object rawValue)
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.Varint);
			this.WriteInt32NoTag(value);
		}

		public void WriteSFixed32(int fieldNumber, string fieldName, int value)
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.Fixed32);
			this.WriteRawLittleEndian32((uint)value);
		}

		public void WriteSFixed64(int fieldNumber, string fieldName, long value)
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.Fixed64);
			this.WriteRawLittleEndian64((ulong)value);
		}

		public void WriteSInt32(int fieldNumber, string fieldName, int value)
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.Varint);
			this.WriteRawVarint32(CodedOutputStream.EncodeZigZag32(value));
		}

		public void WriteSInt64(int fieldNumber, string fieldName, long value)
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.Varint);
			this.WriteRawVarint64(CodedOutputStream.EncodeZigZag64(value));
		}

		public void WriteMessageSetExtension(int fieldNumber, string fieldName, IMessageLite value)
		{
			this.WriteTag(1, WireFormat.WireType.StartGroup);
			this.WriteUInt32(2, "type_id", (uint)fieldNumber);
			this.WriteMessage(3, "message", value);
			this.WriteTag(1, WireFormat.WireType.EndGroup);
		}

		public void WriteMessageSetExtension(int fieldNumber, string fieldName, ByteString value)
		{
			this.WriteTag(1, WireFormat.WireType.StartGroup);
			this.WriteUInt32(2, "type_id", (uint)fieldNumber);
			this.WriteBytes(3, "message", value);
			this.WriteTag(1, WireFormat.WireType.EndGroup);
		}

		public void WriteFieldNoTag(FieldType fieldType, object value)
		{
			switch (fieldType)
			{
			case FieldType.Double:
				this.WriteDoubleNoTag((double)value);
				return;
			case FieldType.Float:
				this.WriteFloatNoTag((float)value);
				return;
			case FieldType.Int64:
				this.WriteInt64NoTag((long)value);
				return;
			case FieldType.UInt64:
				this.WriteUInt64NoTag((ulong)value);
				return;
			case FieldType.Int32:
				this.WriteInt32NoTag((int)value);
				return;
			case FieldType.Fixed64:
				this.WriteFixed64NoTag((ulong)value);
				return;
			case FieldType.Fixed32:
				this.WriteFixed32NoTag((uint)value);
				return;
			case FieldType.Bool:
				this.WriteBoolNoTag((bool)value);
				return;
			case FieldType.String:
				this.WriteStringNoTag((string)value);
				return;
			case FieldType.Group:
				this.WriteGroupNoTag((IMessageLite)value);
				return;
			case FieldType.Message:
				this.WriteMessageNoTag((IMessageLite)value);
				return;
			case FieldType.Bytes:
				this.WriteBytesNoTag((ByteString)value);
				return;
			case FieldType.UInt32:
				this.WriteUInt32NoTag((uint)value);
				return;
			case FieldType.SFixed32:
				this.WriteSFixed32NoTag((int)value);
				return;
			case FieldType.SFixed64:
				this.WriteSFixed64NoTag((long)value);
				return;
			case FieldType.SInt32:
				this.WriteSInt32NoTag((int)value);
				return;
			case FieldType.SInt64:
				this.WriteSInt64NoTag((long)value);
				return;
			case FieldType.Enum:
				if (value is Enum)
				{
					this.WriteEnumNoTag((int)value);
					return;
				}
				this.WriteEnumNoTag(((IEnumLite)value).Number);
				return;
			default:
				return;
			}
		}

		public void WriteDoubleNoTag(double value)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			if (!BitConverter.IsLittleEndian)
			{
				ByteArray.Reverse(bytes);
			}
			if (this.limit - this.position >= 8)
			{
				this.buffer[this.position++] = bytes[0];
				this.buffer[this.position++] = bytes[1];
				this.buffer[this.position++] = bytes[2];
				this.buffer[this.position++] = bytes[3];
				this.buffer[this.position++] = bytes[4];
				this.buffer[this.position++] = bytes[5];
				this.buffer[this.position++] = bytes[6];
				this.buffer[this.position++] = bytes[7];
				return;
			}
			this.WriteRawBytes(bytes, 0, 8);
		}

		public void WriteFloatNoTag(float value)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			if (!BitConverter.IsLittleEndian)
			{
				ByteArray.Reverse(bytes);
			}
			if (this.limit - this.position >= 4)
			{
				this.buffer[this.position++] = bytes[0];
				this.buffer[this.position++] = bytes[1];
				this.buffer[this.position++] = bytes[2];
				this.buffer[this.position++] = bytes[3];
				return;
			}
			this.WriteRawBytes(bytes, 0, 4);
		}

		
		public void WriteUInt64NoTag(ulong value)
		{
			this.WriteRawVarint64(value);
		}

		public void WriteInt64NoTag(long value)
		{
			this.WriteRawVarint64((ulong)value);
		}

		public void WriteInt32NoTag(int value)
		{
			if (value >= 0)
			{
				this.WriteRawVarint32((uint)value);
				return;
			}
			this.WriteRawVarint64((ulong)((long)value));
		}

		
		public void WriteFixed64NoTag(ulong value)
		{
			this.WriteRawLittleEndian64(value);
		}

		
		public void WriteFixed32NoTag(uint value)
		{
			this.WriteRawLittleEndian32(value);
		}

		public void WriteBoolNoTag(bool value)
		{
			this.WriteRawByte(value ? (byte)1 : (byte)0);//yfWarning:
        }

		public void WriteStringNoTag(string value)
		{
			int byteCount = Encoding.UTF8.GetByteCount(value);
			this.WriteRawVarint32((uint)byteCount);
			if (this.limit - this.position >= byteCount)
			{
				Encoding.UTF8.GetBytes(value, 0, value.Length, this.buffer, this.position);
				this.position += byteCount;
				return;
			}
			byte[] bytes = Encoding.UTF8.GetBytes(value);
			this.WriteRawBytes(bytes);
		}

		public void WriteGroupNoTag(IMessageLite value)
		{
			value.WriteTo(this);
		}

		public void WriteMessageNoTag(IMessageLite value)
		{
			this.WriteRawVarint32((uint)value.SerializedSize);
			value.WriteTo(this);
		}

		public void WriteBytesNoTag(ByteString value)
		{
			this.WriteRawVarint32((uint)value.Length);
			value.WriteRawBytesTo(this);
		}

		
		public void WriteUInt32NoTag(uint value)
		{
			this.WriteRawVarint32(value);
		}

		public void WriteEnumNoTag(int value)
		{
			this.WriteInt32NoTag(value);
		}

		public void WriteSFixed32NoTag(int value)
		{
			this.WriteRawLittleEndian32((uint)value);
		}

		public void WriteSFixed64NoTag(long value)
		{
			this.WriteRawLittleEndian64((ulong)value);
		}

		public void WriteSInt32NoTag(int value)
		{
			this.WriteRawVarint32(CodedOutputStream.EncodeZigZag32(value));
		}

		public void WriteSInt64NoTag(long value)
		{
			this.WriteRawVarint64(CodedOutputStream.EncodeZigZag64(value));
		}

		public void WriteArray(FieldType fieldType, int fieldNumber, string fieldName, IEnumerable list)
		{
			IEnumerator enumerator = list.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object current = enumerator.Current;
					this.WriteField(fieldType, fieldNumber, fieldName, current);
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}

		public void WriteGroupArray<T>(int fieldNumber, string fieldName, IEnumerable<T> list) where T : IMessageLite
		{
			using (IEnumerator<T> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					IMessageLite value = enumerator.Current;
					this.WriteGroup(fieldNumber, fieldName, value);
				}
			}
		}

		public void WriteMessageArray<T>(int fieldNumber, string fieldName, IEnumerable<T> list) where T : IMessageLite
		{
			using (IEnumerator<T> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					IMessageLite value = enumerator.Current;
					this.WriteMessage(fieldNumber, fieldName, value);
				}
			}
		}

		public void WriteStringArray(int fieldNumber, string fieldName, IEnumerable<string> list)
		{
			using (IEnumerator<string> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					this.WriteString(fieldNumber, fieldName, current);
				}
			}
		}

		public void WriteBytesArray(int fieldNumber, string fieldName, IEnumerable<ByteString> list)
		{
			using (IEnumerator<ByteString> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ByteString current = enumerator.Current;
					this.WriteBytes(fieldNumber, fieldName, current);
				}
			}
		}

		public void WriteBoolArray(int fieldNumber, string fieldName, IEnumerable<bool> list)
		{
			using (IEnumerator<bool> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					bool current = enumerator.Current;
					this.WriteBool(fieldNumber, fieldName, current);
				}
			}
		}

		public void WriteInt32Array(int fieldNumber, string fieldName, IEnumerable<int> list)
		{
			using (IEnumerator<int> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int current = enumerator.Current;
					this.WriteInt32(fieldNumber, fieldName, current);
				}
			}
		}

		public void WriteSInt32Array(int fieldNumber, string fieldName, IEnumerable<int> list)
		{
			using (IEnumerator<int> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int current = enumerator.Current;
					this.WriteSInt32(fieldNumber, fieldName, current);
				}
			}
		}

		public void WriteUInt32Array(int fieldNumber, string fieldName, IEnumerable<uint> list)
		{
			using (IEnumerator<uint> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					uint current = enumerator.Current;
					this.WriteUInt32(fieldNumber, fieldName, current);
				}
			}
		}

		public void WriteFixed32Array(int fieldNumber, string fieldName, IEnumerable<uint> list)
		{
			using (IEnumerator<uint> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					uint current = enumerator.Current;
					this.WriteFixed32(fieldNumber, fieldName, current);
				}
			}
		}

		public void WriteSFixed32Array(int fieldNumber, string fieldName, IEnumerable<int> list)
		{
			using (IEnumerator<int> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int current = enumerator.Current;
					this.WriteSFixed32(fieldNumber, fieldName, current);
				}
			}
		}

		public void WriteInt64Array(int fieldNumber, string fieldName, IEnumerable<long> list)
		{
			using (IEnumerator<long> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					long current = enumerator.Current;
					this.WriteInt64(fieldNumber, fieldName, current);
				}
			}
		}

		public void WriteSInt64Array(int fieldNumber, string fieldName, IEnumerable<long> list)
		{
			using (IEnumerator<long> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					long current = enumerator.Current;
					this.WriteSInt64(fieldNumber, fieldName, current);
				}
			}
		}

		public void WriteUInt64Array(int fieldNumber, string fieldName, IEnumerable<ulong> list)
		{
			using (IEnumerator<ulong> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ulong current = enumerator.Current;
					this.WriteUInt64(fieldNumber, fieldName, current);
				}
			}
		}

		public void WriteFixed64Array(int fieldNumber, string fieldName, IEnumerable<ulong> list)
		{
			using (IEnumerator<ulong> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ulong current = enumerator.Current;
					this.WriteFixed64(fieldNumber, fieldName, current);
				}
			}
		}

		public void WriteSFixed64Array(int fieldNumber, string fieldName, IEnumerable<long> list)
		{
			using (IEnumerator<long> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					long current = enumerator.Current;
					this.WriteSFixed64(fieldNumber, fieldName, current);
				}
			}
		}

		public void WriteDoubleArray(int fieldNumber, string fieldName, IEnumerable<double> list)
		{
			using (IEnumerator<double> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					double value = enumerator.Current;
					this.WriteDouble(fieldNumber, fieldName, value);
				}
			}
		}

		public void WriteFloatArray(int fieldNumber, string fieldName, IEnumerable<float> list)
		{
			using (IEnumerator<float> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					float value = enumerator.Current;
					this.WriteFloat(fieldNumber, fieldName, value);
				}
			}
		}

		
		public void WriteEnumArray<T>(int fieldNumber, string fieldName, IEnumerable<T> list) where T : struct, IComparable, IFormattable, IConvertible
		{
			if (list is ICastArray)
			{
				using (IEnumerator<int> enumerator = ((ICastArray)list).CastArray<int>().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						int current = enumerator.Current;
						this.WriteEnum(fieldNumber, fieldName, current, null);
					}
					return;
				}
			}
			using (IEnumerator<T> enumerator2 = list.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					object obj = enumerator2.Current;
					this.WriteEnum(fieldNumber, fieldName, (int)obj, null);
				}
			}
		}

		public void WritePackedArray(FieldType fieldType, int fieldNumber, string fieldName, IEnumerable list)
		{
			int num = 0;
			IEnumerator enumerator = list.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object current = enumerator.Current;
					num += CodedOutputStream.ComputeFieldSizeNoTag(fieldType, current);
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			this.WriteTag(fieldNumber, WireFormat.WireType.LengthDelimited);
			this.WriteRawVarint32((uint)num);
			IEnumerator enumerator2 = list.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					object current2 = enumerator2.Current;
					this.WriteFieldNoTag(fieldType, current2);
				}
			}
			finally
			{
				IDisposable disposable2 = enumerator2 as IDisposable;
				if (disposable2 != null)
				{
					disposable2.Dispose();
				}
			}
		}

		public void WritePackedGroupArray<T>(int fieldNumber, string fieldName, int calculatedSize, IEnumerable<T> list) where T : IMessageLite
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.LengthDelimited);
			this.WriteRawVarint32((uint)calculatedSize);
			using (IEnumerator<T> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					IMessageLite value = enumerator.Current;
					this.WriteGroupNoTag(value);
				}
			}
		}

		public void WritePackedMessageArray<T>(int fieldNumber, string fieldName, int calculatedSize, IEnumerable<T> list) where T : IMessageLite
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.LengthDelimited);
			this.WriteRawVarint32((uint)calculatedSize);
			using (IEnumerator<T> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					IMessageLite value = enumerator.Current;
					this.WriteMessageNoTag(value);
				}
			}
		}

		public void WritePackedStringArray(int fieldNumber, string fieldName, int calculatedSize, IEnumerable<string> list)
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.LengthDelimited);
			this.WriteRawVarint32((uint)calculatedSize);
			using (IEnumerator<string> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					this.WriteStringNoTag(current);
				}
			}
		}

		public void WritePackedBytesArray(int fieldNumber, string fieldName, int calculatedSize, IEnumerable<ByteString> list)
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.LengthDelimited);
			this.WriteRawVarint32((uint)calculatedSize);
			using (IEnumerator<ByteString> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ByteString current = enumerator.Current;
					this.WriteBytesNoTag(current);
				}
			}
		}

		public void WritePackedBoolArray(int fieldNumber, string fieldName, int calculatedSize, IEnumerable<bool> list)
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.LengthDelimited);
			this.WriteRawVarint32((uint)calculatedSize);
			using (IEnumerator<bool> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					bool current = enumerator.Current;
					this.WriteBoolNoTag(current);
				}
			}
		}

		public void WritePackedInt32Array(int fieldNumber, string fieldName, int calculatedSize, IEnumerable<int> list)
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.LengthDelimited);
			this.WriteRawVarint32((uint)calculatedSize);
			using (IEnumerator<int> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int current = enumerator.Current;
					this.WriteInt32NoTag(current);
				}
			}
		}

		public void WritePackedSInt32Array(int fieldNumber, string fieldName, int calculatedSize, IEnumerable<int> list)
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.LengthDelimited);
			this.WriteRawVarint32((uint)calculatedSize);
			using (IEnumerator<int> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int current = enumerator.Current;
					this.WriteSInt32NoTag(current);
				}
			}
		}

		public void WritePackedUInt32Array(int fieldNumber, string fieldName, int calculatedSize, IEnumerable<uint> list)
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.LengthDelimited);
			this.WriteRawVarint32((uint)calculatedSize);
			using (IEnumerator<uint> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					uint current = enumerator.Current;
					this.WriteUInt32NoTag(current);
				}
			}
		}

		public void WritePackedFixed32Array(int fieldNumber, string fieldName, int calculatedSize, IEnumerable<uint> list)
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.LengthDelimited);
			this.WriteRawVarint32((uint)calculatedSize);
			using (IEnumerator<uint> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					uint current = enumerator.Current;
					this.WriteFixed32NoTag(current);
				}
			}
		}

		public void WritePackedSFixed32Array(int fieldNumber, string fieldName, int calculatedSize, IEnumerable<int> list)
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.LengthDelimited);
			this.WriteRawVarint32((uint)calculatedSize);
			using (IEnumerator<int> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int current = enumerator.Current;
					this.WriteSFixed32NoTag(current);
				}
			}
		}

		public void WritePackedInt64Array(int fieldNumber, string fieldName, int calculatedSize, IEnumerable<long> list)
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.LengthDelimited);
			this.WriteRawVarint32((uint)calculatedSize);
			using (IEnumerator<long> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					long current = enumerator.Current;
					this.WriteInt64NoTag(current);
				}
			}
		}

		public void WritePackedSInt64Array(int fieldNumber, string fieldName, int calculatedSize, IEnumerable<long> list)
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.LengthDelimited);
			this.WriteRawVarint32((uint)calculatedSize);
			using (IEnumerator<long> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					long current = enumerator.Current;
					this.WriteSInt64NoTag(current);
				}
			}
		}

		public void WritePackedUInt64Array(int fieldNumber, string fieldName, int calculatedSize, IEnumerable<ulong> list)
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.LengthDelimited);
			this.WriteRawVarint32((uint)calculatedSize);
			using (IEnumerator<ulong> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ulong current = enumerator.Current;
					this.WriteUInt64NoTag(current);
				}
			}
		}

		public void WritePackedFixed64Array(int fieldNumber, string fieldName, int calculatedSize, IEnumerable<ulong> list)
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.LengthDelimited);
			this.WriteRawVarint32((uint)calculatedSize);
			using (IEnumerator<ulong> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					ulong current = enumerator.Current;
					this.WriteFixed64NoTag(current);
				}
			}
		}

		public void WritePackedSFixed64Array(int fieldNumber, string fieldName, int calculatedSize, IEnumerable<long> list)
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.LengthDelimited);
			this.WriteRawVarint32((uint)calculatedSize);
			using (IEnumerator<long> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					long current = enumerator.Current;
					this.WriteSFixed64NoTag(current);
				}
			}
		}

		public void WritePackedDoubleArray(int fieldNumber, string fieldName, int calculatedSize, IEnumerable<double> list)
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.LengthDelimited);
			this.WriteRawVarint32((uint)calculatedSize);
			using (IEnumerator<double> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					double value = enumerator.Current;
					this.WriteDoubleNoTag(value);
				}
			}
		}

		public void WritePackedFloatArray(int fieldNumber, string fieldName, int calculatedSize, IEnumerable<float> list)
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.LengthDelimited);
			this.WriteRawVarint32((uint)calculatedSize);
			using (IEnumerator<float> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					float value = enumerator.Current;
					this.WriteFloatNoTag(value);
				}
			}
		}

		
		public void WritePackedEnumArray<T>(int fieldNumber, string fieldName, int calculatedSize, IEnumerable<T> list) where T : struct, IComparable, IFormattable, IConvertible
		{
			this.WriteTag(fieldNumber, WireFormat.WireType.LengthDelimited);
			this.WriteRawVarint32((uint)calculatedSize);
			if (list is ICastArray)
			{
				using (IEnumerator<int> enumerator = ((ICastArray)list).CastArray<int>().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						int current = enumerator.Current;
						this.WriteEnumNoTag(current);
					}
					return;
				}
			}
			using (IEnumerator<T> enumerator2 = list.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					object obj = enumerator2.Current;
					this.WriteEnumNoTag((int)obj);
				}
			}
		}

		
		public void WriteTag(int fieldNumber, WireFormat.WireType type)
		{
			this.WriteRawVarint32(WireFormat.MakeTag(fieldNumber, type));
		}

		
		public void WriteRawVarint32(uint value)
		{
			while (value > 127u)
			{
				if (this.position >= this.limit)
				{
					break;
				}
				this.buffer[this.position++] = (byte)((value & 127u) | 128u);
				value >>= 7;
			}
			while (value > 127u)
			{
				this.WriteRawByte((byte)((value & 127u) | 128u));
				value >>= 7;
			}
			if (this.position < this.limit)
			{
				this.buffer[this.position++] = (byte)value;
				return;
			}
			this.WriteRawByte((byte)value);
		}

		
		public void WriteRawVarint64(ulong value)
		{
			while (value > 127uL)
			{
				if (this.position >= this.limit)
				{
					break;
				}
				this.buffer[this.position++] = (byte)((value & 127uL) | 128uL);
				value >>= 7;
			}
			while (value > 127uL)
			{
				this.WriteRawByte((byte)((value & 127uL) | 128uL));
				value >>= 7;
			}
			if (this.position < this.limit)
			{
				this.buffer[this.position++] = (byte)value;
				return;
			}
			this.WriteRawByte((byte)value);
		}

		
		public void WriteRawLittleEndian32(uint value)
		{
			if (this.position + 4 > this.limit)
			{
				this.WriteRawByte((byte)value);
				this.WriteRawByte((byte)(value >> 8));
				this.WriteRawByte((byte)(value >> 16));
				this.WriteRawByte((byte)(value >> 24));
				return;
			}
			this.buffer[this.position++] = (byte)value;
			this.buffer[this.position++] = (byte)(value >> 8);
			this.buffer[this.position++] = (byte)(value >> 16);
			this.buffer[this.position++] = (byte)(value >> 24);
		}

		
		public void WriteRawLittleEndian64(ulong value)
		{
			if (this.position + 8 > this.limit)
			{
				this.WriteRawByte((byte)value);
				this.WriteRawByte((byte)(value >> 8));
				this.WriteRawByte((byte)(value >> 16));
				this.WriteRawByte((byte)(value >> 24));
				this.WriteRawByte((byte)(value >> 32));
				this.WriteRawByte((byte)(value >> 40));
				this.WriteRawByte((byte)(value >> 48));
				this.WriteRawByte((byte)(value >> 56));
				return;
			}
			this.buffer[this.position++] = (byte)value;
			this.buffer[this.position++] = (byte)(value >> 8);
			this.buffer[this.position++] = (byte)(value >> 16);
			this.buffer[this.position++] = (byte)(value >> 24);
			this.buffer[this.position++] = (byte)(value >> 32);
			this.buffer[this.position++] = (byte)(value >> 40);
			this.buffer[this.position++] = (byte)(value >> 48);
			this.buffer[this.position++] = (byte)(value >> 56);
		}

		public void WriteRawByte(byte value)
		{
			if (this.position == this.limit)
			{
				this.RefreshBuffer();
			}
			this.buffer[this.position++] = value;
		}

		
		public void WriteRawByte(uint value)
		{
			this.WriteRawByte((byte)value);
		}

		public void WriteRawBytes(byte[] value)
		{
			this.WriteRawBytes(value, 0, value.Length);
		}

		public void WriteRawBytes(byte[] value, int offset, int length)
		{
			if (this.limit - this.position >= length)
			{
				ByteArray.Copy(value, offset, this.buffer, this.position, length);
				this.position += length;
				return;
			}
			int num = this.limit - this.position;
			ByteArray.Copy(value, offset, this.buffer, this.position, num);
			offset += num;
			length -= num;
			this.position = this.limit;
			this.RefreshBuffer();
			if (length <= this.limit)
			{
				ByteArray.Copy(value, offset, this.buffer, 0, length);
				this.position = length;
				return;
			}
			this.output.Write(value, offset, length);
		}

		
		public static uint EncodeZigZag32(int n)
		{
			return (uint)(n << 1 ^ n >> 31);
		}

		
		public static ulong EncodeZigZag64(long n)
		{
			return (ulong)(n << 1 ^ n >> 63);
		}

		private void RefreshBuffer()
		{
			if (this.output == null)
			{
				throw new CodedOutputStream.OutOfSpaceException();
			}
			this.output.Write(this.buffer, 0, this.position);
			this.position = 0;
		}

		public void Flush()
		{
			if (this.output != null)
			{
				this.RefreshBuffer();
			}
		}

		public void CheckNoSpaceLeft()
		{
			if (this.SpaceLeft != 0)
			{
				throw new InvalidOperationException("Did not write as much data as expected.");
			}
		}
	}
}
