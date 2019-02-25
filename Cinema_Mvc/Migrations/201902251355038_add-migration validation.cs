namespace Cinema_Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationvalidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cinema", "Nome", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Cinema", "Endereco", c => c.String(nullable: false, maxLength: 120));
            AlterColumn("dbo.Filme", "Nome", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Filme", "Genero", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Filme", "Genero", c => c.String());
            AlterColumn("dbo.Filme", "Nome", c => c.String());
            AlterColumn("dbo.Cinema", "Endereco", c => c.String());
            AlterColumn("dbo.Cinema", "Nome", c => c.String());
        }
    }
}
