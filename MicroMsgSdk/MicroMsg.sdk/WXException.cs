using System;
using System.Collections.Generic;
using System.Globalization;

namespace MicroMsg.sdk
{
	public class WXException : Exception
	{
		public const int ERR_OTHER = 0;

		public const int ERR_DATA_ILLEGA = 1;

		public const int ERR_NOT_SUPPORTED = 2;

		public const int ERR_PACKAGE_ERR = 3;

		private static Dictionary<string, string> errStringMap;

		public WXException(int errCode, string appendString = "") : base(WXException.GetErrString(errCode, appendString))
		{
			base.HResult =errCode;
		}

		private static void initErrStringMap()
		{
			WXException.errStringMap = new Dictionary<string, string>();
			WXException.errStringMap.Add(0 + "_en", "Unknown error:");
			WXException.errStringMap.Add(0 + "_cn", "未知错误");
			WXException.errStringMap.Add(0 + "_tw", "未知錯誤");
			WXException.errStringMap.Add(1 + "_en", "Invalid data format");
			WXException.errStringMap.Add(1 + "_cn", "数据格式不合法");
			WXException.errStringMap.Add(1 + "_tw", "資料格式無效");
			WXException.errStringMap.Add(2 + "_en", "Request not supported by your current version");
			WXException.errStringMap.Add(2 + "_cn", "当前版本不支持该请求");
			WXException.errStringMap.Add(2 + "_tw", "當前版本不支持該請求");
			WXException.errStringMap.Add(3 + "_en", "打包数据时发生错误");
			WXException.errStringMap.Add(3 + "_cn", "打包数据时发生错误");
			WXException.errStringMap.Add(3 + "_tw", "打包数据时发生错误");
		}

		public static string GetErrString(int code, string appendString = "")
		{
			if (WXException.errStringMap == null)
			{
				WXException.initErrStringMap();
			}
			if (appendString == null)
			{
				appendString = "";
			}
			if (code > 3 || code < 0)
			{
				code = 0;
			}
			if (WXException.errStringMap != null)
			{
				string text = WXException.errStringMap[code + "_" + WXException.getLanguage()];
				if (!string.IsNullOrEmpty(appendString))
				{
					text = text + ": " + appendString;
				}
				return text;
			}
			return string.Empty;
		}

		private static string getLanguage()
		{
			RegionInfo currentRegion = RegionInfo.CurrentRegion;
			if (currentRegion.Name == "CN")
			{
				return "cn";
			}
			if (currentRegion.Name == "TW")
			{
				return "tw";
			}
			return "en";
		}
	}
}
