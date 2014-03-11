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
        private readonly NamespaceManager _namespaceManager;

        public Subscriber()
        {
            _namespaceManager = NamespaceManager.CreateFromConnectionString(ConnectionString);
        }

        public void DeleteSubscrtion()
        {
            _namespaceManager.DeleteSubscription(TopicName, "GetAll");
        }

        public void CreateSubscription()
        {
            if (!_namespaceManager.SubscriptionExists(TopicName, "GetAll"))
            {
                _namespaceManager.CreateSubscription(TopicName, "GetAll");
            }
        }

        public void Retrieve()
        {
            var client = SubscriptionClient.CreateFromConnectionString(ConnectionString, TopicName, "GetAll");

            while (true)
            {
                var message = client.Receive();

                if (message == null) continue;
                try
                {
                    var thing = message.GetBody<Thing>();
                    Console.WriteLine("Object found, messadeId - {0}", message.MessageId);
                    Console.WriteLine("Object found, correlationID - {0}", message.TimeToLive);
                    Console.WriteLine("name - {0}", thing.Name);
                    Console.WriteLine("# - {0}", thing.CurrentSequence);
                    message.Complete();
                }
                catch (Exception)
                {
                    message.Abandon();

                }

            }

        }
    }
}
