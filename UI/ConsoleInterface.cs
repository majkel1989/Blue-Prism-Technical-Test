using System;
using BluePrismTechnicalTest.DTO;
using BluePrismTechnicalTest.Helpers;
using BluePrismTechnicalTest.Logic;
using BluePrismTechnicalTest.Validation;
using System.Linq;

namespace BluePrismTechnicalTest.UI
{
    public class ConsoleInterface : IUserInterf
    {
        public void Init()
        {
            var wordLenght = 4;
            var fileExtension = ".txt";
            var defaultDirectory = Environment.CurrentDirectory;
            var parameters = new Parameters(wordLenght, fileExtension, defaultDirectory);

            CreateMessage(new string[] { "#########################################################",
                                         "############### Blue Prism Technical Test ###############",
                                         "#########################################################"});

            CreateMessage(new string[]{"", "Give Dictionary File Name", "Dictionary File Name: "});
            parameters.DictionaryFile = ((FileValidationResult)GetValidResult(new InputFileValidation<string>(parameters.DefaultDirectory, parameters.FileExtension))).FilePath;

            parameters.WordList = DocumentHelper.GetWordList(parameters.DictionaryFile, parameters.WordLenght);

            CreateMessage(new string[]{ "", "Give Start Word (Letter case does matter)", "Start Word: "});
            parameters.StartWord = ((WordValidationResult)GetValidResult(new WordValidation<string>(parameters.WordLenght, parameters.WordList))).Word;

            CreateMessage(new string[]{ "", "Give End Word (Letter case does matter)", "End Word: "});
            parameters.EndWord = ((WordValidationResult)GetValidResult(new WordValidation<string>(parameters.WordLenght, parameters.WordList))).Word;

            CreateMessage(new string[]{ "", "Give Result File Name", "Result File Name: "});
            parameters.ResultFile = ((FileValidationResult)GetValidResult(new OutputFileValidation<string>(parameters.DefaultDirectory, parameters.FileExtension))).FilePath;

            var wordAlgorithm = new WordAlgorithm(parameters);
            //wordAlgorithm.Invoke();
            var result = wordAlgorithm.WordLadder(parameters.StartWord, parameters.EndWord, parameters.WordList.ToArray());
        }

        private ValidationResult GetValidResult(IParameterValidation<string> parameterValidation)
        {
            ValidationResult validationResult;
            string parameter;

            do
            {
                parameter = Console.ReadLine();
                validationResult = parameterValidation.IsValid(parameter);

                if (!validationResult.IsValid)
                {
                    CreateMessage(validationResult.ErrorMessages.ToArray());
                    CreateMessage(new string[] { "", "Try again:" });
                }
            }
            while (!validationResult.IsValid);

            return validationResult;
        }

        private void CreateMessage(string[] messages)
        {
            foreach (var message in messages)
            {
                Console.WriteLine(message);
            }
        }
    }
}