using Google.ProtocolBuffers;
using MicroMsg.sdk.protobuf.Proto;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace MicroMsg.sdk.protobuf
{
	
	public sealed class SendMessageToWXResp : GeneratedMessageLite<SendMessageToWXResp, SendMessageToWXResp.Builder>
	{
		
		public sealed class Builder : GeneratedBuilderLite<SendMessageToWXResp, SendMessageToWXResp.Builder>
		{
			private bool resultIsReadOnly;

			private SendMessageToWXResp result;

			protected override SendMessageToWXResp.Builder ThisBuilder
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

			protected override SendMessageToWXResp MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			public override SendMessageToWXResp DefaultInstanceForType
			{
				get
				{
					return SendMessageToWXResp.DefaultInstance;
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
				this.result = SendMessageToWXResp.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			internal Builder(SendMessageToWXResp cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			private SendMessageToWXResp PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					SendMessageToWXResp other = this.result;
					this.result = new SendMessageToWXResp();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			public override SendMessageToWXResp.Builder Clear()
			{
				this.result = SendMessageToWXResp.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			public override SendMessageToWXResp.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new SendMessageToWXResp.Builder(this.result);
				}
				return new SendMessageToWXResp.Builder().MergeFrom(this.result);
			}

			public override SendMessageToWXResp BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			public override SendMessageToWXResp.Builder MergeFrom(IMessageLite other)
			{
				if (other is SendMessageToWXResp)
				{
					return this.MergeFrom((SendMessageToWXResp)other);
				}
				base.MergeFrom(other);
				return this;
			}

			public override SendMessageToWXResp.Builder MergeFrom(SendMessageToWXResp other)
			{
				return this;
			}

			public override SendMessageToWXResp.Builder MergeFrom(ICodedInputStream input)
			{
				return this.MergeFrom(input, ExtensionRegistry.Empty);
			}

			public override SendMessageToWXResp.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				uint num;
				string text;
				while (input.ReadTag(out num, out text))
				{
					if (num == 0u && text != null)
					{
						int num2 = Array.BinarySearch<string>(SendMessageToWXResp._sendMessageToWXRespFieldNames, text, StringComparer.Ordinal);
						if (num2 < 0)
						{
							this.ParseUnknownField(input, extensionRegistry, num, text);
							continue;
						}
						num = SendMessageToWXResp._sendMessageToWXRespFieldTags[num2];
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

			public SendMessageToWXResp.Builder SetBase(BaseRespP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasBase = true;
				this.result.base_ = value;
				return this;
			}

			public SendMessageToWXResp.Builder SetBase(BaseRespP.Builder builderForValue)
			{
				ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasBase = true;
				this.result.base_ = builderForValue.Build();
				return this;
			}

			public SendMessageToWXResp.Builder MergeBase(BaseRespP value)
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

			public SendMessageToWXResp.Builder ClearBase()
			{
				this.PrepareBuilder();
				this.result.hasBase = false;
				this.result.base_ = null;
				return this;
			}
		}

		public const int BaseFieldNumber = 1;

		private static readonly SendMessageToWXResp defaultInstance;

		private static readonly string[] _sendMessageToWXRespFieldNames;

		private static readonly uint[] _sendMessageToWXRespFieldTags;

		private bool hasBase;

		private BaseRespP base_;

		private int memoizedSerializedSize = -1;

		public static SendMessageToWXResp DefaultInstance
		{
			get
			{
				return SendMessageToWXResp.defaultInstance;
			}
		}

		public override SendMessageToWXResp DefaultInstanceForType
		{
			get
			{
				return SendMessageToWXResp.DefaultInstance;
			}
		}

		protected override SendMessageToWXResp ThisMessage
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

		private SendMessageToWXResp()
		{
		}

		public override void WriteTo(ICodedOutputStream output)
		{
			int arg_06_0 = this.SerializedSize;
			string[] sendMessageToWXRespFieldNames = SendMessageToWXResp._sendMessageToWXRespFieldNames;
			if (this.hasBase)
			{
				output.WriteMessage(1, sendMessageToWXRespFieldNames[0], this.Base);
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
			SendMessageToWXResp sendMessageToWXResp = obj as SendMessageToWXResp;
			return sendMessageToWXResp != null && this.hasBase == sendMessageToWXResp.hasBase && (!this.hasBase || this.base_.Equals(sendMessageToWXResp.base_));
		}

		public override void PrintTo(TextWriter writer)
		{
			GeneratedMessageLite<SendMessageToWXResp, SendMessageToWXResp.Builder>.PrintField("Base", this.hasBase, this.base_, writer);
		}

		public static SendMessageToWXResp ParseFrom(byte[] data)
		{
			return SendMessageToWXResp.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		private SendMessageToWXResp MakeReadOnly()
		{
			return this;
		}

		public static SendMessageToWXResp.Builder CreateBuilder()
		{
			return new SendMessageToWXResp.Builder();
		}

		public override SendMessageToWXResp.Builder ToBuilder()
		{
			return SendMessageToWXResp.CreateBuilder(this);
		}

		public override SendMessageToWXResp.Builder CreateBuilderForType()
		{
			return new SendMessageToWXResp.Builder();
		}

		public static SendMessageToWXResp.Builder CreateBuilder(SendMessageToWXResp prototype)
		{
			return new SendMessageToWXResp.Builder(prototype);
		}

		static SendMessageToWXResp()
		{
			SendMessageToWXResp.defaultInstance = new SendMessageToWXResp().MakeReadOnly();
			SendMessageToWXResp._sendMessageToWXRespFieldNames = new string[]
			{
				"Base"
			};
			SendMessageToWXResp._sendMessageToWXRespFieldTags = new uint[]
			{
				10u
			};
			object.ReferenceEquals(MicroMsg.sdk.protobuf.Proto.SendMessageToWXResp.Descriptor, null);
		}
	}
}
