using System;

namespace MicroMsg.sdk
{
	public abstract class WXBaseMessage
	{
		private const string TAG = "MicroMsg.sdk.WXBaseMessage";

		private const int THUMB_LENGTH_LIMIT = 32768;

		private const int TITLE_LENGTH_LIMIT = 512;

		private const int DESCRIPTION_LENGTH_LIMIT = 1024;

		public const int TYPE_UNKNOWN = 0;

		public const int TYPE_TEXT = 1;

		public const int TYPE_IMAGE = 2;

		public const int TYPE_MUSIC = 3;

		public const int TYPE_VIDEO = 4;

		public const int TYPE_URL = 5;

		public const int TYPE_FILE = 6;

		public const int TYPE_APPDATA = 7;

		public const int TYPE_EMOJI = 8;

		public string Title = "";

		public string Description = "";

		public byte[] ThumbData = new byte[0];

		public void SetThumbImage(byte[] thumbData)
		{
			this.ThumbData = thumbData;
		}

		public abstract int Type();

		internal virtual bool ValidateData()
		{
			if (this.Title != null && this.Title.Length > 512)
			{
				throw new WXException(1, "Title is invalid.");
			}
			if (this.Description != null && this.Description.Length > 1024)
			{
				throw new WXException(1, "Description is invalid.");
			}
			if (this.ThumbData != null && this.ThumbData.Length > 32768)
			{
				throw new WXException(1, "ThumbData is invalid.");
			}
			return true;
		}

		internal abstract object ToProto();

		internal abstract void FromProto(object protoObj);

		internal static WXBaseMessage CreateMessage(int type)
		{
			WXBaseMessage result = null;
			switch (type)
			{
			case 1:
				result = new WXTextMessage();
				break;
			case 2:
				result = new WXImageMessage();
				break;
			case 3:
				result = new WXMusicMessage();
				break;
			case 4:
				result = new WXVideoMessage();
				break;
			case 5:
				result = new WXWebpageMessage();
				break;
			case 6:
				result = new WXFileMessage();
				break;
			case 7:
				result = new WXAppExtendMessage();
				break;
			case 8:
				result = new WXEmojiMessage();
				break;
			}
			return result;
		}
	}
}
