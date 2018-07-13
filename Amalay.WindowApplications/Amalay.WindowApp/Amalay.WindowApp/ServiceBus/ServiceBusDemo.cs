using Amalay.Entities;
using Amalay.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.WindowApp
{
    public class ServiceBusDemo
    {
        #region "Singleton Intance"

        private static readonly ServiceBusDemo _Instance = new ServiceBusDemo();
        private string xmlMessageFilePath = @".\Resources\XmlFiles\Message.xml";
        private string jsonMessageFilePath = @".\Resources\JsonFiles\Message.json";

        private ServiceBusDemo()
        {

        }

        public static ServiceBusDemo Instance
        {
            get
            {
                return _Instance;
            }
        }

        #endregion

        public void SendMessageToServiceBus(string topic, string subscription)
        {
            var messageInfo = XmlSerializerDeSerializerHelper.Instance.DeserializeFromXmlFile<MessageInfo>(xmlMessageFilePath, "MessageInfo");           
            var messageHeader = ServiceBusHelper.Instance.InitialiseMessageHeader(subscription);

            ServiceBusHelper.Instance.SendMessageToServiceBus(ConfigHelper.ServiceBusConnectionString, topic, messageInfo, messageHeader);
        }

        public void SendJsonMessageToServiceBus(string topic, string subscription)
        {
            var jsonMessage = JsonFileHelper.Instance.ReadContentFromJsonFile(jsonMessageFilePath);
            var messageHeader = ServiceBusHelper.Instance.InitialiseMessageHeader(subscription);

            ServiceBusHelper.Instance.SendMessageToServiceBus(ConfigHelper.ServiceBusConnectionString, topic, jsonMessage, messageHeader);
        }

        public void ReceiveMessageToServiceBus()
        {

            
        }

        public void CreateTopicAndSubscriptionToServiceBus()
        {

            
        }

        public List<Topic> GetTopicsAndSubscriptions(string xmlFilePath)
        {
            List<Topic> topics = null;

            try
            {
                if (!string.IsNullOrEmpty(xmlFilePath))
                {
                    topics = XmlSerializerDeSerializerHelper.Instance.DeserializeFromXmlFile<List<Topic>>(xmlFilePath, "Topics");
                    topics.Insert(0, new Topic() { Name = Constants.DefaultSelect });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return topics;
        }
    }
}
