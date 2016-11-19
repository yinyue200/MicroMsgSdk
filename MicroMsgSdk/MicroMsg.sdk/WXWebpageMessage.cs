using Google.ProtocolBuffers;
using MicroMsg.sdk.protobuf;
using System;

namespace MicroMsg.sdk
{
	public class WXWebpageMessage : WXBaseMessage
	{
		private const string TAG = "MicroMsg.SDK.WXWebpageMessage";

		private const int LENGTH_LIMIT = 10240;

		public string WebpageUrl;

		public WXWebpageMessage()
		{
		}

		public WXWebpageMessage(string url)
		{
			this.WebpageUrl = url;
		}

		public override int Type()
		{
			return 5;
		}

		internal override bool ValidateData()
		{
			if (!base.ValidateData())
			{
				return false;
			}
			if (this.WebpageUrl == null || this.WebpageUrl.Length == 0 || this.WebpageUrl.Length > 10240)
			{
				throw new WXException(1, "WebpageUrl is invalid.");
			}
			return true;
		}

		internal override object ToProto()
		{
			WXWebpageMessageP.Builder builder = WXWebpageMessageP.CreateBuilder();
			builder.WebpageUrl = this.WebpageUrl;
			WXMessageP.Builder builder2 = WXMessageP.CreateBuilder();
			builder2.Type = (uint)this.Type();
			builder2.Title = this.Title;
			builder2.Description = this.Description;
			builder2.ThumbData = ByteString.CopyFrom(this.ThumbData);
			builder2.WebpageMessage = builder.Build();
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
			if (wXMessageP.WebpageMessage != null)
			{
				this.WebpageUrl = wXMessageP.WebpageMessage.WebpageUrl;
			}
		}
	}
}
