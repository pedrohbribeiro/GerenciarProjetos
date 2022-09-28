using Microsoft.EntityFrameworkCore;
using GerenciarProjetos.Database.Entities;

namespace GerenciarProjetos.Database
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<MembrosEntity>()
                .HasOne(m => m.Projeto)
                .WithMany(p => p.Membro)
                .HasForeignKey(m => m.IdProjeto);

            builder.Entity<MembrosEntity>()
                .HasOne(m => m.Empregado)
                .WithMany(p => p.Membro)
                .HasForeignKey(m => m.IdEmpregado);

            builder.Entity<ProjetoEntity>()
                .HasOne(m => m.Empregado)
                .WithMany(p => p.Projeto)
                .HasForeignKey(m => m.IdGerente);

            builder.Entity<RefreshTokenEntity>()
                .HasOne(m => m.Usuario)
                .WithMany(p => p.RefreshToken)
                .HasForeignKey(m => m.IdUsuario);

            builder.Entity<UsuarioEntity>()
                .HasIndex(u => u.Email)
                .IsUnique();

            builder.Entity<EmpregadoEntity>()
                .HasIndex(u => u.Endereco)
                .IsUnique();
        }

        public DbSet<ProjetoEntity> Projeto { get; set; }
        public DbSet<EmpregadoEntity> Empregado { get; set; }
        public DbSet<MembrosEntity> Membros { get; set; }
        public DbSet<UsuarioEntity> Usuario { get; set; }
        public DbSet<RefreshTokenEntity> RefreshToken { get; set; }
    }
}
