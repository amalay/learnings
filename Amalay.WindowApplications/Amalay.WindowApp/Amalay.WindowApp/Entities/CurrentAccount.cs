using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.WindowApp.Entities
{
    public class CurrentAccount : IAccount
    {
        public string Name { get; set; }

        public double Balance { get; set; }

        public CurrentAccount()
        {
            this.Name = "Current Account";
            this.Balance = 500;
        }
    }
}
