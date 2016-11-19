using Google.ProtocolBuffers;
using MicroMsg.sdk.protobuf;
using System;

namespace MicroMsg.sdk
{
	public class WXMusicMessage : WXBaseMessage
	{
		private const string TAG = "MicroMsg.SDK.WXMusicMessage";

		private const int LENGTH_LIMIT = 10240;

		public string MusicUrl = "";

		public string MusicLowBandUrl = "";

		public override int Type()
		{
			return 3;
		}

		internal override bool ValidateData()
		{
			if (!base.ValidateData())
			{
				return false;
			}
			if ((this.MusicUrl == null || this.MusicUrl.Length == 0) && (this.MusicLowBandUrl == null || this.MusicLowBandUrl.Length == 0))
			{
				throw new WXException(1, "Both arguments are null.");
			}
			if (this.MusicUrl != null && this.MusicUrl.Length > 10240)
			{
				throw new WXException(1, "MusicUrl is too long.");
			}
			if (this.MusicLowBandUrl != null && this.MusicLowBandUrl.Length > 10240)
			{
				throw new WXException(1, "MusicLowBandUrl is too long.");
			}
			return true;
		}

		internal override object ToProto()
		{
			WXMusicMessageP.Builder builder = WXMusicMessageP.CreateBuilder();
			builder.MusicUrl = this.MusicUrl;
			builder.MusicLowBandUrl = this.MusicLowBandUrl;
			WXMessageP.Builder builder2 = WXMessageP.CreateBuilder();
			builder2.Type = (uint)this.Type();
			builder2.Title = this.Title;
			builder2.Description = this.Description;
			builder2.ThumbData = ByteString.CopyFrom(this.ThumbData);
			builder2.MusicMessage = builder.Build();
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
			if (wXMessageP.MusicMessage != null)
			{
				this.MusicUrl = wXMessageP.MusicMessage.MusicUrl;
				this.MusicLowBandUrl = wXMessageP.MusicMessage.MusicLowBandUrl;
			}
		}
	}
}
