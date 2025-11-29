namespace TravelTripProject1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SonGuncelleme : DbMigration
    {
        public override void Up()
        {
            // CreateTable(
            //    "dbo.Abones",
            //    c => new
            //    {
            //        ID = c.Int(nullable: false, identity: true),
            //        Mail = c.String(),
            //    })
            //    .PrimaryKey(t => t.ID);

            // DropTable("dbo.GezilecekYerlers"); 
        }

        public override void Down()
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
            
        }
    }
}
