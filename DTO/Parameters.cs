using System.Collections.Generic;

namespace BluePrismTechnicalTest.DTO
{
    public class Parameters
    {
        public int WordLenght { get; private set; }
        public string FileExtension { get; private set; }
        public string DefaultDirectory { get; set; }
        public string DictionaryFile { get; set; }
        public string StartWord { get; set; }
        public string EndWord { get; set; }
        public string ResultFile { get; set; }
        public List<string> WordList { get; set; }

        public Parameters(int wordLenght, string fileExtension, string defaultDirectory)
        {
            WordLenght = wordLenght;
            FileExtension = fileExtension;
            DefaultDirectory = defaultDirectory;
        }
    }
}