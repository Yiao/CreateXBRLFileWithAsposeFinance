using System;
using System.IO;

namespace ASPOSEFINANCETEST
{
	public class FileManager
	{
		public FileManager()
		{
		}

		public static string GetTestFileDir()
        {
            string startDirectory = GetTheRootDir();
            return startDirectory != null ? Path.Combine(startDirectory, "TestFile/") : null;
        }

        public static string GetResultFileDir()
        {
            string startDirectory = GetTheRootDir();
            return startDirectory != null ? Path.Combine(startDirectory, "ResultFile/") : null;
        }

        private static string GetTheRootDir()
        {
            var parent = Directory.GetParent(Directory.GetCurrentDirectory());
            string startDirectory = null;

            if (parent != null)
            {
                var directoryInfo = parent.Parent;
                if (directoryInfo != null)
                {
                    startDirectory = directoryInfo.FullName;
                }
            }
            else
            {
                startDirectory = parent.FullName;
            }

            return startDirectory;
        }
    }
}

