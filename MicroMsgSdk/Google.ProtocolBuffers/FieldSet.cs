using Google.ProtocolBuffers.Collections;
using Google.ProtocolBuffers.Descriptors;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Google.ProtocolBuffers
{
	internal sealed class FieldSet
	{
		private static readonly FieldSet defaultInstance = new FieldSet(new Dictionary<IFieldDescriptorLite, object>()).MakeImmutable();

		private IDictionary<IFieldDescriptorLite, object> fields;

		internal static FieldSet DefaultInstance
		{
			get
			{
				return FieldSet.defaultInstance;
			}
		}

		internal IDictionary<IFieldDescriptorLite, object> AllFields
		{
			get
			{
				return Dictionaries.AsReadOnly<IFieldDescriptorLite, object>(this.fields);
			}
		}

		internal object this[IFieldDescriptorLite field]
		{
			get
			{
				object result;
				if (this.fields.TryGetValue(field, out result))
				{
					return result;
				}
				if (field.MappedType != MappedType.Message)
				{
					return field.DefaultValue;
				}
				if (field.IsRepeated)
				{
					return new List<object>();
				}
				return null;
			}
			set
			{
				if (field.IsRepeated)
				{
					List<object> list = value as List<object>;
					if (list == null)
					{
						throw new ArgumentException("Wrong object type used with protocol message reflection.");
					}
					List<object> list2 = new List<object>(list);
					using (List<object>.Enumerator enumerator = list2.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							object current = enumerator.Current;
							FieldSet.VerifyType(field, current);
						}
					}
					value = list2;
				}
				else
				{
					FieldSet.VerifyType(field, value);
				}
				this.fields[field]= value;
			}
		}

		internal object this[IFieldDescriptorLite field, int index]
		{
			get
			{
				if (!field.IsRepeated)
				{
					throw new ArgumentException("Indexer specifying field and index can only be called on repeated fields.");
				}
				return ((IList<object>)this[field])[index];
			}
			set
			{
				if (!field.IsRepeated)
				{
					throw new ArgumentException("Indexer specifying field and index can only be called on repeated fields.");
				}
				FieldSet.VerifyType(field, value);
				object obj;
				if (!this.fields.TryGetValue(field, out obj))
				{
					throw new ArgumentOutOfRangeException();
				}
				((IList<object>)obj)[index]= value;
			}
		}

		internal bool IsInitialized
		{
			get
			{
				using (IEnumerator<KeyValuePair<IFieldDescriptorLite, object>> enumerator = this.fields.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						KeyValuePair<IFieldDescriptorLite, object> current = enumerator.Current;
						IFieldDescriptorLite key = current.Key;
						if (key.MappedType == MappedType.Message)
						{
							if (key.IsRepeated)
							{
								IEnumerator enumerator2 = ((IEnumerable)current.Value).GetEnumerator();
								try
								{
									while (enumerator2.MoveNext())
									{
										IMessageLite messageLite = (IMessageLite)enumerator2.Current;
										if (!messageLite.IsInitialized)
										{
											bool result = false;
											return result;
										}
									}
									continue;
								}
								finally
								{
									IDisposable disposable = enumerator2 as IDisposable;
									if (disposable != null)
									{
										disposable.Dispose();
									}
								}
							}
							if (!((IMessageLite)current.Value).IsInitialized)
							{
								bool result = false;
								return result;
							}
						}
					}
				}
				return true;
			}
		}

		public int SerializedSize
		{
			get
			{
				int num = 0;
				using (IEnumerator<KeyValuePair<IFieldDescriptorLite, object>> enumerator = this.fields.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						KeyValuePair<IFieldDescriptorLite, object> current = enumerator.Current;
						IFieldDescriptorLite key = current.Key;
						object value = current.Value;
						if (key.IsExtension && key.MessageSetWireFormat)
						{
							num += CodedOutputStream.ComputeMessageSetExtensionSize(key.FieldNumber, (IMessageLite)value);
						}
						else
						{
							if (key.IsRepeated)
							{
								IEnumerable enumerable = (IEnumerable)value;
								if (key.IsPacked)
								{
									int num2 = 0;
									IEnumerator enumerator2 = enumerable.GetEnumerator();
									try
									{
										while (enumerator2.MoveNext())
										{
											object current2 = enumerator2.Current;
											num2 += CodedOutputStream.ComputeFieldSizeNoTag(key.FieldType, current2);
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
									num += num2 + CodedOutputStream.ComputeTagSize(key.FieldNumber) + CodedOutputStream.ComputeRawVarint32Size((uint)num2);
									continue;
								}
								IEnumerator enumerator3 = enumerable.GetEnumerator();
								try
								{
									while (enumerator3.MoveNext())
									{
										object current3 = enumerator3.Current;
										num += CodedOutputStream.ComputeFieldSize(key.FieldType, key.FieldNumber, current3);
									}
									continue;
								}
								finally
								{
									IDisposable disposable2 = enumerator3 as IDisposable;
									if (disposable2 != null)
									{
										disposable2.Dispose();
									}
								}
							}
							num += CodedOutputStream.ComputeFieldSize(key.FieldType, key.FieldNumber, value);
						}
					}
				}
				return num;
			}
		}

		private FieldSet(IDictionary<IFieldDescriptorLite, object> fields)
		{
			this.fields = fields;
		}

		public static FieldSet CreateInstance()
		{
			return new FieldSet(new SortedList<IFieldDescriptorLite, object>());
		}

		internal FieldSet MakeImmutable()
		{
			bool flag = false;
			using (IEnumerator<object> enumerator = this.fields.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object current = enumerator.Current;
					IList<object> list = current as IList<object>;
					if (list != null && !list.IsReadOnly)
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				SortedList<IFieldDescriptorLite, object> sortedList = new SortedList<IFieldDescriptorLite, object>();
				using (IEnumerator<KeyValuePair<IFieldDescriptorLite, object>> enumerator2 = this.fields.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						KeyValuePair<IFieldDescriptorLite, object> current2 = enumerator2.Current;
						IList<object> list2 = current2.Value as IList<object>;
						sortedList[current2.Key] = ((list2 == null) ? current2.Value : Lists.AsReadOnly<object>(list2));
					}
				}
				this.fields = sortedList;
			}
			this.fields = Dictionaries.AsReadOnly<IFieldDescriptorLite, object>(this.fields);
			return this;
		}

		public bool HasField(IFieldDescriptorLite field)
		{
			if (field.IsRepeated)
			{
				throw new ArgumentException("HasField() can only be called on non-repeated fields.");
			}
			return this.fields.ContainsKey(field);
		}

		internal void Clear()
		{
			this.fields.Clear();
		}

		internal void AddRepeatedField(IFieldDescriptorLite field, object value)
		{
			if (!field.IsRepeated)
			{
				throw new ArgumentException("AddRepeatedField can only be called on repeated fields.");
			}
			FieldSet.VerifyType(field, value);
			object obj;
			if (!this.fields.TryGetValue(field, out obj))
			{
				obj = new List<object>();
				this.fields[field]= obj;
			}
			((IList<object>)obj).Add(value);
		}

		internal IEnumerator<KeyValuePair<IFieldDescriptorLite, object>> GetEnumerator()
		{
			return this.fields.GetEnumerator();
		}

		internal bool IsInitializedWithRespectTo(IEnumerable typeFields)
		{
			IEnumerator enumerator = typeFields.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					IFieldDescriptorLite fieldDescriptorLite = (IFieldDescriptorLite)enumerator.Current;
					if (fieldDescriptorLite.IsRequired && !this.HasField(fieldDescriptorLite))
					{
						return false;
					}
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
			return this.IsInitialized;
		}

		public void ClearField(IFieldDescriptorLite field)
		{
			this.fields.Remove(field);
		}

		public int GetRepeatedFieldCount(IFieldDescriptorLite field)
		{
			if (!field.IsRepeated)
			{
				throw new ArgumentException("GetRepeatedFieldCount() can only be called on repeated fields.");
			}
			return ((IList<object>)this[field]).Count;
		}

		public void MergeFrom(FieldSet other)
		{
			using (IEnumerator<KeyValuePair<IFieldDescriptorLite, object>> enumerator = other.fields.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<IFieldDescriptorLite, object> current = enumerator.Current;
					this.MergeField(current.Key, current.Value);
				}
			}
		}

		private void MergeField(IFieldDescriptorLite field, object mergeValue)
		{
			object obj;
			this.fields.TryGetValue(field, out obj);
			if (field.IsRepeated)
			{
				if (obj == null)
				{
					obj = new List<object>();
					this.fields[field]= obj;
				}
				IList<object> list = (IList<object>)obj;
				IEnumerator enumerator = ((IEnumerable)mergeValue).GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						object current = enumerator.Current;
						list.Add(current);
					}
					return;
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
			}
			if (field.MappedType == MappedType.Message && obj != null)
			{
				IMessageLite messageLite = (IMessageLite)obj;
				IMessageLite value = messageLite.WeakToBuilder().WeakMergeFrom((IMessageLite)mergeValue).WeakBuild();
				this[field] = value;
				return;
			}
			this[field] = mergeValue;
		}

		public void WriteTo(ICodedOutputStream output)
		{
			using (IEnumerator<KeyValuePair<IFieldDescriptorLite, object>> enumerator = this.fields.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<IFieldDescriptorLite, object> current = enumerator.Current;
					this.WriteField(current.Key, current.Value, output);
				}
			}
		}

		public void WriteField(IFieldDescriptorLite field, object value, ICodedOutputStream output)
		{
			if (field.IsExtension && field.MessageSetWireFormat)
			{
				output.WriteMessageSetExtension(field.FieldNumber, field.Name, (IMessageLite)value);
				return;
			}
			if (!field.IsRepeated)
			{
				output.WriteField(field.FieldType, field.FieldNumber, field.Name, value);
				return;
			}
			IEnumerable list = (IEnumerable)value;
			if (field.IsPacked)
			{
				output.WritePackedArray(field.FieldType, field.FieldNumber, field.Name, list);
				return;
			}
			output.WriteArray(field.FieldType, field.FieldNumber, field.Name, list);
		}

		private static void VerifyType(IFieldDescriptorLite field, object value)
		{
			ThrowHelper.ThrowIfNull(value, "value");
			bool flag = false;
			switch (field.MappedType)
			{
			case MappedType.Int32:
				flag = (value is int);
				break;
			case MappedType.Int64:
				flag = (value is long);
				break;
			case MappedType.UInt32:
				flag = (value is uint);
				break;
			case MappedType.UInt64:
				flag = (value is ulong);
				break;
			case MappedType.Single:
				flag = (value is float);
				break;
			case MappedType.Double:
				flag = (value is double);
				break;
			case MappedType.Boolean:
				flag = (value is bool);
				break;
			case MappedType.String:
				flag = (value is string);
				break;
			case MappedType.ByteString:
				flag = (value is ByteString);
				break;
			case MappedType.Message:
			{
				IMessageLite messageLite = value as IMessageLite;
				flag = (messageLite != null);
				break;
			}
			case MappedType.Enum:
			{
				IEnumLite enumLite = value as IEnumLite;
				flag = (enumLite != null && field.EnumType.IsValidValue(enumLite));
				break;
			}
			}
			if (!flag)
			{
				string text = "Wrong object type used with protocol message reflection.";
				throw new ArgumentException(text);
			}
		}
	}
}
