using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.WindowApp
{
    public class TryCatchFinallyDemo
    {
        #region "Singleton Intance"

        private static readonly TryCatchFinallyDemo _Instance = new TryCatchFinallyDemo();

        private TryCatchFinallyDemo()
        {

        }

        public static TryCatchFinallyDemo Instance
        {
            get
            {
                return _Instance;
            }
        }

        #endregion

        public void UseOfTryCatchFinallyDemo()
        {
            Sample1();

            Console.ReadLine();
        }

        private void Sample1()
        {
            try
            {
                Console.WriteLine("Try");
                throw new Exception();
            }
            catch
            {
                Console.WriteLine("Catch");
                throw;
            }
            finally
            {
                Console.WriteLine("Finally");
            }
        }

        public void TryCatchImplementation_1()
        {
            try
            {
                throw new Exception("401");
            }
            catch (Exception ex) when (ex.Message.Equals("500"))
            {
                //Write("Bad Request");
            }
            catch (Exception ex) when (ex.Message.Equals("401"))
            {
                //Write("Unauthorized");
            }
            catch (Exception ex) when (ex.Message.Equals("402"))
            {
                //Write("Payment Required");
            }
            catch (Exception ex) when (ex.Message.Equals("403"))
            {
                //Write("Forbidden");
            }
            catch (Exception ex) when (ex.Message.Equals("404"))
            {
                //Write("Not Found");
            }
        }
    }
}
