using System;
using System.Collections;
using System.Collections.Generic;

namespace Google.ProtocolBuffers.Collections
{
	public interface IPopsicleList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		void Add(IEnumerable<T> collection);
	}
}
