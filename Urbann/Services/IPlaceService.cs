using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urbann.Models;

namespace Urbann.Services
{
    public interface IPlaceService
    {
        Task<PlaceDto> GetAsync(int id);
        Task<IEnumerable<PlaceDto>> GetAllAsync();
        Task<IEnumerable<PlaceDto>> SearchAsync(string name, string country, string category);
        Task<IEnumerable<PlaceDto>> SearchAsync(string name, string[] countries, string[] categories, int take, int skip = 0);
    }
}
