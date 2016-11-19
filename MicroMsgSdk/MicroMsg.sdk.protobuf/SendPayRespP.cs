using Google.ProtocolBuffers;
using MicroMsg.sdk.protobuf.Proto;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace MicroMsg.sdk.protobuf
{
	
	public sealed class SendPayRespP : GeneratedMessageLite<SendPayRespP, SendPayRespP.Builder>
	{
		
		public sealed class Builder : GeneratedBuilderLite<SendPayRespP, SendPayRespP.Builder>
		{
			private bool resultIsReadOnly;

			private SendPayRespP result;

			protected override SendPayRespP.Builder ThisBuilder
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

			protected override SendPayRespP MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			public override SendPayRespP DefaultInstanceForType
			{
				get
				{
					return SendPayRespP.DefaultInstance;
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

			public string ReturnKey
			{
				get
				{
					return this.result.ReturnKey;
				}
				set
				{
					this.SetReturnKey(value);
				}
			}

			public Builder()
			{
				this.result = SendPayRespP.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			internal Builder(SendPayRespP cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			private SendPayRespP PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					SendPayRespP other = this.result;
					this.result = new SendPayRespP();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			public override SendPayRespP.Builder Clear()
			{
				this.result = SendPayRespP.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			public override SendPayRespP.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new SendPayRespP.Builder(this.result);
				}
				return new SendPayRespP.Builder().MergeFrom(this.result);
			}

			public override SendPayRespP BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			public override SendPayRespP.Builder MergeFrom(IMessageLite other)
			{
				if (other is SendPayRespP)
				{
					return this.MergeFrom((SendPayRespP)other);
				}
				base.MergeFrom(other);
				return this;
			}

			public override SendPayRespP.Builder MergeFrom(SendPayRespP other)
			{
				return this;
			}

			public override SendPayRespP.Builder MergeFrom(ICodedInputStream input)
			{
				return this.MergeFrom(input, ExtensionRegistry.Empty);
			}

			public override SendPayRespP.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				uint num;
				string text;
				while (input.ReadTag(out num, out text))
				{
					if (num == 0u && text != null)
					{
						int num2 = Array.BinarySearch<string>(SendPayRespP._sendPayRespPFieldNames, text, StringComparer.Ordinal);
						if (num2 < 0)
						{
							this.ParseUnknownField(input, extensionRegistry, num, text);
							continue;
						}
						num = SendPayRespP._sendPayRespPFieldTags[num2];
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
							this.result.hasReturnKey = input.ReadString(ref this.result.returnKey_);
						}
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

			public SendPayRespP.Builder SetBase(BaseRespP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasBase = true;
				this.result.base_ = value;
				return this;
			}

			public SendPayRespP.Builder SetBase(BaseRespP.Builder builderForValue)
			{
				ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasBase = true;
				this.result.base_ = builderForValue.Build();
				return this;
			}

			public SendPayRespP.Builder MergeBase(BaseRespP value)
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

			public SendPayRespP.Builder ClearBase()
			{
				this.PrepareBuilder();
				this.result.hasBase = false;
				this.result.base_ = null;
				return this;
			}

			public SendPayRespP.Builder SetReturnKey(string value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasReturnKey = true;
				this.result.returnKey_ = value;
				return this;
			}

			public SendPayRespP.Builder ClearReturnKey()
			{
				this.PrepareBuilder();
				this.result.hasReturnKey = false;
				this.result.returnKey_ = "";
				return this;
			}
		}

		public const int BaseFieldNumber = 1;

		public const int ReturnKeyFieldNumber = 2;

		private static readonly SendPayRespP defaultInstance;

		private static readonly string[] _sendPayRespPFieldNames;

		private static readonly uint[] _sendPayRespPFieldTags;

		private bool hasBase;

		private BaseRespP base_;

		private bool hasReturnKey;

		private string returnKey_ = "";

		private int memoizedSerializedSize = -1;

		public static SendPayRespP DefaultInstance
		{
			get
			{
				return SendPayRespP.defaultInstance;
			}
		}

		public override SendPayRespP DefaultInstanceForType
		{
			get
			{
				return SendPayRespP.DefaultInstance;
			}
		}

		protected override SendPayRespP ThisMessage
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

		public string ReturnKey
		{
			get
			{
				return this.returnKey_;
			}
		}

		public override bool IsInitialized
		{
			get
			{
				return this.hasBase && this.hasReturnKey && this.Base.IsInitialized;
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
				if (this.hasReturnKey)
				{
					num += CodedOutputStream.ComputeStringSize(2, this.ReturnKey);
				}
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		private SendPayRespP()
		{
		}

		public override void WriteTo(ICodedOutputStream output)
		{
			int arg_06_0 = this.SerializedSize;
			string[] sendPayRespPFieldNames = SendPayRespP._sendPayRespPFieldNames;
			if (this.hasBase)
			{
				output.WriteMessage(1, sendPayRespPFieldNames[0], this.Base);
			}
			if (this.hasReturnKey)
			{
				output.WriteString(2, sendPayRespPFieldNames[1], this.ReturnKey);
			}
		}

		public override int GetHashCode()
		{
			int num = base.GetType().GetHashCode();
			if (this.hasBase)
			{
				num ^= this.base_.GetHashCode();
			}
			if (this.hasReturnKey)
			{
				num ^= this.returnKey_.GetHashCode();
			}
			return num;
		}

		public override bool Equals(object obj)
		{
			SendPayRespP sendPayRespP = obj as SendPayRespP;
			return sendPayRespP != null && this.hasBase == sendPayRespP.hasBase && (!this.hasBase || this.base_.Equals(sendPayRespP.base_)) && this.hasReturnKey == sendPayRespP.hasReturnKey && (!this.hasReturnKey || this.returnKey_.Equals(sendPayRespP.returnKey_));
		}

		public override void PrintTo(TextWriter writer)
		{
			GeneratedMessageLite<SendPayRespP, SendPayRespP.Builder>.PrintField("Base", this.hasBase, this.base_, writer);
			GeneratedMessageLite<SendPayRespP, SendPayRespP.Builder>.PrintField("ReturnKey", this.hasReturnKey, this.returnKey_, writer);
		}

		public static SendPayRespP ParseFrom(byte[] data)
		{
			return SendPayRespP.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		private SendPayRespP MakeReadOnly()
		{
			return this;
		}

		public static SendPayRespP.Builder CreateBuilder()
		{
			return new SendPayRespP.Builder();
		}

		public override SendPayRespP.Builder ToBuilder()
		{
			return SendPayRespP.CreateBuilder(this);
		}

		public override SendPayRespP.Builder CreateBuilderForType()
		{
			return new SendPayRespP.Builder();
		}

		public static SendPayRespP.Builder CreateBuilder(SendPayRespP prototype)
		{
			return new SendPayRespP.Builder(prototype);
		}

		static SendPayRespP()
		{
			SendPayRespP.defaultInstance = new SendPayRespP().MakeReadOnly();
			SendPayRespP._sendPayRespPFieldNames = new string[]
			{
				"Base",
				"ReturnKey"
			};
			SendPayRespP._sendPayRespPFieldTags = new uint[]
			{
				10u,
				18u
			};
			object.ReferenceEquals(MicroMsg.sdk.protobuf.Proto.SendPayRespP.Descriptor, null);
		}
	}
}
