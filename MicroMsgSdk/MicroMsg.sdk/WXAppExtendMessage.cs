using Google.ProtocolBuffers;
using MicroMsg.sdk.protobuf;
using System;

namespace MicroMsg.sdk
{
	public class WXAppExtendMessage : WXBaseMessage
	{
		private const string TAG = "MicroMsg.SDK.WXAppExtendMessage";

		private const int EXTINFO_Length_LIMIT = 2048;

		private const int PATH_Length_LIMIT = 10240;

		private const int CONTENT_Length_LIMIT = 10485760;

		public string ExtInfo = "";

		public string FileName = "";

		public byte[] FileData = new byte[0];

		public WXAppExtendMessage(string extInfo, string fileName, byte[] fileData)
		{
			this.ExtInfo = extInfo;
			this.FileData = fileData;
			this.FileName = fileName;
		}

		public WXAppExtendMessage()
		{
		}

		public override int Type()
		{
			return 7;
		}

		internal override bool ValidateData()
		{
			if (!base.ValidateData())
			{
				return false;
			}
			if ((this.ExtInfo == null || this.ExtInfo.Length == 0) && (this.FileName == null || this.FileName.Length == 0) && (this.FileData == null || this.FileData.Length == 0))
			{
				throw new WXException(1, "All arguments is null.");
			}
			if (this.ExtInfo != null && this.ExtInfo.Length > 2048)
			{
				throw new WXException(1, "ExtInfo is invalid.");
			}
			if (this.FileName != null && this.FileName.Length > 10240)
			{
				throw new WXException(1, "FilePath is invalid.");
			}
			if (this.FileData != null && this.FileData.Length > 10485760)
			{
				throw new WXException(1, "FileData is invalid.");
			}
			return true;
		}

		internal override object ToProto()
		{
			WXAppExtendMessageP.Builder builder = WXAppExtendMessageP.CreateBuilder();
			builder.FileData = ByteString.CopyFrom(this.FileData);
			builder.ExtInfo = this.ExtInfo;
			builder.FileName = this.FileName;
			WXMessageP.Builder builder2 = WXMessageP.CreateBuilder();
			builder2.Type = (uint)this.Type();
			builder2.Title = this.Title;
			builder2.Description = this.Description;
			builder2.ThumbData = ByteString.CopyFrom(this.ThumbData);
			builder2.AppExtendMessage = builder.Build();
			return builder2.Build();
		}

		internal override void FromProto(object protoObj)
		{
			if (protoObj == null)
			{
				return;
			}
			WXMessageP wXMessageP = protoObj as WXMessageP;
			if (wXMessageP == null)
			{
				return;
			}
			this.Title = wXMessageP.Title;
			this.Description = wXMessageP.Description;
			this.ThumbData = wXMessageP.ThumbData.ToByteArray();
			if (wXMessageP.AppExtendMessage != null)
			{
				this.FileData = wXMessageP.AppExtendMessage.FileData.ToByteArray();
				this.ExtInfo = wXMessageP.AppExtendMessage.ExtInfo;
				this.FileName = wXMessageP.AppExtendMessage.FileName;
			}
		}
	}
}
