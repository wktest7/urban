using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urbann.Data;

namespace Urbann.Services
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly ApplicationDbContext _context;

        public PlaceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Place> GetAsync(int id)
        {
            return await _context.Places
                .Include(x => x.Address)
                .ThenInclude(p => p.Country)
                .Include(p => p.Category)
                .SingleOrDefaultAsync(x => x.PlaceId == id);
        }

        public async Task<IEnumerable<Place>> GetAllAsync()
        {
            return await _context.Places
                .Include(p => p.Address)
                .ThenInclude(p => p.Country)
                .Include(p => p.Category)
                .Include(p => p.Photos)
                .ToListAsync();
        }
        
        public async Task<IEnumerable<Place>> GetAllAsync(int take, int skip = 0)
        {
            return await _context.Places
                .Include(p => p.Address)
                .ThenInclude(p => p.Country)
                .Include(p => p.Category)
                .Include(p => p.Photos)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }

        public async Task<IEnumerable<Place>> SearchAsync(string name, string country, string category)
        {
            return await _context.Places
                .Include(p => p.Address)
                .ThenInclude(p => p.Country)
                .Include(p => p.Category)
                .Include(p => p.Photos)
                .Where(x => x.Name.Contains(name) || name == null)
                .Where(x => x.Address.Country.Name == country || country == null)
                .Where(x => x.Category.Name == category || category == null)
                .ToListAsync();
        }

        public async Task<IEnumerable<Place>> SearchAsync(string name, string[] countries, string[] categories, int take, int skip = 0)
        {
            var places = _context.Places
             .Include(p => p.Address)
             .ThenInclude(p => p.Country)
             .Include(p => p.Category)
             .Include(p => p.Photos)
             .Where(x => x.Name.Contains(name) || name == null);

            if (countries.Length != 0)
            {
                places = places.Where(x => countries.Any(y => y.Equals(x.Address.Country.Name)));
            };

            if (categories.Length != 0)
            {
                places = places.Where(x => categories.Any(y => y.Equals(x.Category.Name)));
            };

            return await places.Skip(skip).Take(take).ToListAsync();
        }
    }
}

