using System;

namespace MicroMsg.sdk
{
	public static class ConstantsAPI
	{
		public const string SDK_VERSION = "1.5";

		internal const byte SDK_MAIN_VERSION = 1;

		internal const byte SDK_SUB_VERSION = 5;

		public const int COMMAND_UNKNOWN = 0;

		public const int COMMAND_SENDAUTH = 1;

		public const int COMMAND_SENDMESSAGE_TO_WX = 2;

		public const int COMMAND_GETMESSAGE_FROM_WX = 3;

		public const int COMMAND_SHOWMESSAGE_FROM_WX = 4;

		public const int COMMAND_SENDPAY = 5;

		public const string WECHAT_APP_ID = "wechat";

		public const string THIRD_APP_ID = "wechatapp";

		public const string SDK_TEMP_FILE_PATH = "wechat_sdk\\wp.wechat";

		public const string SDK_TEMP_DIR_PATH = "wechat_sdk";
        /// <summary>
        /// 判断设备上是否安装了微信
        /// </summary>
        /// <returns></returns>
        public static async System.Threading.Tasks.Task<bool> CanOpenWXAppAsync()
        {
            return (await Windows.System.Launcher.FindFileHandlersAsync(".wechat")).Count > 0;
        }
    }
}
