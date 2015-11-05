namespace FirstIterationVMC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class State : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Volunteers", "State", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Volunteers", "State");
        }
    }
}
