using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.Helpers
{
    class Enumerations
    {

    }

    public enum SearchKeyType
    {
        Name,
        FriendlyName,
        SubjectName,
        SerialNumber,
        Thumbprint
    }

    public enum JsonSerialiserType
    {
        NewtonsoftJsonSerializer = 0,
        DataContractJsonSerializer = 1
    }
}
