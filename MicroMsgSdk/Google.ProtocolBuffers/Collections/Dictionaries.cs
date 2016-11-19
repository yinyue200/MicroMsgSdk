using System;
using System.Collections;
using System.Collections.Generic;

namespace Google.ProtocolBuffers.Collections
{
	public static class Dictionaries
	{
		public static bool Equals<TKey, TValue>(IDictionary<TKey, TValue> left, IDictionary<TKey, TValue> right)
		{
			if (left.Count != right.Count)
			{
				return false;
			}
			using (IEnumerator<KeyValuePair<TKey, TValue>> enumerator = left.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<TKey, TValue> current = enumerator.Current;
					TValue tValue;
					if (!right.TryGetValue(current.Key, out tValue))
					{
						bool result = false;
						return result;
					}
					IEnumerable enumerable = current.Value as IEnumerable;
					IEnumerable enumerable2 = tValue as IEnumerable;
					if (enumerable == null || enumerable2 == null)
					{
						if (!object.Equals(current.Value, tValue))
						{
							bool result = false;
							return result;
						}
					}
					else if (!Enumerables.Equals(enumerable, enumerable2))
					{
						bool result = false;
						return result;
					}
				}
			}
			return true;
		}

		public static IDictionary<TKey, TValue> AsReadOnly<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
		{
			if (!dictionary.IsReadOnly)
			{
				return new ReadOnlyDictionary<TKey, TValue>(dictionary);
			}
			return dictionary;
		}

		public static int GetHashCode<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
		{
			int num = 31;
			using (IEnumerator<KeyValuePair<TKey, TValue>> enumerator = dictionary.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<TKey, TValue> current = enumerator.Current;
					TKey key = current.Key;
					int num2 = key.GetHashCode() ^ Dictionaries.GetDeepHashCode(current.Value);
					num ^= num2;
				}
			}
			return num;
		}

		private static int GetDeepHashCode(object value)
		{
			IEnumerable enumerable = value as IEnumerable;
			if (enumerable == null)
			{
				return value.GetHashCode();
			}
			int num = 29;
			IEnumerator enumerator = enumerable.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object current = enumerator.Current;
					num = num * 37 + current.GetHashCode();
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return num;
		}
	}
}
