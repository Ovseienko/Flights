namespace Flights.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changedflightcodedatatype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Flights", "Code", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Flights", "Code", c => c.Int(nullable: false));
        }
    }
}
