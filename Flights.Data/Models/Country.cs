using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Flights.Data.Models
{
    [Serializable]
    public class Country : Entity
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public string Capital { get; set; }
    }
}
