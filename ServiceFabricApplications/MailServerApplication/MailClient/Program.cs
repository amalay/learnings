using MailServer.Contracts.Contracts;
using MailServer.Contracts.Model;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailClient
{
    class Program
    {
        private static readonly object _lock = new object();

        static void Main(string[] args)
        {
            IMailService service = GetServiceProxy();

            Task.Run(() =>
            {
                for (;;)
                {
                    GetMailCount(service);
                    Task.Delay(500).Wait();
                }
            });

            Task.Run(() =>
            {
                for(;;)
                {
                    SendMail(service);
                    Task.Delay(500).Wait();
                }
            });

            Console.Read();
        }
               
        public static void SendMail(IMailService svc)
        {
            MailMessage message = new MailMessage
            {
                FromId = Guid.NewGuid(),
                ToId = Guid.NewGuid(),
                Message = "Hello from ABC"
            };
            
            //send mail
            svc.SendMessage(message).GetAwaiter().GetResult();

            lock (_lock)
            {
                Console.SetCursorPosition(27, 4);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(message.FromId + "                                                                                                                            ");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void GetMailCount(IMailService svc)
        {
            //get count
            long count = svc.GetMessageCount().Result;

            lock (_lock)
            {
                Console.SetCursorPosition(27, 7);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(count + "                                                                                                          ");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static IMailService GetServiceProxy()
        {
            IMailService service = null;
            string serviceConnection = "";

            if (DisplayPrompt() == 1)
            {
                serviceConnection = "fabric:/MailServerApplication/MailServerStatelessService";
                service = ServiceProxy.Create<IMailService>
                    (new Uri(serviceConnection));
            }
            else
            {
                serviceConnection = "fabric:/MailServerApplication/MailServerStatefulService";
                service = ServiceProxy.Create<IMailService>
                    (new Uri(serviceConnection), 
                    new ServicePartitionKey(1), 
                    Microsoft.ServiceFabric.Services.Communication.Client.TargetReplicaSelector.Default);
            }

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(" Connected to cluster service :" + serviceConnection);
            Console.SetCursorPosition(0, 4);
            Console.Write("   Sending Mail To :");

            Console.SetCursorPosition(0, 7);
            Console.Write("   Total Mails Processed :");

            return service;
        }

        public static int DisplayPrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Connect client application to ...");
            Console.WriteLine();
            Console.WriteLine("                1. Stateless Mail Service");
            Console.WriteLine("                2. Stateful Mail Service");

            return int.Parse(Console.ReadLine());
        }
    }
}
