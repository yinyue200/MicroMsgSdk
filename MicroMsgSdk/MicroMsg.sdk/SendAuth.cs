using MicroMsg.sdk.protobuf;
using System;

namespace MicroMsg.sdk
{
	public class SendAuth
	{
		public class Req : BaseReq
		{
			private const string TAG = "MicroMsg.SDK.SendAuth.Req";

			private const int LENGTH_LIMIT = 1024;

			public string Scope;

			public string State;

			internal Req()
			{
			}

			public Req(string scope, string state)
			{
				this.Scope = scope;
				this.State = state;
			}

			public override int Type()
			{
				return 1;
			}

			internal override bool ValidateData()
			{
				if (this.Scope == null || this.Scope.Length == 0 || this.Scope.Length > 1024)
				{
					throw new WXException(1, "Scope is invalid.");
				}
				if (this.State != null && this.State.Length > 1024)
				{
					throw new WXException(1, "State is invalid.");
				}
				return true;
			}

			internal override object ToProto()
			{
				BaseReqP.Builder builder = BaseReqP.CreateBuilder();
				builder.Type = (uint)this.Type();
				builder.Transaction = this.Transaction;
				SendAuthReq.Builder builder2 = SendAuthReq.CreateBuilder();
				builder2.Base = builder.Build();
				builder2.Scope = this.Scope;
				builder2.State = this.State;
				return builder2.Build();
			}

			internal override void FromProto(object protoObj)
			{
				if (protoObj == null)
				{
					return;
				}
				SendAuthReq sendAuthReq = protoObj as SendAuthReq;
				if (sendAuthReq == null)
				{
					return;
				}
				this.Transaction = sendAuthReq.Base.Transaction;
				this.Scope = sendAuthReq.Scope;
				this.State = sendAuthReq.State;
			}
		}

		public class Resp : BaseResp
		{
			private const string TAG = "MicroMsg.SDK.SendAuth.Resp";

			private const int LENGTH_LIMIT = 1024;

			public string Code;

			public string State;

			public string Url;

			internal Resp()
			{
			}

			public Resp(string transaction, int errCode, string errString)
			{
				this.Transaction = transaction;
				this.ErrCode = errCode;
				this.ErrStr = errString;
			}

			public Resp(string code, string state, string url)
			{
				this.Code = code;
				this.State = state;
				this.Url = url;
			}

			public override int Type()
			{
				return 1;
			}

			internal override bool ValidateData()
			{
				if (this.State != null && this.State.Length > 1024)
				{
					throw new WXException(1, "State is invalid.");
				}
				return true;
			}

			internal override object ToProto()
			{
				BaseRespP.Builder builder = BaseRespP.CreateBuilder();
				builder.Type = (uint)this.Type();
				builder.Transaction = this.Transaction;
				builder.ErrCode = (uint)this.ErrCode;
				builder.ErrStr = this.ErrStr;
				SendAuthResp.Builder builder2 = SendAuthResp.CreateBuilder();
				builder2.Base = builder.Build();
				builder2.Code = (string.IsNullOrEmpty(this.Code) ? "" : this.Code);
				builder2.State = (string.IsNullOrEmpty(this.State) ? "" : this.State);
				builder2.Url = (string.IsNullOrEmpty(this.Url) ? "" : this.Url);
				return builder2.Build();
			}

			internal override void FromProto(object protoObj)
			{
				if (protoObj == null)
				{
					return;
				}
				SendAuthResp sendAuthResp = protoObj as SendAuthResp;
				if (sendAuthResp == null)
				{
					return;
				}
				this.Transaction = sendAuthResp.Base.Transaction;
				this.ErrCode = (int)sendAuthResp.Base.ErrCode;
				this.ErrStr = sendAuthResp.Base.ErrStr;
				this.Code = sendAuthResp.Code;
				this.State = sendAuthResp.State;
				this.Url = sendAuthResp.Url;
			}
		}

		private SendAuth()
		{
		}
	}
}
