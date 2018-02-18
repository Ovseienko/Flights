namespace Flights.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeys : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cities", "Country_Id", c => c.Int());
            AddColumn("dbo.CrewMembers", "Flight_Id", c => c.Int());
            CreateIndex("dbo.Cities", "Country_Id");
            CreateIndex("dbo.CrewMembers", "Flight_Id");
            AddForeignKey("dbo.Cities", "Country_Id", "dbo.Countries", "Id");
            AddForeignKey("dbo.CrewMembers", "Flight_Id", "dbo.Flights", "Id");
            DropColumn("dbo.Cities", "Country");
            DropColumn("dbo.CrewMembers", "Flight");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CrewMembers", "Flight", c => c.String());
            AddColumn("dbo.Cities", "Country", c => c.String());
            DropForeignKey("dbo.CrewMembers", "Flight_Id", "dbo.Flights");
            DropForeignKey("dbo.Cities", "Country_Id", "dbo.Countries");
            DropIndex("dbo.CrewMembers", new[] { "Flight_Id" });
            DropIndex("dbo.Cities", new[] { "Country_Id" });
            DropColumn("dbo.CrewMembers", "Flight_Id");
            DropColumn("dbo.Cities", "Country_Id");
        }
    }
}
