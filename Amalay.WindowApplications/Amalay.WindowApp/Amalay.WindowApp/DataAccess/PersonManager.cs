using Amalay.Helpers;
using Amalay.Helpers.DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.WindowApp.DataAccess
{
    public class PersonManager
    {
        #region "Properties"

        private DataAccessManager Instance
        {
            get
            {
                return new DataAccessManager(DataProviders.SqlServer);
            }
        }

        #endregion

        public IList<Amalay.Entities.Person> GetAll(ref string message)
        {
            IList<Amalay.Entities.Person> list = null;

            try
            {
                Hashtable outparam = new Hashtable();

                list = Instance.ExecuteDataReader("USP_GetAllPerson", ref outparam, (Func<IDataRecord, Amalay.Entities.Person>)Amalay.Entities.Person.Create);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }
    }
}
