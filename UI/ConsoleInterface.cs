using System;
using BluePrismTechnicalTest.DTO;

namespace BluePrismTechnicalTest.UI
{
    public class ConsoleInterface : IUserInterf
    {
        public void Init()
        {
            var parameters = new Parameters();

            CreateMessage(new string[] { "#########################################################",
                                         "############### Blue Prism Technical Test ###############",
                                         "#########################################################"});

            CreateMessage(new string[]{"", "Give Dictionary File Name", "Dictionary File Name: "});
            parameters.DictionaryFile = Console.ReadLine();

            CreateMessage(new string[]{ "", "Give Start Word (Letter case does matter)", "Start Word: "});
            parameters.StartWord = Console.ReadLine();

            CreateMessage(new string[]{ "", "Give End Word (Letter case does matter)", "End Word: "});
            parameters.EndWord = Console.ReadLine();

            CreateMessage(new string[]{ "", "Give Result File Name", "Result File Name: "});
            parameters.ResultFile = Console.ReadLine();
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