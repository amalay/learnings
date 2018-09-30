using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.WindowApp.Entities
{
    public class Bike : IVehical
    {
        public string Name { get; set; }

        public Bike()
        {
            this.Name = "Bike";
        }
    }
}
