using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.Helpers
{
    public class JsonFileHelper
    {
        #region "Singleton Intance"

        private static readonly JsonFileHelper _Instance = new JsonFileHelper();

        private JsonFileHelper() { }

        public static JsonFileHelper Instance
        {
            get
            {
                return _Instance;
            }
        }

        #endregion

        public string ReadContentFromJsonFile(string jsonFilePath)
        {
            string jsonMessage = string.Empty;

            try
            {
                if (!string.IsNullOrEmpty(jsonFilePath))
                {
                    string content = System.IO.File.ReadAllText(jsonFilePath);

                    jsonMessage = System.Text.RegularExpressions.Regex.Replace(content, @"\\[rnt]", m =>
                    {
                        switch (m.Value)
                        {
                            case @"\r": return "\r";
                            case @"\n": return "\n";
                            case @"\t": return "\t";
                            default: return m.Value;
                        }
                    });
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return jsonMessage;
        }
    }
}
