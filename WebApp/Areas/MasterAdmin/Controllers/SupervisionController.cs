using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Entities.SupervisionEntities;

namespace WebApp.Areas.MasterAdmin.Controllers
{
    [Area("MasterAdmin")]
    public class SupervisionController : Controller
    {
        private readonly PortalDbContext _context;

        public SupervisionController(PortalDbContext context)
        {
            _context = context;
        }

        // GET: MasterAdmin/Supervision
        public async Task<IActionResult> Index()
        {
            return View(await _context.Supervisions.ToListAsync());
        }

        // GET: MasterAdmin/Supervision/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supervisionEntity = await _context.Supervisions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supervisionEntity == null)
            {
                return NotFound();
            }

            return View(supervisionEntity);
        }

        // GET: MasterAdmin/Supervision/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MasterAdmin/Supervision/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Code,Detailes,Id,Description,InsertBy,InsertDate,UpdateBy,UpdateDate,DeleteBy,DeleteDate,IsActive")] SupervisionEntity supervisionEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supervisionEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supervisionEntity);
        }

        // GET: MasterAdmin/Supervision/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supervisionEntity = await _context.Supervisions.FindAsync(id);
            if (supervisionEntity == null)
            {
                return NotFound();
            }
            return View(supervisionEntity);
        }

        // POST: MasterAdmin/Supervision/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Code,Detailes,Id,Description,InsertBy,InsertDate,UpdateBy,UpdateDate,DeleteBy,DeleteDate,IsActive")] SupervisionEntity supervisionEntity)
        {
            if (id != supervisionEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supervisionEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupervisionEntityExists(supervisionEntity.Id))
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
            return View(supervisionEntity);
        }

        // GET: MasterAdmin/Supervision/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supervisionEntity = await _context.Supervisions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supervisionEntity == null)
            {
                return NotFound();
            }

            return View(supervisionEntity);
        }

        // POST: MasterAdmin/Supervision/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supervisionEntity = await _context.Supervisions.FindAsync(id);
            _context.Supervisions.Remove(supervisionEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupervisionEntityExists(int id)
        {
            return _context.Supervisions.Any(e => e.Id == id);
        }
    }
}
