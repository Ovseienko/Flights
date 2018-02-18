namespace Flights.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedcityname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cities", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cities", "Name");
        }
    }
}
