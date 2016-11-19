using Google.ProtocolBuffers;
using MicroMsg.sdk.protobuf.Proto;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace MicroMsg.sdk.protobuf
{
	
	public sealed class SendAuthReq : GeneratedMessageLite<SendAuthReq, SendAuthReq.Builder>
	{
		
		public sealed class Builder : GeneratedBuilderLite<SendAuthReq, SendAuthReq.Builder>
		{
			private bool resultIsReadOnly;

			private SendAuthReq result;

			protected override SendAuthReq.Builder ThisBuilder
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

			protected override SendAuthReq MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			public override SendAuthReq DefaultInstanceForType
			{
				get
				{
					return SendAuthReq.DefaultInstance;
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

			public string Scope
			{
				get
				{
					return this.result.Scope;
				}
				set
				{
					this.SetScope(value);
				}
			}

			public string State
			{
				get
				{
					return this.result.State;
				}
				set
				{
					this.SetState(value);
				}
			}

			public Builder()
			{
				this.result = SendAuthReq.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			internal Builder(SendAuthReq cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			private SendAuthReq PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					SendAuthReq other = this.result;
					this.result = new SendAuthReq();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			public override SendAuthReq.Builder Clear()
			{
				this.result = SendAuthReq.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			public override SendAuthReq.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new SendAuthReq.Builder(this.result);
				}
				return new SendAuthReq.Builder().MergeFrom(this.result);
			}

			public override SendAuthReq BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			public override SendAuthReq.Builder MergeFrom(IMessageLite other)
			{
				if (other is SendAuthReq)
				{
					return this.MergeFrom((SendAuthReq)other);
				}
				base.MergeFrom(other);
				return this;
			}

			public override SendAuthReq.Builder MergeFrom(SendAuthReq other)
			{
				return this;
			}

			public override SendAuthReq.Builder MergeFrom(ICodedInputStream input)
			{
				return this.MergeFrom(input, ExtensionRegistry.Empty);
			}

			public override SendAuthReq.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				uint num;
				string text;
				while (input.ReadTag(out num, out text))
				{
					if (num == 0u && text != null)
					{
						int num2 = Array.BinarySearch<string>(SendAuthReq._sendAuthReqFieldNames, text, StringComparer.Ordinal);
						if (num2 < 0)
						{
							this.ParseUnknownField(input, extensionRegistry, num, text);
							continue;
						}
						num = SendAuthReq._sendAuthReqFieldTags[num2];
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
							this.result.hasScope = input.ReadString(ref this.result.scope_);
							continue;
						}
						if (num3 == 26u)
						{
							this.result.hasState = input.ReadString(ref this.result.state_);
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

			public SendAuthReq.Builder SetBase(BaseReqP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasBase = true;
				this.result.base_ = value;
				return this;
			}

			public SendAuthReq.Builder SetBase(BaseReqP.Builder builderForValue)
			{
				ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasBase = true;
				this.result.base_ = builderForValue.Build();
				return this;
			}

			public SendAuthReq.Builder MergeBase(BaseReqP value)
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

			public SendAuthReq.Builder ClearBase()
			{
				this.PrepareBuilder();
				this.result.hasBase = false;
				this.result.base_ = null;
				return this;
			}

			public SendAuthReq.Builder SetScope(string value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasScope = true;
				this.result.scope_ = value;
				return this;
			}

			public SendAuthReq.Builder ClearScope()
			{
				this.PrepareBuilder();
				this.result.hasScope = false;
				this.result.scope_ = "";
				return this;
			}

			public SendAuthReq.Builder SetState(string value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasState = true;
				this.result.state_ = value;
				return this;
			}

			public SendAuthReq.Builder ClearState()
			{
				this.PrepareBuilder();
				this.result.hasState = false;
				this.result.state_ = "";
				return this;
			}
		}

		public const int BaseFieldNumber = 1;

		public const int ScopeFieldNumber = 2;

		public const int StateFieldNumber = 3;

		private static readonly SendAuthReq defaultInstance;

		private static readonly string[] _sendAuthReqFieldNames;

		private static readonly uint[] _sendAuthReqFieldTags;

		private bool hasBase;

		private BaseReqP base_;

		private bool hasScope;

		private string scope_ = "";

		private bool hasState;

		private string state_ = "";

		private int memoizedSerializedSize = -1;

		public static SendAuthReq DefaultInstance
		{
			get
			{
				return SendAuthReq.defaultInstance;
			}
		}

		public override SendAuthReq DefaultInstanceForType
		{
			get
			{
				return SendAuthReq.DefaultInstance;
			}
		}

		protected override SendAuthReq ThisMessage
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

		public string Scope
		{
			get
			{
				return this.scope_;
			}
		}

		public string State
		{
			get
			{
				return this.state_;
			}
		}

		public override bool IsInitialized
		{
			get
			{
				return this.hasBase && this.hasScope && this.hasState && this.Base.IsInitialized;
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
				if (this.hasScope)
				{
					num += CodedOutputStream.ComputeStringSize(2, this.Scope);
				}
				if (this.hasState)
				{
					num += CodedOutputStream.ComputeStringSize(3, this.State);
				}
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		private SendAuthReq()
		{
		}

		public override void WriteTo(ICodedOutputStream output)
		{
			int arg_06_0 = this.SerializedSize;
			string[] sendAuthReqFieldNames = SendAuthReq._sendAuthReqFieldNames;
			if (this.hasBase)
			{
				output.WriteMessage(1, sendAuthReqFieldNames[0], this.Base);
			}
			if (this.hasScope)
			{
				output.WriteString(2, sendAuthReqFieldNames[1], this.Scope);
			}
			if (this.hasState)
			{
				output.WriteString(3, sendAuthReqFieldNames[2], this.State);
			}
		}

		public override int GetHashCode()
		{
			int num = base.GetType().GetHashCode();
			if (this.hasBase)
			{
				num ^= this.base_.GetHashCode();
			}
			if (this.hasScope)
			{
				num ^= this.scope_.GetHashCode();
			}
			if (this.hasState)
			{
				num ^= this.state_.GetHashCode();
			}
			return num;
		}

		public override bool Equals(object obj)
		{
			SendAuthReq sendAuthReq = obj as SendAuthReq;
			return sendAuthReq != null && this.hasBase == sendAuthReq.hasBase && (!this.hasBase || this.base_.Equals(sendAuthReq.base_)) && this.hasScope == sendAuthReq.hasScope && (!this.hasScope || this.scope_.Equals(sendAuthReq.scope_)) && this.hasState == sendAuthReq.hasState && (!this.hasState || this.state_.Equals(sendAuthReq.state_));
		}

		public override void PrintTo(TextWriter writer)
		{
			GeneratedMessageLite<SendAuthReq, SendAuthReq.Builder>.PrintField("Base", this.hasBase, this.base_, writer);
			GeneratedMessageLite<SendAuthReq, SendAuthReq.Builder>.PrintField("Scope", this.hasScope, this.scope_, writer);
			GeneratedMessageLite<SendAuthReq, SendAuthReq.Builder>.PrintField("State", this.hasState, this.state_, writer);
		}

		public static SendAuthReq ParseFrom(byte[] data)
		{
			return SendAuthReq.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		private SendAuthReq MakeReadOnly()
		{
			return this;
		}

		public static SendAuthReq.Builder CreateBuilder()
		{
			return new SendAuthReq.Builder();
		}

		public override SendAuthReq.Builder ToBuilder()
		{
			return SendAuthReq.CreateBuilder(this);
		}

		public override SendAuthReq.Builder CreateBuilderForType()
		{
			return new SendAuthReq.Builder();
		}

		public static SendAuthReq.Builder CreateBuilder(SendAuthReq prototype)
		{
			return new SendAuthReq.Builder(prototype);
		}

		static SendAuthReq()
		{
			SendAuthReq.defaultInstance = new SendAuthReq().MakeReadOnly();
			SendAuthReq._sendAuthReqFieldNames = new string[]
			{
				"Base",
				"Scope",
				"State"
			};
			SendAuthReq._sendAuthReqFieldTags = new uint[]
			{
				10u,
				18u,
				26u
			};
			object.ReferenceEquals(MicroMsg.sdk.protobuf.Proto.SendAuthReq.Descriptor, null);
		}
	}
}
