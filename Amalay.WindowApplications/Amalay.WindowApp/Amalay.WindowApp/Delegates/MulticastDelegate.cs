using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.WindowApp.Delegates
{
    public class MulticastDelegate
    {
        #region "Singleton Intance"

        private static readonly MulticastDelegate _Instance = new MulticastDelegate();

        private MulticastDelegate()
        {

        }

        public static MulticastDelegate Instance
        {
            get
            {
                return _Instance;
            }
        }

        #endregion

        #region "Delegate Delaration"

        //Delegate Delaration
        public delegate int MyDelegate(int x, int y);

        #endregion

        public void Demo()
        {
            MyDelegate myDelegate1 = new MyDelegate(Utilities.Instance.Sum); //Delegate Instantiation 
            MyDelegate myDelegate2 = new MyDelegate(Utilities.Instance.Multiply); //Delegate Instantiation 

            MyDelegate multicastDelegate1 = (MyDelegate)Delegate.Combine(myDelegate1, myDelegate2); //Combining multiple delegate instances.

            int result = multicastDelegate1.Invoke(2, 3);    
                    
            foreach (MyDelegate md in multicastDelegate1.GetInvocationList())
            {
                int result1 = md.Invoke(1, 2); //Delegate Invocation.
                Console.WriteLine(result1);
            }
            //===================================================

            MyDelegate multicastDelegate2 = myDelegate1 + myDelegate2;

            foreach (MyDelegate md in multicastDelegate2.GetInvocationList())
            {
                int result2 = md.Invoke(2, 3);
                Console.WriteLine(result2);
            }
            //====================================================

            MyDelegate multicastDelegate3 = null;

            multicastDelegate3 += Utilities.Instance.Sum;
            multicastDelegate3 += Utilities.Instance.Multiply;

            foreach (MyDelegate md in multicastDelegate3.GetInvocationList())
            {
                int result3 = md.Invoke(4, 5);
                Console.WriteLine(result3);
            }
            //===========================================================

            //Syntax: Func<InputType1, InputType2, ReturnType> func = delegate {};
            Func<int, int, int> func = delegate (int x, int y)
            {
                return x + y;
            };

            func += delegate (int x, int y)
            {
                return x * y;
            };

            int result4 = func(5, 6);

            foreach (Func<int, int, int> md in func.GetInvocationList())
            {
                int result5 = md(5, 6);
                Console.WriteLine(result5);

                int result6 = md.Invoke(6, 7);
                Console.WriteLine(result6);
            }

            Console.ReadLine();
        }
    }
}
