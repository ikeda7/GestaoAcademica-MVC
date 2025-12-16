namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primeira : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alunos",
                c => new
                    {
                        idAluno = c.Int(nullable: false, identity: true),
                        nomeAluno = c.String(),
                    })
                .PrimaryKey(t => t.idAluno);
            
            CreateTable(
                "dbo.AlunosDisciplinas",
                c => new
                    {
                        idAluno = c.Int(nullable: false),
                        idDisc = c.Int(nullable: false),
                        id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.idAluno, t.idDisc })
                .ForeignKey("dbo.Alunos", t => t.idAluno, cascadeDelete: true)
                .ForeignKey("dbo.Disciplinas", t => t.idDisc, cascadeDelete: true)
                .Index(t => t.idAluno)
                .Index(t => t.idDisc);
            
            CreateTable(
                "dbo.Disciplinas",
                c => new
                    {
                        idDisc = c.Int(nullable: false, identity: true),
                        nomeDisciplina = c.String(),
                    })
                .PrimaryKey(t => t.idDisc);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlunosDisciplinas", "idDisc", "dbo.Disciplinas");
            DropForeignKey("dbo.AlunosDisciplinas", "idAluno", "dbo.Alunos");
            DropIndex("dbo.AlunosDisciplinas", new[] { "idDisc" });
            DropIndex("dbo.AlunosDisciplinas", new[] { "idAluno" });
            DropTable("dbo.Disciplinas");
            DropTable("dbo.AlunosDisciplinas");
            DropTable("dbo.Alunos");
        }
    }
}
