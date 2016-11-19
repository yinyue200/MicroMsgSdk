using Google.ProtocolBuffers;
using MicroMsg.sdk.protobuf.Proto;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace MicroMsg.sdk.protobuf
{
	
	public sealed class ShowMessageFromWXReq : GeneratedMessageLite<ShowMessageFromWXReq, ShowMessageFromWXReq.Builder>
	{
		
		public sealed class Builder : GeneratedBuilderLite<ShowMessageFromWXReq, ShowMessageFromWXReq.Builder>
		{
			private bool resultIsReadOnly;

			private ShowMessageFromWXReq result;

			protected override ShowMessageFromWXReq.Builder ThisBuilder
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

			protected override ShowMessageFromWXReq MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			public override ShowMessageFromWXReq DefaultInstanceForType
			{
				get
				{
					return ShowMessageFromWXReq.DefaultInstance;
				}
			}

			public BaseReqP Base
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

			public WXMessageP Msg
			{
				get
				{
					return this.result.Msg;
				}
				set
				{
					this.SetMsg(value);
				}
			}

			public Builder()
			{
				this.result = ShowMessageFromWXReq.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			internal Builder(ShowMessageFromWXReq cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			private ShowMessageFromWXReq PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					ShowMessageFromWXReq other = this.result;
					this.result = new ShowMessageFromWXReq();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			public override ShowMessageFromWXReq.Builder Clear()
			{
				this.result = ShowMessageFromWXReq.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			public override ShowMessageFromWXReq.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new ShowMessageFromWXReq.Builder(this.result);
				}
				return new ShowMessageFromWXReq.Builder().MergeFrom(this.result);
			}

			public override ShowMessageFromWXReq BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			public override ShowMessageFromWXReq.Builder MergeFrom(IMessageLite other)
			{
				if (other is ShowMessageFromWXReq)
				{
					return this.MergeFrom((ShowMessageFromWXReq)other);
				}
				base.MergeFrom(other);
				return this;
			}

			public override ShowMessageFromWXReq.Builder MergeFrom(ShowMessageFromWXReq other)
			{
				return this;
			}

			public override ShowMessageFromWXReq.Builder MergeFrom(ICodedInputStream input)
			{
				return this.MergeFrom(input, ExtensionRegistry.Empty);
			}

			public override ShowMessageFromWXReq.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				uint num;
				string text;
				while (input.ReadTag(out num, out text))
				{
					if (num == 0u && text != null)
					{
						int num2 = Array.BinarySearch<string>(ShowMessageFromWXReq._showMessageFromWXReqFieldNames, text, StringComparer.Ordinal);
						if (num2 < 0)
						{
							this.ParseUnknownField(input, extensionRegistry, num, text);
							continue;
						}
						num = ShowMessageFromWXReq._showMessageFromWXReqFieldTags[num2];
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
							WXMessageP.Builder builder = WXMessageP.CreateBuilder();
							if (this.result.hasMsg)
							{
								builder.MergeFrom(this.Msg);
							}
							input.ReadMessage(builder, extensionRegistry);
							this.Msg = builder.BuildPartial();
						}
					}
					else
					{
						BaseReqP.Builder builder2 = BaseReqP.CreateBuilder();
						if (this.result.hasBase)
						{
							builder2.MergeFrom(this.Base);
						}
						input.ReadMessage(builder2, extensionRegistry);
						this.Base = builder2.BuildPartial();
					}
				}
				return this;
			}

			public ShowMessageFromWXReq.Builder SetBase(BaseReqP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasBase = true;
				this.result.base_ = value;
				return this;
			}

			public ShowMessageFromWXReq.Builder SetBase(BaseReqP.Builder builderForValue)
			{
				ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasBase = true;
				this.result.base_ = builderForValue.Build();
				return this;
			}

			public ShowMessageFromWXReq.Builder MergeBase(BaseReqP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasBase && this.result.base_ != BaseReqP.DefaultInstance)
				{
					this.result.base_ = BaseReqP.CreateBuilder(this.result.base_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.base_ = value;
				}
				this.result.hasBase = true;
				return this;
			}

			public ShowMessageFromWXReq.Builder ClearBase()
			{
				this.PrepareBuilder();
				this.result.hasBase = false;
				this.result.base_ = null;
				return this;
			}

			public ShowMessageFromWXReq.Builder SetMsg(WXMessageP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasMsg = true;
				this.result.msg_ = value;
				return this;
			}

			public ShowMessageFromWXReq.Builder SetMsg(WXMessageP.Builder builderForValue)
			{
				ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasMsg = true;
				this.result.msg_ = builderForValue.Build();
				return this;
			}

			public ShowMessageFromWXReq.Builder MergeMsg(WXMessageP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				if (this.result.hasMsg && this.result.msg_ != WXMessageP.DefaultInstance)
				{
					this.result.msg_ = WXMessageP.CreateBuilder(this.result.msg_).MergeFrom(value).BuildPartial();
				}
				else
				{
					this.result.msg_ = value;
				}
				this.result.hasMsg = true;
				return this;
			}

			public ShowMessageFromWXReq.Builder ClearMsg()
			{
				this.PrepareBuilder();
				this.result.hasMsg = false;
				this.result.msg_ = null;
				return this;
			}
		}

		public const int BaseFieldNumber = 1;

		public const int MsgFieldNumber = 2;

		private static readonly ShowMessageFromWXReq defaultInstance;

		private static readonly string[] _showMessageFromWXReqFieldNames;

		private static readonly uint[] _showMessageFromWXReqFieldTags;

		private bool hasBase;

		private BaseReqP base_;

		private bool hasMsg;

		private WXMessageP msg_;

		private int memoizedSerializedSize = -1;

		public static ShowMessageFromWXReq DefaultInstance
		{
			get
			{
				return ShowMessageFromWXReq.defaultInstance;
			}
		}

		public override ShowMessageFromWXReq DefaultInstanceForType
		{
			get
			{
				return ShowMessageFromWXReq.DefaultInstance;
			}
		}

		protected override ShowMessageFromWXReq ThisMessage
		{
			get
			{
				return this;
			}
		}

		public BaseReqP Base
		{
			get
			{
				return this.base_ ?? BaseReqP.DefaultInstance;
			}
		}

		public WXMessageP Msg
		{
			get
			{
				return this.msg_ ?? WXMessageP.DefaultInstance;
			}
		}

		public override bool IsInitialized
		{
			get
			{
				return this.hasBase && this.hasMsg && this.Base.IsInitialized && this.Msg.IsInitialized;
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
				if (this.hasMsg)
				{
					num += CodedOutputStream.ComputeMessageSize(2, this.Msg);
				}
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		private ShowMessageFromWXReq()
		{
		}

		public override void WriteTo(ICodedOutputStream output)
		{
			int arg_06_0 = this.SerializedSize;
			string[] showMessageFromWXReqFieldNames = ShowMessageFromWXReq._showMessageFromWXReqFieldNames;
			if (this.hasBase)
			{
				output.WriteMessage(1, showMessageFromWXReqFieldNames[0], this.Base);
			}
			if (this.hasMsg)
			{
				output.WriteMessage(2, showMessageFromWXReqFieldNames[1], this.Msg);
			}
		}

		public override int GetHashCode()
		{
			int num = base.GetType().GetHashCode();
			if (this.hasBase)
			{
				num ^= this.base_.GetHashCode();
			}
			if (this.hasMsg)
			{
				num ^= this.msg_.GetHashCode();
			}
			return num;
		}

		public override bool Equals(object obj)
		{
			ShowMessageFromWXReq showMessageFromWXReq = obj as ShowMessageFromWXReq;
			return showMessageFromWXReq != null && this.hasBase == showMessageFromWXReq.hasBase && (!this.hasBase || this.base_.Equals(showMessageFromWXReq.base_)) && this.hasMsg == showMessageFromWXReq.hasMsg && (!this.hasMsg || this.msg_.Equals(showMessageFromWXReq.msg_));
		}

		public override void PrintTo(TextWriter writer)
		{
			GeneratedMessageLite<ShowMessageFromWXReq, ShowMessageFromWXReq.Builder>.PrintField("Base", this.hasBase, this.base_, writer);
			GeneratedMessageLite<ShowMessageFromWXReq, ShowMessageFromWXReq.Builder>.PrintField("Msg", this.hasMsg, this.msg_, writer);
		}

		public static ShowMessageFromWXReq ParseFrom(byte[] data)
		{
			return ShowMessageFromWXReq.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		private ShowMessageFromWXReq MakeReadOnly()
		{
			return this;
		}

		public static ShowMessageFromWXReq.Builder CreateBuilder()
		{
			return new ShowMessageFromWXReq.Builder();
		}

		public override ShowMessageFromWXReq.Builder ToBuilder()
		{
			return ShowMessageFromWXReq.CreateBuilder(this);
		}

		public override ShowMessageFromWXReq.Builder CreateBuilderForType()
		{
			return new ShowMessageFromWXReq.Builder();
		}

		public static ShowMessageFromWXReq.Builder CreateBuilder(ShowMessageFromWXReq prototype)
		{
			return new ShowMessageFromWXReq.Builder(prototype);
		}

		static ShowMessageFromWXReq()
		{
			ShowMessageFromWXReq.defaultInstance = new ShowMessageFromWXReq().MakeReadOnly();
			ShowMessageFromWXReq._showMessageFromWXReqFieldNames = new string[]
			{
				"Base",
				"Msg"
			};
			ShowMessageFromWXReq._showMessageFromWXReqFieldTags = new uint[]
			{
				10u,
				18u
			};
			object.ReferenceEquals(MicroMsg.sdk.protobuf.Proto.ShowMessageFromWXReq.Descriptor, null);
		}
	}
}
