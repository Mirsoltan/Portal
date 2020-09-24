using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data;
using Entities.HISEntities.PractitionerEntity;

namespace WebApp.Areas.MasterAdmin.Pages.Doctor
{
    public class DeleteModel : PageModel
    {
        private readonly Data.PortalDbContext _context;

        public DeleteModel(Data.PortalDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Doctors Doctors { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Doctors = await _context.Doctors.FirstOrDefaultAsync(m => m.DoctorsID == id);

            if (Doctors == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Doctors = await _context.Doctors.FindAsync(id);

            if (Doctors != null)
            {
                _context.Doctors.Remove(Doctors);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
