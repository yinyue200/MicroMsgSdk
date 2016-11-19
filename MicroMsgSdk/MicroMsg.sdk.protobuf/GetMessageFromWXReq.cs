using Google.ProtocolBuffers;
using MicroMsg.sdk.protobuf.Proto;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace MicroMsg.sdk.protobuf
{
	
	public sealed class GetMessageFromWXReq : GeneratedMessageLite<GetMessageFromWXReq, GetMessageFromWXReq.Builder>
	{
		
		public sealed class Builder : GeneratedBuilderLite<GetMessageFromWXReq, GetMessageFromWXReq.Builder>
		{
			private bool resultIsReadOnly;

			private GetMessageFromWXReq result;

			protected override GetMessageFromWXReq.Builder ThisBuilder
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

			protected override GetMessageFromWXReq MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			public override GetMessageFromWXReq DefaultInstanceForType
			{
				get
				{
					return GetMessageFromWXReq.DefaultInstance;
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

			public Builder()
			{
				this.result = GetMessageFromWXReq.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			internal Builder(GetMessageFromWXReq cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			private GetMessageFromWXReq PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					GetMessageFromWXReq other = this.result;
					this.result = new GetMessageFromWXReq();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			public override GetMessageFromWXReq.Builder Clear()
			{
				this.result = GetMessageFromWXReq.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			public override GetMessageFromWXReq.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new GetMessageFromWXReq.Builder(this.result);
				}
				return new GetMessageFromWXReq.Builder().MergeFrom(this.result);
			}

			public override GetMessageFromWXReq BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			public override GetMessageFromWXReq.Builder MergeFrom(IMessageLite other)
			{
				if (other is GetMessageFromWXReq)
				{
					return this.MergeFrom((GetMessageFromWXReq)other);
				}
				base.MergeFrom(other);
				return this;
			}

			public override GetMessageFromWXReq.Builder MergeFrom(GetMessageFromWXReq other)
			{
				return this;
			}

			public override GetMessageFromWXReq.Builder MergeFrom(ICodedInputStream input)
			{
				return this.MergeFrom(input, ExtensionRegistry.Empty);
			}

			public override GetMessageFromWXReq.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				uint num;
				string text;
				while (input.ReadTag(out num, out text))
				{
					if (num == 0u && text != null)
					{
						int num2 = Array.BinarySearch<string>(GetMessageFromWXReq._getMessageFromWXReqFieldNames, text, StringComparer.Ordinal);
						if (num2 < 0)
						{
							this.ParseUnknownField(input, extensionRegistry, num, text);
							continue;
						}
						num = GetMessageFromWXReq._getMessageFromWXReqFieldTags[num2];
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
							this.result.hasUsername = input.ReadString(ref this.result.username_);
						}
					}
					else
					{
						BaseReqP.Builder builder = BaseReqP.CreateBuilder();
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

			public GetMessageFromWXReq.Builder SetBase(BaseReqP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasBase = true;
				this.result.base_ = value;
				return this;
			}

			public GetMessageFromWXReq.Builder SetBase(BaseReqP.Builder builderForValue)
			{
				ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasBase = true;
				this.result.base_ = builderForValue.Build();
				return this;
			}

			public GetMessageFromWXReq.Builder MergeBase(BaseReqP value)
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

			public GetMessageFromWXReq.Builder ClearBase()
			{
				this.PrepareBuilder();
				this.result.hasBase = false;
				this.result.base_ = null;
				return this;
			}

			public GetMessageFromWXReq.Builder SetUsername(string value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasUsername = true;
				this.result.username_ = value;
				return this;
			}

			public GetMessageFromWXReq.Builder ClearUsername()
			{
				this.PrepareBuilder();
				this.result.hasUsername = false;
				this.result.username_ = "";
				return this;
			}
		}

		public const int BaseFieldNumber = 1;

		public const int UsernameFieldNumber = 2;

		private static readonly GetMessageFromWXReq defaultInstance;

		private static readonly string[] _getMessageFromWXReqFieldNames;

		private static readonly uint[] _getMessageFromWXReqFieldTags;

		private bool hasBase;

		private BaseReqP base_;

		private bool hasUsername;

		private string username_ = "";

		private int memoizedSerializedSize = -1;

		public static GetMessageFromWXReq DefaultInstance
		{
			get
			{
				return GetMessageFromWXReq.defaultInstance;
			}
		}

		public override GetMessageFromWXReq DefaultInstanceForType
		{
			get
			{
				return GetMessageFromWXReq.DefaultInstance;
			}
		}

		protected override GetMessageFromWXReq ThisMessage
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

		public string Username
		{
			get
			{
				return this.username_;
			}
		}

		public override bool IsInitialized
		{
			get
			{
				return this.hasBase && this.hasUsername && this.Base.IsInitialized;
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
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		private GetMessageFromWXReq()
		{
		}

		public override void WriteTo(ICodedOutputStream output)
		{
			int arg_06_0 = this.SerializedSize;
			string[] getMessageFromWXReqFieldNames = GetMessageFromWXReq._getMessageFromWXReqFieldNames;
			if (this.hasBase)
			{
				output.WriteMessage(1, getMessageFromWXReqFieldNames[0], this.Base);
			}
			if (this.hasUsername)
			{
				output.WriteString(2, getMessageFromWXReqFieldNames[1], this.Username);
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
			return num;
		}

		public override bool Equals(object obj)
		{
			GetMessageFromWXReq getMessageFromWXReq = obj as GetMessageFromWXReq;
			return getMessageFromWXReq != null && this.hasBase == getMessageFromWXReq.hasBase && (!this.hasBase || this.base_.Equals(getMessageFromWXReq.base_)) && this.hasUsername == getMessageFromWXReq.hasUsername && (!this.hasUsername || this.username_.Equals(getMessageFromWXReq.username_));
		}

		public override void PrintTo(TextWriter writer)
		{
			GeneratedMessageLite<GetMessageFromWXReq, GetMessageFromWXReq.Builder>.PrintField("Base", this.hasBase, this.base_, writer);
			GeneratedMessageLite<GetMessageFromWXReq, GetMessageFromWXReq.Builder>.PrintField("Username", this.hasUsername, this.username_, writer);
		}

		public static GetMessageFromWXReq ParseFrom(byte[] data)
		{
			return GetMessageFromWXReq.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		private GetMessageFromWXReq MakeReadOnly()
		{
			return this;
		}

		public static GetMessageFromWXReq.Builder CreateBuilder()
		{
			return new GetMessageFromWXReq.Builder();
		}

		public override GetMessageFromWXReq.Builder ToBuilder()
		{
			return GetMessageFromWXReq.CreateBuilder(this);
		}

		public override GetMessageFromWXReq.Builder CreateBuilderForType()
		{
			return new GetMessageFromWXReq.Builder();
		}

		public static GetMessageFromWXReq.Builder CreateBuilder(GetMessageFromWXReq prototype)
		{
			return new GetMessageFromWXReq.Builder(prototype);
		}

		static GetMessageFromWXReq()
		{
			GetMessageFromWXReq.defaultInstance = new GetMessageFromWXReq().MakeReadOnly();
			GetMessageFromWXReq._getMessageFromWXReqFieldNames = new string[]
			{
				"Base",
				"Username"
			};
			GetMessageFromWXReq._getMessageFromWXReqFieldTags = new uint[]
			{
				10u,
				18u
			};
			object.ReferenceEquals(MicroMsg.sdk.protobuf.Proto.GetMessageFromWXReq.Descriptor, null);
		}
	}
}
