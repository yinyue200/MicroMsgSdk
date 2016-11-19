using Google.ProtocolBuffers;
using MicroMsg.sdk.protobuf.Proto;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace MicroMsg.sdk.protobuf
{
	
	public sealed class SendAuthResp : GeneratedMessageLite<SendAuthResp, SendAuthResp.Builder>
	{
		
		public sealed class Builder : GeneratedBuilderLite<SendAuthResp, SendAuthResp.Builder>
		{
			private bool resultIsReadOnly;

			private SendAuthResp result;

			protected override SendAuthResp.Builder ThisBuilder
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

			protected override SendAuthResp MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			public override SendAuthResp DefaultInstanceForType
			{
				get
				{
					return SendAuthResp.DefaultInstance;
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

			public string Code
			{
				get
				{
					return this.result.Code;
				}
				set
				{
					this.SetCode(value);
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

			public string Url
			{
				get
				{
					return this.result.Url;
				}
				set
				{
					this.SetUrl(value);
				}
			}

			public Builder()
			{
				this.result = SendAuthResp.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			internal Builder(SendAuthResp cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			private SendAuthResp PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					SendAuthResp other = this.result;
					this.result = new SendAuthResp();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			public override SendAuthResp.Builder Clear()
			{
				this.result = SendAuthResp.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			public override SendAuthResp.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new SendAuthResp.Builder(this.result);
				}
				return new SendAuthResp.Builder().MergeFrom(this.result);
			}

			public override SendAuthResp BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			public override SendAuthResp.Builder MergeFrom(IMessageLite other)
			{
				if (other is SendAuthResp)
				{
					return this.MergeFrom((SendAuthResp)other);
				}
				base.MergeFrom(other);
				return this;
			}

			public override SendAuthResp.Builder MergeFrom(SendAuthResp other)
			{
				return this;
			}

			public override SendAuthResp.Builder MergeFrom(ICodedInputStream input)
			{
				return this.MergeFrom(input, ExtensionRegistry.Empty);
			}

			public override SendAuthResp.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				uint num;
				string text;
				while (input.ReadTag(out num, out text))
				{
					if (num == 0u && text != null)
					{
						int num2 = Array.BinarySearch<string>(SendAuthResp._sendAuthRespFieldNames, text, StringComparer.Ordinal);
						if (num2 < 0)
						{
							this.ParseUnknownField(input, extensionRegistry, num, text);
							continue;
						}
						num = SendAuthResp._sendAuthRespFieldTags[num2];
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
							BaseRespP.Builder builder = BaseRespP.CreateBuilder();
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
							this.result.hasCode = input.ReadString(ref this.result.code_);
							continue;
						}
						if (num3 == 26u)
						{
							this.result.hasState = input.ReadString(ref this.result.state_);
							continue;
						}
						if (num3 == 34u)
						{
							this.result.hasUrl = input.ReadString(ref this.result.url_);
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

			public SendAuthResp.Builder SetBase(BaseRespP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasBase = true;
				this.result.base_ = value;
				return this;
			}

			public SendAuthResp.Builder SetBase(BaseRespP.Builder builderForValue)
			{
				ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasBase = true;
				this.result.base_ = builderForValue.Build();
				return this;
			}

			public SendAuthResp.Builder MergeBase(BaseRespP value)
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

			public SendAuthResp.Builder ClearBase()
			{
				this.PrepareBuilder();
				this.result.hasBase = false;
				this.result.base_ = null;
				return this;
			}

			public SendAuthResp.Builder SetCode(string value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasCode = true;
				this.result.code_ = value;
				return this;
			}

			public SendAuthResp.Builder ClearCode()
			{
				this.PrepareBuilder();
				this.result.hasCode = false;
				this.result.code_ = "";
				return this;
			}

			public SendAuthResp.Builder SetState(string value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasState = true;
				this.result.state_ = value;
				return this;
			}

			public SendAuthResp.Builder ClearState()
			{
				this.PrepareBuilder();
				this.result.hasState = false;
				this.result.state_ = "";
				return this;
			}

			public SendAuthResp.Builder SetUrl(string value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasUrl = true;
				this.result.url_ = value;
				return this;
			}

			public SendAuthResp.Builder ClearUrl()
			{
				this.PrepareBuilder();
				this.result.hasUrl = false;
				this.result.url_ = "";
				return this;
			}
		}

		public const int BaseFieldNumber = 1;

		public const int CodeFieldNumber = 2;

		public const int StateFieldNumber = 3;

		public const int UrlFieldNumber = 4;

		private static readonly SendAuthResp defaultInstance;

		private static readonly string[] _sendAuthRespFieldNames;

		private static readonly uint[] _sendAuthRespFieldTags;

		private bool hasBase;

		private BaseRespP base_;

		private bool hasCode;

		private string code_ = "";

		private bool hasState;

		private string state_ = "";

		private bool hasUrl;

		private string url_ = "";

		private int memoizedSerializedSize = -1;

		public static SendAuthResp DefaultInstance
		{
			get
			{
				return SendAuthResp.defaultInstance;
			}
		}

		public override SendAuthResp DefaultInstanceForType
		{
			get
			{
				return SendAuthResp.DefaultInstance;
			}
		}

		protected override SendAuthResp ThisMessage
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

		public string Code
		{
			get
			{
				return this.code_;
			}
		}

		public string State
		{
			get
			{
				return this.state_;
			}
		}

		public string Url
		{
			get
			{
				return this.url_;
			}
		}

		public override bool IsInitialized
		{
			get
			{
				return this.hasBase && this.hasCode && this.Base.IsInitialized;
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
				if (this.hasCode)
				{
					num += CodedOutputStream.ComputeStringSize(2, this.Code);
				}
				if (this.hasState)
				{
					num += CodedOutputStream.ComputeStringSize(3, this.State);
				}
				if (this.hasUrl)
				{
					num += CodedOutputStream.ComputeStringSize(4, this.Url);
				}
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		private SendAuthResp()
		{
		}

		public override void WriteTo(ICodedOutputStream output)
		{
			int arg_06_0 = this.SerializedSize;
			string[] sendAuthRespFieldNames = SendAuthResp._sendAuthRespFieldNames;
			if (this.hasBase)
			{
				output.WriteMessage(1, sendAuthRespFieldNames[0], this.Base);
			}
			if (this.hasCode)
			{
				output.WriteString(2, sendAuthRespFieldNames[1], this.Code);
			}
			if (this.hasState)
			{
				output.WriteString(3, sendAuthRespFieldNames[2], this.State);
			}
			if (this.hasUrl)
			{
				output.WriteString(4, sendAuthRespFieldNames[3], this.Url);
			}
		}

		public override int GetHashCode()
		{
			int num = base.GetType().GetHashCode();
			if (this.hasBase)
			{
				num ^= this.base_.GetHashCode();
			}
			if (this.hasCode)
			{
				num ^= this.code_.GetHashCode();
			}
			if (this.hasState)
			{
				num ^= this.state_.GetHashCode();
			}
			if (this.hasUrl)
			{
				num ^= this.url_.GetHashCode();
			}
			return num;
		}

		public override bool Equals(object obj)
		{
			SendAuthResp sendAuthResp = obj as SendAuthResp;
			return sendAuthResp != null && this.hasBase == sendAuthResp.hasBase && (!this.hasBase || this.base_.Equals(sendAuthResp.base_)) && this.hasCode == sendAuthResp.hasCode && (!this.hasCode || this.code_.Equals(sendAuthResp.code_)) && this.hasState == sendAuthResp.hasState && (!this.hasState || this.state_.Equals(sendAuthResp.state_)) && this.hasUrl == sendAuthResp.hasUrl && (!this.hasUrl || this.url_.Equals(sendAuthResp.url_));
		}

		public override void PrintTo(TextWriter writer)
		{
			GeneratedMessageLite<SendAuthResp, SendAuthResp.Builder>.PrintField("Base", this.hasBase, this.base_, writer);
			GeneratedMessageLite<SendAuthResp, SendAuthResp.Builder>.PrintField("Code", this.hasCode, this.code_, writer);
			GeneratedMessageLite<SendAuthResp, SendAuthResp.Builder>.PrintField("State", this.hasState, this.state_, writer);
			GeneratedMessageLite<SendAuthResp, SendAuthResp.Builder>.PrintField("Url", this.hasUrl, this.url_, writer);
		}

		public static SendAuthResp ParseFrom(byte[] data)
		{
			return SendAuthResp.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		private SendAuthResp MakeReadOnly()
		{
			return this;
		}

		public static SendAuthResp.Builder CreateBuilder()
		{
			return new SendAuthResp.Builder();
		}

		public override SendAuthResp.Builder ToBuilder()
		{
			return SendAuthResp.CreateBuilder(this);
		}

		public override SendAuthResp.Builder CreateBuilderForType()
		{
			return new SendAuthResp.Builder();
		}

		public static SendAuthResp.Builder CreateBuilder(SendAuthResp prototype)
		{
			return new SendAuthResp.Builder(prototype);
		}

		static SendAuthResp()
		{
			SendAuthResp.defaultInstance = new SendAuthResp().MakeReadOnly();
			SendAuthResp._sendAuthRespFieldNames = new string[]
			{
				"Base",
				"Code",
				"State",
				"Url"
			};
			SendAuthResp._sendAuthRespFieldTags = new uint[]
			{
				10u,
				18u,
				26u,
				34u
			};
			object.ReferenceEquals(MicroMsg.sdk.protobuf.Proto.SendAuthResp.Descriptor, null);
		}
	}
}
