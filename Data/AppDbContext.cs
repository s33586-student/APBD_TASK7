using Microsoft.EntityFrameworkCore;
using APBD_TASK7.Models;

namespace APBD_TASK7.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Pc> Pcs { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<ComponentType> ComponentTypes { get; set; }
        public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; }
        public DbSet<PcComponent> PcComponents { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pc>(entity =>
            {
                entity.ToTable("PCs");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Weight).HasColumnType("float").HasMaxLength(5).IsRequired();
                entity.Property(e => e.Warranty).IsRequired();
                entity.Property(e => e.CreatedAt).HasColumnType("datetime").IsRequired();
                entity.Property(e => e.Stock).IsRequired();
            });

            modelBuilder.Entity<ComponentManufacturer>(entity =>
            {
                entity.ToTable("ComponentManufacturers");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Abbreviation).HasMaxLength(30).IsRequired();
                entity.Property(e => e.FullName).HasMaxLength(300).IsRequired();
                entity.Property(e => e.FoundationDate).HasColumnType("date").IsRequired();
            });

            modelBuilder.Entity<ComponentType>(entity =>
            {
                entity.ToTable("ComponentTypes");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Abbreviation).HasMaxLength(30).IsRequired();
                entity.Property(e => e.Name).HasMaxLength(150).IsRequired();
            });

            modelBuilder.Entity<Component>(entity =>
            {
                entity.ToTable("Components");
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(10).IsRequired();
                entity.Property(e => e.Name).HasMaxLength(300).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(int.MaxValue);

                entity.HasOne(e => e.ComponentManufacturer)
                    .WithMany(e => e.Components)
                    .HasForeignKey(e => e.ComponentManufacturerId);

                entity.HasOne(e => e.ComponentType)
                    .WithMany(e => e.Components)
                    .HasForeignKey(e => e.ComponentTypeId);
            });

            modelBuilder.Entity<PcComponent>(entity =>
            {
                entity.ToTable("PCComponents");
                entity.HasKey(e => new { e.PcId, e.ComponentCode });

                entity.Property(e => e.Amount).IsRequired();

                entity.HasOne(e => e.Pc)
                    .WithMany(e => e.PcComponents)
                    .HasForeignKey(e => e.PcId);

                entity.HasOne(e => e.Component)
                    .WithMany(e => e.PcComponents)
                    .HasForeignKey(e => e.ComponentCode);
            });



            modelBuilder.Entity<ComponentType>().HasData(
                new ComponentType { Id = 1, Abbreviation = "CPU", Name = "Processor" },
                new ComponentType { Id = 2, Abbreviation = "GPU", Name = "Graphics Card"},
                new ComponentType { Id = 3, Abbreviation = "RAM", Name = "Memory" }
            );

            modelBuilder.Entity<ComponentManufacturer>().HasData(
                new ComponentManufacturer
                {
                    Id = 1,
                    Abbreviation = "INT",
                    FullName = "Intel Corporation",
                    FoundationDate = new DateTime(1968, 1, 2)
                },
                new ComponentManufacturer
                {
                    Id = 2,
                    Abbreviation = "NVD",
                    FullName = "NVIDIA Corporation",
                    FoundationDate = new DateTime(1993, 2, 3)
                },
                new ComponentManufacturer
                {
                    Id = 3,
                    Abbreviation = "RZR",
                    FullName = "Razer Incorporation",
                    FoundationDate = new DateTime(1998, 3, 4)
                }
            );

            modelBuilder.Entity<Component>().HasData(
                new Component
                {
                    Code = "CPU001",
                    Name = "Intel i7",
                    Description = "High performance processor",
                    ComponentTypeId = 1,
                    ComponentManufacturerId = 1
                },
                new Component
                {
                    Code = "GPU001",
                    Name = "RTX 4070",
                    Description = "Gaming graphics card",
                    ComponentTypeId = 2,
                    ComponentManufacturerId = 2
                },
                new Component
                {
                    Code = "RAM001",
                    Name = "Razer Blade 32GB",
                    Description = "Memory module",
                    ComponentTypeId = 3,
                    ComponentManufacturerId = 3
                }
            );

            modelBuilder.Entity<Pc>().HasData(
                new Pc
                {
                    Id = 1,
                    Name = "Gaming Beast X",
                    Weight = 12.5,
                    Warranty = 36,
                    CreatedAt = new DateTime(2026, 5, 8),
                    Stock = 5
                },
                new Pc
                {
                    Id = 2,
                    Name = "Office Mini Pro",
                    Weight = 4.2,
                    Warranty = 24,
                    CreatedAt = new DateTime(2026, 4, 15),
                    Stock = 12
                },
                new Pc
                {
                    Id = 3,
                    Name = "Student Basic PC",
                    Weight = 6.8,
                    Warranty = 12,
                    CreatedAt = new DateTime(2026, 3, 20),
                    Stock = 20
                }
            );

            modelBuilder.Entity<PcComponent>().HasData(
                new PcComponent
                {
                    PcId = 1,
                    ComponentCode = "CPU001",
                    Amount = 1
                },
                new PcComponent
                {
                    PcId = 1,
                    ComponentCode = "GPU001",
                    Amount = 1
                },
                new PcComponent
                {
                    PcId = 1,
                    ComponentCode = "RAM001",
                    Amount = 2
                },

                new PcComponent
                {
                    PcId = 2,
                    ComponentCode = "CPU001",
                    Amount = 1
                },
                new PcComponent
                {
                    PcId = 2,
                    ComponentCode = "RAM001",
                    Amount = 1
                },
                new PcComponent
                {
                    PcId = 3,
                    ComponentCode = "RAM001",
                    Amount = 2
                }
            );
        }
    }
}
