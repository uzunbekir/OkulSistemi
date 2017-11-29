namespace MVCCodefirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ders",
                c => new
                    {
                        DersID = c.Int(nullable: false, identity: true),
                        DersAdi = c.String(nullable: false),
                        Aciklama = c.String(unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.DersID);
            
            CreateTable(
                "dbo.Egitmen",
                c => new
                    {
                        EgitmenID = c.Int(nullable: false, identity: true),
                        AdSoyad = c.String(),
                        DogumTarihi = c.DateTime(),
                    })
                .PrimaryKey(t => t.EgitmenID);
            
            CreateTable(
                "dbo.Ogrencis",
                c => new
                    {
                        OgrenciID = c.Int(nullable: false, identity: true),
                        AdSoyad = c.String(nullable: false, maxLength: 100),
                        DogumTarihi = c.DateTime(),
                        MezunMu = c.Boolean(nullable: false),
                        Ortalama = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.OgrenciID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ogrencis");
            DropTable("dbo.Egitmen");
            DropTable("dbo.Ders");
        }
    }
}
