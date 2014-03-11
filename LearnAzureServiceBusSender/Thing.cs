using System;

namespace ServiceBus
{
    [Serializable]
    public class Thing
    {
        public string Name { get; set; }
        public bool Publish { get; set; }
        public bool PutToQueue { get; set; }
        public int CurrentSequence { get; set; }
        public int NumberOfMessages { get; set; }

        public string RetrieveMessageId { get; set; }
    }
}
