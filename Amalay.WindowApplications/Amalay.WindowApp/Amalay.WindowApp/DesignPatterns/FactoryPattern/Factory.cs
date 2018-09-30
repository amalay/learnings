using Amalay.WindowApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.WindowApp.DesignPatterns.FactoryPattern
{
    public class Factory
    {
        public IVehical GetVehical(VehicalType vehicalType)
        {
            IVehical vehical = null;

            if (vehicalType == VehicalType.Car)
            {
                vehical = new Car();
            }
            else if (vehicalType == VehicalType.Bike)
            {
                vehical = new Bike();
            }

            return vehical;
        }
    }
}
