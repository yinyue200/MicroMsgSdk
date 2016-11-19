using System;

namespace MicroMsg.sdk
{
	public abstract class BaseReq
	{
		public string Transaction;

		public abstract int Type();

		internal abstract bool ValidateData();

		internal abstract object ToProto();

		internal abstract void FromProto(object protoObj);
	}
}
