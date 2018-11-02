namespace ProjetoDCPoint.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DCPointContext : DbContext
    {
        public DCPointContext()
            : base("name=DCPointContext")
        {
        }

        public virtual DbSet<funcao> funcao { get; set; }
        public virtual DbSet<funcionario> funcionario { get; set; }
        public virtual DbSet<ocorrencia> ocorrencia { get; set; }
        public virtual DbSet<ponto> ponto { get; set; }
        public virtual DbSet<setor> setor { get; set; }
        public virtual DbSet<statusOcorrencia> statusOcorrencia { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<funcao>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<funcao>()
                .HasMany(e => e.funcionario)
                .WithRequired(e => e.funcao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<funcionario>()
                .Property(e => e.senha)
                .IsUnicode(false);

            modelBuilder.Entity<funcionario>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<funcionario>()
                .Property(e => e.rg)
                .IsUnicode(false);

            modelBuilder.Entity<funcionario>()
                .Property(e => e.cpf)
                .IsUnicode(false);

            modelBuilder.Entity<funcionario>()
                .Property(e => e.cnh)
                .IsUnicode(false);

            modelBuilder.Entity<funcionario>()
                .Property(e => e.ctps)
                .IsUnicode(false);

            modelBuilder.Entity<funcionario>()
                .HasMany(e => e.ponto)
                .WithRequired(e => e.funcionario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ocorrencia>()
                .Property(e => e.justificativa)
                .IsUnicode(false);

            modelBuilder.Entity<ponto>()
                .HasMany(e => e.ocorrencia)
                .WithRequired(e => e.ponto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<setor>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<setor>()
                .HasMany(e => e.funcionario)
                .WithRequired(e => e.setor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<statusOcorrencia>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<statusOcorrencia>()
                .HasMany(e => e.ocorrencia)
                .WithRequired(e => e.statusOcorrencia)
                .HasForeignKey(e => e.status)
                .WillCascadeOnDelete(false);
        }
    }
}
