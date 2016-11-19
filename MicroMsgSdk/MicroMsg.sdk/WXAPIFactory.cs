using System;

namespace MicroMsg.sdk
{
	public class WXAPIFactory
	{
		public static IWXAPI CreateWXAPI(string appID)
		{
			return new WXApiImplV1(appID);
		}
	}
}
