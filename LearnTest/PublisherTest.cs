using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnAzureServiceBusSender;
using NUnit.Framework;

namespace LearnTest
{
    [TestFixture]
    public class PublisherTest
    {
        [Test]
        public void ShouldCreateTopic()
        {
            var publisher = new Publisher();

            publisher.Create();
            publisher.SendMessage();
        }
    }
}
