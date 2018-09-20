using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Urbann.Data
{
    public class Seeder
    {
        private ApplicationDbContext _context;

        public Seeder(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public void SeedData()
        {
            var rnd = new Random();
            var images = new List<string> { "1.jpeg", "2.jpeg", "3.jpeg", "4.jpeg", "5.jpeg", "6.jpeg" };
            var desc = "Ut arcu enim, dictum quis ultrices id, sagittis eget nulla sed nunc mi, congue ut ultricies ac, varius a eros donec porttitor, libero fermentum fringilla laoreet, eros arcu sodales ante, ut dictum risus lectus vel quam integer ultricies, nunc eget elementum euismod, orci enim vestibulum orci, nec suscipit urna odio et tellus suspendisse suscipit orci sit amet sem venenatis nec lobortis sem suscipit nullam nec imperdiet velit mauris eu nisi a felis imperdiet porta at ac nulla vivamus faucibus felis nec dolor pretium eget pellentesque dolor suscipit maecenas vitae enim arcu, at tincidunt nunc pellentesque eleifend vulputate lacus, vel semper sem ornare sit amet proin sem sapien, auctor vel faucibus id, aliquet vitae ipsum etiam auctor ultricies ante, at dapibus urna viverra sed nullam mi arcu, tempor vitae interdum a, sodales non urna vestibulum dignissim auctor mauris, ac elementum purus fermentum vitae duis placerat laoreet risus, sit amet eleifend tellus lobortis non vivamus iaculis dapibus leo a ornare cras vel sem at felis convallis mollis posuere ultrices dolor sed tellus arcu, accumsan a consectetur sit amet, volutpat eget lorem phasellus quis ipsum orci integer sodales tincidunt nibh a elementum ut ac libero nec orci euismod euismod nec at nulla duis.";

            if (!_context.Places.Any())
            {

                var categories = new List<Category>
                {
                    new Category { Name = "Factory" },
                    new Category { Name = "Church" },
                    new Category { Name = "Underground" },
                    new Category { Name = "Military" }
                };
                _context.Categories.AddRange(categories);
                _context.SaveChanges();

                var countries = new List<Country>
                {
                    new Country { Name = "Poland" },
                    new Country { Name = "Italy" },
                    new Country { Name = "Spain" },
                    new Country { Name = "Sweden" }
                };
                _context.Countries.AddRange(countries);
                _context.SaveChanges();

                var addresses = new List<Address>();
                for (int i = 0; i < 100; i++)
                {
                    addresses.Add(new Address { City = "City " + i, Street = "Street " + i, CountryId = rnd.Next(1, 5) });
                }
                _context.Addresses.AddRange(addresses);
                _context.SaveChanges();

                var places = new List<Place>();
                for (int i = 0; i < 100; i++)
                {
                    places.Add(new Place
                    {
                        Name = "Place " + i,
                        CategoryId = rnd.Next(1, 5),
                        AddressId = i + 1,
                        ThumbnailFileName = images[rnd.Next(0, 6)],
                        Description = desc,


                    });
                }
                _context.Places.AddRange(places);
                _context.SaveChanges();

                var photos = new List<Photo>();
                for (int i = 0; i < 100; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        photos.Add(new Photo { FileName = images[rnd.Next(0, 6)], PlaceId = i + 1 });
                    }
                }
                _context.Photos.AddRange(photos);
                _context.SaveChanges();
            }
        }
    }
}
