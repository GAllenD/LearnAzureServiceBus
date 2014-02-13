using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using Microsoft.WindowsAzure;

namespace LearnAzureServiceBusSender
{
    public class Publisher
    {
        public void Create()
        {
            var connString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");

            var namespaceManager = NamespaceManager.CreateFromConnectionString(connString);

            if (!namespaceManager.TopicExists("Topic1"))
            {
                namespaceManager.CreateTopic("Topic1");
            }
        }
    }
}
