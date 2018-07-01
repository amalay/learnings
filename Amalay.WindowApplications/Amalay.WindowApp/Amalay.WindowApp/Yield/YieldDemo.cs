using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.WindowApp
{
    public class YieldDemo
    {
        #region "Singleton Intance"

        private static readonly YieldDemo _Instance = new YieldDemo();

        private YieldDemo()
        {

        }

        public static YieldDemo Instance
        {
            get
            {
                return _Instance;
            }
        }

        #endregion

        public void UseOfYield()
        {
            foreach (int i in Integers())
            {
                Console.WriteLine(i.ToString());
            }

            foreach (int i in Power(2, 4))
            {
                Console.Write("{0} ", i);                
            }

            Console.ReadLine();
        }

        private IEnumerable<int> Integers()
        {
            yield return 1;
            yield return 2;
            yield return 4;
            yield return 8;
            yield return 16;
        }

        private System.Collections.Generic.IEnumerable<int> Power(int number, int exponent)
        {
            int result = 1;

            for (int i = 0; i < exponent; i++)
            {
                result = result * number;
                yield return result;
            }
        }


        //public IEnumerable<T> Read<T>(string sql, Func<System.Data.IDataReader, T> make, params object[] parms)
        //{
        //    using (var connection = CreateConnection())
        //    {
        //        using (var command = CreateCommand(CommandType.Text, sql, connection, parms))
        //        {
        //            command.CommandTimeout = dataBaseSettings.ReadCommandTimeout;

        //            using (var reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    yield return make(reader);
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
