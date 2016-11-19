using Google.ProtocolBuffers;
using MicroMsg.sdk.protobuf.Proto;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace MicroMsg.sdk.protobuf
{
	
	public sealed class WXWebpageMessageP : GeneratedMessageLite<WXWebpageMessageP, WXWebpageMessageP.Builder>
	{
		
		public sealed class Builder : GeneratedBuilderLite<WXWebpageMessageP, WXWebpageMessageP.Builder>
		{
			private bool resultIsReadOnly;

			private WXWebpageMessageP result;

			protected override WXWebpageMessageP.Builder ThisBuilder
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

			protected override WXWebpageMessageP MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			public override WXWebpageMessageP DefaultInstanceForType
			{
				get
				{
					return WXWebpageMessageP.DefaultInstance;
				}
			}

			public string WebpageUrl
			{
				get
				{
					return this.result.WebpageUrl;
				}
				set
				{
					this.SetWebpageUrl(value);
				}
			}

			public Builder()
			{
				this.result = WXWebpageMessageP.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			internal Builder(WXWebpageMessageP cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			private WXWebpageMessageP PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					WXWebpageMessageP other = this.result;
					this.result = new WXWebpageMessageP();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			public override WXWebpageMessageP.Builder Clear()
			{
				this.result = WXWebpageMessageP.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			public override WXWebpageMessageP.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new WXWebpageMessageP.Builder(this.result);
				}
				return new WXWebpageMessageP.Builder().MergeFrom(this.result);
			}

			public override WXWebpageMessageP BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			public override WXWebpageMessageP.Builder MergeFrom(IMessageLite other)
			{
				if (other is WXWebpageMessageP)
				{
					return this.MergeFrom((WXWebpageMessageP)other);
				}
				base.MergeFrom(other);
				return this;
			}

			public override WXWebpageMessageP.Builder MergeFrom(WXWebpageMessageP other)
			{
				return this;
			}

			public override WXWebpageMessageP.Builder MergeFrom(ICodedInputStream input)
			{
				return this.MergeFrom(input, ExtensionRegistry.Empty);
			}

			public override WXWebpageMessageP.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				uint num;
				string text;
				while (input.ReadTag(out num, out text))
				{
					if (num == 0u && text != null)
					{
						int num2 = Array.BinarySearch<string>(WXWebpageMessageP._wXWebpageMessagePFieldNames, text, StringComparer.Ordinal);
						if (num2 < 0)
						{
							this.ParseUnknownField(input, extensionRegistry, num, text);
							continue;
						}
						num = WXWebpageMessageP._wXWebpageMessagePFieldTags[num2];
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
						this.result.hasWebpageUrl = input.ReadString(ref this.result.webpageUrl_);
					}
				}
				return this;
			}

			public WXWebpageMessageP.Builder SetWebpageUrl(string value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasWebpageUrl = true;
				this.result.webpageUrl_ = value;
				return this;
			}

			public WXWebpageMessageP.Builder ClearWebpageUrl()
			{
				this.PrepareBuilder();
				this.result.hasWebpageUrl = false;
				this.result.webpageUrl_ = "";
				return this;
			}
		}

		public const int WebpageUrlFieldNumber = 1;

		private static readonly WXWebpageMessageP defaultInstance;

		private static readonly string[] _wXWebpageMessagePFieldNames;

		private static readonly uint[] _wXWebpageMessagePFieldTags;

		private bool hasWebpageUrl;

		private string webpageUrl_ = "";

		private int memoizedSerializedSize = -1;

		public static WXWebpageMessageP DefaultInstance
		{
			get
			{
				return WXWebpageMessageP.defaultInstance;
			}
		}

		public override WXWebpageMessageP DefaultInstanceForType
		{
			get
			{
				return WXWebpageMessageP.DefaultInstance;
			}
		}

		protected override WXWebpageMessageP ThisMessage
		{
			get
			{
				return this;
			}
		}

		public string WebpageUrl
		{
			get
			{
				return this.webpageUrl_;
			}
		}

		public override bool IsInitialized
		{
			get
			{
				return this.hasWebpageUrl;
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
				if (this.hasWebpageUrl)
				{
					num += CodedOutputStream.ComputeStringSize(1, this.WebpageUrl);
				}
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		private WXWebpageMessageP()
		{
		}

		public override void WriteTo(ICodedOutputStream output)
		{
			int arg_06_0 = this.SerializedSize;
			string[] wXWebpageMessagePFieldNames = WXWebpageMessageP._wXWebpageMessagePFieldNames;
			if (this.hasWebpageUrl)
			{
				output.WriteString(1, wXWebpageMessagePFieldNames[0], this.WebpageUrl);
			}
		}

		public override int GetHashCode()
		{
			int num = base.GetType().GetHashCode();
			if (this.hasWebpageUrl)
			{
				num ^= this.webpageUrl_.GetHashCode();
			}
			return num;
		}

		public override bool Equals(object obj)
		{
			WXWebpageMessageP wXWebpageMessageP = obj as WXWebpageMessageP;
			return wXWebpageMessageP != null && this.hasWebpageUrl == wXWebpageMessageP.hasWebpageUrl && (!this.hasWebpageUrl || this.webpageUrl_.Equals(wXWebpageMessageP.webpageUrl_));
		}

		public override void PrintTo(TextWriter writer)
		{
			GeneratedMessageLite<WXWebpageMessageP, WXWebpageMessageP.Builder>.PrintField("WebpageUrl", this.hasWebpageUrl, this.webpageUrl_, writer);
		}

		public static WXWebpageMessageP ParseFrom(byte[] data)
		{
			return WXWebpageMessageP.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		private WXWebpageMessageP MakeReadOnly()
		{
			return this;
		}

		public static WXWebpageMessageP.Builder CreateBuilder()
		{
			return new WXWebpageMessageP.Builder();
		}

		public override WXWebpageMessageP.Builder ToBuilder()
		{
			return WXWebpageMessageP.CreateBuilder(this);
		}

		public override WXWebpageMessageP.Builder CreateBuilderForType()
		{
			return new WXWebpageMessageP.Builder();
		}

		public static WXWebpageMessageP.Builder CreateBuilder(WXWebpageMessageP prototype)
		{
			return new WXWebpageMessageP.Builder(prototype);
		}

		static WXWebpageMessageP()
		{
			WXWebpageMessageP.defaultInstance = new WXWebpageMessageP().MakeReadOnly();
			WXWebpageMessageP._wXWebpageMessagePFieldNames = new string[]
			{
				"WebpageUrl"
			};
			WXWebpageMessageP._wXWebpageMessagePFieldTags = new uint[]
			{
				10u
			};
			object.ReferenceEquals(MicroMsg.sdk.protobuf.Proto.WXWebpageMessageP.Descriptor, null);
		}
	}
}
