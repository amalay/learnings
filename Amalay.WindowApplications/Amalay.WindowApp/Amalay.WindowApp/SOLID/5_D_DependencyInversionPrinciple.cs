using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.WindowApp.SOLID.DIP
{
    public class DependencyInversionPrinciple
    {

    }

    public class Customer
    {
        private FileLogger obj = new FileLogger();

        public virtual void Add()
        {
            try
            {
                // Database code goes here
            }
            catch (Exception ex)
            {
                obj.Handle(ex.ToString());
            }
        }
    }

    public class FileLogger
    {
        public void Handle(string error)
        {
            System.IO.File.WriteAllText(@"c:\Error.txt", error);
        }
    }

    //In our customer class if you remember we had created a logger class to satisfy SRP. Down the line let’s say new Logger flavor classes are created.

    //Just to control things we create a common interface and using this common interface new logger flavors will be created.

    //================================================================
    public interface ILogger
    {
        void Handle(string error);
    }

    public class FileLogger_1 : ILogger
    {
        public void Handle(string error)
        {
            System.IO.File.WriteAllText(@"c:\Error.txt", error);
        }
    }

    public class EventViewerLogger_1 : ILogger
    {
        public void Handle(string error)
        {
            // log errors to event viewer
        }
    }

    public class EmailLogger_1 : ILogger
    {
        public void Handle(string error)
        {
            // send errors in email
        }
    }

    //Now depending on configuration settings different logger classes will used at given moment. So to achieve the same we have kept a simple IF condition which decides which 
    //logger class to be used as below: 

    public interface IDiscount
    {
        double GetDiscount(double TotalSales);
    }

    public interface IDatabase
    {
        void AddCustomer();
    }

    public interface IDatabaseV1 : IDatabase // Gets the Add method
    {
        void Read();
    }

    public class Customer_1 : IDiscount, IDatabase
    {
        private ILogger logger;

        public int ExceptionType { get; set; }

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
                if (this.ExceptionType == 1)
                {
                    logger = new FileLogger_1();
                }
                else
                {
                    logger = new EmailLogger_1();
                }

                logger.Handle(ex.Message.ToString());
            }
        }
    }

    //The above code is again violating SRP but this time the aspect is different ,its about deciding which objects should be created. 
    //Now it’s not the work of “Customer” object to decide which instances to be created , he should be concentrating only on Customer class related functionalities.

    //f you watch closely the biggest problem is the “NEW” keyword. He is taking extra responsibilities of which object needs to be created.
    //So if we INVERT / DELEGATE this responsibility to someone else rather the customer class doing it that would really solve the problem to a certain extent.

    //So here’s the modified code with INVERSION implemented. We have opened the constructor mouth and we expect someone else to pass the object rather than the customer class doing it. 
    //So now it’s the responsibility of the client who is consuming the customer object to decide which Logger class to inject.

    public class Customer_2 : IDiscount, IDatabase
    {
        private ILogger logger;

        public Customer_2(ILogger logger)
        {
            this.logger = logger;
        }

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
                this.logger.Handle(ex.Message.ToString());
            }
        }
    }

    public class Demo
    {
        public void Test()
        {
            IDatabase customer = new Customer_2(new EmailLogger_1());
            customer.AddCustomer();
        }
    }
}
