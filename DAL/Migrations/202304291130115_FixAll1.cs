namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixAll1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Uname = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 15),
                        Name = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        PhoneNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Moderators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Uname = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 15),
                        Name = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        PhoneNumber = c.Int(nullable: false),
                        AdminId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.AdminId, cascadeDelete: true)
                .Index(t => t.AdminId);
            
            CreateTable(
                "dbo.SalesReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MonthName = c.String(),
                        TotalSales = c.Int(nullable: false),
                        ReportedBy = c.Int(nullable: false),
                        Admin_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Moderators", t => t.ReportedBy, cascadeDelete: true)
                .ForeignKey("dbo.Admins", t => t.Admin_Id)
                .Index(t => t.ReportedBy)
                .Index(t => t.Admin_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesReports", "Admin_Id", "dbo.Admins");
            DropForeignKey("dbo.SalesReports", "ReportedBy", "dbo.Moderators");
            DropForeignKey("dbo.Moderators", "AdminId", "dbo.Admins");
            DropIndex("dbo.SalesReports", new[] { "Admin_Id" });
            DropIndex("dbo.SalesReports", new[] { "ReportedBy" });
            DropIndex("dbo.Moderators", new[] { "AdminId" });
            DropTable("dbo.SalesReports");
            DropTable("dbo.Moderators");
            DropTable("dbo.Admins");
        }
    }
}
