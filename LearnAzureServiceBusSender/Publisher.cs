using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Microsoft.WindowsAzure;

namespace LearnAzureServiceBusSender
{
    public class Publisher
    {
        public void Create()
        {
            var topicDesc = new TopicDescription("SampleTopic")
                {
                    MaxSizeInMegabytes = 5120,
                    DefaultMessageTimeToLive = new TimeSpan(0, 1, 0)
                };

            var connString = CloudConfigurationManager.GetSetting("");

            var namespaceManager = NamespaceManager.CreateFromConnectionString(connString);

            if (!namespaceManager.TopicExists("SampleTopic"))
            {
                namespaceManager.CreateTopic(topicDesc);
            }
        }
    }
}
