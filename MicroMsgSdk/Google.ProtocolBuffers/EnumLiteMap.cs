using System;
using System.Reflection;

namespace Google.ProtocolBuffers
{
	public class EnumLiteMap<TEnum> : IEnumLiteMap where TEnum : struct, IComparable, IFormattable
	{
		private struct EnumValue : IEnumLite
		{
			private readonly TEnum value;

			int IEnumLite.Number
			{
				get
				{
					return Convert.ToInt32(this.value);
				}
			}

			string IEnumLite.Name
			{
				get
				{
					TEnum tEnum = this.value;
					return tEnum.ToString();
				}
			}

			public EnumValue(TEnum value)
			{
				this.value = value;
			}
		}

		private readonly SortedList<int, IEnumLite> items;

		public EnumLiteMap()
		{
			this.items = new SortedList<int, IEnumLite>();
			FieldInfo[] fields = typeof(TEnum).GetFields((BindingFlags)24);
			for (int i = 0; i < fields.Length; i++)
			{
				FieldInfo fieldInfo = fields[i];
				TEnum tEnum = (TEnum)((object)fieldInfo.GetValue(null));
				this.items.Add(Convert.ToInt32(tEnum), new EnumLiteMap<TEnum>.EnumValue(tEnum));
			}
		}

		IEnumLite IEnumLiteMap.FindValueByNumber(int number)
		{
			return this.FindValueByNumber(number);
		}

		public IEnumLite FindValueByNumber(int number)
		{
			IEnumLite result;
			if (!this.items.TryGetValue(number, out result))
			{
				return null;
			}
			return result;
		}

		public IEnumLite FindValueByName(string name)
		{
			if (!Enum.IsDefined(typeof(TEnum), name))
			{
				return null;
			}
			IEnumLite result;
			if (!this.items.TryGetValue((int)Enum.Parse(typeof(TEnum), name, false), out result))
			{
				return null;
			}
			return result;
		}

		public bool IsValidValue(IEnumLite value)
		{
			return this.items.ContainsKey(value.Number);
		}
	}
}
