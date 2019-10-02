using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PI06.Models.Entity;
using System.Linq;

namespace PI06.Data.Context
{
    public class Contexto : IdentityDbContext
    {
        
        public Contexto (DbContextOptions<Contexto> options) : base (options) { }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Conselho> Conselho { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Paciente> Paciente { get; set; }


        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            foreach (var relacionamento in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relacionamento.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelBuilder);
            modelBuilder.ForSqlServerUseIdentityColumns ();
            modelBuilder.HasDefaultSchema ("dbo");

            modelBuilder.Entity<Pessoa> (mb => {
                mb.ToTable ("Pessoa");
                mb.HasKey (c => c.Id).HasName ("IdPessoa");
                mb.Property (c => c.Id).HasColumnName ("IdPessoa").ValueGeneratedOnAdd ();
                mb.Property (c => c.Nome)
                    .IsRequired ()
                    .HasMaxLength (300);
                mb.Property (f => f.DataNascimento).IsRequired ();
                mb.Property (f => f.EnderecoEmail)
                    .IsRequired ()
                    .HasMaxLength (150);
                mb.Property (f => f.Bairro).IsRequired ();
                mb.Property (f => f.Cidade).IsRequired ();
                mb.Property (f => f.Logradouro).IsRequired ();
                mb.Property (f => f.NumeroEndereco).IsRequired ();
                mb.Property (f => f.Uf).IsRequired ();
                mb.Property (f => f.Complemento);
                mb.Property (f => f.CodigoCpf).IsRequired ();

            });

            modelBuilder.Entity<Funcionario> (mb => {
                mb.ToTable ("Funcionario");
                mb.HasKey (c => c.Id).HasName ("IdFuncionario");
                mb.Property (c => c.Id).HasColumnName ("IdFuncionario").IsRequired();
                mb.Property (f => f.DataContratacao).IsRequired ();
                mb.Property (f => f.DataDemissao).HasDefaultValue (null);
                mb.HasOne(d => d.Pessoa)
                    .WithOne(p => p.Funcionario)
                    .HasForeignKey<Funcionario>(d => d.Id)
                    .HasConstraintName("PFK_PessoaFuncionario");
                mb.HasOne(d => d.Cargo)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.CargoId)
                    .HasConstraintName("FK_Cargo").OnDelete(DeleteBehavior.Restrict);
                mb.HasOne(d => d.Conselho)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.ConselhoId)
                    .HasConstraintName("FK_Conselho").OnDelete(DeleteBehavior.Restrict);


            });
            
            modelBuilder.Entity<Paciente> (mb => {
                mb.ToTable ("Paciente");
                mb.HasKey (c => c.Id).HasName ("IdPaciente");
                mb.Property (c => c.Id).HasColumnName ("IdPaciente").IsRequired();
                mb.HasOne(d => d.Pessoa)
                    .WithOne(p => p.Paciente)
                    .HasForeignKey<Paciente>(d => d.Id)
                    .HasConstraintName("PFK_PessoaPaciente");
            });



            modelBuilder.Entity<Conselho> (mb => {
                mb.ToTable ("Conselho");
                mb.HasKey (c => c.Id).HasName ("IdConselho");
                mb.Property (c => c.Id).HasColumnName ("IdConselho").ValueGeneratedOnAdd();
                mb.Property(f => f.DescricaoConselho);
                mb.Property(f => f.NumeroConselho);

            });

            modelBuilder.Entity<Cargo> (mb => {
                mb.ToTable ("Cargo");
                mb.HasKey (c => c.Id).HasName ("IDCargo");
                mb.Property (c => c.Id).HasColumnName ("IDCargo")
                    .ValueGeneratedOnAdd ();
                mb.Property (f => f.DescricaoCargo).IsRequired ();
                mb.Property (f => f.IsHealthProfession).IsRequired ();
            });


        }
    }
}