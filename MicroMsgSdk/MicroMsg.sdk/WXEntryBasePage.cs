using System;
using System.Net;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MicroMsg.sdk
{
	public class WXEntryBasePage : Page
	{
		private bool bIsHandled;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (!this.bIsHandled)
            {
                string text = null;
                var QueryString = ParseUrl(e.Parameter.ToString());
                if (QueryString.Keys.Contains("fileToken"))
                {
                    text = QueryString["fileToken"];
                }
                if (!string.IsNullOrEmpty(text))
                {
                    this.parseData(text);
                }
                this.bIsHandled = true;
            }
        }
        /// <summary>
        /// 分析 url 字符串中的参数信息
        /// </summary>
        /// <param name="url">输入的 URL</param>
        /// <param name="baseUrl">输出 URL 的基础部分</param>
        /// <param name="nvc">输出分析后得到的 (参数名,参数值) 的集合</param>
        public static System.Collections.Generic.IDictionary<string, string> ParseUrl(string url)
        {
            if (url == null)
                throw new System.ArgumentNullException("url");

            System.Collections.Generic.IDictionary<string, string> nvc = new System.Collections.Generic.Dictionary<string, string>();

            if (url == "")
                return nvc;

            int questionMarkIndex = url.IndexOf('?');

            if (questionMarkIndex == -1)
            {
                return nvc;
            }
            if (questionMarkIndex == url.Length - 1)
                return nvc;
            string ps = url.Substring(questionMarkIndex + 1);

            // 开始分析参数对    
            System.Text.RegularExpressions.Regex re = new System.Text.RegularExpressions.Regex(@"(^|&)?(\w+)=([^&]+)(&|$)?");
            System.Text.RegularExpressions.MatchCollection mc = re.Matches(ps);

            foreach (System.Text.RegularExpressions.Match m in mc)
            {
                nvc.Add(m.Result("$2").ToLower(), WebUtility.UrlDecode(m.Result("$3")));
            }
            return nvc;
        }
        private async void parseData(string fileToken)
		{
			try
			{
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
				if (!FileUtil.dirExists("wechat_sdk"))
				{
					FileUtil.createDir("wechat_sdk");
				}
                await (await SharedStorageAccessManager.RedeemTokenForFileAsync(fileToken)).CopyAsync(localFolder, "wechat_sdk\\wp.wechat", NameCollisionOption.ReplaceExisting);
				//await SharedStorageAccessManager.CopySharedFileAsync(localFolder, "wechat_sdk\\wp.wechat", 1, fileToken);
				if (FileUtil.fileExists("wechat_sdk\\wp.wechat"))
				{
					TransactData transactData = TransactData.ReadFromFile("wechat_sdk\\wp.wechat");
					if (!transactData.ValidateData(true))
					{
                        await new Windows.UI.Popups.MessageDialog("数据验证失败").ShowAsync(); 
					}
					else if (!transactData.CheckSupported())
					{
                        await new Windows.UI.Popups.MessageDialog("当前版本不支持该请求").ShowAsync();
					}
					else if (transactData.Req != null)
					{
						if (transactData.Req.Type() == 3)
						{
							this.On_GetMessageFromWX_Request(transactData.Req as GetMessageFromWX.Req);
						}
						else if (transactData.Req.Type() == 4)
						{
							this.On_ShowMessageFromWX_Request(transactData.Req as ShowMessageFromWX.Req);
						}
					}
					else if (transactData.Resp != null)
					{
						if (transactData.Resp.Type() == 2)
						{
							this.On_SendMessageToWX_Response(transactData.Resp as SendMessageToWX.Resp);
						}
						else if (transactData.Resp.Type() == 1)
						{
							this.On_SendAuth_Response(transactData.Resp as SendAuth.Resp);
						}
						else if (transactData.Resp.Type() == 5)
						{
							this.On_SendPay_Response(transactData.Resp as SendPay.Resp);
						}
					}
				}
			}
			catch
			{
                await new Windows.UI.Popups.MessageDialog("未知错误").ShowAsync();
            }
        }

		public virtual void On_GetMessageFromWX_Request(GetMessageFromWX.Req request)
		{
		}

		public virtual void On_SendMessageToWX_Response(SendMessageToWX.Resp response)
		{
		}

		public virtual void On_SendAuth_Response(SendAuth.Resp response)
		{
		}

		public virtual void On_ShowMessageFromWX_Request(ShowMessageFromWX.Req request)
		{
		}

		public virtual void On_SendPay_Response(SendPay.Resp response)
		{
		}
	}
}
