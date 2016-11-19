using Google.ProtocolBuffers;
using MicroMsg.sdk.protobuf;
using System;

namespace MicroMsg.sdk
{
	public class WXImageMessage : WXBaseMessage
	{
		private const string TAG = "MicroMsg.SDK.WXImageMessage";

		private const int CONTENT_LENGTH_LIMIT = 10485760;

		private const int PATH_LENGTH_LIMIT = 10240;

		private const int URL_LENGTH_LIMIT = 10240;

		public byte[] ImageData = new byte[0];

		public string ImageUrl = "";

		public WXImageMessage()
		{
		}

		public WXImageMessage(byte[] imageData)
		{
			this.ImageData = imageData;
		}

		public WXImageMessage(string imageUrl)
		{
			this.ImageUrl = imageUrl;
		}

		public override int Type()
		{
			return 2;
		}

		internal override bool ValidateData()
		{
			if (!base.ValidateData())
			{
				return false;
			}
			if ((this.ImageData == null || this.ImageData.Length == 0) && (this.ImageUrl == null || this.ImageUrl.Length == 0))
			{
				throw new WXException(1, "All arguments are null.");
			}
			if (this.ImageData != null && this.ImageData.Length > 10485760)
			{
				throw new WXException(1, "ImageData is invalid.");
			}
			if (this.ImageUrl != null && this.ImageUrl.Length > 10240)
			{
				throw new WXException(1, "ImageUrl is invalid.");
			}
			return true;
		}

		internal override object ToProto()
		{
			WXImageMessageP.Builder builder = WXImageMessageP.CreateBuilder();
			builder.ImageData = ByteString.CopyFrom(this.ImageData);
			builder.ImageUrl = this.ImageUrl;
			WXMessageP.Builder builder2 = WXMessageP.CreateBuilder();
			builder2.Type = (uint)this.Type();
			builder2.Title = this.Title;
			builder2.Description = this.Description;
			builder2.ThumbData = ByteString.CopyFrom(this.ThumbData);
			builder2.ImageMessage = builder.Build();
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
			if (wXMessageP.ImageMessage != null)
			{
				this.ImageData = wXMessageP.ImageMessage.ImageData.ToByteArray();
				this.ImageUrl = wXMessageP.ImageMessage.ImageUrl;
			}
		}
	}
}
