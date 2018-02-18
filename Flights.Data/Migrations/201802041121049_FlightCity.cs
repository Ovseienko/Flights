namespace Flights.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FlightCity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flights", "DepartureCity_Id", c => c.Int());
            AddColumn("dbo.Flights", "DestinationCity_Id", c => c.Int());
            CreateIndex("dbo.Flights", "DepartureCity_Id");
            CreateIndex("dbo.Flights", "DestinationCity_Id");
            AddForeignKey("dbo.Flights", "DepartureCity_Id", "dbo.Cities", "Id");
            AddForeignKey("dbo.Flights", "DestinationCity_Id", "dbo.Cities", "Id");
            DropColumn("dbo.Flights", "DepartureCity");
            DropColumn("dbo.Flights", "DestinationCity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Flights", "DestinationCity", c => c.String());
            AddColumn("dbo.Flights", "DepartureCity", c => c.String());
            DropForeignKey("dbo.Flights", "DestinationCity_Id", "dbo.Cities");
            DropForeignKey("dbo.Flights", "DepartureCity_Id", "dbo.Cities");
            DropIndex("dbo.Flights", new[] { "DestinationCity_Id" });
            DropIndex("dbo.Flights", new[] { "DepartureCity_Id" });
            DropColumn("dbo.Flights", "DestinationCity_Id");
            DropColumn("dbo.Flights", "DepartureCity_Id");
        }
    }
}
