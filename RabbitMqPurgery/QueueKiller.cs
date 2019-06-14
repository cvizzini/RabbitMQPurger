using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqPurgery
{
    class QueueKiller
    {

        public QueueKiller(string hostName, string userName, string password, string url, string auth)
        {
            ConnectionFactory factory = new ConnectionFactory();

            factory.HostName = hostName;
            factory.UserName = userName;
            factory.Password = password;
            var failures = false;
            using (var connection = factory.CreateConnection())
            {

                var queues = GetSomething<List<RabbitQueue>>(url, auth);
                foreach (var queue in queues)
                {
                    using (var channel = connection.CreateModel())
                    {
                        try
                        {
                            Console.Write("Killing Queue {0}", queue.Name);
                            channel.QueuePurge(queue.Name);
                            Console.WriteLine("...Done");
                        }
                        catch
                        {
                            failures = true;
                            Console.WriteLine("...FAILED");
                        }
                    }
                }
            }
            if (failures)
            {
                Console.WriteLine("There were one or more queues which were not purged. Please try" +
                                  "restart the RabbitMQ service and try run the purger again.");
            }
        }

        public T GetSomething<T>(string url, string auth)
        {
            var rabbitUrl = url.EndsWith("/") ? url : url + "/";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(rabbitUrl + "api/queues");
            request.Method = "GET";
            request.Headers.Add("Authorization", auth);
            String test = String.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                test = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
            }
            return JsonConvert.DeserializeObject<T>(test);
        }
    }
}
