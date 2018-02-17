namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFacilityTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Facility",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Landmark = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Address2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Facility");
        }
    }
}
