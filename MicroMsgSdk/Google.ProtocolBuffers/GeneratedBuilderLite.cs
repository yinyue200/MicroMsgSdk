using System;

namespace Google.ProtocolBuffers
{
	public abstract class GeneratedBuilderLite<TMessage, TBuilder> : AbstractBuilderLite<TMessage, TBuilder> where TMessage : GeneratedMessageLite<TMessage, TBuilder> where TBuilder : GeneratedBuilderLite<TMessage, TBuilder>
	{
		protected abstract TMessage MessageBeingBuilt
		{
			get;
		}

		public override TBuilder MergeFrom(IMessageLite other)
		{
			return this.ThisBuilder;
		}

		public abstract TBuilder MergeFrom(TMessage other);

		
		protected virtual bool ParseUnknownField(ICodedInputStream input, ExtensionRegistry extensionRegistry, uint tag, string fieldName)
		{
			return input.SkipField();
		}

		public TMessage BuildParsed()
		{
			if (!this.IsInitialized)
			{
				throw new UninitializedMessageException(this.MessageBeingBuilt).AsInvalidProtocolBufferException();
			}
			return this.BuildPartial();
		}

		public override TMessage Build()
		{
			if (!this.IsInitialized)
			{
				throw new UninitializedMessageException(this.MessageBeingBuilt);
			}
			return this.BuildPartial();
		}
	}
}
