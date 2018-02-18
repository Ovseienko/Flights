using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Flights.Data.Models
{
    [Serializable]

    public class Flight : Entity
    {
        public string Code { get; set; }
        public virtual City DepartureCity { get; set; }
        public virtual City DestinationCity { get; set; }
        public string PlaneModel { get; set; }
        public int PassengersNumber { get; set; }
        public int Year { get; set; }
        [XmlIgnore]
        public virtual ICollection<CrewMember> CrewMembers { get; set; }
        [XmlIgnore]
        public virtual ICollection<Passenger> Passengers { get; set; }


    }
}
