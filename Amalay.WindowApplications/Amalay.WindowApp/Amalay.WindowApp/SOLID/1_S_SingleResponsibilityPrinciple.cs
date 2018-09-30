using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.WindowApp.SOLID.SRP
{
    //Understanding “S”- SRP (Single responsibility principle)
    //Have a look at the code below, can you guess what the problem is ?

    public class SingleResponsibilityPrinciple
    {

    }

    public class Customer
    {
        public void Add()
        {
            try
            {
                // Database code goes here
            }
            catch (Exception ex)
            {
                System.IO.File.WriteAllText(@"c:\Error.txt", ex.ToString());
            }
        }
    }

    //The above customer class is doing things WHICH HE IS NOT SUPPOSED TO DO. Customer class should do customer datavalidations, call the customer data access layer etc , 
    //but if you see the catch block closely it also doing LOGGING activity. In simple words its over loaded with lot of responsibility.
    //So tomorrow if add a new logger like event viewer I need to go and change the “Customer”class, that’s very ODD.

    //===========================================================================
    //So SRP says that a class should have only one responsibility and not multiple.So if we apply SRP we can move that logging activity to some other class who will only look after logging activities.

    public class Customer_1
    {
        private FileLogger obj = new FileLogger();

        public void Add()
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

    //Now architecture thought process is an evolution. For some people who are seniors looking at above SRP example can contradict that even the try catch should not be handled by the customer class 
    //because that is not his work. Yes, we can create a global error handler must be in theGlobal.asax file, assuming you are using ASP.NET and handle the errors in those section and
    //make the customer class completely free.

}
