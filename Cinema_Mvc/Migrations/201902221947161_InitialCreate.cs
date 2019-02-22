namespace Cinema_Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cinema",
                c => new
                    {
                        CinemaID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Endereco = c.String(),
                    })
                .PrimaryKey(t => t.CinemaID);
            
            CreateTable(
                "dbo.Sessao",
                c => new
                    {
                        SessaoID = c.Int(nullable: false, identity: true),
                        CinemaID = c.Int(nullable: false),
                        FilmeID = c.Int(nullable: false),
                        Horario = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.SessaoID)
                .ForeignKey("dbo.Cinema", t => t.CinemaID, cascadeDelete: true)
                .ForeignKey("dbo.Filme", t => t.FilmeID, cascadeDelete: true)
                .Index(t => t.CinemaID)
                .Index(t => t.FilmeID);
            
            CreateTable(
                "dbo.Filme",
                c => new
                    {
                        FilmeId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Genero = c.String(),
                        Duracao = c.Int(nullable: false),
                        Classificacao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FilmeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sessao", "FilmeID", "dbo.Filme");
            DropForeignKey("dbo.Sessao", "CinemaID", "dbo.Cinema");
            DropIndex("dbo.Sessao", new[] { "FilmeID" });
            DropIndex("dbo.Sessao", new[] { "CinemaID" });
            DropTable("dbo.Filme");
            DropTable("dbo.Sessao");
            DropTable("dbo.Cinema");
        }
    }
}
