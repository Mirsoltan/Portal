using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Data;
using Entities.HISEntities.PractitionerEntity;
using Data.UnitOfWork;

namespace WebApp.Areas.MasterAdmin.Pages.Doctor
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _uw;

        public CreateModel(IUnitOfWork uw)
        {
            _uw = uw;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Doctors DoctorModels { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Doctors.Add(Doctors);
            //await _context.SaveChangesAsync();

            await _uw.BaseRepository<Doctors>().CreateAsync(DoctorModels);
            await _uw.Commit();

            return RedirectToPage("./Index");
        }
    }
}
