using Google.ProtocolBuffers;
using MicroMsg.sdk.protobuf.Proto;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace MicroMsg.sdk.protobuf
{
	
	public sealed class GetMessageFromWXResp : GeneratedMessageLite<GetMessageFromWXResp, GetMessageFromWXResp.Builder>
	{
		
		public sealed class Builder : GeneratedBuilderLite<GetMessageFromWXResp, GetMessageFromWXResp.Builder>
		{
			private bool resultIsReadOnly;

			private GetMessageFromWXResp result;

			protected override GetMessageFromWXResp.Builder ThisBuilder
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

			protected override GetMessageFromWXResp MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			public override GetMessageFromWXResp DefaultInstanceForType
			{
				get
				{
					return GetMessageFromWXResp.DefaultInstance;
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

			public string Username
			{
				get
				{
					return this.result.Username;
				}
				set
				{
					this.SetUsername(value);
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
				this.result = GetMessageFromWXResp.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			internal Builder(GetMessageFromWXResp cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			private GetMessageFromWXResp PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					GetMessageFromWXResp other = this.result;
					this.result = new GetMessageFromWXResp();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			public override GetMessageFromWXResp.Builder Clear()
			{
				this.result = GetMessageFromWXResp.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			public override GetMessageFromWXResp.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new GetMessageFromWXResp.Builder(this.result);
				}
				return new GetMessageFromWXResp.Builder().MergeFrom(this.result);
			}

			public override GetMessageFromWXResp BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			public override GetMessageFromWXResp.Builder MergeFrom(IMessageLite other)
			{
				if (other is GetMessageFromWXResp)
				{
					return this.MergeFrom((GetMessageFromWXResp)other);
				}
				base.MergeFrom(other);
				return this;
			}

			public override GetMessageFromWXResp.Builder MergeFrom(GetMessageFromWXResp other)
			{
				return this;
			}

			public override GetMessageFromWXResp.Builder MergeFrom(ICodedInputStream input)
			{
				return this.MergeFrom(input, ExtensionRegistry.Empty);
			}

			public override GetMessageFromWXResp.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				uint num;
				string text;
				while (input.ReadTag(out num, out text))
				{
					if (num == 0u && text != null)
					{
						int num2 = Array.BinarySearch<string>(GetMessageFromWXResp._getMessageFromWXRespFieldNames, text, StringComparer.Ordinal);
						if (num2 < 0)
						{
							this.ParseUnknownField(input, extensionRegistry, num, text);
							continue;
						}
						num = GetMessageFromWXResp._getMessageFromWXRespFieldTags[num2];
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
							this.result.hasUsername = input.ReadString(ref this.result.username_);
							continue;
						}
						if (num3 == 26u)
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
					}
					if (WireFormat.IsEndGroupTag(num))
					{
						return this;
					}
					this.ParseUnknownField(input, extensionRegistry, num, text);
				}
				return this;
			}

			public GetMessageFromWXResp.Builder SetBase(BaseRespP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasBase = true;
				this.result.base_ = value;
				return this;
			}

			public GetMessageFromWXResp.Builder SetBase(BaseRespP.Builder builderForValue)
			{
				ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasBase = true;
				this.result.base_ = builderForValue.Build();
				return this;
			}

			public GetMessageFromWXResp.Builder MergeBase(BaseRespP value)
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

			public GetMessageFromWXResp.Builder ClearBase()
			{
				this.PrepareBuilder();
				this.result.hasBase = false;
				this.result.base_ = null;
				return this;
			}

			public GetMessageFromWXResp.Builder SetUsername(string value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasUsername = true;
				this.result.username_ = value;
				return this;
			}

			public GetMessageFromWXResp.Builder ClearUsername()
			{
				this.PrepareBuilder();
				this.result.hasUsername = false;
				this.result.username_ = "";
				return this;
			}

			public GetMessageFromWXResp.Builder SetMsg(WXMessageP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasMsg = true;
				this.result.msg_ = value;
				return this;
			}

			public GetMessageFromWXResp.Builder SetMsg(WXMessageP.Builder builderForValue)
			{
				ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasMsg = true;
				this.result.msg_ = builderForValue.Build();
				return this;
			}

			public GetMessageFromWXResp.Builder MergeMsg(WXMessageP value)
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

			public GetMessageFromWXResp.Builder ClearMsg()
			{
				this.PrepareBuilder();
				this.result.hasMsg = false;
				this.result.msg_ = null;
				return this;
			}
		}

		public const int BaseFieldNumber = 1;

		public const int UsernameFieldNumber = 2;

		public const int MsgFieldNumber = 3;

		private static readonly GetMessageFromWXResp defaultInstance;

		private static readonly string[] _getMessageFromWXRespFieldNames;

		private static readonly uint[] _getMessageFromWXRespFieldTags;

		private bool hasBase;

		private BaseRespP base_;

		private bool hasUsername;

		private string username_ = "";

		private bool hasMsg;

		private WXMessageP msg_;

		private int memoizedSerializedSize = -1;

		public static GetMessageFromWXResp DefaultInstance
		{
			get
			{
				return GetMessageFromWXResp.defaultInstance;
			}
		}

		public override GetMessageFromWXResp DefaultInstanceForType
		{
			get
			{
				return GetMessageFromWXResp.DefaultInstance;
			}
		}

		protected override GetMessageFromWXResp ThisMessage
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

		public string Username
		{
			get
			{
				return this.username_;
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
				if (this.hasUsername)
				{
					num += CodedOutputStream.ComputeStringSize(2, this.Username);
				}
				if (this.hasMsg)
				{
					num += CodedOutputStream.ComputeMessageSize(3, this.Msg);
				}
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		private GetMessageFromWXResp()
		{
		}

		public override void WriteTo(ICodedOutputStream output)
		{
			int arg_06_0 = this.SerializedSize;
			string[] getMessageFromWXRespFieldNames = GetMessageFromWXResp._getMessageFromWXRespFieldNames;
			if (this.hasBase)
			{
				output.WriteMessage(1, getMessageFromWXRespFieldNames[0], this.Base);
			}
			if (this.hasUsername)
			{
				output.WriteString(2, getMessageFromWXRespFieldNames[2], this.Username);
			}
			if (this.hasMsg)
			{
				output.WriteMessage(3, getMessageFromWXRespFieldNames[1], this.Msg);
			}
		}

		public override int GetHashCode()
		{
			int num = base.GetType().GetHashCode();
			if (this.hasBase)
			{
				num ^= this.base_.GetHashCode();
			}
			if (this.hasUsername)
			{
				num ^= this.username_.GetHashCode();
			}
			if (this.hasMsg)
			{
				num ^= this.msg_.GetHashCode();
			}
			return num;
		}

		public override bool Equals(object obj)
		{
			GetMessageFromWXResp getMessageFromWXResp = obj as GetMessageFromWXResp;
			return getMessageFromWXResp != null && this.hasBase == getMessageFromWXResp.hasBase && (!this.hasBase || this.base_.Equals(getMessageFromWXResp.base_)) && this.hasUsername == getMessageFromWXResp.hasUsername && (!this.hasUsername || this.username_.Equals(getMessageFromWXResp.username_)) && this.hasMsg == getMessageFromWXResp.hasMsg && (!this.hasMsg || this.msg_.Equals(getMessageFromWXResp.msg_));
		}

		public override void PrintTo(TextWriter writer)
		{
			GeneratedMessageLite<GetMessageFromWXResp, GetMessageFromWXResp.Builder>.PrintField("Base", this.hasBase, this.base_, writer);
			GeneratedMessageLite<GetMessageFromWXResp, GetMessageFromWXResp.Builder>.PrintField("Username", this.hasUsername, this.username_, writer);
			GeneratedMessageLite<GetMessageFromWXResp, GetMessageFromWXResp.Builder>.PrintField("Msg", this.hasMsg, this.msg_, writer);
		}

		public static GetMessageFromWXResp ParseFrom(byte[] data)
		{
			return GetMessageFromWXResp.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		private GetMessageFromWXResp MakeReadOnly()
		{
			return this;
		}

		public static GetMessageFromWXResp.Builder CreateBuilder()
		{
			return new GetMessageFromWXResp.Builder();
		}

		public override GetMessageFromWXResp.Builder ToBuilder()
		{
			return GetMessageFromWXResp.CreateBuilder(this);
		}

		public override GetMessageFromWXResp.Builder CreateBuilderForType()
		{
			return new GetMessageFromWXResp.Builder();
		}

		public static GetMessageFromWXResp.Builder CreateBuilder(GetMessageFromWXResp prototype)
		{
			return new GetMessageFromWXResp.Builder(prototype);
		}

		static GetMessageFromWXResp()
		{
			GetMessageFromWXResp.defaultInstance = new GetMessageFromWXResp().MakeReadOnly();
			GetMessageFromWXResp._getMessageFromWXRespFieldNames = new string[]
			{
				"Base",
				"Msg",
				"Username"
			};
			GetMessageFromWXResp._getMessageFromWXRespFieldTags = new uint[]
			{
				10u,
				26u,
				18u
			};
			object.ReferenceEquals(MicroMsg.sdk.protobuf.Proto.GetMessageFromWXResp.Descriptor, null);
		}
	}
}
