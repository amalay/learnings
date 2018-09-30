using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.Helpers
{
    public class EmailHelper
    {
        #region "Singleton Intance"

        private static readonly EmailHelper _Instance = new EmailHelper();

        private EmailHelper() { }

        public static EmailHelper Instance
        {
            get
            {
                return _Instance;
            }
        }

        #endregion
    }
}
