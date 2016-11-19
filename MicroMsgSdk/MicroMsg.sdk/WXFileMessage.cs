using Google.ProtocolBuffers;
using MicroMsg.sdk.protobuf;
using System;

namespace MicroMsg.sdk
{
	public class WXFileMessage : WXBaseMessage
	{
		private const string TAG = "MicroMsg.SDK.WXFileMessage";

		private const int CONTENT_LENGTH_LIMIT = 10485760;

		public byte[] FileData;

		public string FileName;

		public WXFileMessage()
		{
		}

		public WXFileMessage(byte[] fileData, string FileName)
		{
			this.FileData = fileData;
			this.FileName = FileName;
		}

		public override int Type()
		{
			return 6;
		}

		internal override bool ValidateData()
		{
			if (!base.ValidateData())
			{
				return false;
			}
			if (this.FileName == null || this.FileName.Length == 0)
			{
				throw new WXException(1, "FileName is invalid.");
			}
			if (this.FileData != null && (this.FileData.Length == 0 || this.FileData.Length > 10485760))
			{
				throw new WXException(1, "FileData is invalid.");
			}
			return true;
		}

		internal override object ToProto()
		{
			WXFileMessageP.Builder builder = WXFileMessageP.CreateBuilder();
			builder.FileData = ByteString.CopyFrom(this.FileData);
			builder.FileName = this.FileName;
			WXMessageP.Builder builder2 = WXMessageP.CreateBuilder();
			builder2.Type = (uint)this.Type();
			builder2.Title = this.Title;
			builder2.Description = this.Description;
			builder2.ThumbData = ByteString.CopyFrom(this.ThumbData);
			builder2.FileMessage = builder.Build();
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
			if (wXMessageP.FileMessage != null)
			{
				this.FileData = wXMessageP.FileMessage.FileData.ToByteArray();
				this.FileName = wXMessageP.FileMessage.FileName;
			}
		}
	}
}
