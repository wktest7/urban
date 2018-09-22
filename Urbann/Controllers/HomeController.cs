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

        public HomeController(ICountryRepository countryRepository, ICategoryRepository categoryRepository)
        {
            _countryRepository = countryRepository;
            _categoryRepository = categoryRepository;
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
    }
}