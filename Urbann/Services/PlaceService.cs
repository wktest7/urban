using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urbann.Data;
using Urbann.Models;

namespace Urbann.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IMapper _mapper;
        private readonly IPlaceRepository _placeRepository;

        public PlaceService(IMapper mapper, IPlaceRepository placeRepository)
        {
            _mapper = mapper;
            _placeRepository = placeRepository;
        }
        public async Task<PlaceDto> GetAsync(int id)
        {
            var place = await _placeRepository.GetAsync(id);
            return _mapper.Map<Place, PlaceDto>(place);
        }

        public async Task<IEnumerable<PlaceDto>> GetAllAsync()
        {
            var places = await _placeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Place>, IEnumerable<PlaceDto>>(places);
        }

        public async Task<IEnumerable<PlaceDto>> SearchAsync(string name, string country, string category)
        {
            var places = await _placeRepository.SearchAsync(name, country, category);
            return _mapper.Map<IEnumerable<Place>, IEnumerable<PlaceDto>>(places);
        }

        public async Task<IEnumerable<PlaceDto>> SearchAsync(string name, string[] countries, string[] categories, int take, int skip = 0)
        {
            var places = await _placeRepository.SearchAsync(name, countries, categories, take, skip);
            return _mapper.Map<IEnumerable<Place>, IEnumerable<PlaceDto>>(places);
        }
    }
}
