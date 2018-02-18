using Flights.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flights.UI.Controllers
{
    public class FindFlightController : Controller
    {
        private DbContext context = new DbContext();

        public ActionResult Index()
        {
            ViewBag.Message = "Find your Flight";

            return View();
        }

        public ActionResult _Find()
        {
            return PartialView();
        }

        public ActionResult City(string country)
        {
            return View();
        }

        public ActionResult Flight()
        {
            return View();
        }

        public ActionResult GetCountry(string key)
        {
            var countries = context.Country.ToArray();
            if (key.Length > 0) countries = countries.Where(c => c.Name.ToLower().IndexOf(key.ToLower()) > -1).ToArray();
            return Json(countries, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCity(string key, string filterParam)
        {
            var cities = context.City.ToArray();
            if (key.Length > 0)
            {
                cities = cities
                    .Where(c => c.Name.ToLower().IndexOf(key.ToLower()) > -1)
                    .ToArray();
            }
            if (filterParam.Length > 0)
            {
                cities = cities
                    .Where(c => c.Country.Name == filterParam)
                    .ToArray();
            }

            return Json(cities, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetFlight(string key, string filterParam)
        {
            var flights = context.Flight.ToArray();
            if (key.Length > 0)
            {
                flights = flights
                    .Where(f => f.Code.ToLower().IndexOf(key.ToLower()) > -1)
                    .ToArray();
            }
            if (filterParam.Length > 0)
            {
                flights = flights
                    .Where(f => f.DepartureCity.Name.ToLower().Contains(filterParam.ToLower()) || f.DestinationCity.Name.ToLower().IndexOf(filterParam.ToLower()) > -1)
                    .ToArray();
            }

            return Json(flights, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCrewMember(string key)
        {
            var crewMembers = context.CrewMember.ToArray();
            if (key.Length > 0)
            {
                crewMembers = crewMembers
                    .Where(cm => cm.LastName.ToLower().IndexOf(key.ToLower()) > -1 || cm.FirstName.ToLower().IndexOf(key.ToLower()) > -1)
                    .ToArray();
            }
            return Json(crewMembers, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPassenger(string key)
        {
            var passengers = context.CrewMember.ToArray();
            if (key.Length > 0)
            {
                passengers = passengers
                    .Where(p => p.LastName.ToLower().IndexOf(key.ToLower()) > -1 || p.FirstName.ToLower().IndexOf(key.ToLower()) > -1)
                    .ToArray();
            }
            return Json(passengers, JsonRequestBehavior.AllowGet);
        }
    }
}