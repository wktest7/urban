using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Urbann.Data.Repositories
{
    public interface ICountryRepository
    {
        Task<IEnumerable<string>> GetAllNamesAsync();
    }
}
