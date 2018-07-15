using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.WindowApp.SOLID.OCP
{
    //Understanding “O” - Open closed principle

    //Let’s continue with our same customer class example. I have added a simple customer type property to the class. This property decided if this is a “Gold” ora “Silver” customer.
    //Depending on the same it calculates discount.Have a look at the “getDiscount” function which returns discount accordingly. 1 for Gold customer and 2 for Silver customer.
    //Guess, what’s the problem with the below code

    public class OpenClosedPrinciple
    {

    }

    public class Customer
    {
        private int _CustType;

        public int CustType
        {
            get { return _CustType; }
            set { _CustType = value; }
        }

        public double getDiscount(double TotalSales)
        {
            if (_CustType == 1)
            {
                return TotalSales - 100;
            }
            else
            {
                return TotalSales - 50;
            }
        }
    }

    //The problem is if we add a new customer type we need to go and add one more “IF” condition in the “getDiscount” function, in other words we need to change the customer class.
    //If we are changing the customer class again and again, we need to ensure that the previous conditions with new one’s are tested again, existing client’s which are referencing 
    //this class are working properly as before.
    //In other words we are “MODIFYING” the current customer code for every change and every time we modify we need to ensure that all the previous functionalities and connected client are 
    //working as before.

    //How about rather than “MODIFYING” we go for “EXTENSION”. In other words every time a new customer type needs to be added we create a new class as shown in the below.
    //So whatever is the current code they are untouched and we just need to test and check the new classes.


    //=========================================================
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

    //Putting in simple words the “Customer” class is now closed for any new modification but it’s open for extensions when new customer types are added to the project.
}
