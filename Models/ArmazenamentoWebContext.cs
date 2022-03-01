using Microsoft.EntityFrameworkCore;

namespace ProjetoAgenda.Models
{
    public class ArmazenamentoWebContext : DbContext
    {
        public DbSet<GrupoModel> Grupo {get;set;}
        public DbSet<UsuarioModel> Usuario {get;set;}
        public ArmazenamentoWebContext(DbContextOptions<ArmazenamentoWebContext> options): base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GrupoModel>().ToTable("Grupo");
            modelBuilder.Entity<UsuarioModel>().ToTable("Usuario");
        }
    }
}