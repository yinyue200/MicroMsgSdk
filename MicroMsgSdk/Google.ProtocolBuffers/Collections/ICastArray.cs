using System;
using System.Collections.Generic;

namespace Google.ProtocolBuffers.Collections
{
	internal interface ICastArray
	{
		IEnumerable<TItemType> CastArray<TItemType>();
	}
}
