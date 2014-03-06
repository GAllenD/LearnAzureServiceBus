using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using Microsoft.WindowsAzure;

namespace ServiceBus
{
    public class Subscriber
    {
        public void Subscribe()
        {
            var topicName = "SampleTopic";

            var connectionString = CloudConfigurationManager.GetSetting("");

            var namespaceManager =
                NamespaceManager.CreateFromConnectionString(connectionString);

            if (!namespaceManager.SubscriptionExists(topicName, "AllMessages"))
            {
                namespaceManager.CreateSubscription(topicName, "AllMessages");
            }
        }
    }
}
