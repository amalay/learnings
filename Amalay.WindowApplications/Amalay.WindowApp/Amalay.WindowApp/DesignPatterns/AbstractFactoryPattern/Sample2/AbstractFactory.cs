using Amalay.WindowApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.WindowApp.DesignPatterns.AbstractFactoryPattern.Sample2
{
    public class AbstractFactory
    {
        public IAccount GetAccount(AccountType accountType)
        {
            IAccount account = null;

            AccountFactory factory = this.GetFactory(accountType);

            if (factory != null)
            {
                account = factory.CreateAccount();
            }

            return account;
        }

        private AccountFactory GetFactory(AccountType accountType)
        {
            AccountFactory factory = null;

            if (accountType == AccountType.SavingAccount)
            {
                return new SavingAccountFactory();
            }
            else if (accountType == AccountType.CurrentAccount)
            {
                return new CurrentAccountFactory();
            }

            return factory;
        }
    }
}
