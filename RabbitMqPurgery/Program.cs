using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqPurgery
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****Rabbit Mq Queues Removal Tool****");
            Console.WriteLine();
            Console.Write("Aquiring the appSettings.config values");
            var hostname = GetConfig("Hostname");
            var rabbitUrl = GetConfig("rabbitUrl");
            var username = GetConfig("Username");
            var password = GetConfig("Password");
            var apiAuthorizationValue = GetConfig("ApiAuthorizationValue");
            Console.WriteLine("...Done");
            Console.WriteLine();
            Console.WriteLine("Starting the rabbit purgery on {0}", rabbitUrl);
            Console.WriteLine();
            var qk = new QueueKiller(hostname, username, password, rabbitUrl, apiAuthorizationValue);
            Console.WriteLine();
            Console.WriteLine("Completed the rabbit purgery");
            Console.WriteLine("Press enter to quit...");
            Console.ReadLine();
        }

        private static string GetConfig(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
