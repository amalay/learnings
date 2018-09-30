using Amalay.WindowApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amalay.WindowApp.DesignPatterns.AbstractFactoryPattern.Sample2
{
    public class AbstractFactoryClient
    {
        #region "Singleton Intance"

        private static readonly AbstractFactoryClient _Instance = new AbstractFactoryClient();

        private AbstractFactoryClient()
        {

        }

        public static AbstractFactoryClient Instance
        {
            get
            {
                return _Instance;
            }
        }

        #endregion

        public void Demo(Label lblInputText, Label lblInput, Label lblOutputText, Label lblOutput)
        {
            IAccount account = null;

            AbstractFactory factory = new AbstractFactory();

            if(factory != null)
            {
                account = factory.GetAccount(AccountType.SavingAccount);
                lblInputText.Text = "First Account Type: " + account.Name;
                lblInput.Text = "Balance: " + account.Balance;

                account = factory.GetAccount(AccountType.CurrentAccount);
                lblOutputText.Text = "Second Account Type: " + account.Name;
                lblOutput.Text = "Balance: " + account.Balance;
            }
        }        
    }
}
