namespace Flights.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixForeignKeysAgain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Passengers", "Flight_Id", c => c.Int());
            CreateIndex("dbo.Passengers", "Flight_Id");
            AddForeignKey("dbo.Passengers", "Flight_Id", "dbo.Flights", "Id");
            DropColumn("dbo.Passengers", "Flight");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Passengers", "Flight", c => c.String());
            DropForeignKey("dbo.Passengers", "Flight_Id", "dbo.Flights");
            DropIndex("dbo.Passengers", new[] { "Flight_Id" });
            DropColumn("dbo.Passengers", "Flight_Id");
        }
    }
}
