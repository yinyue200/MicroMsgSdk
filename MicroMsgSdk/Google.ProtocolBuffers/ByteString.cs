using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Google.ProtocolBuffers
{
	public sealed class ByteString : IEnumerable<byte>, IEnumerable, IEquatable<ByteString>
	{
		internal sealed class CodedBuilder
		{
			private readonly CodedOutputStream output;

			private readonly byte[] buffer;

			internal CodedOutputStream CodedOutput
			{
				get
				{
					return this.output;
				}
			}

			internal CodedBuilder(int size)
			{
				this.buffer = new byte[size];
				this.output = CodedOutputStream.CreateInstance(this.buffer);
			}

			internal ByteString Build()
			{
				this.output.CheckNoSpaceLeft();
				return new ByteString(this.buffer);
			}
		}

		private static readonly ByteString empty = new ByteString(new byte[0]);

		private readonly byte[] bytes;

		public static ByteString Empty
		{
			get
			{
				return ByteString.empty;
			}
		}

		public int Length
		{
			get
			{
				return this.bytes.Length;
			}
		}

		public bool IsEmpty
		{
			get
			{
				return this.Length == 0;
			}
		}

		public byte this[int index]
		{
			get
			{
				return this.bytes[index];
			}
		}

		internal static ByteString AttachBytes(byte[] bytes)
		{
			return new ByteString(bytes);
		}

		private ByteString(byte[] bytes)
		{
			this.bytes = bytes;
		}

		public byte[] ToByteArray()
		{
			return (byte[])this.bytes.Clone();
		}

		public string ToBase64()
		{
			return Convert.ToBase64String(this.bytes);
		}

		public static ByteString FromBase64(string bytes)
		{
			return new ByteString(Convert.FromBase64String(bytes));
		}

		public static ByteString CopyFrom(byte[] bytes)
		{
			return new ByteString((byte[])bytes.Clone());
		}

		public static ByteString CopyFrom(byte[] bytes, int offset, int count)
		{
			byte[] dst = new byte[count];
			ByteArray.Copy(bytes, offset, dst, 0, count);
			return new ByteString(dst);
		}

		public static ByteString CopyFrom(string text, Encoding encoding)
		{
			return new ByteString(encoding.GetBytes(text));
		}

		public static ByteString CopyFromUtf8(string text)
		{
			return ByteString.CopyFrom(text, Encoding.UTF8);
		}

		public string ToString(Encoding encoding)
		{
			return encoding.GetString(this.bytes, 0, this.bytes.Length);
		}

		public string ToStringUtf8()
		{
			return this.ToString(Encoding.UTF8);
		}

		public IEnumerator<byte> GetEnumerator()
		{
			return ((IEnumerable<byte>)this.bytes).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public CodedInputStream CreateCodedInput()
		{
			return CodedInputStream.CreateInstance(this.bytes);
		}

		public override bool Equals(object obj)
		{
			ByteString other = obj as ByteString;
			return obj != null && this.Equals(other);
		}

		public override int GetHashCode()
		{
			int num = 23;
			byte[] array = this.bytes;
			for (int i = 0; i < array.Length; i++)
			{
				byte b = array[i];
				num = (num << 8 | (int)b);
			}
			return num;
		}

		public bool Equals(ByteString other)
		{
			if (other.bytes.Length != this.bytes.Length)
			{
				return false;
			}
			for (int i = 0; i < this.bytes.Length; i++)
			{
				if (other.bytes[i] != this.bytes[i])
				{
					return false;
				}
			}
			return true;
		}

		internal void WriteRawBytesTo(CodedOutputStream outputStream)
		{
			outputStream.WriteRawBytes(this.bytes, 0, this.bytes.Length);
		}

		public void CopyTo(byte[] array, int position)
		{
			ByteArray.Copy(this.bytes, 0, array, position, this.bytes.Length);
		}

		public void WriteTo(Stream outputStream)
		{
			outputStream.Write(this.bytes, 0, this.bytes.Length);
		}
	}
}
