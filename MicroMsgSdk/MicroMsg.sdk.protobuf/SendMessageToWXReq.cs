using Google.ProtocolBuffers;
using MicroMsg.sdk.protobuf.Proto;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace MicroMsg.sdk.protobuf
{
	
	public sealed class SendMessageToWXReq : GeneratedMessageLite<SendMessageToWXReq, SendMessageToWXReq.Builder>
	{
		
		public sealed class Builder : GeneratedBuilderLite<SendMessageToWXReq, SendMessageToWXReq.Builder>
		{
			private bool resultIsReadOnly;

			private SendMessageToWXReq result;

			protected override SendMessageToWXReq.Builder ThisBuilder
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

			protected override SendMessageToWXReq MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			public override SendMessageToWXReq DefaultInstanceForType
			{
				get
				{
					return SendMessageToWXReq.DefaultInstance;
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

			public uint Scene
			{
				get
				{
					return this.result.Scene;
				}
				set
				{
					this.SetScene(value);
				}
			}

			public Builder()
			{
				this.result = SendMessageToWXReq.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			internal Builder(SendMessageToWXReq cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			private SendMessageToWXReq PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					SendMessageToWXReq other = this.result;
					this.result = new SendMessageToWXReq();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			public override SendMessageToWXReq.Builder Clear()
			{
				this.result = SendMessageToWXReq.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			public override SendMessageToWXReq.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new SendMessageToWXReq.Builder(this.result);
				}
				return new SendMessageToWXReq.Builder().MergeFrom(this.result);
			}

			public override SendMessageToWXReq BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			public override SendMessageToWXReq.Builder MergeFrom(IMessageLite other)
			{
				if (other is SendMessageToWXReq)
				{
					return this.MergeFrom((SendMessageToWXReq)other);
				}
				base.MergeFrom(other);
				return this;
			}

			public override SendMessageToWXReq.Builder MergeFrom(SendMessageToWXReq other)
			{
				return this;
			}

			public override SendMessageToWXReq.Builder MergeFrom(ICodedInputStream input)
			{
				return this.MergeFrom(input, ExtensionRegistry.Empty);
			}

			public override SendMessageToWXReq.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				uint num;
				string text;
				while (input.ReadTag(out num, out text))
				{
					if (num == 0u && text != null)
					{
						int num2 = Array.BinarySearch<string>(SendMessageToWXReq._sendMessageToWXReqFieldNames, text, StringComparer.Ordinal);
						if (num2 < 0)
						{
							this.ParseUnknownField(input, extensionRegistry, num, text);
							continue;
						}
						num = SendMessageToWXReq._sendMessageToWXReqFieldTags[num2];
					}
					uint num3 = num;
					if (num3 <= 10u)
					{
						if (num3 == 0u)
						{
							throw InvalidProtocolBufferException.InvalidTag();
						}
						if (num3 == 10u)
						{
							BaseReqP.Builder builder = BaseReqP.CreateBuilder();
							if (this.result.hasBase)
							{
								builder.MergeFrom(this.Base);
							}
							input.ReadMessage(builder, extensionRegistry);
							this.Base = builder.BuildPartial();
							continue;
						}
					}
					else
					{
						if (num3 == 18u)
						{
							WXMessageP.Builder builder2 = WXMessageP.CreateBuilder();
							if (this.result.hasMsg)
							{
								builder2.MergeFrom(this.Msg);
							}
							input.ReadMessage(builder2, extensionRegistry);
							this.Msg = builder2.BuildPartial();
							continue;
						}
						if (num3 == 24u)
						{
							this.result.hasScene = input.ReadUInt32(ref this.result.scene_);
							continue;
						}
					}
					if (WireFormat.IsEndGroupTag(num))
					{
						return this;
					}
					this.ParseUnknownField(input, extensionRegistry, num, text);
				}
				return this;
			}

			public SendMessageToWXReq.Builder SetBase(BaseReqP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasBase = true;
				this.result.base_ = value;
				return this;
			}

			public SendMessageToWXReq.Builder SetBase(BaseReqP.Builder builderForValue)
			{
				ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasBase = true;
				this.result.base_ = builderForValue.Build();
				return this;
			}

			public SendMessageToWXReq.Builder MergeBase(BaseReqP value)
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

			public SendMessageToWXReq.Builder ClearBase()
			{
				this.PrepareBuilder();
				this.result.hasBase = false;
				this.result.base_ = null;
				return this;
			}

			public SendMessageToWXReq.Builder SetMsg(WXMessageP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasMsg = true;
				this.result.msg_ = value;
				return this;
			}

			public SendMessageToWXReq.Builder SetMsg(WXMessageP.Builder builderForValue)
			{
				ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasMsg = true;
				this.result.msg_ = builderForValue.Build();
				return this;
			}

			public SendMessageToWXReq.Builder MergeMsg(WXMessageP value)
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

			public SendMessageToWXReq.Builder ClearMsg()
			{
				this.PrepareBuilder();
				this.result.hasMsg = false;
				this.result.msg_ = null;
				return this;
			}

			public SendMessageToWXReq.Builder SetScene(uint value)
			{
				this.PrepareBuilder();
				this.result.hasScene = true;
				this.result.scene_ = value;
				return this;
			}

			public SendMessageToWXReq.Builder ClearScene()
			{
				this.PrepareBuilder();
				this.result.hasScene = false;
				this.result.scene_ = 0u;
				return this;
			}
		}

		public const int BaseFieldNumber = 1;

		public const int MsgFieldNumber = 2;

		public const int SceneFieldNumber = 3;

		private static readonly SendMessageToWXReq defaultInstance;

		private static readonly string[] _sendMessageToWXReqFieldNames;

		private static readonly uint[] _sendMessageToWXReqFieldTags;

		private bool hasBase;

		private BaseReqP base_;

		private bool hasMsg;

		private WXMessageP msg_;

		private bool hasScene;

		private uint scene_;

		private int memoizedSerializedSize = -1;

		public static SendMessageToWXReq DefaultInstance
		{
			get
			{
				return SendMessageToWXReq.defaultInstance;
			}
		}

		public override SendMessageToWXReq DefaultInstanceForType
		{
			get
			{
				return SendMessageToWXReq.DefaultInstance;
			}
		}

		protected override SendMessageToWXReq ThisMessage
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

		public uint Scene
		{
			get
			{
				return this.scene_;
			}
		}

		public override bool IsInitialized
		{
			get
			{
				return this.hasBase && this.hasMsg && this.hasScene && this.Base.IsInitialized && this.Msg.IsInitialized;
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
				if (this.hasScene)
				{
					num += CodedOutputStream.ComputeUInt32Size(3, this.Scene);
				}
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		private SendMessageToWXReq()
		{
		}

		public override void WriteTo(ICodedOutputStream output)
		{
			int arg_06_0 = this.SerializedSize;
			string[] sendMessageToWXReqFieldNames = SendMessageToWXReq._sendMessageToWXReqFieldNames;
			if (this.hasBase)
			{
				output.WriteMessage(1, sendMessageToWXReqFieldNames[0], this.Base);
			}
			if (this.hasMsg)
			{
				output.WriteMessage(2, sendMessageToWXReqFieldNames[1], this.Msg);
			}
			if (this.hasScene)
			{
				output.WriteUInt32(3, sendMessageToWXReqFieldNames[2], this.Scene);
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
			if (this.hasScene)
			{
				num ^= this.scene_.GetHashCode();
			}
			return num;
		}

		public override bool Equals(object obj)
		{
			SendMessageToWXReq sendMessageToWXReq = obj as SendMessageToWXReq;
			return sendMessageToWXReq != null && this.hasBase == sendMessageToWXReq.hasBase && (!this.hasBase || this.base_.Equals(sendMessageToWXReq.base_)) && this.hasMsg == sendMessageToWXReq.hasMsg && (!this.hasMsg || this.msg_.Equals(sendMessageToWXReq.msg_)) && this.hasScene == sendMessageToWXReq.hasScene && (!this.hasScene || this.scene_.Equals(sendMessageToWXReq.scene_));
		}

		public override void PrintTo(TextWriter writer)
		{
			GeneratedMessageLite<SendMessageToWXReq, SendMessageToWXReq.Builder>.PrintField("Base", this.hasBase, this.base_, writer);
			GeneratedMessageLite<SendMessageToWXReq, SendMessageToWXReq.Builder>.PrintField("Msg", this.hasMsg, this.msg_, writer);
			GeneratedMessageLite<SendMessageToWXReq, SendMessageToWXReq.Builder>.PrintField("Scene", this.hasScene, this.scene_, writer);
		}

		public static SendMessageToWXReq ParseFrom(byte[] data)
		{
			return SendMessageToWXReq.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		private SendMessageToWXReq MakeReadOnly()
		{
			return this;
		}

		public static SendMessageToWXReq.Builder CreateBuilder()
		{
			return new SendMessageToWXReq.Builder();
		}

		public override SendMessageToWXReq.Builder ToBuilder()
		{
			return SendMessageToWXReq.CreateBuilder(this);
		}

		public override SendMessageToWXReq.Builder CreateBuilderForType()
		{
			return new SendMessageToWXReq.Builder();
		}

		public static SendMessageToWXReq.Builder CreateBuilder(SendMessageToWXReq prototype)
		{
			return new SendMessageToWXReq.Builder(prototype);
		}

		static SendMessageToWXReq()
		{
			SendMessageToWXReq.defaultInstance = new SendMessageToWXReq().MakeReadOnly();
			SendMessageToWXReq._sendMessageToWXReqFieldNames = new string[]
			{
				"Base",
				"Msg",
				"Scene"
			};
			SendMessageToWXReq._sendMessageToWXReqFieldTags = new uint[]
			{
				10u,
				18u,
				24u
			};
			object.ReferenceEquals(MicroMsg.sdk.protobuf.Proto.SendMessageToWXReq.Descriptor, null);
		}
	}
}
