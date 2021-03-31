using System;

namespace StudyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage();
            College college1 = new College("ZuZuZu");
            ConsoleUI console = new ConsoleUI();
            console.Run(college1);

            Console.ReadLine();
        }
    }
}
