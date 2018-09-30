using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Amalay.WindowApp
{
    public class TaskDemo
    {
        #region "Singleton Intance"

        private static readonly TaskDemo _Instance = new TaskDemo();

        private TaskDemo()
        {

        }

        public static TaskDemo Instance
        {
            get
            {
                return _Instance;
            }
        }

        #endregion

        #region "UseOfTask"

        public void UseOfTask()
        {
            Task task = new Task(PrintHello);
            task.Start();

            Task<string> returnTask = new Task<string>(GetMessage);
            returnTask.Start();
            returnTask.Wait();
            Console.WriteLine(returnTask.Result);
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            Console.ReadLine();
        }

        private string GetMessage()
        {
            Thread.Sleep(2000);
            return "How are you!";
        }

        private void PrintHello()
        {
            Console.WriteLine("Hello!");
        }
        #endregion

        #region "TaskInputOutputBound"

        public void UseOfTaskIOBound()
        {
            Task<string> task = Task.Factory.StartNew<string>(() => GetPost("https://jsonplaceholder.typicode.com/posts"));

            DoSomethingElse();
                        
            try
            {
                task.Wait(); //Wait for task to complete.
                Console.WriteLine(task.Result);
            }
            catch(AggregateException aex)
            {
                Console.WriteLine(aex.Message);
            }

            Console.ReadLine();
        }

        private void DoSomethingElse()
        {
            //Do something else.
        }

        private static string GetPost(string url)
        {
            using (var client = new System.Net.WebClient())
            {
                return client.DownloadString(url);
            }
        }
        #endregion
    }
}
