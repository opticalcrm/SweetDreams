using System;

namespace Log4netTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger log = new Logger();
            log.Start();

            Console.Write("Press Enter...");
            Console.ReadLine();
        }
    }
}