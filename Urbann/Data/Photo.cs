using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Urbann.Data
{
    public class Photo
    {
        public int PhotoId { get; set; }
        public string FileName { get; set; }

        public int PlaceId { get; set; }
        public Place Place { get; set; }
    }
}
