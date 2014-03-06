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
        private Publisher _publisher;

        public HomeController()
        {
            _publisher = new Publisher();
        }

        public ActionResult Index()
        {
            ViewBag.GenderOptions = new SelectList(new List<string> {"Male", "Female"});

            return View(new Person());
        }

        public ActionResult Save(Person person)
        {
            _publisher.CreateTopc();

            _publisher.SendMessage(person);

            return Index();
        }
    }
}
