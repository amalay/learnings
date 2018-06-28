using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.WindowApp.Entities
{
    public class Car : IVehical
    {
        public string Name { get; set; }

        public Car()
        {
            this.Name = "Car";
        }
    }
}
