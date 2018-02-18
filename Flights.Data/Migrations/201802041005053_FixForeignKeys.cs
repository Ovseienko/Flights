namespace Flights.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixForeignKeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CrewMembers", "Flight_Id", "dbo.Flights");
            DropIndex("dbo.CrewMembers", new[] { "Flight_Id" });
            RenameColumn(table: "dbo.CrewMembers", name: "Flight_Id", newName: "FlightId");
            AlterColumn("dbo.CrewMembers", "FlightId", c => c.Int(nullable: false));
            CreateIndex("dbo.CrewMembers", "FlightId");
            AddForeignKey("dbo.CrewMembers", "FlightId", "dbo.Flights", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CrewMembers", "FlightId", "dbo.Flights");
            DropIndex("dbo.CrewMembers", new[] { "FlightId" });
            AlterColumn("dbo.CrewMembers", "FlightId", c => c.Int());
            RenameColumn(table: "dbo.CrewMembers", name: "FlightId", newName: "Flight_Id");
            CreateIndex("dbo.CrewMembers", "Flight_Id");
            AddForeignKey("dbo.CrewMembers", "Flight_Id", "dbo.Flights", "Id");
        }
    }
}
