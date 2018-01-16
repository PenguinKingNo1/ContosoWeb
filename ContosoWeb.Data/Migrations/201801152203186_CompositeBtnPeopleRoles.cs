namespace ContosoWeb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompositeBtnPeopleRoles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        Desciprtion = c.String(),
                        CreatedBy = c.Int(),
                        UpdatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PeopleRoles",
                c => new
                    {
                        People_Id = c.Int(nullable: false),
                        Roles_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.People_Id, t.Roles_Id })
                .ForeignKey("dbo.People", t => t.People_Id, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.Roles_Id, cascadeDelete: true)
                .Index(t => t.People_Id)
                .Index(t => t.Roles_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PeopleRoles", "Roles_Id", "dbo.Roles");
            DropForeignKey("dbo.PeopleRoles", "People_Id", "dbo.People");
            DropIndex("dbo.PeopleRoles", new[] { "Roles_Id" });
            DropIndex("dbo.PeopleRoles", new[] { "People_Id" });
            DropTable("dbo.PeopleRoles");
            DropTable("dbo.Roles");
        }
    }
}
