namespace Flights.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SmallChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CrewMembers", "FlightId", "dbo.Flights");
            DropIndex("dbo.CrewMembers", new[] { "FlightId" });
            RenameColumn(table: "dbo.CrewMembers", name: "FlightId", newName: "Flight_Id");
            AlterColumn("dbo.CrewMembers", "Flight_Id", c => c.Int());
            CreateIndex("dbo.CrewMembers", "Flight_Id");
            AddForeignKey("dbo.CrewMembers", "Flight_Id", "dbo.Flights", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CrewMembers", "Flight_Id", "dbo.Flights");
            DropIndex("dbo.CrewMembers", new[] { "Flight_Id" });
            AlterColumn("dbo.CrewMembers", "Flight_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.CrewMembers", name: "Flight_Id", newName: "FlightId");
            CreateIndex("dbo.CrewMembers", "FlightId");
            AddForeignKey("dbo.CrewMembers", "FlightId", "dbo.Flights", "Id", cascadeDelete: true);
        }
    }
}
