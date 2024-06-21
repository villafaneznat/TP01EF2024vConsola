using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP01EF2024.Entidades;

namespace TP01EF2024.Datos
{
    public partial class TP01DbContext: DbContext
    {
        public TP01DbContext()
        {
                
        }

        public TP01DbContext(DbContextOptions<TP01DbContext> options) : base(options)
        {

        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<ShoeColour> ShoesColours { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source =.;
                            Initial Catalog = TP01EF2024;
                            Trusted_Connection = true;
                            TrustServerCertificate = true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var brands = new List<Brand>()
            {
                new Brand
                {
                    BrandId = 1,
                    BrandName = "Vans"
                },
                new Brand
                {
                    BrandId = 2,
                    BrandName = "Adidas"
                },
                new Brand
                {
                    BrandId = 3,
                    BrandName = "Topper"
                },
            };

            var genres = new List<Genre>()
            {
                new Genre
                {
                    GenreId = 1,
                    GenreName = "Femenino"
                },
                new Genre
                {
                    GenreId = 2,
                    GenreName = "Masculino"
                },
                new Genre
                {
                    GenreId = 3,
                    GenreName = "Unisex"
                },
            };

            var sports = new List<Sport>()
            {
                new Sport
                {
                    SportId = 1,
                    SportName = "Futbol"
                },
                new Sport
                {
                    SportId = 2,
                    SportName = "Tenis"
                },
                new Sport
                {
                    SportId = 3,
                    SportName = "Basquet"
                },
            };

            var colours = new List<Colour>()
            {
                new Colour
                {
                    ColourId = 1,
                    ColourName = "Rojo"
                },
                new Colour
                {
                    ColourId = 2,
                    ColourName = "Negro"
                },
                new Colour
                {
                    ColourId = 3,
                    ColourName = "Blanco"
                },
            };
            
            var shoes = new List<Shoe>()
            {
                new Shoe
                {
                    ShoeId = 1,
                    BrandId = 1,
                    SportId = 3,
                    GenreId = 2,
                    Model = "Deportivas",
                    Description = "Vans Deportivas",
                    Price = 15
                },
                new Shoe
                {
                    ShoeId = 2,
                    BrandId = 2,
                    SportId = 1,
                    GenreId = 1,
                    Model = "Botines",
                    Description = "Botines Femeninos",
                    Price = 20
                },
                new Shoe
                {
                    ShoeId = 3,
                    BrandId = 3,
                    SportId = 2,
                    GenreId = 3,
                    Model = "1982",
                    Description = "Importados",
                    Price = 35
                },
            };

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.BrandId);
                entity.HasIndex(t => t.BrandName).IsUnique();
                entity.Property(e => e.BrandName).IsRequired().HasMaxLength(50);
                entity.HasData(brands);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.GenreId);
                entity.HasIndex(t => t.GenreName).IsUnique();
                entity.Property(e => e.GenreName).IsRequired().HasMaxLength(10);
                entity.HasData(genres);
            });

            modelBuilder.Entity<Sport>(entity =>
            {
                entity.HasKey(e => e.SportId);
                entity.HasIndex(t => t.SportName).IsUnique();
                entity.Property(e => e.SportName).IsRequired().HasMaxLength(20);
                entity.HasData(sports);
            });

            modelBuilder.Entity<Colour>(entity =>
            {
                entity.HasKey(e => e.ColourId);
                entity.HasIndex(t => t.ColourName).IsUnique();
                entity.Property(e => e.ColourName).IsRequired().HasMaxLength(50);
                entity.HasData(colours);
            });

            modelBuilder.Entity<Shoe>(entity =>
            {
                entity.HasKey(e => e.ShoeId);
                entity.HasOne(s => s.Brand).WithMany(b => b.Shoes).HasForeignKey(s => s.BrandId);
                entity.HasOne(s => s.Genre).WithMany(g => g.Shoes).HasForeignKey(s => s.GenreId);
                entity.HasOne(s => s.Sport).WithMany(s => s.Shoes).HasForeignKey(s => s.SportId);
                entity.Property(e => e.Model).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Price).HasPrecision(10,2);
                entity.Property(e => e.Description).IsRequired();
                entity.HasData(shoes);
            });

            modelBuilder.Entity<ShoeColour>(entity =>
            {
                entity.HasKey(sc => new { sc.ShoeId, sc.ColourId });
                entity.HasOne(sc => sc.Shoe).WithMany(s => s.ShoesColours).HasForeignKey(sc => sc.ShoeId);
                entity.HasOne(sc => sc.Colour).WithMany(c => c.ShoesColours).HasForeignKey(sc => sc.ColourId);
            });

        }
        

    }
}
