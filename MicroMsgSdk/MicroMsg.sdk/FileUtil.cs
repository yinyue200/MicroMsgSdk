using System;
using System.IO;
using System.IO.IsolatedStorage;

namespace MicroMsg.sdk
{
	public class FileUtil
	{
		public static void deleteDir(IsolatedStorageFile isf, string path, bool bDeleteDir = true)
		{
			string[] fileNames = isf.GetFileNames(path + "/*");
			for (int i = 0; i < fileNames.Length; i++)
			{
				string text = fileNames[i];
				isf.DeleteFile(path + "/" + text);
			}
			string[] directoryNames = isf.GetDirectoryNames(path + "/*");
			for (int j = 0; j < directoryNames.Length; j++)
			{
				string text2 = directoryNames[j];
				FileUtil.deleteDir(isf, path + "/" + text2, bDeleteDir);
			}
			if (bDeleteDir)
			{
				isf.DeleteDirectory(path);
			}
		}

		public static bool writeToFile(string fileName, byte[] data, bool bCreateDir = false)
		{
			if (string.IsNullOrEmpty(fileName) || data == null)
			{
				return false;
			}
			try
			{
				using (IsolatedStorageFile userStoreForApplication = IsolatedStorageFile.GetUserStoreForApplication())
				{
					if (bCreateDir)
					{
						string directoryName = Path.GetDirectoryName(fileName);
						if (!userStoreForApplication.DirectoryExists(directoryName))
						{
							userStoreForApplication.CreateDirectory(directoryName);
						}
					}
					using (IsolatedStorageFileStream isolatedStorageFileStream = new IsolatedStorageFileStream(fileName, FileMode.Create, userStoreForApplication))
					{
						isolatedStorageFileStream.Write(data, 0, data.Length);
					}
				}
				return true;
			}
			catch (Exception)
			{
			}
			return false;
		}

		public static void appendToFile(string fileName, byte[] data)
		{
			try
			{
				using (IsolatedStorageFile userStoreForApplication = IsolatedStorageFile.GetUserStoreForApplication())
				{
					using (IsolatedStorageFileStream isolatedStorageFileStream = new IsolatedStorageFileStream(fileName, FileMode.OpenOrCreate, userStoreForApplication))
					{
						isolatedStorageFileStream.Seek(0L, System.IO.SeekOrigin.End);
						isolatedStorageFileStream.Write(data, 0, data.Length);
					}
				}
			}
			catch (Exception)
			{
			}
		}

		public static byte[] readFromFile(string fileName, int offset, int count)
		{
			try
			{
				using (IsolatedStorageFile userStoreForApplication = IsolatedStorageFile.GetUserStoreForApplication())
				{
					using (IsolatedStorageFileStream isolatedStorageFileStream = new IsolatedStorageFileStream(fileName, FileMode.Open, userStoreForApplication))
					{
						isolatedStorageFileStream.Seek((long)offset, 0);
						byte[] array = new byte[count];
						int num = isolatedStorageFileStream.Read(array, 0, array.Length);
						byte[] result;
						if (num != count)
						{
							result = null;
							return result;
						}
						result = array;
						return result;
					}
				}
			}
			catch (Exception)
			{
			}
			return null;
		}

		public static long getFileExistTime(string path)
		{
			try
			{
				using (IsolatedStorageFile userStoreForApplication = IsolatedStorageFile.GetUserStoreForApplication())
				{
					long result;
					if (!userStoreForApplication.FileExists(path))
					{
						result = 0L;
						return result;
					}
					result = (long)DateTime.Now.Subtract(userStoreForApplication.GetCreationTime(path).DateTime).TotalSeconds;
					return result;
				}
			}
			catch (Exception)
			{
			}
			return 0L;
		}

		public static long fileLength(string path)
		{
			if (string.IsNullOrEmpty(path))
			{
				return 0L;
			}
			try
			{
				using (IsolatedStorageFile userStoreForApplication = IsolatedStorageFile.GetUserStoreForApplication())
				{
					if (!userStoreForApplication.FileExists(path))
					{
						long result = 0L;
						return result;
					}
					using (IsolatedStorageFileStream isolatedStorageFileStream = new IsolatedStorageFileStream(path, FileMode.Open, userStoreForApplication))
					{
						long result = isolatedStorageFileStream.Length;
						return result;
					}
				}
			}
			catch (Exception)
			{
			}
			return 0L;
		}

		public static bool fileExists(string path)
		{
			try
			{
				using (IsolatedStorageFile userStoreForApplication = IsolatedStorageFile.GetUserStoreForApplication())
				{
					return userStoreForApplication.FileExists(path);
				}
			}
			catch (Exception)
			{
			}
			return false;
		}

		public static bool dirExists(string path)
		{
			try
			{
				using (IsolatedStorageFile userStoreForApplication = IsolatedStorageFile.GetUserStoreForApplication())
				{
					return userStoreForApplication.DirectoryExists(path);
				}
			}
			catch (Exception)
			{
			}
			return false;
		}

		public static bool deleteFile(string fileName)
		{
			if (string.IsNullOrEmpty(fileName))
			{
				return false;
			}
			try
			{
				using (IsolatedStorageFile userStoreForApplication = IsolatedStorageFile.GetUserStoreForApplication())
				{
					if (userStoreForApplication.FileExists(fileName))
					{
						userStoreForApplication.DeleteFile(fileName);
					}
				}
				return true;
			}
			catch (Exception)
			{
			}
			return false;
		}

		public static bool emptyDir(string strPath)
		{
			if (string.IsNullOrEmpty(strPath))
			{
				return false;
			}
			try
			{
				bool result;
				using (IsolatedStorageFile userStoreForApplication = IsolatedStorageFile.GetUserStoreForApplication())
				{
					if (!userStoreForApplication.DirectoryExists(strPath))
					{
						result = false;
						return result;
					}
					string[] fileNames = userStoreForApplication.GetFileNames(strPath + "/*");
					for (int i = 0; i < fileNames.Length; i++)
					{
						string text = fileNames[i];
						userStoreForApplication.DeleteFile(strPath + "/" + text);
					}
					string[] directoryNames = userStoreForApplication.GetDirectoryNames(strPath + "/*");
					for (int j = 0; j < directoryNames.Length; j++)
					{
						string text2 = directoryNames[j];
						FileUtil.deleteDir(userStoreForApplication, strPath + "/" + text2, true);
					}
				}
				result = true;
				return result;
			}
			catch (Exception)
			{
			}
			return false;
		}

		public static bool createDir(string strPath)
		{
			if (string.IsNullOrEmpty(strPath))
			{
				return false;
			}
			try
			{
				bool result;
				using (IsolatedStorageFile userStoreForApplication = IsolatedStorageFile.GetUserStoreForApplication())
				{
					if (userStoreForApplication.DirectoryExists(strPath))
					{
						result = true;
						return result;
					}
					userStoreForApplication.CreateDirectory(strPath);
				}
				result = true;
				return result;
			}
			catch (Exception)
			{
			}
			return false;
		}

		public static bool emptyFile(string strPath)
		{
			if (string.IsNullOrEmpty(strPath))
			{
				return false;
			}
			try
			{
				bool result;
				using (IsolatedStorageFile userStoreForApplication = IsolatedStorageFile.GetUserStoreForApplication())
				{
					if (!userStoreForApplication.DirectoryExists(strPath))
					{
						result = false;
						return result;
					}
					FileUtil.deleteDir(userStoreForApplication, strPath, false);
				}
				result = true;
				return result;
			}
			catch (Exception)
			{
			}
			return false;
		}
	}
}
