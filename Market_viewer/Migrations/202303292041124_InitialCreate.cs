namespace Market_viewer2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StockDataPoints",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        Open = c.String(),
                        High = c.String(),
                        Low = c.String(),
                        Close = c.String(),
                        Adj_close = c.String(),
                        Volume = c.String(),
                        Dividend = c.String(),
                        Stock_id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Stocks", t => t.Stock_id)
                .Index(t => t.Stock_id);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        IsFavourite = c.Boolean(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Wallets",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        amount = c.Double(nullable: false),
                        tickerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Stocks", t => t.tickerId, cascadeDelete: true)
                .Index(t => t.tickerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wallets", "tickerId", "dbo.Stocks");
            DropForeignKey("dbo.StockDataPoints", "Stock_id", "dbo.Stocks");
            DropIndex("dbo.Wallets", new[] { "tickerId" });
            DropIndex("dbo.StockDataPoints", new[] { "Stock_id" });
            DropTable("dbo.Wallets");
            DropTable("dbo.Stocks");
            DropTable("dbo.StockDataPoints");
        }
    }
}
