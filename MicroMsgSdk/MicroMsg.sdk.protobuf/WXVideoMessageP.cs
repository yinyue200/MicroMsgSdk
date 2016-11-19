using Google.ProtocolBuffers;
using MicroMsg.sdk.protobuf.Proto;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace MicroMsg.sdk.protobuf
{
	
	public sealed class WXVideoMessageP : GeneratedMessageLite<WXVideoMessageP, WXVideoMessageP.Builder>
	{
		
		public sealed class Builder : GeneratedBuilderLite<WXVideoMessageP, WXVideoMessageP.Builder>
		{
			private bool resultIsReadOnly;

			private WXVideoMessageP result;

			protected override WXVideoMessageP.Builder ThisBuilder
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

			protected override WXVideoMessageP MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			public override WXVideoMessageP DefaultInstanceForType
			{
				get
				{
					return WXVideoMessageP.DefaultInstance;
				}
			}

			public string VideoUrl
			{
				get
				{
					return this.result.VideoUrl;
				}
				set
				{
					this.SetVideoUrl(value);
				}
			}

			public string VideoLowBandUrl
			{
				get
				{
					return this.result.VideoLowBandUrl;
				}
				set
				{
					this.SetVideoLowBandUrl(value);
				}
			}

			public Builder()
			{
				this.result = WXVideoMessageP.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			internal Builder(WXVideoMessageP cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			private WXVideoMessageP PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					WXVideoMessageP other = this.result;
					this.result = new WXVideoMessageP();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			public override WXVideoMessageP.Builder Clear()
			{
				this.result = WXVideoMessageP.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			public override WXVideoMessageP.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new WXVideoMessageP.Builder(this.result);
				}
				return new WXVideoMessageP.Builder().MergeFrom(this.result);
			}

			public override WXVideoMessageP BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			public override WXVideoMessageP.Builder MergeFrom(IMessageLite other)
			{
				if (other is WXVideoMessageP)
				{
					return this.MergeFrom((WXVideoMessageP)other);
				}
				base.MergeFrom(other);
				return this;
			}

			public override WXVideoMessageP.Builder MergeFrom(WXVideoMessageP other)
			{
				return this;
			}

			public override WXVideoMessageP.Builder MergeFrom(ICodedInputStream input)
			{
				return this.MergeFrom(input, ExtensionRegistry.Empty);
			}

			public override WXVideoMessageP.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				uint num;
				string text;
				while (input.ReadTag(out num, out text))
				{
					if (num == 0u && text != null)
					{
						int num2 = Array.BinarySearch<string>(WXVideoMessageP._wXVideoMessagePFieldNames, text, StringComparer.Ordinal);
						if (num2 < 0)
						{
							this.ParseUnknownField(input, extensionRegistry, num, text);
							continue;
						}
						num = WXVideoMessageP._wXVideoMessagePFieldTags[num2];
					}
					uint num3 = num;
					if (num3 == 0u)
					{
						throw InvalidProtocolBufferException.InvalidTag();
					}
					if (num3 != 10u)
					{
						if (num3 != 18u)
						{
							if (WireFormat.IsEndGroupTag(num))
							{
								return this;
							}
							this.ParseUnknownField(input, extensionRegistry, num, text);
						}
						else
						{
							this.result.hasVideoLowBandUrl = input.ReadString(ref this.result.videoLowBandUrl_);
						}
					}
					else
					{
						this.result.hasVideoUrl = input.ReadString(ref this.result.videoUrl_);
					}
				}
				return this;
			}

			public WXVideoMessageP.Builder SetVideoUrl(string value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasVideoUrl = true;
				this.result.videoUrl_ = value;
				return this;
			}

			public WXVideoMessageP.Builder ClearVideoUrl()
			{
				this.PrepareBuilder();
				this.result.hasVideoUrl = false;
				this.result.videoUrl_ = "";
				return this;
			}

			public WXVideoMessageP.Builder SetVideoLowBandUrl(string value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasVideoLowBandUrl = true;
				this.result.videoLowBandUrl_ = value;
				return this;
			}

			public WXVideoMessageP.Builder ClearVideoLowBandUrl()
			{
				this.PrepareBuilder();
				this.result.hasVideoLowBandUrl = false;
				this.result.videoLowBandUrl_ = "";
				return this;
			}
		}

		public const int VideoUrlFieldNumber = 1;

		public const int VideoLowBandUrlFieldNumber = 2;

		private static readonly WXVideoMessageP defaultInstance;

		private static readonly string[] _wXVideoMessagePFieldNames;

		private static readonly uint[] _wXVideoMessagePFieldTags;

		private bool hasVideoUrl;

		private string videoUrl_ = "";

		private bool hasVideoLowBandUrl;

		private string videoLowBandUrl_ = "";

		private int memoizedSerializedSize = -1;

		public static WXVideoMessageP DefaultInstance
		{
			get
			{
				return WXVideoMessageP.defaultInstance;
			}
		}

		public override WXVideoMessageP DefaultInstanceForType
		{
			get
			{
				return WXVideoMessageP.DefaultInstance;
			}
		}

		protected override WXVideoMessageP ThisMessage
		{
			get
			{
				return this;
			}
		}

		public string VideoUrl
		{
			get
			{
				return this.videoUrl_;
			}
		}

		public string VideoLowBandUrl
		{
			get
			{
				return this.videoLowBandUrl_;
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
				if (this.hasVideoUrl)
				{
					num += CodedOutputStream.ComputeStringSize(1, this.VideoUrl);
				}
				if (this.hasVideoLowBandUrl)
				{
					num += CodedOutputStream.ComputeStringSize(2, this.VideoLowBandUrl);
				}
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		private WXVideoMessageP()
		{
		}

		public override void WriteTo(ICodedOutputStream output)
		{
			int arg_06_0 = this.SerializedSize;
			string[] wXVideoMessagePFieldNames = WXVideoMessageP._wXVideoMessagePFieldNames;
			if (this.hasVideoUrl)
			{
				output.WriteString(1, wXVideoMessagePFieldNames[1], this.VideoUrl);
			}
			if (this.hasVideoLowBandUrl)
			{
				output.WriteString(2, wXVideoMessagePFieldNames[0], this.VideoLowBandUrl);
			}
		}

		public override int GetHashCode()
		{
			int num = base.GetType().GetHashCode();
			if (this.hasVideoUrl)
			{
				num ^= this.videoUrl_.GetHashCode();
			}
			if (this.hasVideoLowBandUrl)
			{
				num ^= this.videoLowBandUrl_.GetHashCode();
			}
			return num;
		}

		public override bool Equals(object obj)
		{
			WXVideoMessageP wXVideoMessageP = obj as WXVideoMessageP;
			return wXVideoMessageP != null && this.hasVideoUrl == wXVideoMessageP.hasVideoUrl && (!this.hasVideoUrl || this.videoUrl_.Equals(wXVideoMessageP.videoUrl_)) && this.hasVideoLowBandUrl == wXVideoMessageP.hasVideoLowBandUrl && (!this.hasVideoLowBandUrl || this.videoLowBandUrl_.Equals(wXVideoMessageP.videoLowBandUrl_));
		}

		public override void PrintTo(TextWriter writer)
		{
			GeneratedMessageLite<WXVideoMessageP, WXVideoMessageP.Builder>.PrintField("VideoUrl", this.hasVideoUrl, this.videoUrl_, writer);
			GeneratedMessageLite<WXVideoMessageP, WXVideoMessageP.Builder>.PrintField("VideoLowBandUrl", this.hasVideoLowBandUrl, this.videoLowBandUrl_, writer);
		}

		public static WXVideoMessageP ParseFrom(byte[] data)
		{
			return WXVideoMessageP.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		private WXVideoMessageP MakeReadOnly()
		{
			return this;
		}

		public static WXVideoMessageP.Builder CreateBuilder()
		{
			return new WXVideoMessageP.Builder();
		}

		public override WXVideoMessageP.Builder ToBuilder()
		{
			return WXVideoMessageP.CreateBuilder(this);
		}

		public override WXVideoMessageP.Builder CreateBuilderForType()
		{
			return new WXVideoMessageP.Builder();
		}

		public static WXVideoMessageP.Builder CreateBuilder(WXVideoMessageP prototype)
		{
			return new WXVideoMessageP.Builder(prototype);
		}

		static WXVideoMessageP()
		{
			WXVideoMessageP.defaultInstance = new WXVideoMessageP().MakeReadOnly();
			WXVideoMessageP._wXVideoMessagePFieldNames = new string[]
			{
				"VideoLowBandUrl",
				"VideoUrl"
			};
			WXVideoMessageP._wXVideoMessagePFieldTags = new uint[]
			{
				18u,
				10u
			};
			object.ReferenceEquals(MicroMsg.sdk.protobuf.Proto.WXVideoMessageP.Descriptor, null);
		}
	}
}
