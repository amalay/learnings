using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Unity;
using Microsoft.Practices.Unity.Configuration;
using Unity.Attributes;
//using Microsoft.Practices.Unity;

namespace Amalay.Helpers.DataAccess
{
    public class DataConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("Providers")]
        [ConfigurationCollection(typeof(DataProviderCollection), AddItemName = "Provider")]
        public DataProviderCollection DataProviders
        {
            get
            {
                return base["Providers"] as DataProviderCollection;
            }
        }
    }

    public class DataProviderCollection : ConfigurationElementCollection
    {

        public DataProviderCollection() { }

        protected override ConfigurationElement CreateNewElement()
        {
            return new DataProvider();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DataProvider)element).Name;
        }

        public DataProvider this[int index]
        {
            get
            {
                return (DataProvider)BaseGet(index);
            }
        }

        public DataProvider this[string name]
        {
            get
            {
                return (DataProvider)BaseGet(name);
            }
        }
    }

    public class DataProvider : ConfigurationElement, IDataConfiguration
    {
        public DataProvider() { }

        [ConfigurationProperty("Name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get
            {
                return (string)this["Name"];
            }
        }

        [ConfigurationProperty("ConnectionString", IsRequired = true)]
        public string ConnectionString
        {
            get
            {
                return (string)this["ConnectionString"];
            }
        }
        
        private IDataProvider _instance = null;

        [Dependency]
        public IDataProvider Instance
        {
            get
            {
                try
                {
                    IUnityContainer unityContainer = new UnityContainer();

                    UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
                    if (section != null)
                    {
                        //section.Containers.Default.Configure(unityContainer); //It is in old version and has been obsoleted from new version.
                        //section.Containers["unityContainer"].Configure(unityContainer); //It is in old version and has been obsoleted from new version.
                        section.Configure(unityContainer, "UnityContainer"); //It is in new version.
                    }

                    _instance = unityContainer.Resolve<IDataProvider>(this.Name);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return _instance;
            }
        }
    }
}
