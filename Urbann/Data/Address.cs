using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Urbann.Data
{
    public class Address
    {
        public int AddressId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
        public Place Place { get; set; }
    }
}
