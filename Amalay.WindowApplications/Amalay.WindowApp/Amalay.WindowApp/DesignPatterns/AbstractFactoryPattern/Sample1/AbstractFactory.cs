using Amalay.WindowApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.WindowApp.DesignPatterns.AbstractFactoryPattern.Sample1
{
    public class AbstractFactory
    {
        public IVehical GetVehical(VehicalType vehicalType)
        {
            IVehical vehical = null;

            IVehicalFactory factory = this.GetFactory(vehicalType);

            if(factory != null)
            {
                vehical = factory.CreateVehical();
            }

            return vehical;
        }

        private IVehicalFactory GetFactory(VehicalType vehicalType)
        {
            IVehicalFactory factory = null;

            if(vehicalType == VehicalType.Car)
            {
                factory = new CarFactory();
            }
            else if(vehicalType == VehicalType.Bike)
            {
                factory = new BikeFactory();
            }

            return factory;
        }
    }
}
