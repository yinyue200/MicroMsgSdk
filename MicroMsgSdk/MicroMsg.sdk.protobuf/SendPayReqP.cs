using Google.ProtocolBuffers;
using MicroMsg.sdk.protobuf.Proto;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace MicroMsg.sdk.protobuf
{
	
	public sealed class SendPayReqP : GeneratedMessageLite<SendPayReqP, SendPayReqP.Builder>
	{
		
		public sealed class Builder : GeneratedBuilderLite<SendPayReqP, SendPayReqP.Builder>
		{
			private bool resultIsReadOnly;

			private SendPayReqP result;

			protected override SendPayReqP.Builder ThisBuilder
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

			protected override SendPayReqP MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			public override SendPayReqP DefaultInstanceForType
			{
				get
				{
					return SendPayReqP.DefaultInstance;
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

			public string PartnerId
			{
				get
				{
					return this.result.PartnerId;
				}
				set
				{
					this.SetPartnerId(value);
				}
			}

			public string PrepayId
			{
				get
				{
					return this.result.PrepayId;
				}
				set
				{
					this.SetPrepayId(value);
				}
			}

			public string NonceStr
			{
				get
				{
					return this.result.NonceStr;
				}
				set
				{
					this.SetNonceStr(value);
				}
			}

			public uint TimeStamp
			{
				get
				{
					return this.result.TimeStamp;
				}
				set
				{
					this.SetTimeStamp(value);
				}
			}

			public string Package
			{
				get
				{
					return this.result.Package;
				}
				set
				{
					this.SetPackage(value);
				}
			}

			public string Sign
			{
				get
				{
					return this.result.Sign;
				}
				set
				{
					this.SetSign(value);
				}
			}

			public Builder()
			{
				this.result = SendPayReqP.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			internal Builder(SendPayReqP cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			private SendPayReqP PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					SendPayReqP other = this.result;
					this.result = new SendPayReqP();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			public override SendPayReqP.Builder Clear()
			{
				this.result = SendPayReqP.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			public override SendPayReqP.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new SendPayReqP.Builder(this.result);
				}
				return new SendPayReqP.Builder().MergeFrom(this.result);
			}

			public override SendPayReqP BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			public override SendPayReqP.Builder MergeFrom(IMessageLite other)
			{
				if (other is SendPayReqP)
				{
					return this.MergeFrom((SendPayReqP)other);
				}
				base.MergeFrom(other);
				return this;
			}

			public override SendPayReqP.Builder MergeFrom(SendPayReqP other)
			{
				return this;
			}

			public override SendPayReqP.Builder MergeFrom(ICodedInputStream input)
			{
				return this.MergeFrom(input, ExtensionRegistry.Empty);
			}

			public override SendPayReqP.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				uint num;
				string text;
				while (input.ReadTag(out num, out text))
				{
					if (num == 0u && text != null)
					{
						int num2 = Array.BinarySearch<string>(SendPayReqP._sendPayReqPFieldNames, text, StringComparer.Ordinal);
						if (num2 < 0)
						{
							this.ParseUnknownField(input, extensionRegistry, num, text);
							continue;
						}
						num = SendPayReqP._sendPayReqPFieldTags[num2];
					}
					uint num3 = num;
					if (num3 <= 26u)
					{
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
								this.result.hasPartnerId = input.ReadString(ref this.result.partnerId_);
								continue;
							}
							if (num3 == 26u)
							{
								this.result.hasPrepayId = input.ReadString(ref this.result.prepayId_);
								continue;
							}
						}
					}
					else if (num3 <= 40u)
					{
						if (num3 == 34u)
						{
							this.result.hasNonceStr = input.ReadString(ref this.result.nonceStr_);
							continue;
						}
						if (num3 == 40u)
						{
							this.result.hasTimeStamp = input.ReadUInt32(ref this.result.timeStamp_);
							continue;
						}
					}
					else
					{
						if (num3 == 50u)
						{
							this.result.hasPackage = input.ReadString(ref this.result.package_);
							continue;
						}
						if (num3 == 58u)
						{
							this.result.hasSign = input.ReadString(ref this.result.sign_);
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

			public SendPayReqP.Builder SetBase(BaseReqP value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasBase = true;
				this.result.base_ = value;
				return this;
			}

			public SendPayReqP.Builder SetBase(BaseReqP.Builder builderForValue)
			{
				ThrowHelper.ThrowIfNull(builderForValue, "builderForValue");
				this.PrepareBuilder();
				this.result.hasBase = true;
				this.result.base_ = builderForValue.Build();
				return this;
			}

			public SendPayReqP.Builder MergeBase(BaseReqP value)
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

			public SendPayReqP.Builder ClearBase()
			{
				this.PrepareBuilder();
				this.result.hasBase = false;
				this.result.base_ = null;
				return this;
			}

			public SendPayReqP.Builder SetPartnerId(string value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasPartnerId = true;
				this.result.partnerId_ = value;
				return this;
			}

			public SendPayReqP.Builder ClearPartnerId()
			{
				this.PrepareBuilder();
				this.result.hasPartnerId = false;
				this.result.partnerId_ = "";
				return this;
			}

			public SendPayReqP.Builder SetPrepayId(string value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasPrepayId = true;
				this.result.prepayId_ = value;
				return this;
			}

			public SendPayReqP.Builder ClearPrepayId()
			{
				this.PrepareBuilder();
				this.result.hasPrepayId = false;
				this.result.prepayId_ = "";
				return this;
			}

			public SendPayReqP.Builder SetNonceStr(string value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasNonceStr = true;
				this.result.nonceStr_ = value;
				return this;
			}

			public SendPayReqP.Builder ClearNonceStr()
			{
				this.PrepareBuilder();
				this.result.hasNonceStr = false;
				this.result.nonceStr_ = "";
				return this;
			}

			public SendPayReqP.Builder SetTimeStamp(uint value)
			{
				this.PrepareBuilder();
				this.result.hasTimeStamp = true;
				this.result.timeStamp_ = value;
				return this;
			}

			public SendPayReqP.Builder ClearTimeStamp()
			{
				this.PrepareBuilder();
				this.result.hasTimeStamp = false;
				this.result.timeStamp_ = 0u;
				return this;
			}

			public SendPayReqP.Builder SetPackage(string value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasPackage = true;
				this.result.package_ = value;
				return this;
			}

			public SendPayReqP.Builder ClearPackage()
			{
				this.PrepareBuilder();
				this.result.hasPackage = false;
				this.result.package_ = "";
				return this;
			}

			public SendPayReqP.Builder SetSign(string value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasSign = true;
				this.result.sign_ = value;
				return this;
			}

			public SendPayReqP.Builder ClearSign()
			{
				this.PrepareBuilder();
				this.result.hasSign = false;
				this.result.sign_ = "";
				return this;
			}
		}

		public const int BaseFieldNumber = 1;

		public const int PartnerIdFieldNumber = 2;

		public const int PrepayIdFieldNumber = 3;

		public const int NonceStrFieldNumber = 4;

		public const int TimeStampFieldNumber = 5;

		public const int PackageFieldNumber = 6;

		public const int SignFieldNumber = 7;

		private static readonly SendPayReqP defaultInstance;

		private static readonly string[] _sendPayReqPFieldNames;

		private static readonly uint[] _sendPayReqPFieldTags;

		private bool hasBase;

		private BaseReqP base_;

		private bool hasPartnerId;

		private string partnerId_ = "";

		private bool hasPrepayId;

		private string prepayId_ = "";

		private bool hasNonceStr;

		private string nonceStr_ = "";

		private bool hasTimeStamp;

		private uint timeStamp_;

		private bool hasPackage;

		private string package_ = "";

		private bool hasSign;

		private string sign_ = "";

		private int memoizedSerializedSize = -1;

		public static SendPayReqP DefaultInstance
		{
			get
			{
				return SendPayReqP.defaultInstance;
			}
		}

		public override SendPayReqP DefaultInstanceForType
		{
			get
			{
				return SendPayReqP.DefaultInstance;
			}
		}

		protected override SendPayReqP ThisMessage
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

		public string PartnerId
		{
			get
			{
				return this.partnerId_;
			}
		}

		public string PrepayId
		{
			get
			{
				return this.prepayId_;
			}
		}

		public string NonceStr
		{
			get
			{
				return this.nonceStr_;
			}
		}

		public uint TimeStamp
		{
			get
			{
				return this.timeStamp_;
			}
		}

		public string Package
		{
			get
			{
				return this.package_;
			}
		}

		public string Sign
		{
			get
			{
				return this.sign_;
			}
		}

		public override bool IsInitialized
		{
			get
			{
				return this.hasBase && this.hasPartnerId && this.hasPrepayId && this.hasNonceStr && this.hasTimeStamp && this.hasPackage && this.hasSign && this.Base.IsInitialized;
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
				if (this.hasPartnerId)
				{
					num += CodedOutputStream.ComputeStringSize(2, this.PartnerId);
				}
				if (this.hasPrepayId)
				{
					num += CodedOutputStream.ComputeStringSize(3, this.PrepayId);
				}
				if (this.hasNonceStr)
				{
					num += CodedOutputStream.ComputeStringSize(4, this.NonceStr);
				}
				if (this.hasTimeStamp)
				{
					num += CodedOutputStream.ComputeUInt32Size(5, this.TimeStamp);
				}
				if (this.hasPackage)
				{
					num += CodedOutputStream.ComputeStringSize(6, this.Package);
				}
				if (this.hasSign)
				{
					num += CodedOutputStream.ComputeStringSize(7, this.Sign);
				}
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		private SendPayReqP()
		{
		}

		public override void WriteTo(ICodedOutputStream output)
		{
			int arg_06_0 = this.SerializedSize;
			string[] sendPayReqPFieldNames = SendPayReqP._sendPayReqPFieldNames;
			if (this.hasBase)
			{
				output.WriteMessage(1, sendPayReqPFieldNames[0], this.Base);
			}
			if (this.hasPartnerId)
			{
				output.WriteString(2, sendPayReqPFieldNames[3], this.PartnerId);
			}
			if (this.hasPrepayId)
			{
				output.WriteString(3, sendPayReqPFieldNames[4], this.PrepayId);
			}
			if (this.hasNonceStr)
			{
				output.WriteString(4, sendPayReqPFieldNames[1], this.NonceStr);
			}
			if (this.hasTimeStamp)
			{
				output.WriteUInt32(5, sendPayReqPFieldNames[6], this.TimeStamp);
			}
			if (this.hasPackage)
			{
				output.WriteString(6, sendPayReqPFieldNames[2], this.Package);
			}
			if (this.hasSign)
			{
				output.WriteString(7, sendPayReqPFieldNames[5], this.Sign);
			}
		}

		public override int GetHashCode()
		{
			int num = base.GetType().GetHashCode();
			if (this.hasBase)
			{
				num ^= this.base_.GetHashCode();
			}
			if (this.hasPartnerId)
			{
				num ^= this.partnerId_.GetHashCode();
			}
			if (this.hasPrepayId)
			{
				num ^= this.prepayId_.GetHashCode();
			}
			if (this.hasNonceStr)
			{
				num ^= this.nonceStr_.GetHashCode();
			}
			if (this.hasTimeStamp)
			{
				num ^= this.timeStamp_.GetHashCode();
			}
			if (this.hasPackage)
			{
				num ^= this.package_.GetHashCode();
			}
			if (this.hasSign)
			{
				num ^= this.sign_.GetHashCode();
			}
			return num;
		}

		public override bool Equals(object obj)
		{
			SendPayReqP sendPayReqP = obj as SendPayReqP;
			return sendPayReqP != null && this.hasBase == sendPayReqP.hasBase && (!this.hasBase || this.base_.Equals(sendPayReqP.base_)) && this.hasPartnerId == sendPayReqP.hasPartnerId && (!this.hasPartnerId || this.partnerId_.Equals(sendPayReqP.partnerId_)) && this.hasPrepayId == sendPayReqP.hasPrepayId && (!this.hasPrepayId || this.prepayId_.Equals(sendPayReqP.prepayId_)) && this.hasNonceStr == sendPayReqP.hasNonceStr && (!this.hasNonceStr || this.nonceStr_.Equals(sendPayReqP.nonceStr_)) && this.hasTimeStamp == sendPayReqP.hasTimeStamp && (!this.hasTimeStamp || this.timeStamp_.Equals(sendPayReqP.timeStamp_)) && this.hasPackage == sendPayReqP.hasPackage && (!this.hasPackage || this.package_.Equals(sendPayReqP.package_)) && this.hasSign == sendPayReqP.hasSign && (!this.hasSign || this.sign_.Equals(sendPayReqP.sign_));
		}

		public override void PrintTo(TextWriter writer)
		{
			GeneratedMessageLite<SendPayReqP, SendPayReqP.Builder>.PrintField("Base", this.hasBase, this.base_, writer);
			GeneratedMessageLite<SendPayReqP, SendPayReqP.Builder>.PrintField("PartnerId", this.hasPartnerId, this.partnerId_, writer);
			GeneratedMessageLite<SendPayReqP, SendPayReqP.Builder>.PrintField("PrepayId", this.hasPrepayId, this.prepayId_, writer);
			GeneratedMessageLite<SendPayReqP, SendPayReqP.Builder>.PrintField("NonceStr", this.hasNonceStr, this.nonceStr_, writer);
			GeneratedMessageLite<SendPayReqP, SendPayReqP.Builder>.PrintField("TimeStamp", this.hasTimeStamp, this.timeStamp_, writer);
			GeneratedMessageLite<SendPayReqP, SendPayReqP.Builder>.PrintField("Package", this.hasPackage, this.package_, writer);
			GeneratedMessageLite<SendPayReqP, SendPayReqP.Builder>.PrintField("Sign", this.hasSign, this.sign_, writer);
		}

		public static SendPayReqP ParseFrom(byte[] data)
		{
			return SendPayReqP.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		private SendPayReqP MakeReadOnly()
		{
			return this;
		}

		public static SendPayReqP.Builder CreateBuilder()
		{
			return new SendPayReqP.Builder();
		}

		public override SendPayReqP.Builder ToBuilder()
		{
			return SendPayReqP.CreateBuilder(this);
		}

		public override SendPayReqP.Builder CreateBuilderForType()
		{
			return new SendPayReqP.Builder();
		}

		public static SendPayReqP.Builder CreateBuilder(SendPayReqP prototype)
		{
			return new SendPayReqP.Builder(prototype);
		}

		static SendPayReqP()
		{
			SendPayReqP.defaultInstance = new SendPayReqP().MakeReadOnly();
			SendPayReqP._sendPayReqPFieldNames = new string[]
			{
				"Base",
				"NonceStr",
				"Package",
				"PartnerId",
				"PrepayId",
				"Sign",
				"TimeStamp"
			};
			SendPayReqP._sendPayReqPFieldTags = new uint[]
			{
				10u,
				34u,
				50u,
				18u,
				26u,
				58u,
				40u
			};
			object.ReferenceEquals(MicroMsg.sdk.protobuf.Proto.SendPayReqP.Descriptor, null);
		}
	}
}
