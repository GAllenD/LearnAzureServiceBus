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
        public static string TopicName = "SampleTopic";

        public void Create()
        {
            var topicDesc = new TopicDescription(TopicName)
                {
                    MaxSizeInMegabytes = 5120,
                    DefaultMessageTimeToLive = new TimeSpan(0, 1, 0)
                };
            var connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");

            var namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);


            if (!namespaceManager.TopicExists(TopicName))
            {
                namespaceManager.CreateTopic(topicDesc);
            }
            
        }

        public void SendMessage()
        {
            var connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");
            var client = TopicClient.CreateFromConnectionString(connectionString, TopicName);

            var message = new BrokeredMessage("test message");

            client.Send(message);
        }
    }
}
