using Google.ProtocolBuffers;
using MicroMsg.sdk.protobuf.Proto;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace MicroMsg.sdk.protobuf
{
	
	public sealed class WXAppExtendMessageP : GeneratedMessageLite<WXAppExtendMessageP, WXAppExtendMessageP.Builder>
	{
		
		public sealed class Builder : GeneratedBuilderLite<WXAppExtendMessageP, WXAppExtendMessageP.Builder>
		{
			private bool resultIsReadOnly;

			private WXAppExtendMessageP result;

			protected override WXAppExtendMessageP.Builder ThisBuilder
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

			protected override WXAppExtendMessageP MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			public override WXAppExtendMessageP DefaultInstanceForType
			{
				get
				{
					return WXAppExtendMessageP.DefaultInstance;
				}
			}

			public ByteString FileData
			{
				get
				{
					return this.result.FileData;
				}
				set
				{
					this.SetFileData(value);
				}
			}

			public string ExtInfo
			{
				get
				{
					return this.result.ExtInfo;
				}
				set
				{
					this.SetExtInfo(value);
				}
			}

			public string FileName
			{
				get
				{
					return this.result.FileName;
				}
				set
				{
					this.SetFileName(value);
				}
			}

			public Builder()
			{
				this.result = WXAppExtendMessageP.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			internal Builder(WXAppExtendMessageP cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			private WXAppExtendMessageP PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					WXAppExtendMessageP other = this.result;
					this.result = new WXAppExtendMessageP();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			public override WXAppExtendMessageP.Builder Clear()
			{
				this.result = WXAppExtendMessageP.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			public override WXAppExtendMessageP.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new WXAppExtendMessageP.Builder(this.result);
				}
				return new WXAppExtendMessageP.Builder().MergeFrom(this.result);
			}

			public override WXAppExtendMessageP BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			public override WXAppExtendMessageP.Builder MergeFrom(IMessageLite other)
			{
				if (other is WXAppExtendMessageP)
				{
					return this.MergeFrom((WXAppExtendMessageP)other);
				}
				base.MergeFrom(other);
				return this;
			}

			public override WXAppExtendMessageP.Builder MergeFrom(WXAppExtendMessageP other)
			{
				return this;
			}

			public override WXAppExtendMessageP.Builder MergeFrom(ICodedInputStream input)
			{
				return this.MergeFrom(input, ExtensionRegistry.Empty);
			}

			public override WXAppExtendMessageP.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				uint num;
				string text;
				while (input.ReadTag(out num, out text))
				{
					if (num == 0u && text != null)
					{
						int num2 = Array.BinarySearch<string>(WXAppExtendMessageP._wXAppExtendMessagePFieldNames, text, StringComparer.Ordinal);
						if (num2 < 0)
						{
							this.ParseUnknownField(input, extensionRegistry, num, text);
							continue;
						}
						num = WXAppExtendMessageP._wXAppExtendMessagePFieldTags[num2];
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
							this.result.hasFileData = input.ReadBytes(ref this.result.fileData_);
							continue;
						}
					}
					else
					{
						if (num3 == 18u)
						{
							this.result.hasExtInfo = input.ReadString(ref this.result.extInfo_);
							continue;
						}
						if (num3 == 26u)
						{
							this.result.hasFileName = input.ReadString(ref this.result.fileName_);
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

			public WXAppExtendMessageP.Builder SetFileData(ByteString value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasFileData = true;
				this.result.fileData_ = value;
				return this;
			}

			public WXAppExtendMessageP.Builder ClearFileData()
			{
				this.PrepareBuilder();
				this.result.hasFileData = false;
				this.result.fileData_ = ByteString.Empty;
				return this;
			}

			public WXAppExtendMessageP.Builder SetExtInfo(string value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasExtInfo = true;
				this.result.extInfo_ = value;
				return this;
			}

			public WXAppExtendMessageP.Builder ClearExtInfo()
			{
				this.PrepareBuilder();
				this.result.hasExtInfo = false;
				this.result.extInfo_ = "";
				return this;
			}

			public WXAppExtendMessageP.Builder SetFileName(string value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasFileName = true;
				this.result.fileName_ = value;
				return this;
			}

			public WXAppExtendMessageP.Builder ClearFileName()
			{
				this.PrepareBuilder();
				this.result.hasFileName = false;
				this.result.fileName_ = "";
				return this;
			}
		}

		public const int FileDataFieldNumber = 1;

		public const int ExtInfoFieldNumber = 2;

		public const int FileNameFieldNumber = 3;

		private static readonly WXAppExtendMessageP defaultInstance;

		private static readonly string[] _wXAppExtendMessagePFieldNames;

		private static readonly uint[] _wXAppExtendMessagePFieldTags;

		private bool hasFileData;

		private ByteString fileData_ = ByteString.Empty;

		private bool hasExtInfo;

		private string extInfo_ = "";

		private bool hasFileName;

		private string fileName_ = "";

		private int memoizedSerializedSize = -1;

		public static WXAppExtendMessageP DefaultInstance
		{
			get
			{
				return WXAppExtendMessageP.defaultInstance;
			}
		}

		public override WXAppExtendMessageP DefaultInstanceForType
		{
			get
			{
				return WXAppExtendMessageP.DefaultInstance;
			}
		}

		protected override WXAppExtendMessageP ThisMessage
		{
			get
			{
				return this;
			}
		}

		public ByteString FileData
		{
			get
			{
				return this.fileData_;
			}
		}

		public string ExtInfo
		{
			get
			{
				return this.extInfo_;
			}
		}

		public string FileName
		{
			get
			{
				return this.fileName_;
			}
		}

		public override bool IsInitialized
		{
			get
			{
				return true;
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
				if (this.hasFileData)
				{
					num += CodedOutputStream.ComputeBytesSize(1, this.FileData);
				}
				if (this.hasExtInfo)
				{
					num += CodedOutputStream.ComputeStringSize(2, this.ExtInfo);
				}
				if (this.hasFileName)
				{
					num += CodedOutputStream.ComputeStringSize(3, this.FileName);
				}
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		private WXAppExtendMessageP()
		{
		}

		public override void WriteTo(ICodedOutputStream output)
		{
			int arg_06_0 = this.SerializedSize;
			string[] wXAppExtendMessagePFieldNames = WXAppExtendMessageP._wXAppExtendMessagePFieldNames;
			if (this.hasFileData)
			{
				output.WriteBytes(1, wXAppExtendMessagePFieldNames[1], this.FileData);
			}
			if (this.hasExtInfo)
			{
				output.WriteString(2, wXAppExtendMessagePFieldNames[0], this.ExtInfo);
			}
			if (this.hasFileName)
			{
				output.WriteString(3, wXAppExtendMessagePFieldNames[2], this.FileName);
			}
		}

		public override int GetHashCode()
		{
			int num = base.GetType().GetHashCode();
			if (this.hasFileData)
			{
				num ^= this.fileData_.GetHashCode();
			}
			if (this.hasExtInfo)
			{
				num ^= this.extInfo_.GetHashCode();
			}
			if (this.hasFileName)
			{
				num ^= this.fileName_.GetHashCode();
			}
			return num;
		}

		public override bool Equals(object obj)
		{
			WXAppExtendMessageP wXAppExtendMessageP = obj as WXAppExtendMessageP;
			return wXAppExtendMessageP != null && this.hasFileData == wXAppExtendMessageP.hasFileData && (!this.hasFileData || this.fileData_.Equals(wXAppExtendMessageP.fileData_)) && this.hasExtInfo == wXAppExtendMessageP.hasExtInfo && (!this.hasExtInfo || this.extInfo_.Equals(wXAppExtendMessageP.extInfo_)) && this.hasFileName == wXAppExtendMessageP.hasFileName && (!this.hasFileName || this.fileName_.Equals(wXAppExtendMessageP.fileName_));
		}

		public override void PrintTo(TextWriter writer)
		{
			GeneratedMessageLite<WXAppExtendMessageP, WXAppExtendMessageP.Builder>.PrintField("FileData", this.hasFileData, this.fileData_, writer);
			GeneratedMessageLite<WXAppExtendMessageP, WXAppExtendMessageP.Builder>.PrintField("ExtInfo", this.hasExtInfo, this.extInfo_, writer);
			GeneratedMessageLite<WXAppExtendMessageP, WXAppExtendMessageP.Builder>.PrintField("FileName", this.hasFileName, this.fileName_, writer);
		}

		public static WXAppExtendMessageP ParseFrom(byte[] data)
		{
			return WXAppExtendMessageP.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		private WXAppExtendMessageP MakeReadOnly()
		{
			return this;
		}

		public static WXAppExtendMessageP.Builder CreateBuilder()
		{
			return new WXAppExtendMessageP.Builder();
		}

		public override WXAppExtendMessageP.Builder ToBuilder()
		{
			return WXAppExtendMessageP.CreateBuilder(this);
		}

		public override WXAppExtendMessageP.Builder CreateBuilderForType()
		{
			return new WXAppExtendMessageP.Builder();
		}

		public static WXAppExtendMessageP.Builder CreateBuilder(WXAppExtendMessageP prototype)
		{
			return new WXAppExtendMessageP.Builder(prototype);
		}

		static WXAppExtendMessageP()
		{
			WXAppExtendMessageP.defaultInstance = new WXAppExtendMessageP().MakeReadOnly();
			WXAppExtendMessageP._wXAppExtendMessagePFieldNames = new string[]
			{
				"ExtInfo",
				"FileData",
				"FileName"
			};
			WXAppExtendMessageP._wXAppExtendMessagePFieldTags = new uint[]
			{
				18u,
				10u,
				26u
			};
			object.ReferenceEquals(MicroMsg.sdk.protobuf.Proto.WXAppExtendMessageP.Descriptor, null);
		}
	}
}
