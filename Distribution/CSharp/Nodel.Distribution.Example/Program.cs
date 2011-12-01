using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nodle.Distribution;

namespace Nodel.Distribution.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var conn = new NodleConnection(NodleDistributionConfig.Instance, new ConsoleLogger());
            var msg = new NodleMessage { Body = "Hello ducky!" };
            
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine("[SENT #" + i + "]");
                conn.Send(msg);    
            }
            
            Console.ReadLine();
        }
    }

    public class ExampleConfig : INodleDistributionConfig
    {
        public string AccessKey
        {
            get { return "123456"; }
        }

        public string BaseUrl
        {
            get { return "http://nodle.io"; }
        }

        public string Channel
        {
            get { return "example" + new Random().Next(1, 1000); }
        }
    }

    public class ConsoleLogger : INodleLogger
    {
        public NodleLogLevel LogLevel { get; set; }

        public ConsoleLogger()
        {
            LogLevel = NodleLogLevel.INFO;
        }

        public void Info(string infoMessage)
        {
            Console.WriteLine("{0} - [INFO] - {1}", DateTime.Now, infoMessage);
        }

        public void Warn(string warnMessage)
        {
            Console.WriteLine("{0} - [WARN] - {1}", DateTime.Now, warnMessage);
        }

        public void Error(string errorMessage)
        {
            Console.WriteLine("{0} - [ERROR] - {1}", DateTime.Now, errorMessage);
        }
    }
}
