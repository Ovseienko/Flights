using Flights.Data;
using Flights.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace Flights.UI.Controllers
{
    public class FlightController : Controller
    {
        private DbContext context = new DbContext();

        [HttpGet]
        public ActionResult Details(string code)
        {
            var flight = context.Flight.FirstOrDefault(f => f.Code == code);

            return View(flight);
        }

        [HttpPost]
        public ActionResult Details(Passenger passenger, int flightId)
        {
            var flight = context.Flight.FirstOrDefault(f => f.Id == flightId);

            flight.Passengers.Add(passenger);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult RenameCrewMemer(int crewMemberId, string firstName, string lastName)
        {
            var passenger = context.CrewMember.FirstOrDefault(f => f.Id == crewMemberId);

            RenamePerson(passenger, firstName, lastName);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult RenamePassenger(int passengerId, string firstName, string lastName)
        {
            var passenger = context.Passengers.FirstOrDefault(f => f.Id == passengerId);

            RenamePerson(passenger, firstName, lastName);

            return RedirectToAction("Index", "Home");
        }

        private void RenamePerson(Person person, string firstName, string lastName)
        {
            person.FirstName = firstName;
            person.LastName = lastName;

            context.SaveChanges();
        }

        public FileResult SerializeFlights()
        {
            var flights = context.Flight.ToList();

            var flightObjects = new List<Flight>();

            foreach (var flight in flights)
            {
                var flightObject = new Flight()
                {
                    Code = flight.Code,
                    DepartureCity = new City()
                    {
                        Id = flight.DepartureCity.Id,
                        DestinationAirport = flight.DepartureCity.DestinationAirport,
                        IsCapital = flight.DepartureCity.IsCapital,
                        Name = flight.DepartureCity.Name,
                        InternationalCode = flight.DepartureCity.InternationalCode
                    },
                    DestinationCity = new City()
                    {
                        Id = flight.DestinationCity.Id,
                        DestinationAirport = flight.DestinationCity.DestinationAirport,
                        IsCapital = flight.DestinationCity.IsCapital,
                        Name = flight.DestinationCity.Name,
                        InternationalCode = flight.DestinationCity.InternationalCode
                    },
                    PlaneModel = flight.PlaneModel,
                    Year = flight.Year,
                    PassengersNumber = flight.PassengersNumber,
                    Id = flight.Id
                };

                flightObjects.Add(flightObject);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(Flight[]));

            MemoryStream memoryStream = new MemoryStream();

            serializer.Serialize(memoryStream, flightObjects.ToArray());

            return File(memoryStream.ToArray(), "application/xml");
        }


    }
}