using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BluePrismTechnicalTest.Helpers
{
    public static class DocumentHelper
    {
        public static List<string> GetWordList(string filePath, int wordLenght = -1)
        {
            var wordList = new List<string>();

            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string word;
                while ((word = streamReader.ReadLine()) != null)
                {
                    if(wordLenght > 0 && word.Length == wordLenght
                        || wordLenght <= 0)
                    {
                        wordList.Add(word);
                    }
                }
            }

            return wordList;
        }

        public static void SaveWordList(string filePath, List<string> wordList)
        {
            using (var streamWriter = new StreamWriter(filePath))
            {
                foreach (var word in wordList)
                {
                    streamWriter.WriteLine(word);
                }
            }
        }

        public static string GetDefaultPath(this string filePath, string defaultDirectory, string extension)
        {
            if (!string.IsNullOrEmpty(Path.GetFileName(filePath)))
            {
                filePath = Path.ChangeExtension(filePath, extension);
                filePath = string.IsNullOrEmpty(Path.GetDirectoryName(filePath)) ? Path.Combine(defaultDirectory, filePath) : filePath;
            }

            return filePath;
        }
    }
}
