using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.WindowApp.SOLID.LSP
{
    //Understanding “L”- LSP(Liskov substitution principle)
    //Let’s continue with the same customer.Let’s say our system wants to calculate discounts for Enquiries.Now Enquiries are not actual customer’s they are just leads.Because they are just leads 
    //we do not want to save them to database for now.

    //So we create a new class called as Enquiry which inherits from the “Customer” class. We provide some discounts to the enquiry so that they can be converted to actual customers and 
    //we override the “Add’ method with an exception so that no one can add an Enquiry to the database.

    public class LiskovSubstitutionPrinciple
    {

    }

    public class Customer_1
    {
        public virtual double GetDiscount(double TotalSales)
        {
            return TotalSales;
        }

        public virtual void AddCustomer()
        {
            //Method to add particular customer to the respected tables inside database.
        }
    }

    public class SilverCustomer : Customer_1
    {
        public override double GetDiscount(double TotalSales)
        {
            return base.GetDiscount(TotalSales) - 50;
        }

        public override void AddCustomer()
        {
            //Method to add silver customer to the silver customer table inside database.
        }
    }

    public class GoldCustomer : Customer_1
    {
        public override double GetDiscount(double TotalSales)
        {
            return base.GetDiscount(TotalSales) - 100;
        }

        public override void AddCustomer()
        {
            //Method to add gold customer to the gold customer table inside database.
        }
    }

    public class Enquiry : Customer_1
    {
        public override double GetDiscount(double TotalSales)
        {
            return base.GetDiscount(TotalSales) - 5;
        }

        public override void AddCustomer()
        {
            throw new Exception("Not Allowed"); //Adding is not allowed for enquiries.
        }
    }

    //If you visualize the current customer inheritance hierarchy it looks “Customer” is the parent class with “Gold”, “Silver” and “Enquiry” as child classes.
    //So as per polymorphism rule my parent “Customer” class object can point to any of it child class objects i.e. “Gold”, “Silver” or “Enquiry” during runtime without any issues.

    //So for instance in the below code you can see I have created a list collection of “Customer” and thanks to polymorphism I can add “Silver” , “Gold” and “Enquiry” customer to 
    //the “Customer” collection without any issues.

    public class Demo
    {
        List<Customer_1> Customers = new List<Customer_1>();

        public void Set()
        {
            Customers.Add(new SilverCustomer());
            Customers.Add(new GoldCustomer());
            Customers.Add(new Enquiry());
        }

        public void Get()
        {
            foreach (Customer_1 customer in Customers)
            {
                customer.AddCustomer(); //Here it will throw error for Enquiry type of customer as "Not Allowed"
            }
        }
    }

    //Thanks to polymorphism I can also browse the “Customer” list using the parent customer object and invoke the “Add” method as shown in the above code inside Set method.
    //But what happen when the Enquiry object is browsed and invoked in the “FOR EACH” loop inside Set_1 method.

    //As per the inheritance hierarchy the “Customer” object can point to any one of its child objects and we do not expect any unusual behavior.
    //But when “Add” method of the “Enquiry” object is invoked it leads to error as "Not allowed" because our “Equiry” object does save enquiries to database as they are not actual customers.

    //In other words the “Enquiry” has discount calculation , it looks like a “Customer” but IT IS NOT A CUSTOMER. So the parent cannot replace the child object seamlessly. 
    //In other words “Customer” is not the actual parent for the “Enquiry”class. “Enquiry” is a different entity altogether. 

    //So LISKOV principle says the parent should easily replace the child object. So to implement LISKOV we need to create two interfaces one is for discount and other for database as shown below.


    //==================================================================

    public interface IDiscount
    {
        double GetDiscount(double TotalSales);
    }

    public interface IDatabase
    {
        void AddCustomer();
    }

    public class FileLogger
    {
        public void Handle(string error)
        {
            System.IO.File.WriteAllText(@"c:\Error.txt", error);
        }
    }

    //Now the “Enquiry” class will only implement “IDiscount” as he not interested in the “Add” method.
    public class Enquiry_1 : IDiscount
    {
        public double GetDiscount(double TotalSales)
        {
            return TotalSales - 5;
        }
    }

    //While the “Customer” class will implement both “IDiscount” as well as “IDatabase” as it also wants to persist the customer to the database.
    public class Customer_2 : IDiscount, IDatabase
    {
        private FileLogger obj = new FileLogger();

        public virtual double GetDiscount(double TotalSales)
        {
            return TotalSales;
        }

        public virtual void AddCustomer()
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
    
    public class SilverCustomer_1 : Customer_2
    {
        public override double GetDiscount(double TotalSales)
        {
            return base.GetDiscount(TotalSales) - 50;
        }

        public override void AddCustomer()
        {
            
        }
    }

    public class GoldCustomer_1 : Customer_2
    {
        public override double GetDiscount(double TotalSales)
        {
            return base.GetDiscount(TotalSales) - 100;
        }

        public override void AddCustomer()
        {
            //Method to add gold customer to the gold customer table inside database.
        }
    }

    //Now there is no confusion, we can create a list of “Idatabase” interface and add the relevant classes to it. In case we make a mistake of adding “Enquiry” class to the list compiler would 
    //complain as shown in the below code snippet.

    public class Demo_1
    {
        List<IDatabase> Customers = new List<IDatabase>();

        public void Set()
        {
            Customers.Add(new SilverCustomer_1());
            Customers.Add(new GoldCustomer_1());
            //Customers.Add(new Enquiry_1());     //Give compiler error if we do mistake to add Enquiry object
        }

        public void Get()
        {
            foreach (IDatabase customer in Customers)
            {
                customer.AddCustomer();
            }
        }
    }
}
