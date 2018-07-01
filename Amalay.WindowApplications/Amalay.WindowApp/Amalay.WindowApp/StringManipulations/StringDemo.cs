using Amalay.WindowApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.WindowApp
{
    public class StringDemo
    {
        #region "Singleton Intance"

        private static readonly StringDemo _Instance = new StringDemo();

        private StringDemo()
        {

        }

        public static StringDemo Instance
        {
            get
            {
                return _Instance;
            }
        }

        #endregion

        public void UseOfStringComparison()
        {
            string s1 = "Hello";
            string s2 = s1;

            //Compare the actual string data.
            Console.WriteLine("Actual data of string are equal: " + (s1 == s2 ? true : false));   //True

            //Compare the string value i.e. pointer to data.
            Console.WriteLine("Are the values (pointer to data) of string same? " + object.ReferenceEquals(s1, s2)); //True

            //Here both results are true because both s1 and s2 are pointing to the same reference/data.
            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            string s3 = s1;
            s3 += " User";

            //Compare the actual string data.
            Console.WriteLine("Actual data of string are equal: " + (s1 == s3 ? true : false));

            //Compare the string value i.e. pointer to data.
            Console.WriteLine("Are the values (pointer to data) of string same? " + object.ReferenceEquals(s1, s3));

            //Here results are false because as soon as we perform some operaion of the string, it create a new instance for the resultent string.
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            Console.ReadLine();
        }

        public void UseOfStringFormating()
        {
            Person p = new Person() { Name = "John", DOB = new DateTime(1980, 6, 21) };
            string text = string.Format("{0} was born on {1:D}", p.Name, p.DOB);
            string text1 = $"{p.Name} was born on {p.DOB:D}";

            Console.WriteLine(text);
            Console.WriteLine(text1);
            Console.ReadLine();
        }

        #region "Twin Strings"

        public void FindTwins()
        {
            string[] a = { "cdab", "dcba" };
            string[] b = { "abcd", "abcd" };

            try
            {
                string[] result = Twins(a, b);

                for (int i = 0; i < result.Length; i++)
                {
                    Console.WriteLine(string.Format("Are {0} and {1} twins? {2}", a[i], b[i], result[i]));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            Console.ReadLine();
        }

        private string[] Twins(string[] a, string[] b)
        {
            if (a == null || b == null || a.Length <= 0 || b.Length <= 0 || a.Length != b.Length)
            {
                throw new Exception("Invalid input supplied!");
            }

            int inputLength = a.Length;
            string[] results = new string[inputLength];

            for (int i = 0; i < inputLength; i++)
            {
                results[i] = "NO";
            }

            for (int i = 0; i < inputLength; i++)
            {
                string s1 = a[i];
                string s2 = b[i];

                if (s1.Length == s2.Length)
                {
                    char[] temp = s1.ToCharArray();
                    bool evenCheck = true;

                    temp[0] = s1[2];
                    temp[2] = s1[0];

                    Comparision:
                    string s = new string(temp);
                    if (s == s2)
                    {
                        results[i] = "YES";
                    }
                    else if (evenCheck)
                    {
                        evenCheck = false;
                        temp[1] = s1[3];
                        temp[3] = s1[1];
                        goto Comparision;
                    }
                }
            }

            return results;
        }

        #endregion
    }
}
