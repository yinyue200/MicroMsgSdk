using Google.ProtocolBuffers;
using MicroMsg.sdk.protobuf.Proto;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace MicroMsg.sdk.protobuf
{
	
	public sealed class WXTextMessageP : GeneratedMessageLite<WXTextMessageP, WXTextMessageP.Builder>
	{
		
		public sealed class Builder : GeneratedBuilderLite<WXTextMessageP, WXTextMessageP.Builder>
		{
			private bool resultIsReadOnly;

			private WXTextMessageP result;

			protected override WXTextMessageP.Builder ThisBuilder
			{
				get
				{
					return this;
				}
			}

			public override bool IsInitialized
			{
				get
				{
					return this.result.IsInitialized;
				}
			}

			protected override WXTextMessageP MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			public override WXTextMessageP DefaultInstanceForType
			{
				get
				{
					return WXTextMessageP.DefaultInstance;
				}
			}

			public string Text
			{
				get
				{
					return this.result.Text;
				}
				set
				{
					this.SetText(value);
				}
			}

			public Builder()
			{
				this.result = WXTextMessageP.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			internal Builder(WXTextMessageP cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			private WXTextMessageP PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					WXTextMessageP other = this.result;
					this.result = new WXTextMessageP();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			public override WXTextMessageP.Builder Clear()
			{
				this.result = WXTextMessageP.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			public override WXTextMessageP.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new WXTextMessageP.Builder(this.result);
				}
				return new WXTextMessageP.Builder().MergeFrom(this.result);
			}

			public override WXTextMessageP BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			public override WXTextMessageP.Builder MergeFrom(IMessageLite other)
			{
				if (other is WXTextMessageP)
				{
					return this.MergeFrom((WXTextMessageP)other);
				}
				base.MergeFrom(other);
				return this;
			}

			public override WXTextMessageP.Builder MergeFrom(WXTextMessageP other)
			{
				return this;
			}

			public override WXTextMessageP.Builder MergeFrom(ICodedInputStream input)
			{
				return this.MergeFrom(input, ExtensionRegistry.Empty);
			}

			public override WXTextMessageP.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				uint num;
				string text;
				while (input.ReadTag(out num, out text))
				{
					if (num == 0u && text != null)
					{
						int num2 = Array.BinarySearch<string>(WXTextMessageP._wXTextMessagePFieldNames, text, StringComparer.Ordinal);
						if (num2 < 0)
						{
							this.ParseUnknownField(input, extensionRegistry, num, text);
							continue;
						}
						num = WXTextMessageP._wXTextMessagePFieldTags[num2];
					}
					uint num3 = num;
					if (num3 == 0u)
					{
						throw InvalidProtocolBufferException.InvalidTag();
					}
					if (num3 != 10u)
					{
						if (WireFormat.IsEndGroupTag(num))
						{
							return this;
						}
						this.ParseUnknownField(input, extensionRegistry, num, text);
					}
					else
					{
						this.result.hasText = input.ReadString(ref this.result.text_);
					}
				}
				return this;
			}

			public WXTextMessageP.Builder SetText(string value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasText = true;
				this.result.text_ = value;
				return this;
			}

			public WXTextMessageP.Builder ClearText()
			{
				this.PrepareBuilder();
				this.result.hasText = false;
				this.result.text_ = "";
				return this;
			}
		}

		public const int TextFieldNumber = 1;

		private static readonly WXTextMessageP defaultInstance;

		private static readonly string[] _wXTextMessagePFieldNames;

		private static readonly uint[] _wXTextMessagePFieldTags;

		private bool hasText;

		private string text_ = "";

		private int memoizedSerializedSize = -1;

		public static WXTextMessageP DefaultInstance
		{
			get
			{
				return WXTextMessageP.defaultInstance;
			}
		}

		public override WXTextMessageP DefaultInstanceForType
		{
			get
			{
				return WXTextMessageP.DefaultInstance;
			}
		}

		protected override WXTextMessageP ThisMessage
		{
			get
			{
				return this;
			}
		}

		public string Text
		{
			get
			{
				return this.text_;
			}
		}

		public override bool IsInitialized
		{
			get
			{
				return this.hasText;
			}
		}

		public override int SerializedSize
		{
			get
			{
				int num = this.memoizedSerializedSize;
				if (num != -1)
				{
					return num;
				}
				num = 0;
				if (this.hasText)
				{
					num += CodedOutputStream.ComputeStringSize(1, this.Text);
				}
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		private WXTextMessageP()
		{
		}

		public override void WriteTo(ICodedOutputStream output)
		{
			int arg_06_0 = this.SerializedSize;
			string[] wXTextMessagePFieldNames = WXTextMessageP._wXTextMessagePFieldNames;
			if (this.hasText)
			{
				output.WriteString(1, wXTextMessagePFieldNames[0], this.Text);
			}
		}

		public override int GetHashCode()
		{
			int num = base.GetType().GetHashCode();
			if (this.hasText)
			{
				num ^= this.text_.GetHashCode();
			}
			return num;
		}

		public override bool Equals(object obj)
		{
			WXTextMessageP wXTextMessageP = obj as WXTextMessageP;
			return wXTextMessageP != null && this.hasText == wXTextMessageP.hasText && (!this.hasText || this.text_.Equals(wXTextMessageP.text_));
		}

		public override void PrintTo(TextWriter writer)
		{
			GeneratedMessageLite<WXTextMessageP, WXTextMessageP.Builder>.PrintField("Text", this.hasText, this.text_, writer);
		}

		public static WXTextMessageP ParseFrom(byte[] data)
		{
			return WXTextMessageP.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		private WXTextMessageP MakeReadOnly()
		{
			return this;
		}

		public static WXTextMessageP.Builder CreateBuilder()
		{
			return new WXTextMessageP.Builder();
		}

		public override WXTextMessageP.Builder ToBuilder()
		{
			return WXTextMessageP.CreateBuilder(this);
		}

		public override WXTextMessageP.Builder CreateBuilderForType()
		{
			return new WXTextMessageP.Builder();
		}

		public static WXTextMessageP.Builder CreateBuilder(WXTextMessageP prototype)
		{
			return new WXTextMessageP.Builder(prototype);
		}

		static WXTextMessageP()
		{
			WXTextMessageP.defaultInstance = new WXTextMessageP().MakeReadOnly();
			WXTextMessageP._wXTextMessagePFieldNames = new string[]
			{
				"Text"
			};
			WXTextMessageP._wXTextMessagePFieldTags = new uint[]
			{
				10u
			};
			object.ReferenceEquals(MicroMsg.sdk.protobuf.Proto.WXTextMessageP.Descriptor, null);
		}
	}
}
