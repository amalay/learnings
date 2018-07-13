using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.Helpers
{
    public class JsonSerializerDeSerializerHelper
    {
        private static readonly JsonSerializerDeSerializerHelper _Instance = new JsonSerializerDeSerializerHelper();

        private JsonSerializerDeSerializerHelper() { }

        public static JsonSerializerDeSerializerHelper Instance
        {
            get
            {
                return _Instance;
            }
        }                        
    }
}
