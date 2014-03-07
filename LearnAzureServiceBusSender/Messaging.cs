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
    public class Messaging : ServiceBusBase
    {
        public void AddMessage(object message)
        {
            var client = QueueClient.CreateFromConnectionString(ConnectionString, QueueName);

            client.Send(new BrokeredMessage(message));
        }
    }
}
