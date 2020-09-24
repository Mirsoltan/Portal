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
    public class DetailsModel : PageModel
    {
        private readonly Data.PortalDbContext _context;

        public DetailsModel(Data.PortalDbContext context)
        {
            _context = context;
        }

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
    }
}
