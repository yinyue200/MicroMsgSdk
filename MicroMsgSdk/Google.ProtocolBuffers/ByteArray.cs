using System;

namespace Google.ProtocolBuffers
{
	internal static class ByteArray
	{
		private const int CopyThreshold = 12;

		public static void Copy(byte[] src, int srcOffset, byte[] dst, int dstOffset, int count)
		{
			if (count > 12)
			{
				Buffer.BlockCopy(src, srcOffset, dst, dstOffset, count);
				return;
			}
			ByteArray.ByteCopy(src, srcOffset, dst, dstOffset, count);
		}

		public static void ByteCopy(byte[] src, int srcOffset, byte[] dst, int dstOffset, int count)
		{
			int num = srcOffset + count;
			for (int i = srcOffset; i < num; i++)
			{
				dst[dstOffset++] = src[i];
			}
		}

		public static void Reverse(byte[] bytes)
		{
			int i = 0;
			int num = bytes.Length - 1;
			while (i < num)
			{
				byte b = bytes[i];
				bytes[i] = bytes[num];
				bytes[num] = b;
				i++;
				num--;
			}
		}
	}
}
