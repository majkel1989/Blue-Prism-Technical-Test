using BluePrismTechnicalTest.UI;

namespace BluePrismTechnicalTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserInterf interf = new ConsoleInterface();
            interf.Init();
        }
    }
}
