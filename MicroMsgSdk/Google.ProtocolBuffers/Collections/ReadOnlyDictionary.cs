using System;
using System.Collections;
using System.Collections.Generic;

namespace Google.ProtocolBuffers.Collections
{
	public sealed class ReadOnlyDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
	{
		private readonly IDictionary<TKey, TValue> wrapped;

		public ICollection<TKey> Keys
		{
			get
			{
				return this.wrapped.Keys;
			}
		}

		public ICollection<TValue> Values
		{
			get
			{
				return this.wrapped.Values;
			}
		}

		public TValue this[TKey key]
		{
			get
			{
				return this.wrapped[key];
			}
			set
			{
				throw new InvalidOperationException();
			}
		}

		public int Count
		{
			get
			{
				return this.wrapped.Count;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return true;
			}
		}

		public ReadOnlyDictionary(IDictionary<TKey, TValue> wrapped)
		{
			this.wrapped = wrapped;
		}

		public void Add(TKey key, TValue value)
		{
			throw new InvalidOperationException();
		}

		public bool ContainsKey(TKey key)
		{
			return this.wrapped.ContainsKey(key);
		}

		public bool Remove(TKey key)
		{
			throw new InvalidOperationException();
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			return this.wrapped.TryGetValue(key, out value);
		}

		public void Add(KeyValuePair<TKey, TValue> item)
		{
			throw new InvalidOperationException();
		}

		public void Clear()
		{
			throw new InvalidOperationException();
		}

		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			return this.wrapped.Contains(item);
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			this.wrapped.CopyTo(array, arrayIndex);
		}

		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			throw new InvalidOperationException();
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return this.wrapped.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.wrapped.GetEnumerator();
		}

		public override bool Equals(object obj)
		{
			return this.wrapped.Equals(obj);
		}

		public override int GetHashCode()
		{
			return this.wrapped.GetHashCode();
		}

		public override string ToString()
		{
			return this.wrapped.ToString();
		}
	}
}
