using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Urbann.Data
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}
