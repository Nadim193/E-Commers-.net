namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modyfiTokenTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tokens", "SellerId", c => c.String(nullable: false));
            AlterColumn("dbo.Tokens", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tokens", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tokens", "SellerId", c => c.Int(nullable: false));
        }
    }
}
