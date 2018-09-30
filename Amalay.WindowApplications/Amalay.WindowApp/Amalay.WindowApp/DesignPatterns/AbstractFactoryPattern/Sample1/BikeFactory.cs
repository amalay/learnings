using Amalay.WindowApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.WindowApp.DesignPatterns.AbstractFactoryPattern.Sample1
{
    public class BikeFactory : IVehicalFactory
    {
        public IVehical CreateVehical()
        {
            return new Bike();
        }
    }
}
