using System;

namespace Google.ProtocolBuffers
{
	public interface IRpcServerStub : IDisposable
	{
		IMessageLite CallMethod(string methodName, ICodedInputStream input, ExtensionRegistry registry);
	}
}
