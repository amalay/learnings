using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.WindowApp
{
    public class Utilities
    {
        #region "Singleton Intance"

        private static readonly Utilities _Instance = new Utilities();

        private Utilities()
        {

        }

        public static Utilities Instance
        {
            get
            {
                return _Instance;
            }
        }

        #endregion

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public string GetFullName(string firstName, string lastName)
        {
            return firstName + " " + lastName;
        }

        public int Sum(int x, int y)
        {
            return x + y;
        }

        public int Multiply(int x, int y)
        {
            return x * y;
        }
    }
}
