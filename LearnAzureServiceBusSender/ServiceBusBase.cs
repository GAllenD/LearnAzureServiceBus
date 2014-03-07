using Microsoft.WindowsAzure;

namespace ServiceBus
{
    public abstract class ServiceBusBase
    {
        public static string TopicName = "SampleTopic";
        public static string QueueName = "SampleQueue";
        protected readonly string ConnectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");
    }
}
