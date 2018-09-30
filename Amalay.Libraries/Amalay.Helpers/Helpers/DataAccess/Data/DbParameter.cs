using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace Amalay.Helpers.DataAccess
{
    public abstract class DbParameter
    {
        public abstract string Name
        {
            get;
        }

        public abstract object Value
        {
            get;
        }

        public abstract ParameterDirection Direction
        {
            get;
        }

        public abstract object ParameterType
        {
            get;
        }
    }
}
