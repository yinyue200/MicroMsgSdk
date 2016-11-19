using MicroMsg.sdk.protobuf;
using System;

namespace MicroMsg.sdk
{
	public class TransactData
	{
		public int ConmandID;

		public BaseReq Req;

		public BaseResp Resp;

		public string AppID;

		public string SdkVersion;

		public string CheckContent;

		public string CheckSummary;

		public bool ValidateData(bool checkSummary = true)
		{
			if (string.IsNullOrEmpty(this.AppID))
			{
				throw new WXException(1, "AppID can't be empty.");
			}
			if (string.IsNullOrEmpty(this.SdkVersion) || string.IsNullOrEmpty(this.CheckContent) || string.IsNullOrEmpty(this.CheckSummary))
			{
				return false;
			}
			if (this.Req == null && this.Resp == null)
			{
				return false;
			}
			if (this.Req != null && !this.Req.ValidateData())
			{
				return false;
			}
			if (this.Resp != null && !this.Resp.ValidateData())
			{
				return false;
			}
			if (checkSummary)
			{
				string checkSummary2 = WXApiImplV1.getCheckSummary(this.CheckContent, this.SdkVersion, this.AppID);
				if (checkSummary2 == null || !checkSummary2.Equals(this.CheckSummary, StringComparison.CurrentCultureIgnoreCase))
				{
					return false;
				}
			}
			return true;
		}

		public bool CheckSupported()
		{
			if (this.Req == null && this.Resp == null)
			{
				return false;
			}
			bool flag;
			switch (this.ConmandID)
			{
			case 1:
			case 2:
			case 3:
			case 4:
			case 5:
				flag = true;
				break;
			default:
				flag = false;
				break;
			}
			WXBaseMessage wXBaseMessage = null;
			if (this.Req != null && this.Req is SendMessageToWX.Req)
			{
				SendMessageToWX.Req req = this.Req as SendMessageToWX.Req;
				wXBaseMessage = req.Message;
			}
			if (this.Req != null && this.Req is ShowMessageFromWX.Req)
			{
				ShowMessageFromWX.Req req2 = this.Req as ShowMessageFromWX.Req;
				wXBaseMessage = req2.Message;
			}
			if (this.Resp != null && this.Resp is GetMessageFromWX.Resp)
			{
				GetMessageFromWX.Resp resp = this.Resp as GetMessageFromWX.Resp;
				wXBaseMessage = resp.Message;
			}
			if (wXBaseMessage != null)
			{
				flag &= (wXBaseMessage.Type() >= 0 && wXBaseMessage.Type() <= 8);
			}
			return flag;
		}

		internal TransactDataP ToProto()
		{
			TransactDataP.Builder builder = TransactDataP.CreateBuilder();
			builder.ConmandID = (uint)this.ConmandID;
			builder.AppID = this.AppID;
			builder.SdkVersion = this.SdkVersion;
			builder.CheckContent = this.CheckContent;
			builder.CheckSummary = this.CheckSummary;
			if (this.Req != null)
			{
				switch (this.Req.Type())
				{
				case 1:
					builder.AuthReq = (this.Req.ToProto() as SendAuthReq);
					break;
				case 2:
					builder.SendReq = (this.Req.ToProto() as SendMessageToWXReq);
					break;
				case 3:
					builder.GetReq = (this.Req.ToProto() as GetMessageFromWXReq);
					break;
				case 4:
					builder.ShowReq = (this.Req.ToProto() as ShowMessageFromWXReq);
					break;
				case 5:
					builder.PayReq = (this.Req.ToProto() as SendPayReqP);
					break;
				}
			}
			if (this.Resp != null)
			{
				switch (this.Resp.Type())
				{
				case 1:
					builder.AuthResp = (this.Resp.ToProto() as SendAuthResp);
					break;
				case 2:
					builder.SendResp = (this.Resp.ToProto() as SendMessageToWXResp);
					break;
				case 3:
					builder.GetResp = (this.Resp.ToProto() as GetMessageFromWXResp);
					break;
				case 4:
					builder.ShowResp = (this.Resp.ToProto() as ShowMessageFromWXResp);
					break;
				case 5:
					builder.PayResp = (this.Resp.ToProto() as SendPayRespP);
					break;
				}
			}
			return builder.Build();
		}

		internal void FromProto(object protoObj)
		{
			if (protoObj == null)
			{
				return;
			}
			TransactDataP transactDataP = protoObj as TransactDataP;
			if (transactDataP == null)
			{
				return;
			}
			this.ConmandID = (int)transactDataP.ConmandID;
			this.AppID = transactDataP.AppID;
			this.SdkVersion = transactDataP.SdkVersion;
			this.CheckContent = transactDataP.CheckContent;
			this.CheckSummary = transactDataP.CheckSummary;
			if (!string.IsNullOrEmpty(transactDataP.GetReq.Base.Transaction))
			{
				this.Req = new GetMessageFromWX.Req();
				this.Req.FromProto(transactDataP.GetReq);
			}
			if (!string.IsNullOrEmpty(transactDataP.AuthReq.Base.Transaction))
			{
				this.Req = new SendAuth.Req();
				this.Req.FromProto(transactDataP.AuthReq);
			}
			if (!string.IsNullOrEmpty(transactDataP.SendReq.Base.Transaction))
			{
				this.Req = new SendMessageToWX.Req();
				this.Req.FromProto(transactDataP.SendReq);
			}
			if (!string.IsNullOrEmpty(transactDataP.ShowReq.Base.Transaction))
			{
				this.Req = new ShowMessageFromWX.Req();
				this.Req.FromProto(transactDataP.ShowReq);
			}
			if (!string.IsNullOrEmpty(transactDataP.GetResp.Base.Transaction))
			{
				this.Resp = new GetMessageFromWX.Resp();
				this.Resp.FromProto(transactDataP.GetResp);
			}
			if (!string.IsNullOrEmpty(transactDataP.AuthResp.Base.Transaction))
			{
				this.Resp = new SendAuth.Resp();
				this.Resp.FromProto(transactDataP.AuthResp);
			}
			if (!string.IsNullOrEmpty(transactDataP.SendResp.Base.Transaction))
			{
				this.Resp = new SendMessageToWX.Resp();
				this.Resp.FromProto(transactDataP.SendResp);
			}
			if (!string.IsNullOrEmpty(transactDataP.ShowResp.Base.Transaction))
			{
				this.Resp = new ShowMessageFromWX.Resp();
				this.Resp.FromProto(transactDataP.ShowResp);
			}
			if (!string.IsNullOrEmpty(transactDataP.PayReq.Base.Transaction))
			{
				this.Req = new SendPay.Req();
				this.Req.FromProto(transactDataP.PayReq);
			}
			if (!string.IsNullOrEmpty(transactDataP.PayResp.Base.Transaction))
			{
				this.Resp = new SendPay.Resp();
				this.Resp.FromProto(transactDataP.PayResp);
			}
		}

		public static void WriteToFile(TransactData data, string filePath)
		{
			byte[] array = new byte[64];
			array[0] = 1;
			array[1] = 5;
			TransactDataP transactDataP = data.ToProto();
			byte[] array2 = transactDataP.ToByteArray();
			int num = array2.Length;
			byte[] bytes = BitConverter.GetBytes(num);
			Array.Copy(bytes, 0, array, 2, 4);
			FileUtil.writeToFile(filePath, array, true);
			FileUtil.appendToFile(filePath, array2);
		}

		public static TransactData ReadFromFile(string filePath)
		{
			byte[] array = FileUtil.readFromFile(filePath, 0, 64);
			byte[] array2 = new byte[4];
			Array.Copy(array, 2, array2, 0, 4);
			int count = BitConverter.ToInt32(array2, 0);
			byte[] data = FileUtil.readFromFile(filePath, 64, count);
			TransactDataP protoObj = TransactDataP.ParseFrom(data);
			TransactData transactData = new TransactData();
			transactData.FromProto(protoObj);
			return transactData;
		}
	}
}
