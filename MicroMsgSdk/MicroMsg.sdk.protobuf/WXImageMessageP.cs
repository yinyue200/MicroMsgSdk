using Google.ProtocolBuffers;
using MicroMsg.sdk.protobuf.Proto;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace MicroMsg.sdk.protobuf
{
	
	public sealed class WXImageMessageP : GeneratedMessageLite<WXImageMessageP, WXImageMessageP.Builder>
	{
		
		public sealed class Builder : GeneratedBuilderLite<WXImageMessageP, WXImageMessageP.Builder>
		{
			private bool resultIsReadOnly;

			private WXImageMessageP result;

			protected override WXImageMessageP.Builder ThisBuilder
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

			protected override WXImageMessageP MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			public override WXImageMessageP DefaultInstanceForType
			{
				get
				{
					return WXImageMessageP.DefaultInstance;
				}
			}

			public ByteString ImageData
			{
				get
				{
					return this.result.ImageData;
				}
				set
				{
					this.SetImageData(value);
				}
			}

			public string ImageUrl
			{
				get
				{
					return this.result.ImageUrl;
				}
				set
				{
					this.SetImageUrl(value);
				}
			}

			public Builder()
			{
				this.result = WXImageMessageP.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			internal Builder(WXImageMessageP cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			private WXImageMessageP PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					WXImageMessageP other = this.result;
					this.result = new WXImageMessageP();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			public override WXImageMessageP.Builder Clear()
			{
				this.result = WXImageMessageP.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			public override WXImageMessageP.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new WXImageMessageP.Builder(this.result);
				}
				return new WXImageMessageP.Builder().MergeFrom(this.result);
			}

			public override WXImageMessageP BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			public override WXImageMessageP.Builder MergeFrom(IMessageLite other)
			{
				if (other is WXImageMessageP)
				{
					return this.MergeFrom((WXImageMessageP)other);
				}
				base.MergeFrom(other);
				return this;
			}

			public override WXImageMessageP.Builder MergeFrom(WXImageMessageP other)
			{
				return this;
			}

			public override WXImageMessageP.Builder MergeFrom(ICodedInputStream input)
			{
				return this.MergeFrom(input, ExtensionRegistry.Empty);
			}

			public override WXImageMessageP.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				uint num;
				string text;
				while (input.ReadTag(out num, out text))
				{
					if (num == 0u && text != null)
					{
						int num2 = Array.BinarySearch<string>(WXImageMessageP._wXImageMessagePFieldNames, text, StringComparer.Ordinal);
						if (num2 < 0)
						{
							this.ParseUnknownField(input, extensionRegistry, num, text);
							continue;
						}
						num = WXImageMessageP._wXImageMessagePFieldTags[num2];
					}
					uint num3 = num;
					if (num3 == 0u)
					{
						throw InvalidProtocolBufferException.InvalidTag();
					}
					if (num3 != 10u)
					{
						if (num3 != 26u)
						{
							if (WireFormat.IsEndGroupTag(num))
							{
								return this;
							}
							this.ParseUnknownField(input, extensionRegistry, num, text);
						}
						else
						{
							this.result.hasImageUrl = input.ReadString(ref this.result.imageUrl_);
						}
					}
					else
					{
						this.result.hasImageData = input.ReadBytes(ref this.result.imageData_);
					}
				}
				return this;
			}

			public WXImageMessageP.Builder SetImageData(ByteString value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasImageData = true;
				this.result.imageData_ = value;
				return this;
			}

			public WXImageMessageP.Builder ClearImageData()
			{
				this.PrepareBuilder();
				this.result.hasImageData = false;
				this.result.imageData_ = ByteString.Empty;
				return this;
			}

			public WXImageMessageP.Builder SetImageUrl(string value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasImageUrl = true;
				this.result.imageUrl_ = value;
				return this;
			}

			public WXImageMessageP.Builder ClearImageUrl()
			{
				this.PrepareBuilder();
				this.result.hasImageUrl = false;
				this.result.imageUrl_ = "";
				return this;
			}
		}

		public const int ImageDataFieldNumber = 1;

		public const int ImageUrlFieldNumber = 3;

		private static readonly WXImageMessageP defaultInstance;

		private static readonly string[] _wXImageMessagePFieldNames;

		private static readonly uint[] _wXImageMessagePFieldTags;

		private bool hasImageData;

		private ByteString imageData_ = ByteString.Empty;

		private bool hasImageUrl;

		private string imageUrl_ = "";

		private int memoizedSerializedSize = -1;

		public static WXImageMessageP DefaultInstance
		{
			get
			{
				return WXImageMessageP.defaultInstance;
			}
		}

		public override WXImageMessageP DefaultInstanceForType
		{
			get
			{
				return WXImageMessageP.DefaultInstance;
			}
		}

		protected override WXImageMessageP ThisMessage
		{
			get
			{
				return this;
			}
		}

		public ByteString ImageData
		{
			get
			{
				return this.imageData_;
			}
		}

		public string ImageUrl
		{
			get
			{
				return this.imageUrl_;
			}
		}

		public override bool IsInitialized
		{
			get
			{
				return true;
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
				if (this.hasImageData)
				{
					num += CodedOutputStream.ComputeBytesSize(1, this.ImageData);
				}
				if (this.hasImageUrl)
				{
					num += CodedOutputStream.ComputeStringSize(3, this.ImageUrl);
				}
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		private WXImageMessageP()
		{
		}

		public override void WriteTo(ICodedOutputStream output)
		{
			int arg_06_0 = this.SerializedSize;
			string[] wXImageMessagePFieldNames = WXImageMessageP._wXImageMessagePFieldNames;
			if (this.hasImageData)
			{
				output.WriteBytes(1, wXImageMessagePFieldNames[0], this.ImageData);
			}
			if (this.hasImageUrl)
			{
				output.WriteString(3, wXImageMessagePFieldNames[1], this.ImageUrl);
			}
		}

		public override int GetHashCode()
		{
			int num = base.GetType().GetHashCode();
			if (this.hasImageData)
			{
				num ^= this.imageData_.GetHashCode();
			}
			if (this.hasImageUrl)
			{
				num ^= this.imageUrl_.GetHashCode();
			}
			return num;
		}

		public override bool Equals(object obj)
		{
			WXImageMessageP wXImageMessageP = obj as WXImageMessageP;
			return wXImageMessageP != null && this.hasImageData == wXImageMessageP.hasImageData && (!this.hasImageData || this.imageData_.Equals(wXImageMessageP.imageData_)) && this.hasImageUrl == wXImageMessageP.hasImageUrl && (!this.hasImageUrl || this.imageUrl_.Equals(wXImageMessageP.imageUrl_));
		}

		public override void PrintTo(TextWriter writer)
		{
			GeneratedMessageLite<WXImageMessageP, WXImageMessageP.Builder>.PrintField("ImageData", this.hasImageData, this.imageData_, writer);
			GeneratedMessageLite<WXImageMessageP, WXImageMessageP.Builder>.PrintField("ImageUrl", this.hasImageUrl, this.imageUrl_, writer);
		}

		public static WXImageMessageP ParseFrom(byte[] data)
		{
			return WXImageMessageP.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		private WXImageMessageP MakeReadOnly()
		{
			return this;
		}

		public static WXImageMessageP.Builder CreateBuilder()
		{
			return new WXImageMessageP.Builder();
		}

		public override WXImageMessageP.Builder ToBuilder()
		{
			return WXImageMessageP.CreateBuilder(this);
		}

		public override WXImageMessageP.Builder CreateBuilderForType()
		{
			return new WXImageMessageP.Builder();
		}

		public static WXImageMessageP.Builder CreateBuilder(WXImageMessageP prototype)
		{
			return new WXImageMessageP.Builder(prototype);
		}

		static WXImageMessageP()
		{
			WXImageMessageP.defaultInstance = new WXImageMessageP().MakeReadOnly();
			WXImageMessageP._wXImageMessagePFieldNames = new string[]
			{
				"ImageData",
				"ImageUrl"
			};
			WXImageMessageP._wXImageMessagePFieldTags = new uint[]
			{
				10u,
				26u
			};
			object.ReferenceEquals(MicroMsg.sdk.protobuf.Proto.WXImageMessageP.Descriptor, null);
		}
	}
}
