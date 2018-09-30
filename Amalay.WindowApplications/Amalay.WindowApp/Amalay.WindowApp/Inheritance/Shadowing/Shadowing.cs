using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.WindowApp
{
    public class Shadowing
    {
        #region "Singleton Intance"

        private static readonly Shadowing _Instance = new Shadowing();

        private Shadowing()
        {

        }

        public static Shadowing Instance
        {
            get
            {
                return _Instance;
            }
        }

        #endregion

        public void UseOfShadowing()
        {
            var customer = new PrivilegedCustomer();
            int discount = customer.Discount();

            Console.WriteLine(discount);
            Console.ReadLine();
        }
    }

    public class Customer
    {
        public int Discount()
        {
            return 0;
        }
    }

    public class PrivilegedCustomer : Customer
    {
        public new int Discount()
        {
            return 10;
        }
    }
}
