using Amalay.WindowApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.WindowApp
{
    public class StaticVariablesDemo
    {
        #region "Singleton Intance"

        private static readonly StaticVariablesDemo _Instance = new StaticVariablesDemo();

        private StaticVariablesDemo()
        {

        }

        public static StaticVariablesDemo Instance
        {
            get
            {
                return _Instance;
            }
        }

        #endregion

        public void UseOfStaticVariables()
        {
            //string s;
            //DateTime d;

            //Console.WriteLine(s == null ? "null" : s);
            //Console.WriteLine(d == null ? "null" : d.ToString());
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            Employee.SetNextEmpId(76);
            Employee emp1 = new Employee();
            Employee emp2 = new Employee();

            Console.WriteLine(Employee.GetNextEmpId());
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Console.ReadLine();
        }
    }    
}
