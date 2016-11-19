using Google.ProtocolBuffers.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Google.ProtocolBuffers
{
	public abstract class ExtendableMessageLite<TMessage, TBuilder> : GeneratedMessageLite<TMessage, TBuilder> where TMessage : GeneratedMessageLite<TMessage, TBuilder> where TBuilder : GeneratedBuilderLite<TMessage, TBuilder>
	{
		protected class ExtensionWriter
		{
			private readonly IEnumerator<KeyValuePair<IFieldDescriptorLite, object>> iterator;

			private readonly FieldSet extensions;

			private KeyValuePair<IFieldDescriptorLite, object>? next = default(KeyValuePair<IFieldDescriptorLite, object>?);

			internal ExtensionWriter(ExtendableMessageLite<TMessage, TBuilder> message)
			{
				this.extensions = message.extensions;
				this.iterator = message.extensions.GetEnumerator();
				if (this.iterator.MoveNext())
				{
					this.next = new KeyValuePair<IFieldDescriptorLite, object>?(this.iterator.Current);
				}
			}

			public void WriteUntil(int end, ICodedOutputStream output)
			{
				while (this.next.HasValue && this.next.Value.Key.FieldNumber < end)
				{
					this.extensions.WriteField(this.next.Value.Key, this.next.Value.Value, output);
					if (this.iterator.MoveNext())
					{
						this.next = new KeyValuePair<IFieldDescriptorLite, object>?(this.iterator.Current);
					}
					else
					{
						this.next = default(KeyValuePair<IFieldDescriptorLite, object>?);
					}
				}
			}
		}

		private readonly FieldSet extensions = FieldSet.CreateInstance();

		internal FieldSet Extensions
		{
			get
			{
				return this.extensions;
			}
		}

		protected bool ExtensionsAreInitialized
		{
			get
			{
				return this.extensions.IsInitialized;
			}
		}

		public override bool IsInitialized
		{
			get
			{
				return this.ExtensionsAreInitialized;
			}
		}

		protected int ExtensionsSerializedSize
		{
			get
			{
				return this.extensions.SerializedSize;
			}
		}

		public override bool Equals(object obj)
		{
			ExtendableMessageLite<TMessage, TBuilder> extendableMessageLite = obj as ExtendableMessageLite<TMessage, TBuilder>;
			return !object.ReferenceEquals(null, extendableMessageLite) && Dictionaries.Equals<IFieldDescriptorLite, object>(this.extensions.AllFields, extendableMessageLite.extensions.AllFields);
		}

		public override int GetHashCode()
		{
			return Dictionaries.GetHashCode<IFieldDescriptorLite, object>(this.extensions.AllFields);
		}

		public override void PrintTo(TextWriter writer)
		{
			using (IEnumerator<KeyValuePair<IFieldDescriptorLite, object>> enumerator = this.extensions.AllFields.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<IFieldDescriptorLite, object> current = enumerator.Current;
					string name = string.Format("[{0}]", current.Key.FullName);
					if (current.Key.IsRepeated)
					{
						IEnumerator enumerator2 = ((IEnumerable)current.Value).GetEnumerator();
						try
						{
							while (enumerator2.MoveNext())
							{
								object current2 = enumerator2.Current;
								GeneratedMessageLite<TMessage, TBuilder>.PrintField(name, true, current2, writer);
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
					GeneratedMessageLite<TMessage, TBuilder>.PrintField(name, true, current.Value, writer);
				}
			}
		}

		public bool HasExtension<TExtension>(GeneratedExtensionLite<TMessage, TExtension> extension)
		{
			this.VerifyExtensionContainingType<TExtension>(extension);
			return this.extensions.HasField(extension.Descriptor);
		}

		public int GetExtensionCount<TExtension>(GeneratedExtensionLite<TMessage, IList<TExtension>> extension)
		{
			this.VerifyExtensionContainingType<IList<TExtension>>(extension);
			return this.extensions.GetRepeatedFieldCount(extension.Descriptor);
		}

		public TExtension GetExtension<TExtension>(GeneratedExtensionLite<TMessage, TExtension> extension)
		{
			this.VerifyExtensionContainingType<TExtension>(extension);
			object obj = this.extensions[extension.Descriptor];
			if (obj == null)
			{
				return extension.DefaultValue;
			}
			return (TExtension)((object)extension.FromReflectionType(obj));
		}

		public TExtension GetExtension<TExtension>(GeneratedExtensionLite<TMessage, IList<TExtension>> extension, int index)
		{
			this.VerifyExtensionContainingType<IList<TExtension>>(extension);
			return (TExtension)((object)extension.SingularFromReflectionType(this.extensions[extension.Descriptor, index]));
		}

		protected ExtendableMessageLite<TMessage, TBuilder>.ExtensionWriter CreateExtensionWriter(ExtendableMessageLite<TMessage, TBuilder> message)
		{
			return new ExtendableMessageLite<TMessage, TBuilder>.ExtensionWriter(message);
		}

		internal void VerifyExtensionContainingType<TExtension>(GeneratedExtensionLite<TMessage, TExtension> extension)
		{
			if (!object.ReferenceEquals(extension.ContainingTypeDefaultInstance, this.DefaultInstanceForType))
			{
				throw new ArgumentException(string.Format("Extension is for type \"{0}\" which does not match message type \"{1}\".", extension.ContainingTypeDefaultInstance, this.DefaultInstanceForType));
			}
		}
	}
}
