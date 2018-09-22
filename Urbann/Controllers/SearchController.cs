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
    public class SearchController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPlaceRepository _placeRepository;

        public SearchController(ICountryRepository countryRepository, ICategoryRepository categoryRepository,
            IPlaceRepository placeRepository)
        {
            _countryRepository = countryRepository;
            _categoryRepository = categoryRepository;
            _placeRepository = placeRepository;

        }

        public async Task<IActionResult> Index(string name)
        {
            var countries = await _countryRepository.GetAllNamesAsync();
            var categories = await _categoryRepository.GetAllNamesAsync();

            var model = new FilterOptionsViewModel
            {
                Countries = countries,
                Categories = categories,
            };

            ViewBag.Name = name;


            return View(model);
        }
    }
}