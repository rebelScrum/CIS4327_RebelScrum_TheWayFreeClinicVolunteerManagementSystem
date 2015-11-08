using System;
using System.Data.Entity.Migrations;

public partial class Seed : DbMigration
{
    public override void Up()
    {
        CreateTable(
            "dbo.Volunteers",
            c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    FName = c.String(nullable: false, maxLength: 25),
                    LName = c.String(nullable: false, maxLength: 30),
                    DOB = c.DateTime(nullable: false),
                    phone = c.String(nullable: false, maxLength: 15),
                    Email = c.String(nullable: false),
                    Address = c.String(nullable: false, maxLength: 30),
                    City = c.String(nullable: false, maxLength: 25),
                    State = c.String(nullable: false, maxLength: 2),
                    Zip = c.String(nullable: false, maxLength: 5),
                    Specialty = c.String(nullable: false, maxLength: 30),
                })
            .PrimaryKey(t => t.ID);
        
    }
    
    public override void Down()
    {
        DropTable("dbo.Volunteers");
    }
}
