using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urbann.Data;

namespace Urbann.Models
{
    public class SearchViewModel
    {
        public IEnumerable<string> Countries { get; set; }
        public IEnumerable<string> Categories { get; set; }
        //public IPagedList<Place> Places { get; set; }
    }
}
