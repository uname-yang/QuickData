namespace SQLST.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KeyValueSTs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        type = c.Int(nullable: false),
                        key = c.String(),
                        value = c.String(),
                        isShare = c.Boolean(nullable: false),
                        readOnly = c.Boolean(nullable: false),
                        AuthorizedID_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Authorizes", t => t.AuthorizedID_ID)
                .Index(t => t.AuthorizedID_ID);
            
            CreateTable(
                "dbo.Authorizes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        userinfo = c.String(),
                        passwd = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KeyValueSTs", "AuthorizedID_ID", "dbo.Authorizes");
            DropIndex("dbo.KeyValueSTs", new[] { "AuthorizedID_ID" });
            DropTable("dbo.Authorizes");
            DropTable("dbo.KeyValueSTs");
        }
    }
}
