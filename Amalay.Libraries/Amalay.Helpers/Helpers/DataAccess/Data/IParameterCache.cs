using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Amalay.Helpers.DataAccess
{
    public interface IParameterCache
    {
        IDbDataParameter[] GetSpParameters(string connectionString, string storeProcedure, bool includeReturnValueParameter);
    }
}
