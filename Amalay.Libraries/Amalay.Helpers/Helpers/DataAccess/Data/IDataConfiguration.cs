using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Amalay.Helpers.DataAccess
{
    public interface IDataConfiguration
    {
        string Name
        {
            get;
        }

        string ConnectionString
        {
            get;
        }

        IDataProvider Instance
        {
            get;
        }
    }    
}
