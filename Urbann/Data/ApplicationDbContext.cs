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

            builder.Entity<Address>()
                .Property(p => p.AddressId)
                .UseSqlServerIdentityColumn();

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

        }
    }
}


