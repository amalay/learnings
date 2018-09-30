using Amalay.WindowApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Amalay.WindowApp
{
    public class MultiThreading
    {
        #region "Singleton Intance"

        private static readonly MultiThreading _Instance = new MultiThreading();

        private MultiThreading()
        {

        }

        public static MultiThreading Instance
        {
            get
            {
                return _Instance;
            }
        }

        #endregion

        #region "Context Switching"
        public void UseOfContextSwitching()
        {
            Thread thread = new Thread(WriteUsingNewThread);
            thread.Name = "Amalay Worker Thread";
            //Worker Thread
            thread.Start();

            //Main thread
            Thread.CurrentThread.Name = "Amalay Main Thread";
            for (int i = 0; i < 100; i++)
            {
                Console.Write("M" + i + " ");
            }

            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Console.ReadLine();
        }

        private void WriteUsingNewThread()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.Write("W" + i + " ");
            }
        }

        #endregion

        #region "Resource Sharing"

        private bool isComplete { get; set; }

        public void UseOfResourceSharing()
        {
            Thread thread = new Thread(PrintHello1);
            thread.Name = "Amalay Worker Thread";
            //Worker Thread
            thread.Start();

            //Main thread
            Thread.CurrentThread.Name = "Amalay Main Thread";
            PrintHello1();

            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Console.ReadLine();
        }

        private void PrintHello()
        {
            if (!isComplete)
            {
                isComplete = true;      //If put this check here it will print only once. But it is not a full proof solution.
                Console.WriteLine("Hello should print only once!");
                //isComplete = true;    //If put this check here it will print twice.
            }
        }

        private readonly object lockComplete = new object();

        //Full proof solution by using lock.
        private void PrintHello1()
        {
            lock (lockComplete)
            {
                if (!isComplete)
                {
                    isComplete = true;
                    Console.WriteLine("Hello should print only once!");
                }
            }
        }

        #endregion

        #region "Local Memory Sharing"
        public void UseOfLocalMemorySharing()
        {
            Thread thread = new Thread(Print);
            thread.Name = "Amalay Worker Thread";
            //Worker Thread
            thread.Start();

            //Main thread
            Thread.CurrentThread.Name = "Amalay Main Thread";
            Print();

            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Console.ReadLine();
        }

        private void Print()
        {
            for (int i = 0; i < 30; i++)
            {
                Console.Write(i + 1 + " ");
            }
        }

        #endregion

        #region "ThreadPool"

        public void UseOfThreadPool()
        {
            Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread); //Check whether it thread pool or not.

            Employee employee = new Employee() { Name = "Amalay", CompanyName = "Microsoft" };
            ThreadPool.QueueUserWorkItem(new WaitCallback(DisplayImployeeInfo), employee);

            var processorCount = Environment.ProcessorCount;
            int workerThread = 0;
            int completionPortThread = 0;
            ThreadPool.GetMinThreads(out workerThread, out completionPortThread);
            ThreadPool.SetMaxThreads(workerThread * 2, completionPortThread * 2);

            Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread); //Check whether it thread pool or not.
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Console.ReadKey();
        }

        private void DisplayImployeeInfo(object employee)
        {
            Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread); //Check whether it thread pool or not.
            Employee emp = employee as Employee;

            if (emp != null)
            {
                Console.WriteLine("Employee name is {0} and company name is {1}", emp.Name, emp.CompanyName);
            }
        }

        #endregion

        #region "ThreadConcept"

        public void UseOfSleepAndJoin()
        {
            Thread thread = new Thread(PrintHelloWorld);
            thread.Name = "Amalay Worker Thread";
            //Worker Thread
            thread.Start();
            thread.IsBackground = true;
            thread.Join();

            //Main thread            
            Thread.CurrentThread.Name = "Amalay Main Thread";
            Console.WriteLine("Hello world printed!");

            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Console.ReadLine();
        }

        private void PrintHelloWorld()
        {
            Console.WriteLine("Hello world!");
            Thread.Sleep(5000);
        }

        #endregion

        #region "Exception handlling in multithreading"

        public void UseOfExceptionHandlling()
        {
            //RaiseException();
            RaiseException1();
        }

        private void RaiseException()
        {
            try
            {
                //Execute();    //Main thread.
                new Thread(Execute).Start();    //Worker thread.
            }
            catch(Exception ex) //Main thread catch block.
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Execute()
        {
            throw null;
        }

        private void RaiseException1()
        {
            //Execute1();    //Main thread.
            new Thread(Execute1).Start();    //Worker thread.
        }

        private void Execute1()
        {
            try
            {
                throw null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
