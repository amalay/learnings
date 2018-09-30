using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.WindowApp.Entities
{
    public class SavingAccount : IAccount
    {
        public string Name { get; set; }

        public double Balance { get; set; }

        public SavingAccount()
        {
            this.Name = "Saving Account";
            this.Balance = 1000;
        }
    }
}
