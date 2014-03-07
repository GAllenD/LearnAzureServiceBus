using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceBus;

namespace PresentationTier.Controllers
{
    public class HomeController : Controller
    {
        private readonly Publisher _publisher;
        private Messaging _messaging;

        public HomeController()
        {
            _publisher = new Publisher();
            _messaging = new Messaging();
        }

        public ActionResult Index()
        {
            ViewBag.GenderOptions = new SelectList(new List<string> {"Male", "Female"});

            return View(new Person());
        }

        public ActionResult Save(Person person)
        {
            if (person.Publish)
                SendToTopic(person);    
            
            if(person.PutToQueue)
                SendToQueue(person);

            return Index();
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
