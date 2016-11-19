using System;
using System.Collections.Generic;
using System.Text;

namespace Google.ProtocolBuffers
{
	public sealed class UninitializedMessageException : Exception
	{
		private readonly IList<string> missingFields;

		public IList<string> MissingFields
		{
			get
			{
				return this.missingFields;
			}
		}

		private UninitializedMessageException(IList<string> missingFields) : base(UninitializedMessageException.BuildDescription(missingFields))
		{
			this.missingFields = new List<string>(missingFields);
		}

		public InvalidProtocolBufferException AsInvalidProtocolBufferException()
		{
			return new InvalidProtocolBufferException(this.Message);
		}

		private static string BuildDescription(IEnumerable<string> missingFields)
		{
			StringBuilder stringBuilder = new StringBuilder("Message missing required fields: ");
			bool flag = true;
			using (IEnumerator<string> enumerator = missingFields.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					if (flag)
					{
						flag = false;
					}
					else
					{
						stringBuilder.Append(", ");
					}
					stringBuilder.Append(current);
				}
			}
			return stringBuilder.ToString();
		}

		public UninitializedMessageException(IMessageLite message) : base(string.Format("Message {0} is missing required fields", message.GetType()))
		{
			this.missingFields = new List<string>();
		}
	}
}
