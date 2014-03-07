using System;

namespace ServiceBus
{
    [Serializable]
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public bool Publish { get; set; }
        public bool PutToQueue { get; set; }
    }
}
