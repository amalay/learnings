using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.WindowApp.SOLID.ISP
{
    //Understanding “I” - ISP (Interface Segregation principle)
    //Now assume that our customer class has become a SUPER HIT component and it’s consumed across 1000 clients and they are very happy using the customer class.

    //Now let’s say some new clients come up with a demand saying that we also want a method which will help us to “Read” customer data. 

    public class InterfaceSegregationPrinciple
    {

    }

    public class FileLogger
    {
        public void Handle(string error)
        {
            System.IO.File.WriteAllText(@"c:\Error.txt", error);
        }
    }

    public interface IDiscount
    {
        double GetDiscount(double TotalSales);
    }

    public interface IDatabase
    {
        void AddCustomer();

        //void Read();
    }

    //So developers who are highly enthusiastic would like to change the “IDatabase” interfaceas and add Read() method shown above.
    //But by doing so we have done something terrible, can you guess ? 
    //If you visualize the new requirement which has come up, you have two kinds of client’s: -
    //1. Who want’s just use “Add” method.
    //2. The other who wants to use “Add” + “Read”.

    //Now by changing the current interface you are doing an awful thing, disturbing the 1000 satisfied current client’s , even when they are not interested in the “Read” method. 
    //You are forcing them to use the “Read” method.
    
    public class SilverCustomer : IDiscount, IDatabase
    {
        private FileLogger obj = new FileLogger();

        public double GetDiscount(double TotalSales)
        {
            return TotalSales - 50;
        }

        public void AddCustomer()
        {
            try
            {
                // Database code goes here
            }
            catch (Exception ex)
            {
                obj.Handle(ex.Message.ToString());
            }
        }
    }

    public class GoldCustomer : IDiscount, IDatabase
    {
        private FileLogger obj = new FileLogger();

        public double GetDiscount(double TotalSales)
        {
            return TotalSales - 100;
        }

        public void AddCustomer()
        {
            try
            {
                // Database code goes here
            }
            catch (Exception ex)
            {
                obj.Handle(ex.Message.ToString());
            }
        }
    }

    public class DimondCustomer : IDiscount, IDatabase
    {
        private FileLogger obj = new FileLogger();

        public double GetDiscount(double TotalSales)
        {
            return TotalSales - 100;
        }

        public void AddCustomer()
        {
            try
            {
                // Database code goes here
            }
            catch (Exception ex)
            {
                obj.Handle(ex.Message.ToString());
            }
        }

        public void Read()
        {
            // Implements  logic for read
        }
    }

    //==============================================================================
    //So a better approach would be to keep existing clients in their own sweet world and the serve the new client’s separately.
    //So the better solution would be to create a new interface rather than updating the current interface. So we can keep the current interface “IDatabase” as it is and 
    //add a new interface “IDatabaseV1” with the “Read” method the “V1” stands for version 1.

    public interface IDatabaseV1 : IDatabase // Gets the Add method
    {
        void Read();
    }

    public class SilverCustomer_1 : IDiscount, IDatabase
    {
        private FileLogger obj = new FileLogger();

        public double GetDiscount(double TotalSales)
        {
            return TotalSales - 50;
        }

        public void AddCustomer()
        {
            try
            {
                // Database code goes here
            }
            catch (Exception ex)
            {
                obj.Handle(ex.Message.ToString());
            }
        }
    }

    public class GoldCustomer_1 : IDiscount, IDatabase
    {
        private FileLogger obj = new FileLogger();

        public double GetDiscount(double TotalSales)
        {
            return TotalSales - 100;
        }

        public void AddCustomer()
        {
            try
            {
                // Database code goes here
            }
            catch (Exception ex)
            {
                obj.Handle(ex.Message.ToString());
            }
        }
    }

    public class DimondCustomer_1 : IDiscount, IDatabaseV1
    {
        private FileLogger obj = new FileLogger();

        public double GetDiscount(double TotalSales)
        {
            return TotalSales - 100;
        }

        public void AddCustomer()
        {
            try
            {
                // Database code goes here
            }
            catch (Exception ex)
            {
                obj.Handle(ex.Message.ToString());
            }
        }
        public void Read()
        {
            // Implements  logic for read
        }
    }   
}
