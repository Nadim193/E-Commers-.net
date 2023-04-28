namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixTokenTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tokens", "SellerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tokens", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tokens", "UserId", c => c.String());
            AlterColumn("dbo.Tokens", "SellerId", c => c.String(nullable: false));
        }
    }
}
