using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Data.Models
{
    public class Passenger : Person
    {
        public int SeatNumber { get; set; }
        public bool IsVegetarian { get; set; }
        public bool HasReturnTicket { get; set; }
        public bool HasSpecialNeeds { get; set; }
    }
}
