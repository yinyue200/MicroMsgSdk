using Google.ProtocolBuffers;
using MicroMsg.sdk.protobuf.Proto;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace MicroMsg.sdk.protobuf
{
	
	public sealed class BaseRespP : GeneratedMessageLite<BaseRespP, BaseRespP.Builder>
	{
		
		public sealed class Builder : GeneratedBuilderLite<BaseRespP, BaseRespP.Builder>
		{
			private bool resultIsReadOnly;

			private BaseRespP result;

			protected override BaseRespP.Builder ThisBuilder
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

			protected override BaseRespP MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			public override BaseRespP DefaultInstanceForType
			{
				get
				{
					return BaseRespP.DefaultInstance;
				}
			}

			public uint Type
			{
				get
				{
					return this.result.Type;
				}
				set
				{
					this.SetType(value);
				}
			}

			public string Transaction
			{
				get
				{
					return this.result.Transaction;
				}
				set
				{
					this.SetTransaction(value);
				}
			}

			public uint ErrCode
			{
				get
				{
					return this.result.ErrCode;
				}
				set
				{
					this.SetErrCode(value);
				}
			}

			public string ErrStr
			{
				get
				{
					return this.result.ErrStr;
				}
				set
				{
					this.SetErrStr(value);
				}
			}

			public Builder()
			{
				this.result = BaseRespP.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			internal Builder(BaseRespP cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			private BaseRespP PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					BaseRespP other = this.result;
					this.result = new BaseRespP();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			public override BaseRespP.Builder Clear()
			{
				this.result = BaseRespP.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			public override BaseRespP.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new BaseRespP.Builder(this.result);
				}
				return new BaseRespP.Builder().MergeFrom(this.result);
			}

			public override BaseRespP BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			public override BaseRespP.Builder MergeFrom(IMessageLite other)
			{
				if (other is BaseRespP)
				{
					return this.MergeFrom((BaseRespP)other);
				}
				base.MergeFrom(other);
				return this;
			}

			public override BaseRespP.Builder MergeFrom(BaseRespP other)
			{
				return this;
			}

			public override BaseRespP.Builder MergeFrom(ICodedInputStream input)
			{
				return this.MergeFrom(input, ExtensionRegistry.Empty);
			}

			public override BaseRespP.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				uint num;
				string text;
				while (input.ReadTag(out num, out text))
				{
					if (num == 0u && text != null)
					{
						int num2 = Array.BinarySearch<string>(BaseRespP._baseRespPFieldNames, text, StringComparer.Ordinal);
						if (num2 < 0)
						{
							this.ParseUnknownField(input, extensionRegistry, num, text);
							continue;
						}
						num = BaseRespP._baseRespPFieldTags[num2];
					}
					uint num3 = num;
					if (num3 <= 8u)
					{
						if (num3 == 0u)
						{
							throw InvalidProtocolBufferException.InvalidTag();
						}
						if (num3 == 8u)
						{
							this.result.hasType = input.ReadUInt32(ref this.result.type_);
							continue;
						}
					}
					else
					{
						if (num3 == 18u)
						{
							this.result.hasTransaction = input.ReadString(ref this.result.transaction_);
							continue;
						}
						if (num3 == 24u)
						{
							this.result.hasErrCode = input.ReadUInt32(ref this.result.errCode_);
							continue;
						}
						if (num3 == 34u)
						{
							this.result.hasErrStr = input.ReadString(ref this.result.errStr_);
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

			public BaseRespP.Builder SetType(uint value)
			{
				this.PrepareBuilder();
				this.result.hasType = true;
				this.result.type_ = value;
				return this;
			}

			public BaseRespP.Builder ClearType()
			{
				this.PrepareBuilder();
				this.result.hasType = false;
				this.result.type_ = 0u;
				return this;
			}

			public BaseRespP.Builder SetTransaction(string value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasTransaction = true;
				this.result.transaction_ = value;
				return this;
			}

			public BaseRespP.Builder ClearTransaction()
			{
				this.PrepareBuilder();
				this.result.hasTransaction = false;
				this.result.transaction_ = "";
				return this;
			}

			public BaseRespP.Builder SetErrCode(uint value)
			{
				this.PrepareBuilder();
				this.result.hasErrCode = true;
				this.result.errCode_ = value;
				return this;
			}

			public BaseRespP.Builder ClearErrCode()
			{
				this.PrepareBuilder();
				this.result.hasErrCode = false;
				this.result.errCode_ = 0u;
				return this;
			}

			public BaseRespP.Builder SetErrStr(string value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasErrStr = true;
				this.result.errStr_ = value;
				return this;
			}

			public BaseRespP.Builder ClearErrStr()
			{
				this.PrepareBuilder();
				this.result.hasErrStr = false;
				this.result.errStr_ = "";
				return this;
			}
		}

		public const int TypeFieldNumber = 1;

		public const int TransactionFieldNumber = 2;

		public const int ErrCodeFieldNumber = 3;

		public const int ErrStrFieldNumber = 4;

		private static readonly BaseRespP defaultInstance;

		private static readonly string[] _baseRespPFieldNames;

		private static readonly uint[] _baseRespPFieldTags;

		private bool hasType;

		private uint type_;

		private bool hasTransaction;

		private string transaction_ = "";

		private bool hasErrCode;

		private uint errCode_;

		private bool hasErrStr;

		private string errStr_ = "";

		private int memoizedSerializedSize = -1;

		public static BaseRespP DefaultInstance
		{
			get
			{
				return BaseRespP.defaultInstance;
			}
		}

		public override BaseRespP DefaultInstanceForType
		{
			get
			{
				return BaseRespP.DefaultInstance;
			}
		}

		protected override BaseRespP ThisMessage
		{
			get
			{
				return this;
			}
		}

		public uint Type
		{
			get
			{
				return this.type_;
			}
		}

		public string Transaction
		{
			get
			{
				return this.transaction_;
			}
		}

		public uint ErrCode
		{
			get
			{
				return this.errCode_;
			}
		}

		public string ErrStr
		{
			get
			{
				return this.errStr_;
			}
		}

		public override bool IsInitialized
		{
			get
			{
				return this.hasType && this.hasTransaction;
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
				if (this.hasType)
				{
					num += CodedOutputStream.ComputeUInt32Size(1, this.Type);
				}
				if (this.hasTransaction)
				{
					num += CodedOutputStream.ComputeStringSize(2, this.Transaction);
				}
				if (this.hasErrCode)
				{
					num += CodedOutputStream.ComputeUInt32Size(3, this.ErrCode);
				}
				if (this.hasErrStr)
				{
					num += CodedOutputStream.ComputeStringSize(4, this.ErrStr);
				}
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		private BaseRespP()
		{
		}

		public override void WriteTo(ICodedOutputStream output)
		{
			int arg_06_0 = this.SerializedSize;
			string[] baseRespPFieldNames = BaseRespP._baseRespPFieldNames;
			if (this.hasType)
			{
				output.WriteUInt32(1, baseRespPFieldNames[3], this.Type);
			}
			if (this.hasTransaction)
			{
				output.WriteString(2, baseRespPFieldNames[2], this.Transaction);
			}
			if (this.hasErrCode)
			{
				output.WriteUInt32(3, baseRespPFieldNames[0], this.ErrCode);
			}
			if (this.hasErrStr)
			{
				output.WriteString(4, baseRespPFieldNames[1], this.ErrStr);
			}
		}

		public override int GetHashCode()
		{
			int num = base.GetType().GetHashCode();
			if (this.hasType)
			{
				num ^= this.type_.GetHashCode();
			}
			if (this.hasTransaction)
			{
				num ^= this.transaction_.GetHashCode();
			}
			if (this.hasErrCode)
			{
				num ^= this.errCode_.GetHashCode();
			}
			if (this.hasErrStr)
			{
				num ^= this.errStr_.GetHashCode();
			}
			return num;
		}

		public override bool Equals(object obj)
		{
			BaseRespP baseRespP = obj as BaseRespP;
			return baseRespP != null && this.hasType == baseRespP.hasType && (!this.hasType || this.type_.Equals(baseRespP.type_)) && this.hasTransaction == baseRespP.hasTransaction && (!this.hasTransaction || this.transaction_.Equals(baseRespP.transaction_)) && this.hasErrCode == baseRespP.hasErrCode && (!this.hasErrCode || this.errCode_.Equals(baseRespP.errCode_)) && this.hasErrStr == baseRespP.hasErrStr && (!this.hasErrStr || this.errStr_.Equals(baseRespP.errStr_));
		}

		public override void PrintTo(TextWriter writer)
		{
			GeneratedMessageLite<BaseRespP, BaseRespP.Builder>.PrintField("Type", this.hasType, this.type_, writer);
			GeneratedMessageLite<BaseRespP, BaseRespP.Builder>.PrintField("Transaction", this.hasTransaction, this.transaction_, writer);
			GeneratedMessageLite<BaseRespP, BaseRespP.Builder>.PrintField("ErrCode", this.hasErrCode, this.errCode_, writer);
			GeneratedMessageLite<BaseRespP, BaseRespP.Builder>.PrintField("ErrStr", this.hasErrStr, this.errStr_, writer);
		}

		public static BaseRespP ParseFrom(byte[] data)
		{
			return BaseRespP.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		private BaseRespP MakeReadOnly()
		{
			return this;
		}

		public static BaseRespP.Builder CreateBuilder()
		{
			return new BaseRespP.Builder();
		}

		public override BaseRespP.Builder ToBuilder()
		{
			return BaseRespP.CreateBuilder(this);
		}

		public override BaseRespP.Builder CreateBuilderForType()
		{
			return new BaseRespP.Builder();
		}

		public static BaseRespP.Builder CreateBuilder(BaseRespP prototype)
		{
			return new BaseRespP.Builder(prototype);
		}

		static BaseRespP()
		{
			BaseRespP.defaultInstance = new BaseRespP().MakeReadOnly();
			BaseRespP._baseRespPFieldNames = new string[]
			{
				"ErrCode",
				"ErrStr",
				"Transaction",
				"Type"
			};
			BaseRespP._baseRespPFieldTags = new uint[]
			{
				24u,
				34u,
				18u,
				8u
			};
			object.ReferenceEquals(MicroMsg.sdk.protobuf.Proto.BaseRespP.Descriptor, null);
		}
	}
}
