namespace TravelTripProject1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YeniMimariGecis : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GezilecekYerlers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Baslik = c.String(),
                        Aciklama = c.String(),
                        Resim = c.String(),
                        Kategori = c.String(),
                        Sehir = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TurPaketleris",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Baslik = c.String(),
                        Resim = c.String(),
                        Sure = c.String(),
                        Fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bolge = c.String(),
                        Detay = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            //DropTable("dbo.AdresBlogs");
            DropTable("dbo.Rehbers");
        }
        
        public override void Down()
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
            
            CreateTable(
                "dbo.AdresBlogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Baslik = c.String(),
                        Aciklama = c.String(),
                        AdresAcik = c.String(),
                        Mail = c.String(),
                        Telefon = c.String(),
                        Konum = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.TurPaketleris");
            DropTable("dbo.GezilecekYerlers");
        }
    }
}
