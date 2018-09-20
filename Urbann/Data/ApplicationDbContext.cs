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



            //builder.Entity<Place>()
            //    .HasOne(a => a.Address)
            //    .WithOne(b => b.Place)
            //    .HasForeignKey<Address>(a => a.AddressId);
            //builder.Entity<Place>().ToTable("Places");
            //builder.Entity<Address>().ToTable("Places");




            //    builder.Entity<Category>().HasData(
            //       new Category { CategoryId = 1, Name = "Factory" },
            //       new Category { CategoryId = 2, Name = "Church" },
            //       new Category { CategoryId = 3, Name = "Underground" },
            //       new Category { CategoryId = 4, Name = "Military" }
            //   );

            //    builder.Entity<Country>().HasData(
            //        new Country { CountryId = 1, Name = "Poland" },
            //        new Country { CountryId = 2, Name = "Italy" },
            //        new Country { CountryId = 3, Name = "Spain" },
            //        new Country { CountryId = 4, Name = "Sweden" }
            //        );

            //    builder.Entity<Address>().HasData(
            //        new Address { AddressId = 1, CountryId = 1, City = "Cracow", Street = "Tyniecka 22" },
            //        new Address { AddressId = 2, CountryId = 1, City = "Cracow", Street = "Drukarska 10" },
            //        new Address { AddressId = 3, CountryId = 2, City = "Rome", Street = "via catania 32" },
            //        new Address { AddressId = 4, CountryId = 2, City = "Rome", Street = "via imperia 5" },
            //        new Address { AddressId = 5, CountryId = 3, City = "Madrid", Street = "calle menorca 2" },
            //        new Address { AddressId = 6, CountryId = 4, City = "Uppsala", Street = "kungsgatan 76" }
            //        );

            //    builder.Entity<Place>().HasData(
            //        new Place { PlaceId = 1, Name = "Place 1", CategoryId = 1, AddressId = 1, ThumbnailFileName = "1.jpeg" },
            //        new Place { PlaceId = 2, Name = "Place 2", CategoryId = 1, AddressId = 2, ThumbnailFileName = "2.jpeg" },
            //        new Place { PlaceId = 3, Name = "Place 3", CategoryId = 1, AddressId = 3, ThumbnailFileName = "3.jpeg" },
            //        new Place { PlaceId = 4, Name = "Place 4", CategoryId = 2, AddressId = 4, ThumbnailFileName = "4.jpeg" },
            //        new Place { PlaceId = 5, Name = "Place 5", CategoryId = 2, AddressId = 5, ThumbnailFileName = "5.jpeg" },
            //        new Place { PlaceId = 6, Name = "Place 6", CategoryId = 2, AddressId = 6, ThumbnailFileName = "6.jpeg" }
            //        );

            //    var rnd = new Random();
            //    var desc = "Ut arcu enim, dictum quis ultrices id, sagittis eget nulla sed nunc mi, congue ut ultricies ac, varius a eros donec porttitor, libero fermentum fringilla laoreet, eros arcu sodales ante, ut dictum risus lectus vel quam integer ultricies, nunc eget elementum euismod, orci enim vestibulum orci, nec suscipit urna odio et tellus suspendisse suscipit orci sit amet sem venenatis nec lobortis sem suscipit nullam nec imperdiet velit mauris eu nisi a felis imperdiet porta at ac nulla vivamus faucibus felis nec dolor pretium eget pellentesque dolor suscipit maecenas vitae enim arcu, at tincidunt nunc pellentesque eleifend vulputate lacus, vel semper sem ornare sit amet proin sem sapien, auctor vel faucibus id, aliquet vitae ipsum etiam auctor ultricies ante, at dapibus urna viverra sed nullam mi arcu, tempor vitae interdum a, sodales non urna vestibulum dignissim auctor mauris, ac elementum purus fermentum vitae duis placerat laoreet risus, sit amet eleifend tellus lobortis non vivamus iaculis dapibus leo a ornare cras vel sem at felis convallis mollis posuere ultrices dolor sed tellus arcu, accumsan a consectetur sit amet, volutpat eget lorem phasellus quis ipsum orci integer sodales tincidunt nibh a elementum ut ac libero nec orci euismod euismod nec at nulla duis.";
            //    var fileNames = new List<string> { "1.jpeg", "2.jpeg", "3.jpeg", "4.jpeg", "5.jpeg", "6.jpeg" };


            //    for (int i = 7; i < 100; i++)
            //    {
            //        builder.Entity<Place>().HasData(
            //            new Place
            //            {
            //                PlaceId = i,
            //                Name = $"Place: {i}",
            //                CategoryId = rnd.Next(1, 7),
            //                ThumbnailFileName = fileNames[rnd.Next(1, 6)],
            //                Description = desc,
            //                    //Address = new Address { AddressId = i, City = $"city {i}", Street = $"street {i}", CountryId = rnd.Next(1, 5) }
            //                }
            //        );
            //    }

            //    for (int i = 0; i < 100; i++)
            //    {
            //        for (int j = 0; j < 5; j++)
            //        {
            //            builder.Entity<Photo>().HasData(
            //               new Photo { PhotoId = Guid.NewGuid(), FileName = fileNames[rnd.Next(1, 6)], PlaceId = i }
            //               );
            //        }
            //    }
        }
        }
    }


