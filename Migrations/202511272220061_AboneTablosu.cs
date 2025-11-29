namespace TravelTripProject1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AboneTablosu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abones",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Mail = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Abones");
        }
    }
}
