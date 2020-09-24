using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Entities.LocationsEntities;
using Data.Repositories;
using ViewModels.Location;
using WebApp.Areas.UserPanel.Models;
using Data.UnitOfWork;

namespace WebApp.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class LocationsController : Controller
    {
        private readonly IUnitOfWork _uw;
        public LocationsController(IUnitOfWork uw)
        {

            _uw = uw;
        }

        // GET: UserPanel/Locations
        public async Task<IActionResult> Index()
        {
            //var portalDbContext = _context.Locations.Include(l => l.location);
            //return View(await portalDbContext.ToListAsync());
            //var Locations = await (from c in _context.Locations
            //                  where (c.ParentLocationID == null)
            //                  select new TreeViewLocation
            //                  { LocationID = c.LocationID, LocationName = c.LocationName }).ToListAsync();

            //foreach (var item in Locations)
            //{
            //    _repository.BindSubCategories(item);
            //}
            HomeViewModel ViewModel = new HomeViewModel(_uw.ILocationRepository.GetLocations());

            return View(ViewModel);
        }

        // GET: UserPanel/Locations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var location = await _uw.BaseRepository<Locations>().FindByConditionAsync(i=>i.LocationID==id,o=>o.OrderBy(l=>l.LocationName),l=>l.LocationS);
            var location =await  _uw.BaseRepository<Locations>().FindByIdAsync(id);
            //.FindByConditionAsync(i => i.LocationID == id).Result
            //  .Select(x => new Locations
            //  {
            //      IconAddress = x.IconAddress,
            //      LocationID = x.LocationID,
            //      LocationName = x.LocationName,
            //      ParentLocationID = x.ParentLocationID
            //  });
            //.FindByConditionAsync(includes:"location")
            //.Include(l => l.location)
            //.FirstOrDefaultAsync(m => m.LocationID == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // GET: UserPanel/Locations/Create
        public async Task<IActionResult> Create()
        {
            ViewData["ParentLocationID"] = new SelectList(await _uw.BaseRepository<Locations>().FindAllAsync(), "LocationID", "LocationName");
            return View();
        }

        // POST: UserPanel/Locations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationID,LocationName,ParentLocationID")] Locations location)
        {
            if (ModelState.IsValid)
            {
                await _uw.BaseRepository<Locations>().CreateAsync(location);
                await _uw.Commit();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParentLocationID"] = new SelectList(await _uw.BaseRepository<Locations>().FindAllAsync(), "LocationID", "LocationName", location.ParentLocationID);
            return View(location);
        }

        // GET: UserPanel/Locations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _uw.BaseRepository<Locations>().FindByIdAsync(id);
            if (location == null)
            {
                return NotFound();
            }
            ViewData["ParentLocationID"] = new SelectList(await _uw.BaseRepository<Locations>().FindAllAsync(), "LocationID", "LocationName", location.ParentLocationID);
            return View(location);
        }

        // POST: UserPanel/Locations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocationID,LocationName,ParentLocationID")] Locations location)
        {
            if (id != location.LocationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uw.BaseRepository<Locations>().Update(location);
                    await _uw.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationExists(location.LocationID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParentLocationID"] = new SelectList(await _uw.BaseRepository<Locations>().FindAllAsync(), "LocationID", "LocationName", location.ParentLocationID);
            return View(location);
        }

        // GET: UserPanel/Locations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _uw.BaseRepository<Locations>().FindByIdAsync(id);
            //    .Include(l => l.location)
            //    .FirstOrDefaultAsync(m => m.LocationID == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // POST: UserPanel/Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var location = await _context.Locations.FindAsync(id);
            //_context.Locations.Remove(location);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationExists(int id)
        {
            return (_uw.BaseRepository<Locations>().FindByIdAsync(id) != null);
        }
    }
}
