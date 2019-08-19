namespace BluePrismTechnicalTest.DTO
{
    public class WordValidationResult : ValidationResult
    {
        public string Word { get; private set; }

        public WordValidationResult(string word)
        {
            Word = word;
        }
    }
}