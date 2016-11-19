using MicroMsg.sdk.protobuf;
using System;

namespace MicroMsg.sdk
{
	public class ShowMessageFromWX
	{
		public class Req : BaseReq
		{
			public WXBaseMessage Message;

			internal Req()
			{
			}

			public Req(WXBaseMessage message)
			{
				this.Message = message;
			}

			public override int Type()
			{
				return 4;
			}

			internal override bool ValidateData()
			{
				if (this.Message == null)
				{
					throw new WXException(1, "Message can't be null.");
				}
				return this.Message.ValidateData();
			}

			internal override object ToProto()
			{
				BaseReqP.Builder builder = BaseReqP.CreateBuilder();
				builder.Type = (uint)this.Type();
				builder.Transaction = this.Transaction;
				ShowMessageFromWXReq.Builder builder2 = ShowMessageFromWXReq.CreateBuilder();
				builder2.Base = builder.Build();
				if (this.Message != null)
				{
					WXMessageP msg = this.Message.ToProto() as WXMessageP;
					builder2.Msg = msg;
				}
				return builder2.Build();
			}

			internal override void FromProto(object protoObj)
			{
				if (protoObj == null)
				{
					return;
				}
				ShowMessageFromWXReq showMessageFromWXReq = protoObj as ShowMessageFromWXReq;
				if (showMessageFromWXReq == null)
				{
					return;
				}
				this.Transaction = showMessageFromWXReq.Base.Transaction;
				this.Message = WXBaseMessage.CreateMessage((int)showMessageFromWXReq.Msg.Type);
				if (this.Message != null)
				{
					this.Message.FromProto(showMessageFromWXReq.Msg);
				}
			}
		}

		public class Resp : BaseResp
		{
			public Resp()
			{
			}

			public Resp(string transaction, int errCode, string errString)
			{
				this.Transaction = transaction;
				this.ErrCode = errCode;
				this.ErrStr = errString;
			}

			public override int Type()
			{
				return 4;
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
				GetMessageFromWXResp.Builder builder2 = GetMessageFromWXResp.CreateBuilder();
				builder2.Base = builder.Build();
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
			}
		}

		private ShowMessageFromWX()
		{
		}
	}
}
