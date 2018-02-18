namespace Flights.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedflight : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CrewMembers", "Flight", c => c.String());
            AddColumn("dbo.Passengers", "Flight", c => c.String());
            DropColumn("dbo.CrewMembers", "EmergencyContactPerson");
            DropColumn("dbo.Passengers", "IsNewClient");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Passengers", "IsNewClient", c => c.Boolean(nullable: false));
            AddColumn("dbo.CrewMembers", "EmergencyContactPerson", c => c.String());
            DropColumn("dbo.Passengers", "Flight");
            DropColumn("dbo.CrewMembers", "Flight");
        }
    }
}
