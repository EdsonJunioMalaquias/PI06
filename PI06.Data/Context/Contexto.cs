using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PI06.Data.Models.Entity;
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
                mb.ToTable ("Pessoa").HasIndex(e => new { e.CodigoCpf, e.Uf, e.Sus  }).IsUnique();
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
                mb.Property (f => f.Uf).IsRequired();
                mb.Property (f => f.Complemento);
                mb.Property (f => f.CodigoCpf).IsRequired();
                
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

            modelBuilder.Entity<Consulta>(pro => {
                pro.ToTable("Consulta");
                pro.HasKey(c => c.Id).HasName("IdConsulta");
                pro.Property(c => c.Id).HasColumnName("IdConsulta")
                .ValueGeneratedOnAdd();
                pro.Property(c => c.DataInicio).IsRequired();
                pro.Property(c => c.DataTermino);
                pro.HasOne(d => d.FuncionarioMedico)
                    .WithMany(p => p.Consultas)
                    .HasForeignKey(a => a.IdFuncionarioMedico)
                    .HasConstraintName("FK_FuncionarioConsulta");

                pro.HasOne(d => d.Paciente)
                   .WithMany(p => p.Consultas)
                   .HasForeignKey(d => d.IdPaciente)
                   .HasConstraintName("FK_PacienteConsulta");
            });

            modelBuilder.Entity<TipoExame>(te => {
                te.ToTable("TipoExame");
                te.HasKey(c => c.Id).HasName("IdTipoExame");
                te.Property(c => c.Id).HasColumnName("IdTipoExame").ValueGeneratedOnAdd();
                te.Property(c => c.Descricao).IsRequired();
                te.Property(c => c.ResultadoReferencia).IsRequired();                    
            });

            modelBuilder.Entity<TipoProcedimento>(tp => {
                tp.ToTable("TipoProcedimento");
                tp.HasKey(c => c.Id).HasName("IdTipoProcedimento");
                tp.Property(c => c.Id).HasColumnName("IdTipoProcedimento").ValueGeneratedOnAdd();
                tp.Property(c => c.Descricao).IsRequired();
            });

            modelBuilder.Entity<Cirurgia>(ci => {
                ci.ToTable("Cirurgia");
                ci.HasKey(c => c.Id).HasName("IdCirurgiaProcedimento");
                ci.Property (c => c.Id).HasColumnName ("IdCirurgiaProcedimento").IsRequired();
                
                ci.HasOne(d => d.Procedimento)
                    .WithOne(p => p.Cirurgia)
                    .HasForeignKey<Cirurgia>(d => d.Id)
                    .HasConstraintName("PFK_IdProcedimentoCirurgia");
                
                ci.Property(c => c.Descricao).IsRequired();


            });

            modelBuilder.Entity<Exame>(ex => {
                ex.ToTable("Exame");
                ex.HasKey(c => c.Id).HasName("IdExame");
                ex.Property(c => c.Id).HasColumnName("IdExame");
                ex.Property(e => e.Resultado).IsRequired();
                ex.HasOne(p => p.Procedimento)
                    .WithOne(p => p.Exame)
                    .HasForeignKey<Exame>(a => a.Id)
                    .HasConstraintName("PFK_ProcedimentoExame");

                ex.HasOne(p=> p.TipoExame)
                    .WithMany(i => i.Exames)
                    .HasForeignKey(i => i.IdTipoExame)
                    .HasConstraintName("FK_IdTipoExame");
            });

            modelBuilder.Entity<Procedimento>(proc => {
                proc.ToTable("Procedimento");
                proc.HasKey(c => c.Id).HasName("IdProcedimento");
                proc.Property(c => c.Id).HasColumnName("idProcedimento");
                proc.Property(e => e.Observacao).IsRequired();
                proc.HasOne(d => d.Consulta)
                   .WithMany(p => p.Procedimentos)
                   .HasForeignKey(d => d.IdConsulta)
                   .HasConstraintName("FK_IdConsulta");

               proc.HasOne(d => d.TipoProcedimento)
                    .WithMany(d => d.Procedimentos)
                    .HasForeignKey(d=>d.IdTipoProcedimento)
                    .HasConstraintName("FK_IdTipoProcedimento");  
            });


        }
    }
}