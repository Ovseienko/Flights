namespace Flights.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addednametocountry : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Countries", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Countries", "Name");
        }
    }
}
