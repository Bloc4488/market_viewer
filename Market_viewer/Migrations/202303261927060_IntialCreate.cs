namespace Market_viewer2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialCreate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Stocks", newName: "Tickers");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Tickers", newName: "Stocks");
        }
    }
}
