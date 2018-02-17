namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 100),
                        PasswordHash = c.String(nullable: false),
                        PasswordSalt = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ErrorLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppName = c.String(nullable: false),
                        Thread = c.String(nullable: false),
                        Level = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        Message = c.String(nullable: false),
                        Exception = c.String(nullable: false),
                        LogDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ErrorLog");
            DropTable("dbo.Account");
        }
    }
}
