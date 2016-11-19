using Google.ProtocolBuffers;
using MicroMsg.sdk.protobuf.Proto;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace MicroMsg.sdk.protobuf
{

    public sealed class WXFileMessageP : GeneratedMessageLite<WXFileMessageP, WXFileMessageP.Builder>
	{
		
		public sealed class Builder : GeneratedBuilderLite<WXFileMessageP, WXFileMessageP.Builder>
		{
			private bool resultIsReadOnly;

			private WXFileMessageP result;

			protected override WXFileMessageP.Builder ThisBuilder
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

			protected override WXFileMessageP MessageBeingBuilt
			{
				get
				{
					return this.PrepareBuilder();
				}
			}

			public override WXFileMessageP DefaultInstanceForType
			{
				get
				{
					return WXFileMessageP.DefaultInstance;
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
				this.result = WXFileMessageP.DefaultInstance;
				this.resultIsReadOnly = true;
			}

			internal Builder(WXFileMessageP cloneFrom)
			{
				this.result = cloneFrom;
				this.resultIsReadOnly = true;
			}

			private WXFileMessageP PrepareBuilder()
			{
				if (this.resultIsReadOnly)
				{
					WXFileMessageP other = this.result;
					this.result = new WXFileMessageP();
					this.resultIsReadOnly = false;
					this.MergeFrom(other);
				}
				return this.result;
			}

			public override WXFileMessageP.Builder Clear()
			{
				this.result = WXFileMessageP.DefaultInstance;
				this.resultIsReadOnly = true;
				return this;
			}

			public override WXFileMessageP.Builder Clone()
			{
				if (this.resultIsReadOnly)
				{
					return new WXFileMessageP.Builder(this.result);
				}
				return new WXFileMessageP.Builder().MergeFrom(this.result);
			}

			public override WXFileMessageP BuildPartial()
			{
				if (this.resultIsReadOnly)
				{
					return this.result;
				}
				this.resultIsReadOnly = true;
				return this.result.MakeReadOnly();
			}

			public override WXFileMessageP.Builder MergeFrom(IMessageLite other)
			{
				if (other is WXFileMessageP)
				{
					return this.MergeFrom((WXFileMessageP)other);
				}
				base.MergeFrom(other);
				return this;
			}

			public override WXFileMessageP.Builder MergeFrom(WXFileMessageP other)
			{
				return this;
			}

			public override WXFileMessageP.Builder MergeFrom(ICodedInputStream input)
			{
				return this.MergeFrom(input, ExtensionRegistry.Empty);
			}

			public override WXFileMessageP.Builder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry)
			{
				this.PrepareBuilder();
				uint num;
				string text;
				while (input.ReadTag(out num, out text))
				{
					if (num == 0u && text != null)
					{
						int num2 = Array.BinarySearch<string>(WXFileMessageP._wXFileMessagePFieldNames, text, StringComparer.Ordinal);
						if (num2 < 0)
						{
							this.ParseUnknownField(input, extensionRegistry, num, text);
							continue;
						}
						num = WXFileMessageP._wXFileMessagePFieldTags[num2];
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
							this.result.hasFileName = input.ReadString(ref this.result.fileName_);
						}
					}
					else
					{
						this.result.hasFileData = input.ReadBytes(ref this.result.fileData_);
					}
				}
				return this;
			}

			public WXFileMessageP.Builder SetFileData(ByteString value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasFileData = true;
				this.result.fileData_ = value;
				return this;
			}

			public WXFileMessageP.Builder ClearFileData()
			{
				this.PrepareBuilder();
				this.result.hasFileData = false;
				this.result.fileData_ = ByteString.Empty;
				return this;
			}

			public WXFileMessageP.Builder SetFileName(string value)
			{
				ThrowHelper.ThrowIfNull(value, "value");
				this.PrepareBuilder();
				this.result.hasFileName = true;
				this.result.fileName_ = value;
				return this;
			}

			public WXFileMessageP.Builder ClearFileName()
			{
				this.PrepareBuilder();
				this.result.hasFileName = false;
				this.result.fileName_ = "";
				return this;
			}
		}

		public const int FileDataFieldNumber = 1;

		public const int FileNameFieldNumber = 2;

		private static readonly WXFileMessageP defaultInstance;

		private static readonly string[] _wXFileMessagePFieldNames;

		private static readonly uint[] _wXFileMessagePFieldTags;

		private bool hasFileData;

		private ByteString fileData_ = ByteString.Empty;

		private bool hasFileName;

		private string fileName_ = "";

		private int memoizedSerializedSize = -1;

		public static WXFileMessageP DefaultInstance
		{
			get
			{
				return WXFileMessageP.defaultInstance;
			}
		}

		public override WXFileMessageP DefaultInstanceForType
		{
			get
			{
				return WXFileMessageP.DefaultInstance;
			}
		}

		protected override WXFileMessageP ThisMessage
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
				return this.hasFileData && this.hasFileName;
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
				if (this.hasFileName)
				{
					num += CodedOutputStream.ComputeStringSize(2, this.FileName);
				}
				this.memoizedSerializedSize = num;
				return num;
			}
		}

		private WXFileMessageP()
		{
		}

		public override void WriteTo(ICodedOutputStream output)
		{
			int arg_06_0 = this.SerializedSize;
			string[] wXFileMessagePFieldNames = WXFileMessageP._wXFileMessagePFieldNames;
			if (this.hasFileData)
			{
				output.WriteBytes(1, wXFileMessagePFieldNames[0], this.FileData);
			}
			if (this.hasFileName)
			{
				output.WriteString(2, wXFileMessagePFieldNames[1], this.FileName);
			}
		}

		public override int GetHashCode()
		{
			int num = base.GetType().GetHashCode();
			if (this.hasFileData)
			{
				num ^= this.fileData_.GetHashCode();
			}
			if (this.hasFileName)
			{
				num ^= this.fileName_.GetHashCode();
			}
			return num;
		}

		public override bool Equals(object obj)
		{
			WXFileMessageP wXFileMessageP = obj as WXFileMessageP;
			return wXFileMessageP != null && this.hasFileData == wXFileMessageP.hasFileData && (!this.hasFileData || this.fileData_.Equals(wXFileMessageP.fileData_)) && this.hasFileName == wXFileMessageP.hasFileName && (!this.hasFileName || this.fileName_.Equals(wXFileMessageP.fileName_));
		}

		public override void PrintTo(TextWriter writer)
		{
			GeneratedMessageLite<WXFileMessageP, WXFileMessageP.Builder>.PrintField("FileData", this.hasFileData, this.fileData_, writer);
			GeneratedMessageLite<WXFileMessageP, WXFileMessageP.Builder>.PrintField("FileName", this.hasFileName, this.fileName_, writer);
		}

		public static WXFileMessageP ParseFrom(byte[] data)
		{
			return WXFileMessageP.CreateBuilder().MergeFrom(data).BuildParsed();
		}

		private WXFileMessageP MakeReadOnly()
		{
			return this;
		}

		public static WXFileMessageP.Builder CreateBuilder()
		{
			return new WXFileMessageP.Builder();
		}

		public override WXFileMessageP.Builder ToBuilder()
		{
			return WXFileMessageP.CreateBuilder(this);
		}

		public override WXFileMessageP.Builder CreateBuilderForType()
		{
			return new WXFileMessageP.Builder();
		}

		public static WXFileMessageP.Builder CreateBuilder(WXFileMessageP prototype)
		{
			return new WXFileMessageP.Builder(prototype);
		}

		static WXFileMessageP()
		{
			WXFileMessageP.defaultInstance = new WXFileMessageP().MakeReadOnly();
			WXFileMessageP._wXFileMessagePFieldNames = new string[]
			{
				"FileData",
				"FileName"
			};
			WXFileMessageP._wXFileMessagePFieldTags = new uint[]
			{
				10u,
				18u
			};
			object.ReferenceEquals(MicroMsg.sdk.protobuf.Proto.WXFileMessageP.Descriptor, null);
		}
	}
}
