namespace TravelTripProject1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RezervasyonSistemi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rezervasyons",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AdSoyad = c.String(),
                        Mail = c.String(),
                        Telefon = c.String(),
                        KisiSayisi = c.String(),
                        Tarih = c.DateTime(nullable: false),
                        RezervasyonYapilanYer = c.String(),
                        Durum = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Rezervasyons");
        }
    }
}
