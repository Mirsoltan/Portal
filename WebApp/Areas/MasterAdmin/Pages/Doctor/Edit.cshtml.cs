using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Entities.HISEntities.PractitionerEntity;
using Data.UnitOfWork;

namespace WebApp.Areas.MasterAdmin.Pages.Doctor
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _uw;

        public EditModel(IUnitOfWork uw)
        {
            _uw = _uw;
        }

        [BindProperty]
        public Doctors DoctoList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DoctoList = await _uw.BaseRepository<Doctors>().FindByIdAsync(id);

            if (DoctoList == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            
            //_context.Attach(DoctoList).State = EntityState.Modified;

            try
            {
                //await _context.SaveChangesAsync();
                 _uw.BaseRepository<Doctors>().Update(DoctoList);
                await _uw.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorsExists(DoctoList.DoctorsID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DoctorsExists(int id)
        {
            return (_uw.BaseRepository<Doctors>().FindByIdAsync(id)!=null);
        }
    }
}
