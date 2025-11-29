namespace TravelTripProject1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HakkimizdaGuncelleme : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hakkimizdas", "Vizyon", c => c.String());
            AddColumn("dbo.Hakkimizdas", "Misyon", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Hakkimizdas", "Misyon");
            DropColumn("dbo.Hakkimizdas", "Vizyon");
        }
    }
}
