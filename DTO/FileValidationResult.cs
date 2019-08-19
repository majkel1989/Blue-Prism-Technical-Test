namespace BluePrismTechnicalTest.DTO
{
    public class FileValidationResult : ValidationResult
    {
        public string FilePath { get; }

        public FileValidationResult(string filePath)
        {
            FilePath = filePath;
        }
    }
}