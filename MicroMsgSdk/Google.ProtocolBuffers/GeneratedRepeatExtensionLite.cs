using Google.ProtocolBuffers.Descriptors;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Google.ProtocolBuffers
{
	public class GeneratedRepeatExtensionLite<TContainingType, TExtensionType> : GeneratedExtensionLite<TContainingType, IList<TExtensionType>> where TContainingType : IMessageLite
	{
		public GeneratedRepeatExtensionLite(string fullName, TContainingType containingTypeDefaultInstance, IMessageLite messageDefaultInstance, IEnumLiteMap enumTypeMap, int number, FieldType type, bool isPacked) : base(fullName, containingTypeDefaultInstance, new List<TExtensionType>(), messageDefaultInstance, enumTypeMap, number, type, isPacked)
		{
		}

		public override object ToReflectionType(object value)
		{
			IList<object> list = new List<object>();
			IEnumerator enumerator = ((IEnumerable)value).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object current = enumerator.Current;
					list.Add(base.SingularToReflectionType(current));
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
			return list;
		}

		public override object FromReflectionType(object value)
		{
			List<TExtensionType> list = new List<TExtensionType>();
			IEnumerator enumerator = ((IEnumerable)value).GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object current = enumerator.Current;
					list.Add((TExtensionType)((object)base.SingularFromReflectionType(current)));
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
			return list;
		}
	}
}
