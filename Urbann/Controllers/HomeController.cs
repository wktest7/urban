using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Urbann.Data.Repositories;
using Urbann.Models;
using Urbann.Services;

namespace Urbann.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPlaceRepository _placeRepository;

        public HomeController(ICountryRepository countryRepository, ICategoryRepository categoryRepository,
            IPlaceRepository placeRepository)
        {
            _countryRepository = countryRepository;
            _categoryRepository = categoryRepository;
            _placeRepository = placeRepository;
        }

        public async Task<IActionResult> Index()
        {
            var countries = await _countryRepository.GetAllNamesAsync();
            var categories = await _categoryRepository.GetAllNamesAsync();

            var model = new FilterOptionsViewModel
            {
                Countries = countries.OrderBy(x => x),
                Categories = categories.OrderBy(x => x),
            };

            return View(model);
        }

        public async Task<IActionResult> Place(int id)
        {
            var place = await _placeRepository.GetAsync(id);

            if (place == null)
            {
                return NotFound();
            }

            return View(place);
        }

        public IActionResult About()
        {
            return View();
        }
    }
}