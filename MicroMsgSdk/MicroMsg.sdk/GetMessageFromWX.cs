using MicroMsg.sdk.protobuf;
using System;

namespace MicroMsg.sdk
{
	public class GetMessageFromWX
	{
		public class Req : BaseReq
		{
			public string Username;

			internal Req()
			{
			}

			public Req(string username)
			{
				this.Username = username;
			}

			public override int Type()
			{
				return 3;
			}

			internal override bool ValidateData()
			{
				if (string.IsNullOrEmpty(this.Username))
				{
					throw new WXException(1, "Username can't be empty.");
				}
				return true;
			}

			internal override object ToProto()
			{
				BaseReqP.Builder builder = BaseReqP.CreateBuilder();
				builder.Type = (uint)this.Type();
				builder.Transaction = this.Transaction;
				GetMessageFromWXReq.Builder builder2 = GetMessageFromWXReq.CreateBuilder();
				builder2.Base = builder.Build();
				builder2.Username = this.Username;
				return builder2.Build();
			}

			internal override void FromProto(object protoObj)
			{
				if (protoObj == null)
				{
					return;
				}
				GetMessageFromWXReq getMessageFromWXReq = protoObj as GetMessageFromWXReq;
				if (getMessageFromWXReq == null)
				{
					return;
				}
				this.Transaction = getMessageFromWXReq.Base.Transaction;
				this.Username = getMessageFromWXReq.Username;
			}
		}

		public class Resp : BaseResp
		{
			public string Username = "";

			public WXBaseMessage Message;

			internal Resp()
			{
			}

			public Resp(string transaction, int errCode, string errString)
			{
				this.Transaction = transaction;
				this.ErrCode = errCode;
				this.ErrStr = errString;
			}

			public Resp(string transaction, string username, WXBaseMessage message)
			{
				this.Username = username;
				this.Message = message;
				this.Transaction = transaction;
			}

			public override int Type()
			{
				return 3;
			}

			internal override bool ValidateData()
			{
				if (string.IsNullOrEmpty(this.Username))
				{
					throw new WXException(1, "Username can't be empty.");
				}
				if (this.ErrCode != 0)
				{
					return true;
				}
				if (this.Message == null)
				{
					throw new WXException(1, "Message can't be null.");
				}
				return this.Message.ValidateData();
			}

			internal override object ToProto()
			{
				BaseRespP.Builder builder = BaseRespP.CreateBuilder();
				builder.Type = (uint)this.Type();
				builder.Transaction = this.Transaction;
				builder.ErrCode = (uint)this.ErrCode;
				builder.ErrStr = this.ErrStr;
				GetMessageFromWXResp.Builder builder2 = GetMessageFromWXResp.CreateBuilder();
				builder2.Base = builder.Build();
				if (this.Message != null)
				{
					WXMessageP msg = this.Message.ToProto() as WXMessageP;
					builder2.Msg = msg;
				}
				builder2.Username = this.Username;
				return builder2.Build();
			}

			internal override void FromProto(object protoObj)
			{
				if (protoObj == null)
				{
					return;
				}
				GetMessageFromWXResp getMessageFromWXResp = protoObj as GetMessageFromWXResp;
				if (getMessageFromWXResp == null)
				{
					return;
				}
				this.Transaction = getMessageFromWXResp.Base.Transaction;
				this.ErrCode = (int)getMessageFromWXResp.Base.ErrCode;
				this.ErrStr = getMessageFromWXResp.Base.ErrStr;
				this.Username = getMessageFromWXResp.Username;
				this.Message = WXBaseMessage.CreateMessage((int)getMessageFromWXResp.Msg.Type);
				if (this.Message != null)
				{
					this.Message.FromProto(getMessageFromWXResp.Msg);
				}
			}
		}

		private GetMessageFromWX()
		{
		}
	}
}
