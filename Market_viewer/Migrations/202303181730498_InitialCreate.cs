namespace Market_viewer2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        isFavorite = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Wallets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        amount = c.Double(nullable: false),
                        tickerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tickers", t => t.tickerId, cascadeDelete: true)
                .Index(t => t.tickerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wallets", "tickerId", "dbo.Tickers");
            DropIndex("dbo.Wallets", new[] { "tickerId" });
            DropTable("dbo.Wallets");
            DropTable("dbo.Tickers");
        }
    }
}
