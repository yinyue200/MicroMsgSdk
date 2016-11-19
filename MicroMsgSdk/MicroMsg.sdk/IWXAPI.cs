using System;

namespace MicroMsg.sdk
{
	public interface IWXAPI
	{
		void OpenWXApp();

		bool SendReq(BaseReq request, string targetAppID = "wechat");

		bool SendResp(BaseResp response, string targetAppID = "wechat");
	}
}
