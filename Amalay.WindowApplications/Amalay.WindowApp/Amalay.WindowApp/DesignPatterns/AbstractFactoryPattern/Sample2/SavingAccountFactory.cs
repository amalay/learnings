using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amalay.WindowApp.Entities;

namespace Amalay.WindowApp.DesignPatterns.AbstractFactoryPattern.Sample2
{
    public class SavingAccountFactory : AccountFactory
    {
        public override IAccount CreateAccount()
        {
            return new SavingAccount();
        }
    }
}
