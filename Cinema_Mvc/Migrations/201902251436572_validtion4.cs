namespace Cinema_Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validtion4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Filme", "Genero", c => c.String(nullable: false, maxLength: 60));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Filme", "Genero", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
