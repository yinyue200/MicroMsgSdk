using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Google.ProtocolBuffers
{
	public abstract class GeneratedMessageLite<TMessage, TBuilder> : AbstractMessageLite<TMessage, TBuilder> where TMessage : GeneratedMessageLite<TMessage, TBuilder> where TBuilder : GeneratedBuilderLite<TMessage, TBuilder>
	{
		protected abstract TMessage ThisMessage
		{
			get;
		}

		public sealed override string ToString()
		{
			string result;
			using (StringWriter stringWriter = new StringWriter())
			{
				this.PrintTo(stringWriter);
				result = stringWriter.ToString();
			}
			return result;
		}

		protected static void PrintField<T>(string name, IList<T> value, TextWriter writer)
		{
			using (IEnumerator<T> enumerator = value.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					T current = enumerator.Current;
					GeneratedMessageLite<TMessage, TBuilder>.PrintField(name, true, current, writer);
				}
			}
		}

		protected static void PrintField(string name, bool hasValue, object value, TextWriter writer)
		{
			if (!hasValue)
			{
				return;
			}
			if (value is IMessageLite)
			{
				writer.WriteLine("{0} {{", name);
				((IMessageLite)value).PrintTo(writer);
				writer.WriteLine("}");
				return;
			}
			if (value is ByteString || value is string)
			{
				writer.Write("{0}: \"", name);
				if (value is string)
				{
					GeneratedMessageLite<TMessage, TBuilder>.EscapeBytes(Encoding.UTF8.GetBytes((string)value), writer);
				}
				else
				{
					GeneratedMessageLite<TMessage, TBuilder>.EscapeBytes((ByteString)value, writer);
				}
				writer.WriteLine("\"");
				return;
			}
			if (value is bool)
			{
				writer.WriteLine("{0}: {1}", name, ((bool)value) ? "true" : "false");
				return;
			}
			if (value is IEnumLite)
			{
				writer.WriteLine("{0}: {1}", name, ((IEnumLite)value).Name);
				return;
			}
			writer.WriteLine("{0}: {1}", name, ((IConvertible)value).ToString(CultureInfo.InvariantCulture));
		}

		private static void EscapeBytes(IEnumerable<byte> input, TextWriter writer)
		{
			using (IEnumerator<byte> enumerator = input.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					byte current = enumerator.Current;
					byte b = current;
					if (b <= 34)
					{
						switch (b)
						{
						case 7:
							writer.Write("\\a");
							continue;
						case 8:
							writer.Write("\\b");
							continue;
						case 9:
							writer.Write("\\t");
							continue;
						case 10:
							writer.Write("\\n");
							continue;
						case 11:
							writer.Write("\\v");
							continue;
						case 12:
							writer.Write("\\f");
							continue;
						case 13:
							writer.Write("\\r");
							continue;
						default:
							if (b == 34)
							{
								writer.Write("\\\"");
								continue;
							}
							break;
						}
					}
					else
					{
						if (b == 39)
						{
							writer.Write("\\'");
							continue;
						}
						if (b == 92)
						{
							writer.Write("\\\\");
							continue;
						}
					}
					if (current >= 32 && current < 128)
					{
						writer.Write((char)current);
					}
					else
					{
						writer.Write('\\');
						writer.Write((char)(48 + (current >> 6 & 3)));
						writer.Write((char)(48 + (current >> 3 & 7)));
						writer.Write((char)(48 + (current & 7)));
					}
				}
			}
		}
	}
}
