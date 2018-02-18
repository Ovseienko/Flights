namespace Flights.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedcitieandcountries : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Country = c.String(),
                        IsCapital = c.Boolean(nullable: false),
                        DestinationAirport = c.String(),
                        InternationalCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Region = c.String(),
                        Capital = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CrewMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Position = c.String(),
                        YearsOfExperience = c.Int(nullable: false),
                        YearsInCompany = c.Int(nullable: false),
                        IsPilot = c.Boolean(nullable: false),
                        EmergencyContactPerson = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Sex = c.String(),
                        Age = c.Int(nullable: false),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        DepartureCity = c.String(),
                        Destination = c.String(),
                        PlaneModel = c.String(),
                        PassengersNumber = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Passengers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsNewClient = c.Boolean(nullable: false),
                        SeatNumber = c.Int(nullable: false),
                        IsVegetarian = c.Boolean(nullable: false),
                        HasReturnTicket = c.Boolean(nullable: false),
                        HasSpecialNeeds = c.Boolean(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Sex = c.String(),
                        Age = c.Int(nullable: false),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Passangers");
            DropTable("dbo.Pilots");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Pilots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Passangers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Passengers");
            DropTable("dbo.Flights");
            DropTable("dbo.CrewMembers");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
        }
    }
}
