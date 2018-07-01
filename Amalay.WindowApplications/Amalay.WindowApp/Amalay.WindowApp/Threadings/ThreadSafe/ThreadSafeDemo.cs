using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Amalay.WindowApp
{
    public class ThreadSafeDemo
    {
        #region "Singleton Intance"

        private static readonly ThreadSafeDemo _Instance = new ThreadSafeDemo();

        private ThreadSafeDemo()
        {

        }

        public static ThreadSafeDemo Instance
        {
            get
            {
                return _Instance;
            }
        }

        #endregion

        static Random random = new Random();
        static readonly object _object = new object();

        #region "Not Thread Safe"

        public void UseOfNotThreadSafe()
        {
            Thread thread = new Thread(Division);
            thread.Start();

            Division();

            Console.ReadLine();
        }

        /// <summary>
        /// It could be possible that divide by zero exception may or may not occur.
        /// </summary>
        private void Division()
        {
            int a = 0, b = 0;

            for (int i = 0; i <= 100; i++)
            {
                try
                {
                    //Choosing random numbers between 1 to 5
                    a = random.Next(1, 5);
                    b = random.Next(1, 5);

                    //Dividing
                    double result = a / b;

                    //Reset Variables
                    a = 0;
                    b = 0;

                    Console.WriteLine("Result : {0} --> {1}", i, result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        #endregion

        #region "ThredSafe"

        public void UseOfThreadSafe()
        {
            Thread thread = new Thread(Division_1);
            thread.Start();

            Division_1();

            Console.ReadLine();
        }

        /// <summary>
        /// To prevent devide by zero exception, we need to apply thread safty technique like Monitor or lock.
        /// </summary>
        private void Division_1()
        {
            int a = 0, b = 0;

            for (int i = 0; i <= 100; i++)
            {
                try
                {
                    Monitor.Enter(_object);

                    //Choosing random numbers between 1 to 5
                    a = random.Next(1, 5);
                    b = random.Next(1, 5);

                    //Dividing
                    double result = a / b;

                    //Reset Variables
                    a = 0;
                    b = 0;

                    Console.WriteLine("Result : {0} --> {1}", i, result);

                    Monitor.Exit(_object);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        #endregion

        #region "Mutex"

        Mutex ObjMutex = new Mutex(true, "Test");

        public void UseOfMutex()
        {
            if (CheckInstance() == true)
            {
                Console.WriteLine("New Instance created...");
            }
            else
            {
                Console.WriteLine("Instance already acquired! Please wait to free...");
            }

            Console.ReadLine();
        }

        private bool CheckInstance()
        {
            if (ObjMutex.WaitOne(5000, false) == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        #region "Semaphore"

        static Semaphore objSem = new Semaphore(2, 2, "Test");

        public void UseOfSemaphore()
        {
            if (CheckInstance() == true)
            {
                Console.WriteLine("New Instance created...");
            }
            else
            {
                Console.WriteLine("Instance already acquired! Please wait to free...");
            }

            Console.ReadLine();
        }

        private bool CheckInstance_1()
        {
            if (objSem.WaitOne(5000, false) == false)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        #endregion
    }
}
