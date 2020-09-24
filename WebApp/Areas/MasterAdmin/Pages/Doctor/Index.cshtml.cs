using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data;
using Entities.HISEntities.PractitionerEntity;
using Data.UnitOfWork;

namespace WebApp.Areas.MasterAdmin.Pages.Doctor
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _uw;

        public IndexModel(IUnitOfWork uw)
        {
            _uw = uw;
        }

        public IList<Doctors> DoctorsList { get; set; }

        public async Task OnGetAsync()
        {
            DoctorsList = (IList<Doctors>)await _uw.BaseRepository<Doctors>().FindAllAsync();
        }
    }
}
