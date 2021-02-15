namespace ClientOrganizer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changefield : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Client", "Email", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Client", "Email", c => c.String(maxLength: 50));
        }
    }
}
