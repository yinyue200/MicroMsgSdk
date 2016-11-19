using Google.ProtocolBuffers;
using MicroMsg.sdk.protobuf.Proto;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace MicroMsg.sdk.protobuf
{
	
	public sealed class WXMusicMessageP : GeneratedMessageLite<WXMusicMessageP, WXMusicMessageP.Builder>
	{
		
		public sealed class Builder : GeneratedBuilderLite<WXMusicMessageP, WXMusicMessageP.Builder>
		{
			private bool resultIsReadOnly;

			private WXMusicMessageP result;

			protected override WXMusicMessageP.Builder ThisBuilder
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

			protected override WXMusicMessageP MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			public override WXMusicMessageP DefaultInstanceForType
			{
				get
				{
					return WXMusicMessageP.DefaultInstance;
				}
			}

			public string MusicUrl
			{
				get
				{
					return this.result.MusicUrl;
				}
				set
				{
					this.SetMusicUrl(value);
				}
			}

			public string MusicLowBandUrl
			{
				get
				{
					return this.result.MusicLowBandUrl;
				}
				set
				{
					this.SetMusicLowBandUrl(value);
				}
			}

			public Builder()
			{
				this.result = WXMusicMessageP.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			internal Builder(WXMusicMessageP cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			private WXMusicMessageP PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					WXMusicMessageP other = this.result;
					this.result = new WXMusicMessageP();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			public override WXMusicMessageP.Builder Clear()
			{
				this.result = WXMusicMessageP.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			public override WXMusicMessageP.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new WXMusicMessageP.Builder(this.result);
				}
				return new WXMusicMessageP.Builder().MergeFrom(this.result);
			}

			public override WXMusicMessageP BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			public override WXMusicMessageP.Builder MergeFrom(IMessageLite other)
			{
				if (other is WXMusicMessageP)
				{
					return this.MergeFrom((WXMusicMessageP)other);
				}
				base.MergeFrom(other);
				return this;
			}

			public override WXMusicMessageP.Builder MergeFrom(WXMusicMessageP other)
			{
				return this;
			}

			public override WXMusicMessageP.Builder MergeFrom(ICodedInputStream input)
			{
				return this.MergeFrom(input, ExtensionRegistry.Empty);
			}

			public override WXMusicMessageP.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				uint num;
				string text;
				while (input.ReadTag(out num, out text))
				{
					if (num == 0u && text != null)
					{
						int num2 = Array.BinarySearch<string>(WXMusicMessageP._wXMusicMessagePFieldNames, text, StringComparer.Ordinal);
						if (num2 < 0)
						{
							this.ParseUnknownField(input, extensionRegistry, num, text);
							continue;
						}
						num = WXMusicMessageP._wXMusicMessagePFieldTags[num2];
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
							this.result.hasMusicLowBandUrl = input.ReadString(ref this.result.musicLowBandUrl_);
						}
					}
					else
					{
						this.result.hasMusicUrl = input.ReadString(ref this.result.musicUrl_);
					}
				}
				return this;
			}

			public WXMusicMessageP.Builder SetMusicUrl(string value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasMusicUrl = true;
				this.result.musicUrl_ = value;
				return this;
			}

			public WXMusicMessageP.Builder ClearMusicUrl()
			{
				this.PrepareBuilder();
				this.result.hasMusicUrl = false;
				this.result.musicUrl_ = "";
				return this;
			}

			public WXMusicMessageP.Builder SetMusicLowBandUrl(string value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasMusicLowBandUrl = true;
				this.result.musicLowBandUrl_ = value;
				return this;
			}

			public WXMusicMessageP.Builder ClearMusicLowBandUrl()
			{
				this.PrepareBuilder();
				this.result.hasMusicLowBandUrl = false;
				this.result.musicLowBandUrl_ = "";
				return this;
			}
		}

		public const int MusicUrlFieldNumber = 1;

		public const int MusicLowBandUrlFieldNumber = 2;

		private static readonly WXMusicMessageP defaultInstance;

		private static readonly string[] _wXMusicMessagePFieldNames;

		private static readonly uint[] _wXMusicMessagePFieldTags;

		private bool hasMusicUrl;

		private string musicUrl_ = "";

		private bool hasMusicLowBandUrl;

		private string musicLowBandUrl_ = "";

		private int memoizedSerializedSize = -1;

		public static WXMusicMessageP DefaultInstance
		{
			get
			{
				return WXMusicMessageP.defaultInstance;
			}
		}

		public override WXMusicMessageP DefaultInstanceForType
		{
			get
			{
				return WXMusicMessageP.DefaultInstance;
			}
		}

		protected override WXMusicMessageP ThisMessage
		{
			get
			{
				return this;
			}
		}

		public string MusicUrl
		{
			get
			{
				return this.musicUrl_;
			}
		}

		public string MusicLowBandUrl
		{
			get
			{
				return this.musicLowBandUrl_;
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
				if (this.hasMusicUrl)
				{
					num += CodedOutputStream.ComputeStringSize(1, this.MusicUrl);
				}
				if (this.hasMusicLowBandUrl)
				{
					num += CodedOutputStream.ComputeStringSize(2, this.MusicLowBandUrl);
				}
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		private WXMusicMessageP()
		{
		}

		public override void WriteTo(ICodedOutputStream output)
		{
			int arg_06_0 = this.SerializedSize;
			string[] wXMusicMessagePFieldNames = WXMusicMessageP._wXMusicMessagePFieldNames;
			if (this.hasMusicUrl)
			{
				output.WriteString(1, wXMusicMessagePFieldNames[1], this.MusicUrl);
			}
			if (this.hasMusicLowBandUrl)
			{
				output.WriteString(2, wXMusicMessagePFieldNames[0], this.MusicLowBandUrl);
			}
		}

		public override int GetHashCode()
		{
			int num = base.GetType().GetHashCode();
			if (this.hasMusicUrl)
			{
				num ^= this.musicUrl_.GetHashCode();
			}
			if (this.hasMusicLowBandUrl)
			{
				num ^= this.musicLowBandUrl_.GetHashCode();
			}
			return num;
		}

		public override bool Equals(object obj)
		{
			WXMusicMessageP wXMusicMessageP = obj as WXMusicMessageP;
			return wXMusicMessageP != null && this.hasMusicUrl == wXMusicMessageP.hasMusicUrl && (!this.hasMusicUrl || this.musicUrl_.Equals(wXMusicMessageP.musicUrl_)) && this.hasMusicLowBandUrl == wXMusicMessageP.hasMusicLowBandUrl && (!this.hasMusicLowBandUrl || this.musicLowBandUrl_.Equals(wXMusicMessageP.musicLowBandUrl_));
		}

		public override void PrintTo(TextWriter writer)
		{
			GeneratedMessageLite<WXMusicMessageP, WXMusicMessageP.Builder>.PrintField("MusicUrl", this.hasMusicUrl, this.musicUrl_, writer);
			GeneratedMessageLite<WXMusicMessageP, WXMusicMessageP.Builder>.PrintField("MusicLowBandUrl", this.hasMusicLowBandUrl, this.musicLowBandUrl_, writer);
		}

		public static WXMusicMessageP ParseFrom(byte[] data)
		{
			return WXMusicMessageP.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		private WXMusicMessageP MakeReadOnly()
		{
			return this;
		}

		public static WXMusicMessageP.Builder CreateBuilder()
		{
			return new WXMusicMessageP.Builder();
		}

		public override WXMusicMessageP.Builder ToBuilder()
		{
			return WXMusicMessageP.CreateBuilder(this);
		}

		public override WXMusicMessageP.Builder CreateBuilderForType()
		{
			return new WXMusicMessageP.Builder();
		}

		public static WXMusicMessageP.Builder CreateBuilder(WXMusicMessageP prototype)
		{
			return new WXMusicMessageP.Builder(prototype);
		}

		static WXMusicMessageP()
		{
			WXMusicMessageP.defaultInstance = new WXMusicMessageP().MakeReadOnly();
			WXMusicMessageP._wXMusicMessagePFieldNames = new string[]
			{
				"MusicLowBandUrl",
				"MusicUrl"
			};
			WXMusicMessageP._wXMusicMessagePFieldTags = new uint[]
			{
				18u,
				10u
			};
			object.ReferenceEquals(MicroMsg.sdk.protobuf.Proto.WXMusicMessageP.Descriptor, null);
		}
	}
}
