using System;
using System.IO;

namespace Languages
{
    public static class LanguageWrapper
    {
        /// <summary>
        /// Gets all installed language files
        /// </summary>
        /// <param name="path">Path where search to begin</param>
        /// <returns>String array of installed languages</returns>
        public static string[] GetInstalledLanguages(string path)
        {
            string[] files = Directory.GetFiles(path, "Languages.resources*", SearchOption.AllDirectories);

            string[] Result = new string[files.Length + 1];
            Result[0] = "en-GB";

            for (int i = 1; i < Result.Length; i++)
            {
                string file = files[i -1].Replace(path, String.Empty);

                file = file.Substring(0, file.IndexOf("\\"));
                Result[i] = file;
            }

            return (Result);
        }
    }
}
