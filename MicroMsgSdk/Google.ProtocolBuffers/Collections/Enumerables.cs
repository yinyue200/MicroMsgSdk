using System;
using System.Collections;

namespace Google.ProtocolBuffers.Collections
{
	public static class Enumerables
	{
		public static bool Equals(IEnumerable left, IEnumerable right)
		{
			IEnumerator enumerator = left.GetEnumerator();
			try
			{
				IEnumerator enumerator2 = right.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						object current = enumerator2.Current;
						if (!enumerator.MoveNext())
						{
							bool result = false;
							return result;
						}
						if (!object.Equals(enumerator.Current, current))
						{
							bool result = false;
							return result;
						}
					}
				}
				finally
				{
					IDisposable disposable = enumerator2 as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
				if (enumerator.MoveNext())
				{
					bool result = false;
					return result;
				}
			}
			finally
			{
				IDisposable disposable2 = enumerator as IDisposable;
				if (disposable2 != null)
				{
					disposable2.Dispose();
				}
			}
			return true;
		}
	}
}
