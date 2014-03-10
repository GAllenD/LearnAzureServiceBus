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
    public class Subscriber : ServiceBusBase
    {
        public void CreateSubscription()
        {
            var connectionString = CloudConfigurationManager.GetSetting(ConnectionString);

            var namespaceManager =
                NamespaceManager.CreateFromConnectionString(connectionString);

            if (!namespaceManager.SubscriptionExists(TopicName, "GetAll"))
            {
                namespaceManager.CreateSubscription(TopicName, "GetAll");
            }
        }

        public BrokeredMessage Retrieve()
        {
            var client = SubscriptionClient.CreateFromConnectionString(ConnectionString, TopicName, "GetAll");

            client.Receive();

            while (true)
            {
                var message = client.Receive();

                if (message == null) continue;
                try
                {
                    return message;

                }
                catch (Exception)
                {
                    message.Abandon();
                }
                finally
                {
                    message.Complete();
                }
            }

        }
    }
}
