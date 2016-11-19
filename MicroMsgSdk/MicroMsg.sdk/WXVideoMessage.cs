using Google.ProtocolBuffers;
using MicroMsg.sdk.protobuf;
using System;

namespace MicroMsg.sdk
{
	public class WXVideoMessage : WXBaseMessage
	{
		private const string TAG = "MicroMsg.SDK.WXVideoMessage";

		private const int LENGTH_LIMIT = 10240;

		public string VideoUrl = "";

		public string VideoLowBandUrl = "";

		public override int Type()
		{
			return 4;
		}

		internal override bool ValidateData()
		{
			if (!base.ValidateData())
			{
				return false;
			}
			if ((this.VideoUrl == null || this.VideoUrl.Length == 0) && (this.VideoLowBandUrl == null || this.VideoLowBandUrl.Length == 0))
			{
				throw new WXException(1, "Both arguments are null.");
			}
			if (this.VideoUrl != null && this.VideoUrl.Length > 10240)
			{
				throw new WXException(1, "VideoUrl is too long.");
			}
			if (this.VideoLowBandUrl != null && this.VideoLowBandUrl.Length > 10240)
			{
				throw new WXException(1, "VideoLowBandUrl is too long.");
			}
			return true;
		}

		internal override object ToProto()
		{
			WXVideoMessageP.Builder builder = WXVideoMessageP.CreateBuilder();
			builder.VideoUrl = this.VideoUrl;
			builder.VideoLowBandUrl = this.VideoLowBandUrl;
			WXMessageP.Builder builder2 = WXMessageP.CreateBuilder();
			builder2.Type = (uint)this.Type();
			builder2.Title = this.Title;
			builder2.Description = this.Description;
			builder2.ThumbData = ByteString.CopyFrom(this.ThumbData);
			builder2.VideoMessage = builder.Build();
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
			if (wXMessageP.VideoMessage != null)
			{
				this.VideoUrl = wXMessageP.VideoMessage.VideoUrl;
				this.VideoLowBandUrl = wXMessageP.VideoMessage.VideoLowBandUrl;
			}
		}
	}
}
