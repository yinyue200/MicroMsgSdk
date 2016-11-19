using Google.ProtocolBuffers;
using MicroMsg.sdk.protobuf;
using System;

namespace MicroMsg.sdk
{
	public class WXTextMessage : WXBaseMessage
	{
		private const string TAG = "MicroMsg.SDK.WXTextMessage";

		private const int LENGTH_LIMIT = 10240;

		public string Text;

		public WXTextMessage()
		{
		}

		public WXTextMessage(string text)
		{
			this.Text = text;
		}

		public override int Type()
		{
			return 1;
		}

		internal override bool ValidateData()
		{
			if (!base.ValidateData())
			{
				return false;
			}
			if (this.Text == null || this.Text.Length == 0 || this.Text.Length > 10240)
			{
				throw new WXException(1, "Text is invalid.");
			}
			return true;
		}

		internal override object ToProto()
		{
			WXTextMessageP.Builder builder = WXTextMessageP.CreateBuilder();
			builder.Text = this.Text;
			WXMessageP.Builder builder2 = WXMessageP.CreateBuilder();
			builder2.Type = (uint)this.Type();
			builder2.Title = this.Title;
			builder2.Description = this.Description;
			if (this.ThumbData == null)
			{
				this.ThumbData = new byte[0];
			}
			builder2.ThumbData = ByteString.CopyFrom(this.ThumbData);
			builder2.TextMessage = builder.Build();
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
			if (wXMessageP.TextMessage != null)
			{
				this.Text = wXMessageP.TextMessage.Text;
			}
		}
	}
}
