namespace Flights.Data
{
    using Flights.Data.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DbContext : System.Data.Entity.DbContext
    {
        public DbContext()
            : base("name=DbContext")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public virtual DbSet<CrewMember> CrewMember { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Flight> Flight { get; set; }

    }

}