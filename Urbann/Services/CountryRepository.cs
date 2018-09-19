using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urbann.Data;
using Urbann.Data.Repositories;

namespace Urbann.Services
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;

        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<string>> GetAllNamesAsync()
        {
            return await _context.Countries.Select(x => x.Name).ToListAsync();
        }
    }
}
