using Google.ProtocolBuffers;
using MicroMsg.sdk.protobuf.Proto;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace MicroMsg.sdk.protobuf
{
	
	public sealed class ShowMessageFromWXResp : GeneratedMessageLite<ShowMessageFromWXResp, ShowMessageFromWXResp.Builder>
	{
		
		public sealed class Builder : GeneratedBuilderLite<ShowMessageFromWXResp, ShowMessageFromWXResp.Builder>
		{
			private bool resultIsReadOnly;

			private ShowMessageFromWXResp result;

			protected override ShowMessageFromWXResp.Builder ThisBuilder
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

			protected override ShowMessageFromWXResp MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			public override ShowMessageFromWXResp DefaultInstanceForType
			{
				get
				{
					return ShowMessageFromWXResp.DefaultInstance;
				}
			}

			public BaseRespP Base
			{
				get
				{
					return this.result.Base;
				}
				set
				{
					this.SetBase(value);
				}
			}

			public Builder()
			{
				this.result = ShowMessageFromWXResp.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			internal Builder(ShowMessageFromWXResp cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			private ShowMessageFromWXResp PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					ShowMessageFromWXResp other = this.result;
					this.result = new ShowMessageFromWXResp();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			public override ShowMessageFromWXResp.Builder Clear()
			{
				this.result = ShowMessageFromWXResp.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			public override ShowMessageFromWXResp.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new ShowMessageFromWXResp.Builder(this.result);
				}
				return new ShowMessageFromWXResp.Builder().MergeFrom(this.result);
			}

			public override ShowMessageFromWXResp BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			public override ShowMessageFromWXResp.Builder MergeFrom(IMessageLite other)
			{
				if (other is ShowMessageFromWXResp)
				{
					return this.MergeFrom((ShowMessageFromWXResp)other);
				}
				base.MergeFrom(other);
				return this;
			}

			public override ShowMessageFromWXResp.Builder MergeFrom(ShowMessageFromWXResp other)
			{
				return this;
			}

			public override ShowMessageFromWXResp.Builder MergeFrom(ICodedInputStream input)
			{
				return this.MergeFrom(input, ExtensionRegistry.Empty);
			}

			public override ShowMessageFromWXResp.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				uint num;
				string text;
				while (input.ReadTag(out num, out text))
				{
					if (num == 0u && text != null)
					{
						int num2 = Array.BinarySearch<string>(ShowMessageFromWXResp._showMessageFromWXRespFieldNames, text, StringComparer.Ordinal);
						if (num2 < 0)
						{
							this.ParseUnknownField(input, extensionRegistry, num, text);
							continue;
						}
						num = ShowMessageFromWXResp._showMessageFromWXRespFieldTags[num2];
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
						BaseRespP.Builder builder = BaseRespP.CreateBuilder();
						if (this.result.hasBase)
						{
							builder.MergeFrom(this.Base);
						}
						input.ReadMessage(builder, extensionRegistry);
						this.Base = builder.BuildPartial();
					}
				}
				return this;
			}

			public ShowMessageFromWXResp.Builder SetBase(BaseRespP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasBase = true;
				this.result.base_ = value;
				return this;
			}

			public ShowMessageFromWXResp.Builder SetBase(BaseRespP.Builder builderForValue)
			{
				ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasBase = true;
				this.result.base_ = builderForValue.Build();
				return this;
			}

			public ShowMessageFromWXResp.Builder MergeBase(BaseRespP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasBase && this.result.base_ != BaseRespP.DefaultInstance)
				{
					this.result.base_ = BaseRespP.CreateBuilder(this.result.base_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.base_ = value;
				}
				this.result.hasBase = true;
				return this;
			}

			public ShowMessageFromWXResp.Builder ClearBase()
			{
				this.PrepareBuilder();
				this.result.hasBase = false;
				this.result.base_ = null;
				return this;
			}
		}

		public const int BaseFieldNumber = 1;

		private static readonly ShowMessageFromWXResp defaultInstance;

		private static readonly string[] _showMessageFromWXRespFieldNames;

		private static readonly uint[] _showMessageFromWXRespFieldTags;

		private bool hasBase;

		private BaseRespP base_;

		private int memoizedSerializedSize = -1;

		public static ShowMessageFromWXResp DefaultInstance
		{
			get
			{
				return ShowMessageFromWXResp.defaultInstance;
			}
		}

		public override ShowMessageFromWXResp DefaultInstanceForType
		{
			get
			{
				return ShowMessageFromWXResp.DefaultInstance;
			}
		}

		protected override ShowMessageFromWXResp ThisMessage
		{
			get
			{
				return this;
			}
		}

		public BaseRespP Base
		{
			get
			{
				return this.base_ ?? BaseRespP.DefaultInstance;
			}
		}

		public override bool IsInitialized
		{
			get
			{
				return this.hasBase && this.Base.IsInitialized;
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
				if (this.hasBase)
				{
					num += CodedOutputStream.ComputeMessageSize(1, this.Base);
				}
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		private ShowMessageFromWXResp()
		{
		}

		public override void WriteTo(ICodedOutputStream output)
		{
			int arg_06_0 = this.SerializedSize;
			string[] showMessageFromWXRespFieldNames = ShowMessageFromWXResp._showMessageFromWXRespFieldNames;
			if (this.hasBase)
			{
				output.WriteMessage(1, showMessageFromWXRespFieldNames[0], this.Base);
			}
		}

		public override int GetHashCode()
		{
			int num = base.GetType().GetHashCode();
			if (this.hasBase)
			{
				num ^= this.base_.GetHashCode();
			}
			return num;
		}

		public override bool Equals(object obj)
		{
			ShowMessageFromWXResp showMessageFromWXResp = obj as ShowMessageFromWXResp;
			return showMessageFromWXResp != null && this.hasBase == showMessageFromWXResp.hasBase && (!this.hasBase || this.base_.Equals(showMessageFromWXResp.base_));
		}

		public override void PrintTo(TextWriter writer)
		{
			GeneratedMessageLite<ShowMessageFromWXResp, ShowMessageFromWXResp.Builder>.PrintField("Base", this.hasBase, this.base_, writer);
		}

		public static ShowMessageFromWXResp ParseFrom(byte[] data)
		{
			return ShowMessageFromWXResp.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		private ShowMessageFromWXResp MakeReadOnly()
		{
			return this;
		}

		public static ShowMessageFromWXResp.Builder CreateBuilder()
		{
			return new ShowMessageFromWXResp.Builder();
		}

		public override ShowMessageFromWXResp.Builder ToBuilder()
		{
			return ShowMessageFromWXResp.CreateBuilder(this);
		}

		public override ShowMessageFromWXResp.Builder CreateBuilderForType()
		{
			return new ShowMessageFromWXResp.Builder();
		}

		public static ShowMessageFromWXResp.Builder CreateBuilder(ShowMessageFromWXResp prototype)
		{
			return new ShowMessageFromWXResp.Builder(prototype);
		}

		static ShowMessageFromWXResp()
		{
			ShowMessageFromWXResp.defaultInstance = new ShowMessageFromWXResp().MakeReadOnly();
			ShowMessageFromWXResp._showMessageFromWXRespFieldNames = new string[]
			{
				"Base"
			};
			ShowMessageFromWXResp._showMessageFromWXRespFieldTags = new uint[]
			{
				10u
			};
			object.ReferenceEquals(MicroMsg.sdk.protobuf.Proto.ShowMessageFromWXResp.Descriptor, null);
		}
	}
}
