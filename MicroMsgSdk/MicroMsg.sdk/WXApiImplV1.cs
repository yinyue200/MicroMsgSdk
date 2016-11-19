using System;
using Windows.Storage;
using Windows.System;

namespace MicroMsg.sdk
{
	internal class WXApiImplV1 : IWXAPI
	{
		private const string TEMP_FILE_NAME = "wp";

		private string mAppID;

		internal WXApiImplV1(string appID)
		{
			this.mAppID = appID;
		}

		public async void OpenWXApp()
		{
			await Launcher.LaunchUriAsync(new Uri("wechat:LaunchWechat?target=MainPage"));
		}

		public bool SendReq(BaseReq request, string targetAppID = "wechat")
		{
			if (request == null)
			{
				throw new WXException(1, "Req can't be null.");
			}
			if (string.IsNullOrEmpty(targetAppID))
			{
				throw new WXException(1, "targetAppID can't be empty.");
			}
			TransactData transactData = new TransactData();
			transactData.Req = request;
			transactData.AppID = this.mAppID;
			transactData.ConmandID = request.Type();
			transactData.SdkVersion = "1.5";
			transactData.CheckContent = WXApiImplV1.getCheckContent();
			transactData.CheckSummary = WXApiImplV1.getCheckSummary(transactData.CheckContent, transactData.SdkVersion, transactData.AppID);
			if (string.IsNullOrEmpty(request.Transaction))
			{
				request.Transaction = WXApiImplV1.getTransactionId();
			}
			if (!FileUtil.dirExists("wechat_sdk"))
			{
				FileUtil.createDir("wechat_sdk");
			}
			string text = "wechat_sdk\\wp." + targetAppID;
			if (FileUtil.fileExists(text))
			{
				FileUtil.deleteFile(text);
			}
			if (transactData.ValidateData(false))
			{
				try
				{
					TransactData.WriteToFile(transactData, text);
					this.sendOut(text, targetAppID);
					return true;
				}
				catch (Exception ex)
				{
					throw new WXException(0, ex.Message);
				}
				//return false;
			}
			return false;
		}

		public bool SendResp(BaseResp response, string targetAppID)
		{
			if (response == null)
			{
				throw new WXException(1, "Resp can't be null.");
			}
			if (string.IsNullOrEmpty(targetAppID))
			{
				throw new WXException(1, "targetAppID can't be empty.");
			}
			TransactData transactData = new TransactData();
			transactData.Resp = response;
			transactData.AppID = this.mAppID;
			transactData.ConmandID = response.Type();
			transactData.SdkVersion = "1.5";
			transactData.CheckContent = WXApiImplV1.getCheckContent();
			transactData.CheckSummary = WXApiImplV1.getCheckSummary(transactData.CheckContent, transactData.SdkVersion, transactData.AppID);
			if (string.IsNullOrEmpty(response.Transaction))
			{
				response.Transaction = WXApiImplV1.getTransactionId();
			}
			if (!FileUtil.dirExists("wechat_sdk"))
			{
				FileUtil.createDir("wechat_sdk");
			}
			string text = "wechat_sdk\\wp." + targetAppID;
			if (FileUtil.fileExists(text))
			{
				FileUtil.deleteFile(text);
			}
			if (transactData.ValidateData(false))
			{
				try
				{
					TransactData.WriteToFile(transactData, text);
					this.sendOut(text, targetAppID);
					return true;
				}
				catch (Exception ex)
				{
					throw new WXException(0, ex.Message);
				}
				//return false;
			}
			return false;
		}

		private async void sendOut(string filePath, string targetAppID)
		{
			StorageFolder localFolder = ApplicationData.Current.LocalFolder;
			StorageFile storageFile = await localFolder.GetFileAsync(filePath);
			if (storageFile != null)
			{
				bool flag = await Launcher.LaunchFileAsync(storageFile);
			}
		}

		private static string getCheckContent()
		{
			DateTime dateTime = DateTime.Now.ToUniversalTime();
			DateTime dateTime2 = new DateTime(1970, 1, 1);
			double totalMilliseconds = dateTime.Subtract(dateTime2).TotalMilliseconds;
			return Convert.ToString(totalMilliseconds);
		}

		internal static string getCheckSummary(string content, string sdkVersion, string appID)
		{
			string input = WXApiImplV1.trimToEmpty(content) + WXApiImplV1.trimToEmpty(sdkVersion) + WXApiImplV1.trimToEmpty(appID);
			return MD5Util.GetHashString(input);
		}

		private static string trimToEmpty(string s)
		{
			if (s != null)
			{
				return s.Trim();
			}
			return "";
		}

		private static string getTransactionId()
		{
			DateTime dateTime = DateTime.Now.ToUniversalTime();
			DateTime dateTime2 = new DateTime(1970, 1, 1);
			double totalMilliseconds = dateTime.Subtract(dateTime2).TotalMilliseconds;
			return Convert.ToString(totalMilliseconds);
		}
	}
}
