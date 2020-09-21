using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Entities.HelpDesk;

namespace WebApp.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class RequestWardsController : Controller
    {
        private readonly PortalDbContext _context;

        public RequestWardsController(PortalDbContext context)
        {
            _context = context;
        }

        // GET: UserPanel/RequestWards
        public async Task<IActionResult> Index()
        {
            var portalDbContext = _context.RequestWard.Include(r => r.DemanderWard).Include(r => r.RecepterWard);
            return View(await portalDbContext.ToListAsync());
        }

        // GET: UserPanel/RequestWards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestWard = await _context.RequestWard
                .Include(r => r.DemanderWard)
                .Include(r => r.RecepterWard)
                .FirstOrDefaultAsync(m => m.RequestWardID == id);
            if (requestWard == null)
            {
                return NotFound();
            }

            return View(requestWard);
        }

        // GET: UserPanel/RequestWards/Create
        public IActionResult Create()
        {
            ViewData["DemanderWardID"] = new SelectList(_context.Locations, "LocationID", "LocationName");
            ViewData["RecepterWardID"] = new SelectList(_context.Locations, "LocationID", "LocationName");
            //ViewData["RecepterWardID"] = new SelectList(RequestPriorityType., "LocationID", "LocationName");

            return View();
        }

        // POST: UserPanel/RequestWards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestWardID,Title,Description,RequestStatusType,RequestPriorityType,DemanderWardID,RecepterWardID,ParentRequestWardID,IsRefered")] RequestWard requestWard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requestWard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DemanderWardID"] = new SelectList(_context.Locations, "LocationID", "LocationName", requestWard.DemanderWardID);
            ViewData["RecepterWardID"] = new SelectList(_context.Locations, "LocationID", "LocationName", requestWard.RecepterWardID);
            return View(requestWard);
        }

        // GET: UserPanel/RequestWards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestWard = await _context.RequestWard.FindAsync(id);
            if (requestWard == null)
            {
                return NotFound();
            }
            ViewData["DemanderWardID"] = new SelectList(_context.Locations, "LocationID", "LocationName", requestWard.DemanderWardID);
            ViewData["RecepterWardID"] = new SelectList(_context.Locations, "LocationID", "LocationName", requestWard.RecepterWardID);
            return View(requestWard);
        }

        // POST: UserPanel/RequestWards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestWardID,Title,Description,RequestStatusType,RequestPriorityType,DemanderWardID,RecepterWardID,ParentRequestWardID,IsRefered")] RequestWard requestWard)
        {
            if (id != requestWard.RequestWardID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requestWard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestWardExists(requestWard.RequestWardID))
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
            ViewData["DemanderWardID"] = new SelectList(_context.Locations, "LocationID", "LocationName", requestWard.DemanderWardID);
            ViewData["RecepterWardID"] = new SelectList(_context.Locations, "LocationID", "LocationName", requestWard.RecepterWardID);
            return View(requestWard);
        }

        // GET: UserPanel/RequestWards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestWard = await _context.RequestWard
                .Include(r => r.DemanderWard)
                .Include(r => r.RecepterWard)
                .FirstOrDefaultAsync(m => m.RequestWardID == id);
            if (requestWard == null)
            {
                return NotFound();
            }

            return View(requestWard);
        }

        // POST: UserPanel/RequestWards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requestWard = await _context.RequestWard.FindAsync(id);
            _context.RequestWard.Remove(requestWard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestWardExists(int id)
        {
            return _context.RequestWard.Any(e => e.RequestWardID == id);
        }
    }
}
