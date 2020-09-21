using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Entities.HISEntities.PractitionerEntity;

namespace WebApp.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class DoctorsController : Controller
    {
        private readonly PortalDbContext _context;

        public DoctorsController(PortalDbContext context)
        {
            _context = context;
        }

        // GET: UserPanel/Doctors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Doctors.ToListAsync());
        }

        // GET: UserPanel/Doctors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctors = await _context.Doctors
                .FirstOrDefaultAsync(m => m.DoctorsID == id);
            if (doctors == null)
            {
                return NotFound();
            }

            return View(doctors);
        }

        // GET: UserPanel/Doctors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserPanel/Doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Doctors doctors)
        {
            if (ModelState.IsValid)
            {
                var dc = new Doctors
                {
                    PractitionerJobCategory = doctors.PractitionerJobCategory,
                    FirstName = doctors.FirstName,
                    LastName = doctors.LastName,
                    Gender = doctors.Gender,
                    RegisterationNo = doctors.RegisterationNo,
                };
                _context.Add(doctors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctors);
        }

        // GET: UserPanel/Doctors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctors = await _context.Doctors.FindAsync(id);
            if (doctors == null)
            {
                return NotFound();
            }
            return View(doctors);
        }

        // POST: UserPanel/Doctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DoctorsID,PractitionerSpeciality,PractitionerJobCategory,FirstName,LastName,IsActive,Gender,RegisterationNo")] Doctors doctors)
        {
            if (id != doctors.DoctorsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorsExists(doctors.DoctorsID))
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
            return View(doctors);
        }

        // GET: UserPanel/Doctors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctors = await _context.Doctors
                .FirstOrDefaultAsync(m => m.DoctorsID == id);
            if (doctors == null)
            {
                return NotFound();
            }

            return View(doctors);
        }

        // POST: UserPanel/Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctors = await _context.Doctors.FindAsync(id);
            _context.Doctors.Remove(doctors);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorsExists(int id)
        {
            return _context.Doctors.Any(e => e.DoctorsID == id);
        }
    }
}
