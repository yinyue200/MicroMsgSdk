using System;

namespace Google.ProtocolBuffers
{
	public interface IRpcDispatch
	{
		TMessage CallMethod<TMessage, TBuilder>(string method, IMessageLite request, IBuilderLite<TMessage, TBuilder> response) where TMessage : IMessageLite<TMessage, TBuilder> where TBuilder : IBuilderLite<TMessage, TBuilder>;
	}
}
