using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urbann.Data;

namespace Urbann.Services
{
    public interface IPlaceRepository
    {
        Task<IEnumerable<Place>> GetAllAsync();
        //Task<IEnumerable<Place>> GetAllAsync(int take);
        Task<IEnumerable<Place>> GetAllAsync(int take, int skip = 0);
        Task<IEnumerable<Place>> SearchAsync(string name, string country, string category);
        Task<IEnumerable<Place>> SearchAsync(string name, string[] countries, string[] categories, int take, int skip = 0);
        Task<Place> GetAsync(int id);

    }
}
