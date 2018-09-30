using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.WindowApp.Delegates
{
    public class SinglecastDelegate
    {
        #region "Singleton Intance"

        private static readonly SinglecastDelegate _Instance = new SinglecastDelegate();

        private SinglecastDelegate()
        {

        }

        public static SinglecastDelegate Instance
        {
            get
            {
                return _Instance;
            }
        }

        #endregion

        #region "Delegate Delaration"

        public delegate void DelegateOne(string text);
        public delegate string DelegateTwo(string firstName, string lastName);
        public delegate int DelegateThree(int x, int y);

        #endregion

        public void Demo()
        {
            DelegateOne instance1 = new DelegateOne(Utilities.Instance.DisplayMessage); //Delegate Instantiation            
            instance1("Hello!");   //Delegate Invocation.
            //=====================================================

            DelegateTwo instance2 = new DelegateTwo(Utilities.Instance.GetFullName); //Delegate Instantiation            
            string fullName = instance2("Amalay", "Verma");   //Delegate Invocation.
            Console.WriteLine(fullName);
            //=======================================================

            DelegateThree instance3 = new DelegateThree(Utilities.Instance.Sum);  //Delegate Instantiation   
            int result1 = instance3(2, 5);          //Delegate Invocation. OR
            int result2 = instance3.Invoke(3, 9);   //Delegate Invocation.
            Console.WriteLine(result1);
            Console.WriteLine(result2);
            //===========================================================

            DelegateThree instance31 = Utilities.Instance.Sum;      //Delegate Instantiation
            int result3 = instance31(4, 5);                         //Delegate Invocation.
            Console.WriteLine(result3);
            //=======================================

            DelegateThree instance32 = delegate (int x, int y) // Instantiate delegate with anonymous method:
            {
                return x * y;
            };

            int result4 = instance32(11, 5); //Delegate Invocation.
            Console.WriteLine(result4);
            //=======================================

            DelegateThree instance33 = (x, y) => x * y;     //Instantiate delegate with lambda expression
            int result5 = instance33(31, 4);                //Delegate Invocation.
            Console.WriteLine(result5);
            //===========================================

            Console.ReadLine();
        }
    }
}
