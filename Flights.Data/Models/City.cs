using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Flights.Data.Models
{
    [Serializable]
    public class City:Entity
    {
        public string Name { get; set; }

        [XmlIgnore]
        public virtual Country Country { get; set; }
        public bool IsCapital { get; set; }
        public string DestinationAirport { get; set; }
        public string InternationalCode { get; set; }
    }
}
