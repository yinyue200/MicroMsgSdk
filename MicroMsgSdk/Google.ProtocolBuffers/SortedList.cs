using System;
using System.Collections;
using System.Collections.Generic;

namespace Google.ProtocolBuffers
{
	internal sealed class SortedList<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
	{
		private readonly IDictionary<TKey, TValue> wrapped = new Dictionary<TKey, TValue>();

		public ICollection<TKey> Keys
		{
			get
			{
				List<TKey> list = new List<TKey>(this.wrapped.Count);
				using (IEnumerator<KeyValuePair<TKey, TValue>> enumerator = this.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						KeyValuePair<TKey, TValue> current = enumerator.Current;
						list.Add(current.Key);
					}
				}
				return list;
			}
		}

		public ICollection<TValue> Values
		{
			get
			{
				List<TValue> list = new List<TValue>(this.wrapped.Count);
				using (IEnumerator<KeyValuePair<TKey, TValue>> enumerator = this.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						KeyValuePair<TKey, TValue> current = enumerator.Current;
						list.Add(current.Value);
					}
				}
				return list;
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
				this.wrapped[key]= value;
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
				return this.wrapped.IsReadOnly;
			}
		}

		public SortedList()
		{
		}

		public SortedList(IDictionary<TKey, TValue> dictionary)
		{
			using (IEnumerator<KeyValuePair<TKey, TValue>> enumerator = dictionary.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<TKey, TValue> current = enumerator.Current;
					this.Add(current.Key, current.Value);
				}
			}
		}

		public void Add(TKey key, TValue value)
		{
			this.wrapped.Add(key, value);
		}

		public bool ContainsKey(TKey key)
		{
			return this.wrapped.ContainsKey(key);
		}

		public bool Remove(TKey key)
		{
			return this.wrapped.Remove(key);
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			return this.wrapped.TryGetValue(key, out value);
		}

		public void Add(KeyValuePair<TKey, TValue> item)
		{
			this.wrapped.Add(item);
		}

		public void Clear()
		{
			this.wrapped.Clear();
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
			return this.wrapped.Remove(item);
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			IComparer<TKey> comparer = Comparer<TKey>.Default;
			List<KeyValuePair<TKey, TValue>> list = new List<KeyValuePair<TKey, TValue>>(this.wrapped);
			list.Sort((KeyValuePair<TKey, TValue> x, KeyValuePair<TKey, TValue> y) => comparer.Compare(x.Key, y.Key));
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}
