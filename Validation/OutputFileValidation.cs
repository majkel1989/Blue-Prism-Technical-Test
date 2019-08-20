using System.Collections.Generic;
using System.IO;
using BluePrismTechnicalTest.DTO;
using BluePrismTechnicalTest.Helpers;

namespace BluePrismTechnicalTest.Validation
{
    public class OutputFileValidation<T> : IParameterValidation<T>
    {
        private string DefaultDirectory { get; set; }
        private string Extension { get; set; }

        public OutputFileValidation(string defaultDirectory, string extension)
        {
            DefaultDirectory = defaultDirectory;
            Extension = extension;
        }

        public ValidationResult IsValid(T parameter)
        {
            var errorMessages = new List<string>();
            var filePath = parameter.ToString();
            filePath = filePath.GetDefaultPath(DefaultDirectory, Extension);

            var validationResult = new FileValidationResult(filePath);

            if (string.IsNullOrEmpty(Path.GetFileName(validationResult.FilePath)))
            {
                errorMessages.Add("Invalid: File name can't be empty");
            }
            else if (!Directory.Exists(Path.GetDirectoryName(validationResult.FilePath)))
            {
                errorMessages.Add("Invalid: Directory doesn't exist");
            }
            else if (File.Exists(validationResult.FilePath))
            {
                errorMessages.Add($"Invalid: File '{Path.GetFileName(validationResult.FilePath)}' under given Directory already exist");
            }

            validationResult.ErrorMessages = errorMessages;
            return validationResult;
        }
    }
}