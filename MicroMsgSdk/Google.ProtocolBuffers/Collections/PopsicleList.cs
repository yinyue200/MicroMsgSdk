using System;
using System.Collections;
using System.Collections.Generic;

namespace Google.ProtocolBuffers.Collections
{
	public sealed class PopsicleList<T> : IPopsicleList<T>, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, ICastArray
	{
		private static readonly bool CheckForNull = default(T) == null;

		private static readonly T[] EmptySet = new T[0];

		private List<T> items;

		private bool readOnly;

		public T this[int index]
		{
			get
			{
				if (this.items == null)
				{
					throw new ArgumentOutOfRangeException();
				}
				return this.items[index];
			}
			set
			{
				this.ValidateModification();
				if (PopsicleList<T>.CheckForNull)
				{
					ThrowHelper.ThrowIfNull(value);
				}
				this.items[index]= value;
			}
		}

		public int Count
		{
			get
			{
				if (this.items != null)
				{
					return this.items.Count;
				}
				return 0;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return this.readOnly;
			}
		}

		public void MakeReadOnly()
		{
			this.readOnly = true;
		}

		public int IndexOf(T item)
		{
			if (this.items != null)
			{
				return this.items.IndexOf(item);
			}
			return -1;
		}

		public void Insert(int index, T item)
		{
			this.ValidateModification();
			if (PopsicleList<T>.CheckForNull)
			{
				ThrowHelper.ThrowIfNull(item);
			}
			this.items.Insert(index, item);
		}

		public void RemoveAt(int index)
		{
			this.ValidateModification();
			this.items.RemoveAt(index);
		}

		public void Add(T item)
		{
			this.ValidateModification();
			if (PopsicleList<T>.CheckForNull)
			{
				ThrowHelper.ThrowIfNull(item);
			}
			this.items.Add(item);
		}

		public void Clear()
		{
			this.ValidateModification();
			this.items.Clear();
		}

		public bool Contains(T item)
		{
			return this.items != null && this.items.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			if (this.items != null)
			{
				this.items.CopyTo(array, arrayIndex);
			}
		}

		public bool Remove(T item)
		{
			this.ValidateModification();
			return this.items.Remove(item);
		}

		public IEnumerator<T> GetEnumerator()
		{
			IEnumerable<T> enumerable = this.items ?? ((IEnumerable<T>)PopsicleList<T>.EmptySet);
			return enumerable.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public void Add(IEnumerable<T> collection)
		{
			this.ValidateModification();
			ThrowHelper.ThrowIfNull(collection);
			if (!PopsicleList<T>.CheckForNull || collection is PopsicleList<T>)
			{
				this.items.AddRange(collection);
				return;
			}
			if (collection is ICollection<T>)
			{
				ThrowHelper.ThrowIfAnyNull<T>(collection);
				this.items.AddRange(collection);
				return;
			}
			using (IEnumerator<T> enumerator = collection.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					T current = enumerator.Current;
					ThrowHelper.ThrowIfNull(current);
					this.items.Add(current);
				}
			}
		}

		private void ValidateModification()
		{
			if (this.readOnly)
			{
				throw new NotSupportedException("List is read-only");
			}
			if (this.items == null)
			{
				this.items = new List<T>();
			}
		}

		IEnumerable<TItemType> ICastArray.CastArray<TItemType>()
		{
			if (this.items == null)
			{
				return PopsicleList<TItemType>.EmptySet;
			}
			return this.items.ToArray() as TItemType[];//yfWarning:
        }
	}
}
