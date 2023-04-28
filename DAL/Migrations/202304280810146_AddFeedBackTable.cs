namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFeedBackTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeedBacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        ReviewFeedBack = c.String(nullable: false, maxLength: 150),
                        rid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reviews", t => t.rid, cascadeDelete: true)
                .Index(t => t.rid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FeedBacks", "rid", "dbo.Reviews");
            DropIndex("dbo.FeedBacks", new[] { "rid" });
            DropTable("dbo.FeedBacks");
        }
    }
}
