namespace AutoReservation.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Marke = c.String(nullable: false, maxLength: 20),
                        Tagestarif = c.Int(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Basistarif = c.Int(),
                        AutoKlasse = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationsNr = c.Int(nullable: false, identity: true),
                        Von = c.DateTime(nullable: false),
                        Bis = c.DateTime(nullable: false),
                        KundeId = c.Int(nullable: false),
                        AutoId = c.Int(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ReservationsNr)
                .ForeignKey("dbo.Auto", t => t.AutoId, cascadeDelete: true)
                .ForeignKey("dbo.Kunde", t => t.KundeId, cascadeDelete: true)
                .Index(t => t.KundeId)
                .Index(t => t.AutoId);
            
            CreateTable(
                "dbo.Kunde",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nachname = c.String(nullable: false, maxLength: 20),
                        Vorname = c.String(nullable: false, maxLength: 20),
                        Geburtsdatum = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "KundeId", "dbo.Kunde");
            DropForeignKey("dbo.Reservations", "AutoId", "dbo.Auto");
            DropIndex("dbo.Reservations", new[] { "AutoId" });
            DropIndex("dbo.Reservations", new[] { "KundeId" });
            DropTable("dbo.Kunde");
            DropTable("dbo.Reservations");
            DropTable("dbo.Auto");
        }
    }
}
