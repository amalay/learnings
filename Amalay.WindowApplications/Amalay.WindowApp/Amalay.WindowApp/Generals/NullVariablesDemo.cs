using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.WindowApp
{
    public class NullVariablesDemo
    {
        #region "Singleton Intance"

        private static readonly NullVariablesDemo _Instance = new NullVariablesDemo();

        private NullVariablesDemo()
        {

        }

        public static NullVariablesDemo Instance
        {
            get
            {
                return _Instance;
            }
        }

        #endregion

        public void UseOfNullVariables()
        {
            string s;
            DateTime d;

            //Console.WriteLine(s == null ? "null" : s);
            //Console.WriteLine(d == null ? "null" : d.ToString());
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Console.ReadLine();
        }

    }
}
