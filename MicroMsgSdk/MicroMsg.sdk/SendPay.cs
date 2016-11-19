using MicroMsg.sdk.protobuf;
using System;

namespace MicroMsg.sdk
{
	public class SendPay
	{
		public class Req : BaseReq
		{
			private const string TAG = "MicroMsg.SDK.SendPay.Req";

			private const int LENGTH_LIMIT = 1024;

			public string PartnerId;

			public string PrepayId;

			public string NonceStr;

			public uint TimeStamp;

			public string Package;

			public string Sign;

			internal Req()
			{
			}

			public Req(string partnerId, string prepayId, string nonceStr, uint timeStamp, string package, string sign)
			{
				this.PartnerId = partnerId;
				this.PrepayId = prepayId;
				this.NonceStr = nonceStr;
				this.TimeStamp = timeStamp;
				this.Package = package;
				this.Sign = sign;
			}

			public override int Type()
			{
				return 5;
			}

			internal override bool ValidateData()
			{
				if (string.IsNullOrWhiteSpace(this.PartnerId) || this.PartnerId.Length > 1024)
				{
					throw new WXException(1, "PartnerId is invalid.");
				}
				if (string.IsNullOrWhiteSpace(this.PrepayId) || this.PrepayId.Length > 1024)
				{
					throw new WXException(1, "PrepayId is invalid.");
				}
				if (string.IsNullOrWhiteSpace(this.NonceStr) || this.NonceStr.Length > 1024)
				{
					throw new WXException(1, "NonceStr is invalid.");
				}
				if (this.TimeStamp == 0u)
				{
					throw new WXException(1, "TimeStamp is invalid.");
				}
				if (string.IsNullOrWhiteSpace(this.Package) || this.Package.Length > 1024)
				{
					throw new WXException(1, "Package is invalid.");
				}
				if (string.IsNullOrWhiteSpace(this.Sign) || this.Sign.Length > 1024)
				{
					throw new WXException(1, "Sign is invalid.");
				}
				return true;
			}

			internal override object ToProto()
			{
				BaseReqP.Builder builder = BaseReqP.CreateBuilder();
				builder.Type = (uint)this.Type();
				builder.Transaction = this.Transaction;
				SendPayReqP.Builder builder2 = SendPayReqP.CreateBuilder();
				builder2.Base = builder.Build();
				builder2.PartnerId = this.PartnerId;
				builder2.PrepayId = this.PrepayId;
				builder2.NonceStr = this.NonceStr;
				builder2.TimeStamp = this.TimeStamp;
				builder2.Package = this.Package;
				builder2.Sign = this.Sign;
				return builder2.Build();
			}

			internal override void FromProto(object protoObj)
			{
				if (protoObj == null)
				{
					return;
				}
				SendPayReqP sendPayReqP = protoObj as SendPayReqP;
				if (sendPayReqP == null)
				{
					return;
				}
				this.Transaction = sendPayReqP.Base.Transaction;
				this.PartnerId = sendPayReqP.PartnerId;
				this.PrepayId = sendPayReqP.PrepayId;
				this.NonceStr = sendPayReqP.NonceStr;
				this.TimeStamp = sendPayReqP.TimeStamp;
				this.Package = sendPayReqP.Package;
				this.Sign = sendPayReqP.Sign;
			}
		}

		public class Resp : BaseResp
		{
			private const string TAG = "MicroMsg.SDK.SendPay.Resp";

			private const int LENGTH_LIMIT = 1024;

			public string ReturnKey;

			internal Resp()
			{
			}

			public Resp(string transaction, int errCode, string errString)
			{
				this.Transaction = transaction;
				this.ErrCode = errCode;
				this.ErrStr = errString;
			}

			public Resp(string returnKey)
			{
				this.ReturnKey = returnKey;
			}

			public override int Type()
			{
				return 5;
			}

			internal override bool ValidateData()
			{
				return true;
			}

			internal override object ToProto()
			{
				BaseRespP.Builder builder = BaseRespP.CreateBuilder();
				builder.Type = (uint)this.Type();
				builder.Transaction = this.Transaction;
				builder.ErrCode = (uint)this.ErrCode;
				builder.ErrStr = this.ErrStr;
				SendPayRespP.Builder builder2 = SendPayRespP.CreateBuilder();
				builder2.Base = builder.Build();
				builder2.ReturnKey = (string.IsNullOrEmpty(this.ReturnKey) ? "" : this.ReturnKey);
				return builder2.Build();
			}

			internal override void FromProto(object protoObj)
			{
				if (protoObj == null)
				{
					return;
				}
				SendPayRespP sendPayRespP = protoObj as SendPayRespP;
				if (sendPayRespP == null)
				{
					return;
				}
				this.Transaction = sendPayRespP.Base.Transaction;
				this.ErrCode = (int)sendPayRespP.Base.ErrCode;
				this.ErrStr = sendPayRespP.Base.ErrStr;
				this.ReturnKey = sendPayRespP.ReturnKey;
			}
		}

		private SendPay()
		{
		}
	}
}
