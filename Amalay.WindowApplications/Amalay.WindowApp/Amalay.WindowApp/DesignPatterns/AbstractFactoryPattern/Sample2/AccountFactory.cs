using Amalay.WindowApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.WindowApp.DesignPatterns.AbstractFactoryPattern.Sample2
{
    public abstract class AccountFactory
    {
        public abstract IAccount CreateAccount();
    }
}
