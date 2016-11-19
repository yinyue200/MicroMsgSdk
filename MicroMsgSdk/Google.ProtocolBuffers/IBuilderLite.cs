using System;
using System.IO;

namespace Google.ProtocolBuffers
{
	public interface IBuilderLite
	{
		bool IsInitialized
		{
			get;
		}

		IMessageLite WeakDefaultInstanceForType
		{
			get;
		}

		IBuilderLite WeakClear();

		IBuilderLite WeakMergeFrom(IMessageLite message);

		IBuilderLite WeakMergeFrom(ByteString data);

		IBuilderLite WeakMergeFrom(ByteString data, ExtensionRegistry registry);

		IBuilderLite WeakMergeFrom(ICodedInputStream input);

		IBuilderLite WeakMergeFrom(ICodedInputStream input, ExtensionRegistry registry);

		IMessageLite WeakBuild();

		IMessageLite WeakBuildPartial();

		IBuilderLite WeakClone();
	}
	public interface IBuilderLite<TMessage, TBuilder> : IBuilderLite where TMessage : IMessageLite<TMessage, TBuilder> where TBuilder : IBuilderLite<TMessage, TBuilder>
	{
		TMessage DefaultInstanceForType
		{
			get;
		}

		TBuilder Clear();

		TBuilder MergeFrom(IMessageLite other);

		TMessage Build();

		TMessage BuildPartial();

		TBuilder Clone();

		TBuilder MergeFrom(ICodedInputStream input);

		TBuilder MergeFrom(ICodedInputStream input, ExtensionRegistry extensionRegistry);

		TBuilder MergeDelimitedFrom(Stream input);

		TBuilder MergeDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry);

		TBuilder MergeFrom(ByteString data);

		TBuilder MergeFrom(ByteString data, ExtensionRegistry extensionRegistry);

		TBuilder MergeFrom(byte[] data);

		TBuilder MergeFrom(byte[] data, ExtensionRegistry extensionRegistry);

		TBuilder MergeFrom(Stream input);

		TBuilder MergeFrom(Stream input, ExtensionRegistry extensionRegistry);
	}
}
