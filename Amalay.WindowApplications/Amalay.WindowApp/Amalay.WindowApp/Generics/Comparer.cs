using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.WindowApp
{
    public class Comparer<Unknown>
    {
        #region "Singleton Intance"

        private static readonly Comparer<Unknown> _Instance = new Comparer<Unknown>();

        private Comparer()
        {

        }

        public static Comparer<Unknown> Instance
        {
            get
            {
                return _Instance;
            }
        }

        #endregion

        private bool Compare(Unknown t1, Unknown t2)
        {
            if (t1.Equals(t2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ComparerDemo()
        {
            Comparer<int> oComparerInt = new Comparer<int>();
            var result = oComparerInt.Compare(10, 10);

            Comparer<string> oComparerStr = new Comparer<string>();
            var result1 = oComparerStr.Compare("jdhsjhds", "10");
        }
    }
}
