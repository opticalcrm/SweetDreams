using System;
using System.Diagnostics;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Log4netTest
{
    class Logger
    {
        private const int begin = 1, defaultEndValue = 0;
        private int end = defaultEndValue;
        private string input = "";
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void Start()
        {
            try
            {
                Console.WriteLine("Enter a number(integer value) to test execution time:");
                input = Console.ReadLine();
                if (GetInputValidity())
                {
                    Stopwatch stopwatch = new Stopwatch();
                    if (end > defaultEndValue)
                    {
                        stopwatch.Start();
                        for (int iteration = begin; iteration <= end; iteration++) { }
                        stopwatch.Stop();
                    }
                    Console.WriteLine($"amount of time it took to run the loop: {stopwatch.Elapsed} ms");
                    log.Info($"Input: {input} - loop Time Elapsed: {stopwatch.Elapsed} ms");
                }
            }
            catch (Exception exceptionMessage)
            {
                log.Error(exceptionMessage);
            }
        }

        private bool GetInputValidity() // Check if input is a Non-Negative Integer
        {
            bool validity = true;
            if (!Int32.TryParse(input, out end))
            {
                validity = false;
                Console.WriteLine("Not a valid integer value");
                log.Error($"Input: {input} - Not a valid integer value");
            }
            else if(end < defaultEndValue)
            {
                validity = false;
                Console.WriteLine("Not a positive integer value");
                log.Error($"Input: {input} - Not a positive integer value");
            }
            return validity;
        }
    }
}