namespace FirstIterationVMC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Volunteers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Volunteers", "FName", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Volunteers", "LName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Volunteers", "phone", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Volunteers", "Address", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Volunteers", "City", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Volunteers", "State", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.Volunteers", "Zip", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.Volunteers", "Specialty", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Volunteers", "Specialty", c => c.String());
            AlterColumn("dbo.Volunteers", "Zip", c => c.String());
            AlterColumn("dbo.Volunteers", "State", c => c.String());
            AlterColumn("dbo.Volunteers", "City", c => c.String());
            AlterColumn("dbo.Volunteers", "Address", c => c.String());
            AlterColumn("dbo.Volunteers", "phone", c => c.String());
            AlterColumn("dbo.Volunteers", "LName", c => c.String());
            AlterColumn("dbo.Volunteers", "FName", c => c.String());
            DropColumn("dbo.Volunteers", "Email");
        }
    }
}
