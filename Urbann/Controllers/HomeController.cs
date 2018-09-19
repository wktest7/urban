using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Urbann.Data;
using Urbann.Models;
using Urbann.Services;

namespace Urbann.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlaceRepository _placeRepository;

        public HomeController(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        // GET: Places
        public async Task<IActionResult> Index()
        {
            return View(await _placeRepository.GetAllAsync(12));
        }

        //public async Task<IActionResult> LoadMore(int skip)
        //{
        //    //var places = await _context.Places
        //    //    .Include(p => p.Address)
        //    //    .ThenInclude(p => p.Country)
        //    //    .Include(p => p.Category)
        //    //    .Skip(7)
        //    //    .Take(6)
        //    //    .ToArrayAsync();

        //    //skip
        //    var places = await _placeService.GetAllAsync(3, 3);

        //    var placesDto = AutoMapper.Mapper.Map(places, new List<PlaceDto>());

        //    var jsonSettings = new JsonSerializerSettings
        //    {
        //        Formatting = Formatting.Indented,
        //        //ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        //        PreserveReferencesHandling = PreserveReferencesHandling.Objects
        //    };
        //    return Content(JsonConvert.SerializeObject(places, jsonSettings));
        //}

        //public IActionResult Foo()
        //{
        //    var aaa = new { Id = 1, Name = "Foo" };

        //    return Content(JsonConvert.SerializeObject(aaa));
        //}


        //public async Task<IActionResult> Search(string q)
        //{
        //    var places = await _context.Places
        //        .Include(p => p.Address)
        //        .ThenInclude(p => p.Country)
        //        .Include(p => p.Category)
        //        .ToListAsync();

        //    var list = places.Where(x => x.Address.City == q);

        //    return View(list);
        //}

        //// GET: Places/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var place = await _context.Places
        //        .Include(p => p.Address)
        //        .Include(p => p.Category)
        //        .FirstOrDefaultAsync(m => m.PlaceId == id);
        //    if (place == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(place);
        //}

        //// GET: Places/Create
        //public IActionResult Create()
        //{
        //    ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId");
        //    ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
        //    return View();
        //}

        //// POST: Places/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("PlaceId,Name,Description,ThumbnailFileName,AddressId,CategoryId")] Place place)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(place);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId", place.AddressId);
        //    ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", place.CategoryId);
        //    return View(place);
        //}

        //// GET: Places/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var place = await _context.Places.FindAsync(id);
        //    if (place == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId", place.AddressId);
        //    ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", place.CategoryId);
        //    return View(place);
        //}

        //// POST: Places/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("PlaceId,Name,Description,ThumbnailFileName,AddressId,CategoryId")] Place place)
        //{
        //    if (id != place.PlaceId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(place);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PlaceExists(place.PlaceId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId", place.AddressId);
        //    ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", place.CategoryId);
        //    return View(place);
        //}

        //// GET: Places/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var place = await _context.Places
        //        .Include(p => p.Address)
        //        .Include(p => p.Category)
        //        .FirstOrDefaultAsync(m => m.PlaceId == id);
        //    if (place == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(place);
        //}

        //// POST: Places/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var place = await _context.Places.FindAsync(id);
        //    _context.Places.Remove(place);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool PlaceExists(int id)
        //{
        //    return _context.Places.Any(e => e.PlaceId == id);
        //}
    }
}
