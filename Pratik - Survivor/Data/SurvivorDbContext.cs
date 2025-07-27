using Microsoft.EntityFrameworkCore;
using Pratik___Survivor.Entities;

namespace Pratik___Survivor.Context
{
    public class SurvivorDbContext : DbContext
    {
      
            public SurvivorDbContext(DbContextOptions<SurvivorDbContext> options) : base(options) 
            { 
            }

            public DbSet<CompetitorEntity> Competitors { get; set; }
            public DbSet<CategoryEntity> Categories { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<CategoryEntity>()
                    .HasMany(c => c.Competitors)
                    .WithOne(c => c.Category)
                    .HasForeignKey(c => c.CategoryId);

                modelBuilder.Entity<CategoryEntity>().HasData(
                    new CategoryEntity { Id = 1, Name = "Ünlüler" },
                    new CategoryEntity { Id = 2, Name = "Gönüllüler" }
                );

                var createdDate = new DateTime(2024, 1, 1, 10, 0, 0);
                modelBuilder.Entity<CompetitorEntity>().HasData(
                    new CompetitorEntity { Id = 1, FirstName = "Acun", LastName = "Ilıcalı", CreatedDate = createdDate, ModifiedDate = createdDate, IsDeleted = false, CategoryId = 1 },
                    new CompetitorEntity { Id = 2, FirstName = "Aleyna", LastName = "Avcı", CreatedDate = createdDate, ModifiedDate = createdDate, IsDeleted = false, CategoryId = 1 },
                    new CompetitorEntity { Id = 3, FirstName = "Hadise", LastName = "Açıkgöz", CreatedDate = createdDate, ModifiedDate = createdDate, IsDeleted = false, CategoryId = 1 },
                    new CompetitorEntity { Id = 4, FirstName = "Sertan", LastName = "Bozkuş", CreatedDate = createdDate, ModifiedDate = createdDate, IsDeleted = false, CategoryId = 1 },
                    new CompetitorEntity { Id = 5, FirstName = "Özge", LastName = "Açık", CreatedDate = createdDate, ModifiedDate = createdDate, IsDeleted = false, CategoryId = 1 },
                    new CompetitorEntity { Id = 6, FirstName = "Kıvanç", LastName = "Tatlıtuğ", CreatedDate = createdDate, ModifiedDate = createdDate, IsDeleted = false, CategoryId = 1 },
                    new CompetitorEntity { Id = 7, FirstName = "Ahmet", LastName = "Yılmaz", CreatedDate = createdDate, ModifiedDate = createdDate, IsDeleted = false, CategoryId = 2 },
                    new CompetitorEntity { Id = 8, FirstName = "Elif", LastName = "Demirtaş", CreatedDate = createdDate, ModifiedDate = createdDate, IsDeleted = false, CategoryId = 2 },
                    new CompetitorEntity { Id = 9, FirstName = "Cem", LastName = "Öztürk", CreatedDate = createdDate, ModifiedDate = createdDate, IsDeleted = false, CategoryId = 2 },
                    new CompetitorEntity { Id = 10, FirstName = "Ayşe", LastName = "Karaca", CreatedDate = createdDate, ModifiedDate = createdDate, IsDeleted = false, CategoryId = 2 }
                );
            }
        }
    }

