namespace TravelTripProject1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RehberTablosuAktif : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rehbers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Baslik = c.String(maxLength: 100),
                        Aciklama = c.String(),
                        GorunurGorsel = c.String(),
                        HaritaKonum = c.String(),
                        TahminiMaliyet = c.String(),
                        Kategori = c.String(),
                        Puan = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Rehbers");
        }
    }
}
