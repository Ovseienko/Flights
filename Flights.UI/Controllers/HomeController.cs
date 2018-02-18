using Flights.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flights.UI.Controllers
{
    public class HomeController : Controller
    {
        private DbContext context = new DbContext();

        public ActionResult Index()
        {
            var flights = context.Flight.ToList();
            
            return View(flights);
        }
    }
}