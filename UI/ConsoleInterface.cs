using System;

namespace BluePrismTechnicalTest.UI
{
    public class ConsoleInterface : IUserInterf
    {
        public void Init()
        {
            CreateMessage(new string[] { "#########################################################",
                                         "############### Blue Prism Technical Test ###############",
                                         "#########################################################"});

            CreateMessage(new string[]{"", "Give Dictionary File Name", "Dictionary File Name: "});

            CreateMessage(new string[]{ "", "Give Start Word (Letter case does matter)", "Start Word: "});

            CreateMessage(new string[]{ "", "Give End Word (Letter case does matter)", "End Word: "});

            CreateMessage(new string[]{ "", "Give Result File Name", "Result File Name: "});
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