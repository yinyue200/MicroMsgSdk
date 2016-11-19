using Google.ProtocolBuffers;
using MicroMsg.sdk.protobuf;
using System;

namespace MicroMsg.sdk
{
	public class WXEmojiMessage : WXBaseMessage
	{
		private const string TAG = "MicroMsg.SDK.WXEmojiMessage";

		private const int CONTENT_LENGTH_LIMIT = 10485760;

		public byte[] EmojiData;

		public WXEmojiMessage()
		{
		}

		public WXEmojiMessage(byte[] emojiData)
		{
			this.EmojiData = emojiData;
		}

		public override int Type()
		{
			return 8;
		}

		internal override bool ValidateData()
		{
			if (!base.ValidateData())
			{
				return false;
			}
			if (this.EmojiData == null || this.EmojiData.Length == 0)
			{
				throw new WXException(1, "EmojiData is invalid.");
			}
			if (this.EmojiData != null && this.EmojiData.Length > 10485760)
			{
				throw new WXException(1, "EmojiData is invalid.");
			}
			return true;
		}

		internal override object ToProto()
		{
			WXEmojiMessageP.Builder builder = WXEmojiMessageP.CreateBuilder();
			builder.EmojiData = ByteString.CopyFrom(this.EmojiData);
			WXMessageP.Builder builder2 = WXMessageP.CreateBuilder();
			builder2.Type = (uint)this.Type();
			builder2.Title = this.Title;
			builder2.Description = this.Description;
			builder2.ThumbData = ByteString.CopyFrom(this.ThumbData);
			builder2.EmojiMessage = builder.Build();
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
			if (wXMessageP.EmojiMessage != null)
			{
				this.EmojiData = wXMessageP.EmojiMessage.EmojiData.ToByteArray();
			}
		}
	}
}
