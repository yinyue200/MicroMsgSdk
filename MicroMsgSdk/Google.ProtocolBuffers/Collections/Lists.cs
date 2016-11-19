using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Google.ProtocolBuffers.Collections
{
	public static class Lists
	{
		public static IList<T> AsReadOnly<T>(IList<T> list)
		{
			return Lists<T>.AsReadOnly(list);
		}

		public static bool Equals<T>(IList<T> left, IList<T> right)
		{
			if (left == right)
			{
				return true;
			}
			if (left == null || right == null)
			{
				return false;
			}
			if (left.Count != right.Count)
			{
				return false;
			}
			IEqualityComparer<T> @default = EqualityComparer<T>.Default;
			for (int i = 0; i < left.Count; i++)
			{
				if (!@default.Equals(left[i], right[i]))
				{
					return false;
				}
			}
			return true;
		}

		public static int GetHashCode<T>(IList<T> list)
		{
			int num = 31;
			using (IEnumerator<T> enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					T current = enumerator.Current;
					num = num * 29 + current.GetHashCode();
				}
			}
			return num;
		}
	}
	public static class Lists<T>
	{
		private static readonly ReadOnlyCollection<T> empty = new ReadOnlyCollection<T>(new T[0]);

		public static ReadOnlyCollection<T> Empty
		{
			get
			{
				return Lists<T>.empty;
			}
		}

		public static IList<T> AsReadOnly(IList<T> list)
		{
			if (!list.IsReadOnly)
			{
				return new ReadOnlyCollection<T>(list);
			}
			return list;
		}
	}
}
