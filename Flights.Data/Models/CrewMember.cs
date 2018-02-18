using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Data.Models
{
    public class CrewMember : Person
    {
        public string Position { get; set; }
        public int YearsOfExperience { get; set; }
        public int YearsInCompany { get; set; }
        public bool IsPilot { get; set; }
    }
}
