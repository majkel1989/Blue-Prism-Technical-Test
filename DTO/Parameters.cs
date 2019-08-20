using System.Collections.Generic;

namespace BluePrismTechnicalTest.DTO
{
    public class Parameters
    {
        public int WordLenght { get; private set; }
        public string FileExtension { get; private set; }
        public string DefaultDirectory { get; private set; }
        public int WordLetterDifferenceValue { get; private set; }
        public string DictionaryFile { get; set; }
        public string StartWord { get; set; }
        public string EndWord { get; set; }
        public string ResultFile { get; set; }
        public List<string> WordList { get; set; }

        public Parameters(int wordLenght, string fileExtension, string defaultDirectory, int wordLetterDifferenceValue)
        {
            WordLenght = wordLenght;
            FileExtension = fileExtension;
            DefaultDirectory = defaultDirectory;
            WordLetterDifferenceValue = wordLetterDifferenceValue;
        }
    }
}