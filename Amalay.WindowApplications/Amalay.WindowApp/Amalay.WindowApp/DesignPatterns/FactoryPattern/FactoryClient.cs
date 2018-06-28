using Amalay.WindowApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amalay.WindowApp.DesignPatterns.FactoryPattern
{
    public class FactoryClient
    {
        #region "Singleton Intance"

        private static readonly FactoryClient _Instance = new FactoryClient();

        private FactoryClient()
        {

        }

        public static FactoryClient Instance
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

            var factory = new Factory();

            if (factory != null)
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
