using Microsoft.EntityFrameworkCore;

namespace ApiTestUser.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Models.Categoria> Categorias { get; set; }
        public DbSet<Models.Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Models.Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);
                entity.Property(entity => entity.IdCategoria).UseIdentityColumn().ValueGeneratedOnAdd();
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Nivel).IsRequired();
                entity.Property(e => e.Descripcion).HasMaxLength(100);
                entity.Property(e => e.SalarioBase).HasColumnType("decimal(18,2)");
                entity.ToTable("Categorias");
                entity.HasData(
                    new Models.Categoria { IdCategoria = 1, Nombre = "Programador jr", Nivel = 1, Descripcion = "Puesto de inicio", SalarioBase = 1000 },
                    new Models.Categoria { IdCategoria = 2, Nombre = "Programador sr", Nivel = 2, Descripcion = "Puesto intermedio", SalarioBase = 2000 },
                    new Models.Categoria { IdCategoria = 3, Nombre = "Programador pl", Nivel = 3, Descripcion = "Puesto avanzado", SalarioBase = 3000 },
                    new Models.Categoria { IdCategoria = 4, Nombre = "Arquitecto", Nivel = 4, Descripcion = "Puesto de liderazgo", SalarioBase = 4000 }
                 );
            });

            modelBuilder.Entity<Models.Usuario>(entity =>
            {
                entity.HasKey(e => e.idUsuario);
                entity.Property(e => e.idUsuario).UseIdentityColumn().ValueGeneratedOnAdd();
                entity.Property(e => e.nombre).IsRequired().HasMaxLength(50);
                entity.Property(e => e.apellido).HasMaxLength(50);
                entity.Property(e => e.email).IsRequired().HasMaxLength(50);
                entity.Property(e => e.FechaNasc).HasColumnType("date");
                entity.HasOne(e => e.CategoriaReferencia).WithMany(e => e.UsuariosReferencia).HasForeignKey(e => e.idCategoria);
                entity.ToTable("Usuarios");
               



            });
        }
        }
    }
