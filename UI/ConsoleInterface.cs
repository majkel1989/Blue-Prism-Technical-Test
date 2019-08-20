using System;
using BluePrismTechnicalTest.DTO;
using BluePrismTechnicalTest.Helpers;
using BluePrismTechnicalTest.Logic;
using BluePrismTechnicalTest.Validation;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

namespace BluePrismTechnicalTest.UI
{
    public class ConsoleInterface : IUserInterf
    {
        public void Init()
        {
            var wordLenght = 4;
            var fileExtension = ".txt";
            var defaultDirectory = Environment.CurrentDirectory;
            var wordLetterDifferenceValue = 1;
            var parameters = new Parameters(wordLenght, fileExtension, defaultDirectory, wordLetterDifferenceValue);

            CreateMessage(new string[] { "#########################################################",
                                         "############### Blue Prism Technical Test ###############",
                                         "#########################################################"});

            CreateMessage(new string[]{"", "Provide Dictionary File Name (can contain full path):" });
            parameters.DictionaryFile = ((FileValidationResult)GetValidResult(new InputFileValidation<string>(parameters.DefaultDirectory, parameters.FileExtension))).FilePath;

            parameters.WordList = DocumentHelper.GetWordList(parameters.DictionaryFile, parameters.WordLenght);

            CreateMessage(new string[]{ "", "Provide Start Word (Letter case does matter):"});
            parameters.StartWord = ((WordValidationResult)GetValidResult(new WordValidation<string>(parameters.WordLenght, parameters.WordList, new List<string>()))).Word;

            CreateMessage(new string[]{ "", "Provide End Word (Letter case does matter):"});
            parameters.EndWord = ((WordValidationResult)GetValidResult(new WordValidation<string>(parameters.WordLenght, parameters.WordList, new List<string>() { parameters.StartWord }))).Word;

            CreateMessage(new string[]{ "", "Provide Result File Name (can contain full path):"});
            parameters.ResultFile = ((FileValidationResult)GetValidResult(new OutputFileValidation<string>(parameters.DefaultDirectory, parameters.FileExtension))).FilePath;

            var wordAlgorithm = new WordAlgorithm(parameters);
            var wordListResult = wordAlgorithm.GetWordAlgorithmResult();

            CreateMessage(new string[] { "", "Result:" });
            CreateMessage(wordListResult.ToArray());

            DocumentHelper.SaveWordList(parameters.ResultFile, wordListResult);
            
            try
            {
                Process.Start("notepad.exe", parameters.ResultFile);
            }
            catch { }

            CreateMessage(new string[] { "",
                                         "#########################################################",
                                         "############### Blue Prism Technical Test ###############",
                                         "#########################################################"});

            CreateMessage(new string[] { "", "Click any button to exit..." });
            Console.ReadKey();
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