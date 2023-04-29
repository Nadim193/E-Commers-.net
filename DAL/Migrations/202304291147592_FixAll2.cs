namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixAll2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Moderators", name: "AdminId", newName: "AddedBy");
            RenameIndex(table: "dbo.Moderators", name: "IX_AdminId", newName: "IX_AddedBy");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Moderators", name: "IX_AddedBy", newName: "IX_AdminId");
            RenameColumn(table: "dbo.Moderators", name: "AddedBy", newName: "AdminId");
        }
    }
}
