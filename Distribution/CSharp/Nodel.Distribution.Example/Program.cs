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
            var msg = new ExampleMessage();
            conn.Send(msg);
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
            get { return "http://monkey-pc"; }
        }

        public string Channel
        {
            get { return "example"; }
        }
    }

    public class ExampleMessage : INodleMessage
    {
        public string Action { get; set; }
        public List<string> Params { get; set; }

        public ExampleMessage()
        {
            Action = "PUBLISH";
            Params = new List<string>{ "cheese","cats","monkeys" };
        }
    }

    public class ConsoleLogger:INodleLogger
    {
        public NodleLogLevel LogLevel { get; set; }

        public ConsoleLogger()
        {
            LogLevel = NodleLogLevel.INFO;
        }

        public void Info(string infoMessage)
        {
            Console.WriteLine("{0} - [INFO] - {1}",DateTime.Now, infoMessage);
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
