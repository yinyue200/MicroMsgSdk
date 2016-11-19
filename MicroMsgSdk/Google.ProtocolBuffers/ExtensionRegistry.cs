using System;
using System.Collections.Generic;

namespace Google.ProtocolBuffers
{
	public sealed class ExtensionRegistry
	{
		internal struct ExtensionIntPair : IEquatable<ExtensionRegistry.ExtensionIntPair>
		{
			private readonly object msgType;

			private readonly int number;

			internal ExtensionIntPair(object msgType, int number)
			{
				this.msgType = msgType;
				this.number = number;
			}

			public override int GetHashCode()
			{
				return this.msgType.GetHashCode() * 65535 + this.number;
			}

			public override bool Equals(object obj)
			{
				return obj is ExtensionRegistry.ExtensionIntPair && this.Equals((ExtensionRegistry.ExtensionIntPair)obj);
			}

			public bool Equals(ExtensionRegistry.ExtensionIntPair other)
			{
				return this.msgType.Equals(other.msgType) && this.number == other.number;
			}
		}

		private static readonly ExtensionRegistry empty = new ExtensionRegistry(new Dictionary<object, Dictionary<string, IGeneratedExtensionLite>>(), new Dictionary<ExtensionRegistry.ExtensionIntPair, IGeneratedExtensionLite>(), true);

		private readonly Dictionary<object, Dictionary<string, IGeneratedExtensionLite>> extensionsByName;

		private readonly Dictionary<ExtensionRegistry.ExtensionIntPair, IGeneratedExtensionLite> extensionsByNumber;

		private readonly bool readOnly;

		public static ExtensionRegistry Empty
		{
			get
			{
				return ExtensionRegistry.empty;
			}
		}

		public IGeneratedExtensionLite this[IMessageLite containingType, int fieldNumber]
		{
			get
			{
				IGeneratedExtensionLite result;
				this.extensionsByNumber.TryGetValue(new ExtensionRegistry.ExtensionIntPair(containingType, fieldNumber), out result);
				return result;
			}
		}

		private ExtensionRegistry(Dictionary<object, Dictionary<string, IGeneratedExtensionLite>> byName, Dictionary<ExtensionRegistry.ExtensionIntPair, IGeneratedExtensionLite> byNumber, bool readOnly)
		{
			this.extensionsByName = byName;
			this.extensionsByNumber = byNumber;
			this.readOnly = readOnly;
		}

		public static ExtensionRegistry CreateInstance()
		{
			return new ExtensionRegistry(new Dictionary<object, Dictionary<string, IGeneratedExtensionLite>>(), new Dictionary<ExtensionRegistry.ExtensionIntPair, IGeneratedExtensionLite>(), false);
		}

		public ExtensionRegistry AsReadOnly()
		{
			return new ExtensionRegistry(this.extensionsByName, this.extensionsByNumber, true);
		}

		public IGeneratedExtensionLite FindByName(IMessageLite defaultInstanceOfType, string fieldName)
		{
			return this.FindExtensionByName(defaultInstanceOfType, fieldName);
		}

		private IGeneratedExtensionLite FindExtensionByName(object forwhat, string fieldName)
		{
			IGeneratedExtensionLite result = null;
			Dictionary<string, IGeneratedExtensionLite> dictionary;
			if (this.extensionsByName.TryGetValue(forwhat, out dictionary) && dictionary.TryGetValue(fieldName, out result))
			{
				return result;
			}
			return null;
		}

		public void Add(IGeneratedExtensionLite extension)
		{
			if (this.readOnly)
			{
				throw new InvalidOperationException("Cannot add entries to a read-only extension registry");
			}
			this.extensionsByNumber.Add(new ExtensionRegistry.ExtensionIntPair(extension.ContainingType, extension.Number), extension);
			Dictionary<string, IGeneratedExtensionLite> dictionary;
			if (!this.extensionsByName.TryGetValue(extension.ContainingType, out dictionary))
			{
				this.extensionsByName.Add(extension.ContainingType, dictionary = new Dictionary<string, IGeneratedExtensionLite>());
			}
			dictionary[extension.Descriptor.Name]= extension;
			dictionary[extension.Descriptor.FullName]= extension;
		}
	}
}
