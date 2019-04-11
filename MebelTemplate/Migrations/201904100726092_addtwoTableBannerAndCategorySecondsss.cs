namespace MebelTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtwoTableBannerAndCategorySecondsss : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblBanner",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 150),
                        BannerContent = c.String(nullable: false, maxLength: 500),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblCategory", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.tblCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CatName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblHome",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HeaderTitle = c.String(nullable: false, maxLength: 35),
                        HeaderPrice = c.String(nullable: false, maxLength: 35),
                        Image = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServicesTitle = c.String(nullable: false, maxLength: 155),
                        ServicesContent = c.String(nullable: false, maxLength: 300),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblBanner", "CategoryId", "dbo.tblCategory");
            DropIndex("dbo.tblBanner", new[] { "CategoryId" });
            DropTable("dbo.tblServices");
            DropTable("dbo.tblHome");
            DropTable("dbo.tblCategory");
            DropTable("dbo.tblBanner");
        }
    }
}
