using Google.ProtocolBuffers;
using MicroMsg.sdk.protobuf.Proto;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace MicroMsg.sdk.protobuf
{
	
	public sealed class WXEmojiMessageP : GeneratedMessageLite<WXEmojiMessageP, WXEmojiMessageP.Builder>
	{
		
		public sealed class Builder : GeneratedBuilderLite<WXEmojiMessageP, WXEmojiMessageP.Builder>
		{
			private bool resultIsReadOnly;

			private WXEmojiMessageP result;

			protected override WXEmojiMessageP.Builder ThisBuilder
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

			protected override WXEmojiMessageP MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			public override WXEmojiMessageP DefaultInstanceForType
			{
				get
				{
					return WXEmojiMessageP.DefaultInstance;
				}
			}

			public ByteString EmojiData
			{
				get
				{
					return this.result.EmojiData;
				}
				set
				{
					this.SetEmojiData(value);
				}
			}

			public Builder()
			{
				this.result = WXEmojiMessageP.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			internal Builder(WXEmojiMessageP cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			private WXEmojiMessageP PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					WXEmojiMessageP other = this.result;
					this.result = new WXEmojiMessageP();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			public override WXEmojiMessageP.Builder Clear()
			{
				this.result = WXEmojiMessageP.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			public override WXEmojiMessageP.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new WXEmojiMessageP.Builder(this.result);
				}
				return new WXEmojiMessageP.Builder().MergeFrom(this.result);
			}

			public override WXEmojiMessageP BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			public override WXEmojiMessageP.Builder MergeFrom(IMessageLite other)
			{
				if (other is WXEmojiMessageP)
				{
					return this.MergeFrom((WXEmojiMessageP)other);
				}
				base.MergeFrom(other);
				return this;
			}

			public override WXEmojiMessageP.Builder MergeFrom(WXEmojiMessageP other)
			{
				return this;
			}

			public override WXEmojiMessageP.Builder MergeFrom(ICodedInputStream input)
			{
				return this.MergeFrom(input, ExtensionRegistry.Empty);
			}

			public override WXEmojiMessageP.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				uint num;
				string text;
				while (input.ReadTag(out num, out text))
				{
					if (num == 0u && text != null)
					{
						int num2 = Array.BinarySearch<string>(WXEmojiMessageP._wXEmojiMessagePFieldNames, text, StringComparer.Ordinal);
						if (num2 < 0)
						{
							this.ParseUnknownField(input, extensionRegistry, num, text);
							continue;
						}
						num = WXEmojiMessageP._wXEmojiMessagePFieldTags[num2];
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
						this.result.hasEmojiData = input.ReadBytes(ref this.result.emojiData_);
					}
				}
				return this;
			}

			public WXEmojiMessageP.Builder SetEmojiData(ByteString value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasEmojiData = true;
				this.result.emojiData_ = value;
				return this;
			}

			public WXEmojiMessageP.Builder ClearEmojiData()
			{
				this.PrepareBuilder();
				this.result.hasEmojiData = false;
				this.result.emojiData_ = ByteString.Empty;
				return this;
			}
		}

		public const int EmojiDataFieldNumber = 1;

		private static readonly WXEmojiMessageP defaultInstance;

		private static readonly string[] _wXEmojiMessagePFieldNames;

		private static readonly uint[] _wXEmojiMessagePFieldTags;

		private bool hasEmojiData;

		private ByteString emojiData_ = ByteString.Empty;

		private int memoizedSerializedSize = -1;

		public static WXEmojiMessageP DefaultInstance
		{
			get
			{
				return WXEmojiMessageP.defaultInstance;
			}
		}

		public override WXEmojiMessageP DefaultInstanceForType
		{
			get
			{
				return WXEmojiMessageP.DefaultInstance;
			}
		}

		protected override WXEmojiMessageP ThisMessage
		{
			get
			{
				return this;
			}
		}

		public ByteString EmojiData
		{
			get
			{
				return this.emojiData_;
			}
		}

		public override bool IsInitialized
		{
			get
			{
				return this.hasEmojiData;
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
				if (this.hasEmojiData)
				{
					num += CodedOutputStream.ComputeBytesSize(1, this.EmojiData);
				}
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		private WXEmojiMessageP()
		{
		}

		public override void WriteTo(ICodedOutputStream output)
		{
			int arg_06_0 = this.SerializedSize;
			string[] wXEmojiMessagePFieldNames = WXEmojiMessageP._wXEmojiMessagePFieldNames;
			if (this.hasEmojiData)
			{
				output.WriteBytes(1, wXEmojiMessagePFieldNames[0], this.EmojiData);
			}
		}

		public override int GetHashCode()
		{
			int num = base.GetType().GetHashCode();
			if (this.hasEmojiData)
			{
				num ^= this.emojiData_.GetHashCode();
			}
			return num;
		}

		public override bool Equals(object obj)
		{
			WXEmojiMessageP wXEmojiMessageP = obj as WXEmojiMessageP;
			return wXEmojiMessageP != null && this.hasEmojiData == wXEmojiMessageP.hasEmojiData && (!this.hasEmojiData || this.emojiData_.Equals(wXEmojiMessageP.emojiData_));
		}

		public override void PrintTo(TextWriter writer)
		{
			GeneratedMessageLite<WXEmojiMessageP, WXEmojiMessageP.Builder>.PrintField("EmojiData", this.hasEmojiData, this.emojiData_, writer);
		}

		public static WXEmojiMessageP ParseFrom(byte[] data)
		{
			return WXEmojiMessageP.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		private WXEmojiMessageP MakeReadOnly()
		{
			return this;
		}

		public static WXEmojiMessageP.Builder CreateBuilder()
		{
			return new WXEmojiMessageP.Builder();
		}

		public override WXEmojiMessageP.Builder ToBuilder()
		{
			return WXEmojiMessageP.CreateBuilder(this);
		}

		public override WXEmojiMessageP.Builder CreateBuilderForType()
		{
			return new WXEmojiMessageP.Builder();
		}

		public static WXEmojiMessageP.Builder CreateBuilder(WXEmojiMessageP prototype)
		{
			return new WXEmojiMessageP.Builder(prototype);
		}

		static WXEmojiMessageP()
		{
			WXEmojiMessageP.defaultInstance = new WXEmojiMessageP().MakeReadOnly();
			WXEmojiMessageP._wXEmojiMessagePFieldNames = new string[]
			{
				"EmojiData"
			};
			WXEmojiMessageP._wXEmojiMessagePFieldTags = new uint[]
			{
				10u
			};
			object.ReferenceEquals(MicroMsg.sdk.protobuf.Proto.WXEmojiMessageP.Descriptor, null);
		}
	}
}
