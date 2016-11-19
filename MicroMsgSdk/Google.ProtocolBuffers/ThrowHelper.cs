using System;
using System.Collections.Generic;

namespace Google.ProtocolBuffers
{
	public static class ThrowHelper
	{
		public static void ThrowIfNull(object value, string name)
		{
			if (value == null)
			{
				throw new ArgumentNullException(name);
			}
		}

		public static void ThrowIfNull(object value)
		{
			if (value == null)
			{
				throw new ArgumentNullException();
			}
		}

		public static void ThrowIfAnyNull<T>(IEnumerable<T> sequence)
		{
			using (IEnumerator<T> enumerator = sequence.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					T current = enumerator.Current;
					if (current == null)
					{
						throw new ArgumentNullException();
					}
				}
			}
		}

		public static Exception CreateMissingMethod(Type type, string methodName)
		{
			return new MissingMethodException(string.Format("The method '{0}' was not found on type {1}", methodName, type));
		}
	}
}
