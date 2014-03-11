using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceBus;

namespace AppTierConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var subscriber = new Subscriber();

            //subscriber.DeleteSubscrtion();
            subscriber.CreateSubscription();

            subscriber.Retrieve();

            //Console.WriteLine("Object found, messadeId - {0}", topicObject.RetrieveMessageId);
            //Console.WriteLine("name - {0}", topicObject.Name);

            //Console.Read();
        }

    }
}
