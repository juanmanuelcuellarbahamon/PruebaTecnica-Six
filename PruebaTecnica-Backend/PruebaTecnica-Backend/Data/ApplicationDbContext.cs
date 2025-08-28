using Microsoft.EntityFrameworkCore;
using PruebaTecnica_Backend.Models;

namespace PruebaTecnica_Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Usuario");

                entity.HasKey(e => e.UsuID);

                entity.Property(e => e.UsuID)
                      .HasColumnName("usuID")
                      .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Nombre)
                      .HasColumnName("nombre")
                      .HasMaxLength(100)
                      .IsUnicode(false);

                entity.Property(e => e.Apellido)
                      .HasColumnName("apellido")
                      .HasMaxLength(100)
                      .IsUnicode(false);
            });

            modelBuilder.Entity<User>().HasData(
                new User { UsuID = 1, Nombre = "Juan", Apellido = "Pérez" },
                new User { UsuID = 2, Nombre = "Ana", Apellido = "Gómez" },
                new User { UsuID = 3, Nombre = "Luis", Apellido = "Martínez" },
                new User { UsuID = 4, Nombre = "Marta", Apellido = "López" },
                new User { UsuID = 5, Nombre = "Carlos", Apellido = "Ramírez" }
            );
        }
    }
}
