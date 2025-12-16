using MVC.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

public class AppDbContext : DbContext
{
    // Construtor aponta para a connectionString
    public AppDbContext() : base("ConnectString")
    {
    }

    // DbSets (tabelas)
    public DbSet<Alunos> Alunos { get; set; }
    public DbSet<Disciplinas> Disciplinas { get; set; }
    public DbSet<AlunosDisciplinas> AlunosDisciplinas { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        // Remove pluralização automática (opcional, comum em legado)
        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        // Chave primária de Aluno
        modelBuilder.Entity<Alunos>()
            .HasKey(a => a.idAluno);

        // Chave primária de Disciplina
        modelBuilder.Entity<Disciplinas>()
            .HasKey(d => d.idDisc);

        // Chave composta da tabela de junção
        modelBuilder.Entity<AlunosDisciplinas>()
            .HasKey(ad => new { ad.idAluno, ad.idDisc });

        // Relacionamento Aluno -> AlunoDisciplina (1:N)
        modelBuilder.Entity<AlunosDisciplinas>()
            .HasRequired(ad => ad.Alunos)
            .WithMany(a => a.AlunosDisciplinas)
            .HasForeignKey(ad => ad.idAluno);

        // Relacionamento Disciplina -> AlunoDisciplina (1:N)
        modelBuilder.Entity<AlunosDisciplinas>()
            .HasRequired(ad => ad.Disciplinas)
            .WithMany(d => d.AlunosDisciplinas)
            .HasForeignKey(ad => ad.idDisc);

        base.OnModelCreating(modelBuilder);
    }

}