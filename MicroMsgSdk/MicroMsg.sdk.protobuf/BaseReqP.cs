using Google.ProtocolBuffers;
using MicroMsg.sdk.protobuf.Proto;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace MicroMsg.sdk.protobuf
{
	
	public sealed class BaseReqP : GeneratedMessageLite<BaseReqP, BaseReqP.Builder>
	{
		
		public sealed class Builder : GeneratedBuilderLite<BaseReqP, BaseReqP.Builder>
		{
			private bool resultIsReadOnly;

			private BaseReqP result;

			protected override BaseReqP.Builder ThisBuilder
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

			protected override BaseReqP MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			public override BaseReqP DefaultInstanceForType
			{
				get
				{
					return BaseReqP.DefaultInstance;
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

			public Builder()
			{
				this.result = BaseReqP.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			internal Builder(BaseReqP cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			private BaseReqP PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					BaseReqP other = this.result;
					this.result = new BaseReqP();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			public override BaseReqP.Builder Clear()
			{
				this.result = BaseReqP.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			public override BaseReqP.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new BaseReqP.Builder(this.result);
				}
				return new BaseReqP.Builder().MergeFrom(this.result);
			}

			public override BaseReqP BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			public override BaseReqP.Builder MergeFrom(IMessageLite other)
			{
				if (other is BaseReqP)
				{
					return this.MergeFrom((BaseReqP)other);
				}
				base.MergeFrom(other);
				return this;
			}

			public override BaseReqP.Builder MergeFrom(BaseReqP other)
			{
				return this;
			}

			public override BaseReqP.Builder MergeFrom(ICodedInputStream input)
			{
				return this.MergeFrom(input, ExtensionRegistry.Empty);
			}

			public override BaseReqP.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				uint num;
				string text;
				while (input.ReadTag(out num, out text))
				{
					if (num == 0u && text != null)
					{
						int num2 = Array.BinarySearch<string>(BaseReqP._baseReqPFieldNames, text, StringComparer.Ordinal);
						if (num2 < 0)
						{
							this.ParseUnknownField(input, extensionRegistry, num, text);
							continue;
						}
						num = BaseReqP._baseReqPFieldTags[num2];
					}
					uint num3 = num;
					if (num3 == 0u)
					{
						throw InvalidProtocolBufferException.InvalidTag();
					}
					if (num3 != 8u)
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
							this.result.hasTransaction = input.ReadString(ref this.result.transaction_);
						}
					}
					else
					{
						this.result.hasType = input.ReadUInt32(ref this.result.type_);
					}
				}
				return this;
			}

			public BaseReqP.Builder SetType(uint value)
			{
				this.PrepareBuilder();
				this.result.hasType = true;
				this.result.type_ = value;
				return this;
			}

			public BaseReqP.Builder ClearType()
			{
				this.PrepareBuilder();
				this.result.hasType = false;
				this.result.type_ = 0u;
				return this;
			}

			public BaseReqP.Builder SetTransaction(string value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasTransaction = true;
				this.result.transaction_ = value;
				return this;
			}

			public BaseReqP.Builder ClearTransaction()
			{
				this.PrepareBuilder();
				this.result.hasTransaction = false;
				this.result.transaction_ = "";
				return this;
			}
		}

		public const int TypeFieldNumber = 1;

		public const int TransactionFieldNumber = 2;

		private static readonly BaseReqP defaultInstance;

		private static readonly string[] _baseReqPFieldNames;

		private static readonly uint[] _baseReqPFieldTags;

		private bool hasType;

		private uint type_;

		private bool hasTransaction;

		private string transaction_ = "";

		private int memoizedSerializedSize = -1;

		public static BaseReqP DefaultInstance
		{
			get
			{
				return BaseReqP.defaultInstance;
			}
		}

		public override BaseReqP DefaultInstanceForType
		{
			get
			{
				return BaseReqP.DefaultInstance;
			}
		}

		protected override BaseReqP ThisMessage
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
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		private BaseReqP()
		{
		}

		public override void WriteTo(ICodedOutputStream output)
		{
			int arg_06_0 = this.SerializedSize;
			string[] baseReqPFieldNames = BaseReqP._baseReqPFieldNames;
			if (this.hasType)
			{
				output.WriteUInt32(1, baseReqPFieldNames[1], this.Type);
			}
			if (this.hasTransaction)
			{
				output.WriteString(2, baseReqPFieldNames[0], this.Transaction);
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
			return num;
		}

		public override bool Equals(object obj)
		{
			BaseReqP baseReqP = obj as BaseReqP;
			return baseReqP != null && this.hasType == baseReqP.hasType && (!this.hasType || this.type_.Equals(baseReqP.type_)) && this.hasTransaction == baseReqP.hasTransaction && (!this.hasTransaction || this.transaction_.Equals(baseReqP.transaction_));
		}

		public override void PrintTo(TextWriter writer)
		{
			GeneratedMessageLite<BaseReqP, BaseReqP.Builder>.PrintField("Type", this.hasType, this.type_, writer);
			GeneratedMessageLite<BaseReqP, BaseReqP.Builder>.PrintField("Transaction", this.hasTransaction, this.transaction_, writer);
		}

		public static BaseReqP ParseFrom(byte[] data)
		{
			return BaseReqP.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		private BaseReqP MakeReadOnly()
		{
			return this;
		}

		public static BaseReqP.Builder CreateBuilder()
		{
			return new BaseReqP.Builder();
		}

		public override BaseReqP.Builder ToBuilder()
		{
			return BaseReqP.CreateBuilder(this);
		}

		public override BaseReqP.Builder CreateBuilderForType()
		{
			return new BaseReqP.Builder();
		}

		public static BaseReqP.Builder CreateBuilder(BaseReqP prototype)
		{
			return new BaseReqP.Builder(prototype);
		}

		static BaseReqP()
		{
			BaseReqP.defaultInstance = new BaseReqP().MakeReadOnly();
			BaseReqP._baseReqPFieldNames = new string[]
			{
				"Transaction",
				"Type"
			};
			BaseReqP._baseReqPFieldTags = new uint[]
			{
				18u,
				8u
			};
			object.ReferenceEquals(MicroMsg.sdk.protobuf.Proto.BaseReqP.Descriptor, null);
		}
	}
}
