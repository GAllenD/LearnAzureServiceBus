using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Microsoft.WindowsAzure;

namespace ServiceBus
{
    public class Publisher : ServiceBusBase
    {
        public void CreateTopc()
        {
            var topicDesc = new TopicDescription(TopicName)
                {
                    MaxSizeInMegabytes = 5120,
                    DefaultMessageTimeToLive = new TimeSpan(0, 20, 0)
                };

            var namespaceManager = NamespaceManager.CreateFromConnectionString(ConnectionString);


            if (!namespaceManager.TopicExists(TopicName))
            {
                namespaceManager.CreateTopic(topicDesc);
            }
            
        }

        public void SendMessage(object messageObject)
        {

            var client = TopicClient.CreateFromConnectionString(ConnectionString, TopicName);

            client.SendAsync(new BrokeredMessage(messageObject));
        }
    }
}
