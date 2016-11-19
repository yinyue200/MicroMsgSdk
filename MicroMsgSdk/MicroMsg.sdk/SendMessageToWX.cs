using MicroMsg.sdk.protobuf;
using System;

namespace MicroMsg.sdk
{
	public class SendMessageToWX
	{
		public class Req : BaseReq
		{
			public const int WXSceneChooseByUser = 0;

			public const int WXSceneSession = 1;

			public const int WXSceneTimeline = 2;

			private const string TAG = "MicroMsg.SDK.SendMessageToWX.Req";

			public WXBaseMessage Message;

			public int Scene;

			internal Req()
			{
			}

			public Req(WXBaseMessage message, int scene = 1)
			{
				this.Message = message;
				this.Scene = scene;
			}

			public override int Type()
			{
				return 2;
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
				SendMessageToWXReq.Builder builder2 = SendMessageToWXReq.CreateBuilder();
				builder2.Base = builder.Build();
				builder2.Scene = (uint)this.Scene;
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
				SendMessageToWXReq sendMessageToWXReq = protoObj as SendMessageToWXReq;
				if (sendMessageToWXReq == null)
				{
					return;
				}
				this.Transaction = sendMessageToWXReq.Base.Transaction;
				this.Scene = (int)sendMessageToWXReq.Scene;
				this.Message = WXBaseMessage.CreateMessage((int)sendMessageToWXReq.Msg.Type);
				if (this.Message != null)
				{
					this.Message.FromProto(sendMessageToWXReq.Msg);
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
				return 2;
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
				SendMessageToWXResp.Builder builder2 = SendMessageToWXResp.CreateBuilder();
				builder2.Base = builder.Build();
				return builder2.Build();
			}

			internal override void FromProto(object protoObj)
			{
				if (protoObj == null)
				{
					return;
				}
				SendMessageToWXResp sendMessageToWXResp = protoObj as SendMessageToWXResp;
				if (sendMessageToWXResp == null)
				{
					return;
				}
				this.Transaction = sendMessageToWXResp.Base.Transaction;
				this.ErrCode = (int)sendMessageToWXResp.Base.ErrCode;
				this.ErrStr = sendMessageToWXResp.Base.ErrStr;
			}
		}

		private SendMessageToWX()
		{
		}
	}
}
