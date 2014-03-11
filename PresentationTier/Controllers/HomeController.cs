using System.Web.Mvc;
using ServiceBus;

namespace PresentationTier.Controllers
{
    public class HomeController : Controller
    {
        private readonly Publisher _publisher;
        private readonly Messaging _messaging;

        public HomeController()
        {
            _publisher = new Publisher();
            _messaging = new Messaging();
        }

        public ActionResult Index()
        {
            return View(new Thing());
        }

        public ActionResult Save(Thing thing)
        {
            for (var i = 0; i < thing.NumberOfMessages + 1; i++)
            {
                thing.CurrentSequence++;
                if (thing.Publish)
                    SendToTopic(thing);

                if (thing.PutToQueue)
                    SendToQueue(thing);    
            }
            

            return View("index",new Thing());
        }

        private void SendToTopic(object message)
        {
            _publisher.CreateTopc();

            _publisher.SendMessage(message);
        }

        private void SendToQueue(object message)
        {
            _messaging.AddMessage(message);
        }
    }
}
