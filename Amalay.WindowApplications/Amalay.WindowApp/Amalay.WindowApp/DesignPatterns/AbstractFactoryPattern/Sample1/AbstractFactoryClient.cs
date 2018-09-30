using Amalay.WindowApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amalay.WindowApp.DesignPatterns.AbstractFactoryPattern.Sample1
{
    public class AbstractFactoryClient
    {
        #region "Singleton Intance"

        private static readonly AbstractFactoryClient _Instance = new AbstractFactoryClient();

        private AbstractFactoryClient()
        {

        }

        public static AbstractFactoryClient Instance
        {
            get
            {
                return _Instance;
            }
        }

        #endregion

        public void Demo(Label lblInputText, Label lblInput, Label lblOutputText, Label lblOutput)
        {
            IVehical vehical = null;

            AbstractFactory factory = new AbstractFactory();

            if(factory != null)
            {
                vehical = factory.GetVehical(VehicalType.Car);
                lblInputText.Text = "First Vehical:";
                lblInput.Text = vehical.Name;

                vehical = factory.GetVehical(VehicalType.Bike);
                lblOutputText.Text = "Second Vehical:";
                lblOutput.Text = vehical.Name;
            }
        }        
    }
}
