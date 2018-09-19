using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Urbann.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Photo> Photos { get; set; } 

        protected override void OnModelCreating(ModelBuilder builder)
        { 
            base.OnModelCreating(builder);

            builder.Entity<Category>()
                .HasMany(a => a.Places)
                .WithOne(b => b.Category);

            builder.Entity<Photo>()
                .HasOne(a => a.Place)
                .WithMany(b => b.Photos)
                .HasForeignKey(a => a.PlaceId);


            builder.Entity<Address>()
                .HasOne(a => a.Country)
                .WithMany(b => b.Addresses)
                .HasForeignKey(a => a.CountryId);

            builder.Entity<Place>()
                .HasOne(a => a.Address)
                .WithOne(b => b.Place)
                .HasForeignKey<Place>(a => a.AddressId);

            builder.Entity<Category>().HasData(
               new Category { CategoryId = 1, Name = "Factory" },
               new Category { CategoryId = 2, Name = "Church" }
           );

            builder.Entity<Country>().HasData(
                new Country { CountryId = 1, Name = "Poland" },
                new Country { CountryId = 2, Name = "Italy" },
                new Country { CountryId = 3, Name = "Spain" },
                new Country { CountryId = 4, Name = "Sweden" }
                );

            builder.Entity<Address>().HasData(
                new Address { AddressId = 1, CountryId = 1, City = "Cracow", Street = "Tyniecka 22" },
                new Address { AddressId = 2, CountryId = 1, City = "Cracow", Street = "Drukarska 10" },
                new Address { AddressId = 3, CountryId = 2, City = "Rome", Street = "via catania 32" },
                new Address { AddressId = 4, CountryId = 2, City = "Rome", Street = "via imperia 5" },
                new Address { AddressId = 5, CountryId = 3, City = "Madrid", Street = "calle menorca 2" },
                new Address { AddressId = 6, CountryId = 4, City = "Uppsala", Street = "kungsgatan 76" }
                );

            builder.Entity<Place>().HasData(
                new Place { PlaceId = 1, Name = "Place 1", CategoryId = 1, AddressId = 1, ThumbnailFileName = "1.jpeg" },
                new Place { PlaceId = 2, Name = "Place 2", CategoryId = 1, AddressId = 2, ThumbnailFileName = "2.jpeg" },
                new Place { PlaceId = 3, Name = "Place 3", CategoryId = 1, AddressId = 3, ThumbnailFileName = "3.jpeg" },
                new Place { PlaceId = 4, Name = "Place 4", CategoryId = 2, AddressId = 4, ThumbnailFileName = "4.jpeg" },
                new Place { PlaceId = 5, Name = "Place 5", CategoryId = 2, AddressId = 5, ThumbnailFileName = "5.jpeg" },
                new Place { PlaceId = 6, Name = "Place 6", CategoryId = 2, AddressId = 6, ThumbnailFileName = "6.jpeg" }
                );

            // ?int fk
            for (int i = 10; i < 100; i++)
            {
                builder.Entity<Place>().HasData(
                new Place { PlaceId = i, Name = $"Place: {i}", CategoryId = 1, ThumbnailFileName = "1.jpeg" }
                );
            }

            builder.Entity<Photo>().HasData(
                new Photo { PhotoId = 1, FileName = "1.jpeg", PlaceId = 1 },
                new Photo { PhotoId = 2, FileName = "2.jpeg", PlaceId = 1 },
                new Photo { PhotoId = 3, FileName = "3.jpeg", PlaceId = 1 },
                new Photo { PhotoId = 4, FileName = "4.jpeg", PlaceId = 1 },
                new Photo { PhotoId = 5, FileName = "5.jpeg", PlaceId = 2 },
                new Photo { PhotoId = 6, FileName = "6.jpeg", PlaceId = 2 }
                );
        }
    }
}
