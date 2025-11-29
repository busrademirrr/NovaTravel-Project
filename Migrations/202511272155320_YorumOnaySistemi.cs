namespace TravelTripProject1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YorumOnaySistemi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Yorumlars", "Durum", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Yorumlars", "Durum");
        }
    }
}
