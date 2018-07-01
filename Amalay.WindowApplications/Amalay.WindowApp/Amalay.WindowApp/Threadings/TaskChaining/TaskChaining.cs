using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Amalay.WindowApp
{
    public class TaskChaining
    {
        #region "Singleton Intance"

        private static readonly TaskChaining _Instance = new TaskChaining();

        private TaskChaining()
        {

        }

        public static TaskChaining Instance
        {
            get
            {
                return _Instance;
            }
        }

        #endregion

        #region "UseOfTaskChaining"

        public void Method1()
        {
            Task<string> antecedent = Task.Run(() => DateTime.Now.ToString());
            Task<string> continuation = antecedent.ContinueWith(x => "Time now is : " + antecedent.Result);
            Console.WriteLine(continuation.Result);
        }

        public void Method2()
        {
            Task<string> antecedent = Task.Run(() => 
            {
                Task.Delay(2000);
                return DateTime.Now.ToString();
            });

            Task<string> continuation = antecedent.ContinueWith(x => 
            {
                return "Time now is : " + antecedent.Result;
            });

            Console.WriteLine("Print before result!");
            Console.WriteLine(continuation.Result);
        }
        #endregion
    }
}
