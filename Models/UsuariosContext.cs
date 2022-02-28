
using Microsoft.EntityFrameworkCore;

namespace UsandoViews.Models
{
    public class UsuariosContext :DbContext
     {
        public DbSet<Usuario> Users {get; set;}

        public  UsuariosContext(DbContextOptions<UsuariosContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Users");
        }

     }
 }