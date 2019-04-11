namespace MebelTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccountUserRolsInitiallast : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RoleDTOes", newName: "tblRoles");
            CreateTable(
                "dbo.tblRolesUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.tblUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblRolesUsers", "UserId", "dbo.tblUsers");
            DropForeignKey("dbo.tblRolesUsers", "RoleId", "dbo.tblRoles");
            DropIndex("dbo.tblRolesUsers", new[] { "RoleId" });
            DropIndex("dbo.tblRolesUsers", new[] { "UserId" });
            DropTable("dbo.tblRolesUsers");
            RenameTable(name: "dbo.tblRoles", newName: "RoleDTOes");
        }
    }
}
