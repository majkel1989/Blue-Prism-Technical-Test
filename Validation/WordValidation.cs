using System.Collections.Generic;
using System.Linq;
using BluePrismTechnicalTest.DTO;

namespace BluePrismTechnicalTest.Validation
{
    public class WordValidation<T> : IParameterValidation<T>
    {
        private int WordLenght { get; set; }
        private IEnumerable<string> WordList { get; set; }
        private IEnumerable<string> SuppliedWords { get; set; }

        public WordValidation(int wordLenght, IEnumerable<string> wordList, IEnumerable<string> suppliedWords)
        {
            WordLenght = wordLenght;
            WordList = wordList;
            SuppliedWords = suppliedWords;
        }

        public ValidationResult IsValid(T parameter)
        {
            var errorMessages = new List<string>();
            var validationResult = new WordValidationResult(parameter.ToString());

            if (string.IsNullOrEmpty(validationResult.Word))
            {
                errorMessages.Add("Invalid: Word can't be empty");
            }
            else if (validationResult.Word.Length != WordLenght)
            {
                errorMessages.Add($"Invalid: Word can be only {WordLenght} characters long");
            }
            else if (SuppliedWords.Any(w => w == validationResult.Word))
            {
                errorMessages.Add($"Invalid: Word '{validationResult.Word}' already supplied");
            }
            else if (!WordList.Any(w => w == validationResult.Word))
            {
                errorMessages.Add($"Invalid: Unable to find '{validationResult.Word}' in the Dictionary File");
            }

            validationResult.ErrorMessages = errorMessages;
            return validationResult;
        }
    }
}