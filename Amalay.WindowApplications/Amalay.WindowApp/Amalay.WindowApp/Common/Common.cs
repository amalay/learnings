using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.WindowApp
{
    public class Common
    {
        #region "Singleton Intance"

        private static readonly Common _Instance = new Common();

        private Common()
        {

        }

        public static Common Instance
        {
            get
            {
                return _Instance;
            }
        }

        #endregion

        public void Swap<T>(ref T t1, ref T t2)
        {
            T t = t1;
            t1 = t2;
            t2 = t;
        }
    }
}
