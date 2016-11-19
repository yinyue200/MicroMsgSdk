using System;

namespace Google.ProtocolBuffers
{
	public interface IEnumLiteMap
	{
		bool IsValidValue(IEnumLite value);

		IEnumLite FindValueByNumber(int number);

		IEnumLite FindValueByName(string name);
	}
}
