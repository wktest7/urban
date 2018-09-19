using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Urbann.Models
{
    public class PlaceDto
    {
        public int PlaceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ThumbnailFileName { get; set; }
        public AddressDto Address { get; set; }
        public string Category { get; set; }
        public IEnumerable<PhotoDto> Photos { get; set; }
    }
}
