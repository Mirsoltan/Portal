using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Entities.HISEntities.PatientEntity;
using ViewModels.HIS;
using System.Security.Cryptography.X509Certificates;
using Entities.Person;
using Data.UnitOfWork;
using ReflectionIT.Mvc.Paging;
using Microsoft.AspNetCore.Routing;
using Microsoft.CodeAnalysis;
using Entities.LocationsEntities;
using Data.Repositories;
using Data.HIS.Repositories;

namespace WebApp.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class AdmissionsController : Controller
    {
        private readonly PortalDbContext _context;
        private readonly IUnitOfWork _uw;
        private readonly LocationRepository _locationRepository;
        private readonly AdmissionReposotories _admitRepo;

        public AdmissionsController(PortalDbContext context, IUnitOfWork uw, LocationRepository locationRepository
            , AdmissionReposotories admitRepo)
        {
            _context = context;
            _uw = uw;
            _locationRepository = locationRepository;
            _admitRepo = admitRepo;
        }

        // GET: UserPanel/Admissions
        public async Task<IActionResult> Index(int page = 1, int row = 1000, string sortExpression = "DateIn",
            string firstname = "", string lastname = "", int? pracid = null, DateTime? datein = null, DateTime? dateout = null,
            int? userid = null, int? locationid = null, int? admitstatus = null,string msg="")
        {
            List<int> Rows = new List<int> { 10, 25, 50, 100 };
            ViewBag.RowID = new SelectList(Rows, row);
            ViewBag.NumOfRow = (page - 1) * row + 1;

            if (msg != null)
            {
                ViewBag.Msg = "در ثبت اطلاعات خطایی رخ داده است لطفا مجددا تلاش کنید !!!";
            }

            firstname = String.IsNullOrEmpty(firstname) ? "" : firstname;
            lastname = String.IsNullOrEmpty(lastname) ? "" : lastname;

            //ViewBag.Search = (firstname.Length > 0 || lastname.Length > 0 || pracid != null || datein != null || dateout != null || userid != null || locationid != null || admitstatus != null ? true : false);
            ViewBag.Search = (firstname != null || lastname != null);
            

            // && w.Patients.LastName.Contains(lastname.TrimStart().TrimEnd()) &&
            //w.PractitionerID == pracid && w.UserID == userid && w.DateIn == datein && w.DateOut == dateout

            //var model = await _context.Admissions.Include(a => a.Doctors)
            //    .Include(a => a.Locations).Include(a => a.Patients)
            //    .Include(a => a.Practitioners).Include(a => a.Users)
            //    .Where(w => w.Patients.FirstName.Contains(firstname.TrimStart().TrimEnd())
            //    && w.Patients.LastName.Contains(lastname.Trim())
            //    && w.LocationID == locationid
            //    )
            //    .Select(x => new AdmissionViewModel
            //    {
            //        AdmissionID = x.AdmissionID,
            //        AdmissionStatus = x.AdmissionStatus,
            //        AdmissionType = x.AdmissionType,
            //        DateIn = x.DateIn,
            //        DateOut = (DateTime)x.DateOut,
            //        Description = x.Description,
            //        DoctorID = x.DoctorID,
            //        Doctors = x.Doctors.LastName + ' ' + x.Doctors.FirstName + ':' + x.Doctors.RegisterationNo,
            //        FirstName = x.Patients.FirstName,
            //        LastName = x.Patients.LastName,
            //        PatientID = x.PatientID,
            //        Locations = x.Locations.LocationName,
            //        LocationID = x.LocationID,
            //        PractitionerID = x.PractitionerID,
            //        Practitioners = x.Practitioners.LastName + ' ' + x.Practitioners.FirstName + ':' + x.Practitioners.RegisterationNo,
            //        Users = x.Users.LastName + ' ' + x.Users.FirstName,
            //        UserID = x.UserID,
            //    }).ToListAsync();

            var model1 = _admitRepo.GetClinicAdmisions(firstname, lastname, pracid, datein, dateout
                , userid, locationid, admitstatus);

            //var pagingmodel = PagingList.Create( model1, row, page, sortExpression, "DateIn");
            var pagingmodel = PagingList.Create( model1, row, page, sortExpression, "DateIn");
            pagingmodel.RouteValue = new RouteValueDictionary
            {
                { "row" , row },
                {"locationid",locationid },
                { "pracid",pracid},
            };


            ViewData["LocationID"] = new SelectList(await _uw.BaseRepository<Locations>().FindAllAsync(), "LocationID", "LocationName");
            ViewData["LocationsComboTree"] = _locationRepository.GetLocations(true);

            ViewData["PractitionerID"] = new SelectList(_context.Users.Where(w => w.AssistType == AssistType.Practitioner)
                            .Select(fl => new PersonFullName { PersonID = fl.Id, FullName = fl.LastName + ' ' + fl.FirstName + ' ' + fl.RegisterationNo }), "FullName", "FullName");

            return View(pagingmodel);
        }

        public async Task<IActionResult> AdvancedSearch()
        {

            return View();
        }
        //public async Task<IActionResult> Index()
        // {
        //     var portalDbContext = _context.Admissions.Include(a => a.Doctors).Include(a => a.Locations).Include(a => a.Patients).Include(a => a.Practitioners).Include(a => a.Users);
        //     return View(await portalDbContext.ToListAsync());
        // }

        // GET: UserPanel/Admissions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admission = await _context.Admissions
                .Include(a => a.Doctors)
                .Include(a => a.Locations)
                .Include(a => a.Patients)
                .Include(a => a.Practitioners)
                .Include(a => a.Users)
                .FirstOrDefaultAsync(m => m.AdmissionID == id);
            if (admission == null)
            {
                return NotFound();
            }

            return View(admission);
        }

        // GET: UserPanel/Admissions/Create
        public IActionResult Create()
        {
            //ViewData["DoctorID"] = new SelectList(_context.Practitioners, "DoctorsID", "RegisterationNo");
            //ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "LocationName");
            //ViewData["PatientID"] = new SelectList(_context.Patients, "PatientID", "BirthPlace");
            //ViewData["PractitionerID"] = new SelectList(_context.Users, "Id", "Id");
            //ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["DoctorID"] = new SelectList(_context.Doctors.Where(w => w.IsActive == true)
                .Select(fl => new PersonFullName { PersonID = fl.DoctorsID, FullName = fl.LastName + ' ' + fl.FirstName + ' ' + fl.RegisterationNo }), "PersonID", "FullName");
            ViewData["LocationID"] = new SelectList(_uw.BaseRepository<Locations>().FindAll(), "LocationID", "LocationName");//, admission.LocationID);
            //ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "LocationName");//, admission.LocationID);
            //ViewData["PatientID"] = new SelectList(_context.Patients, "PatientID", "BirthPlace")//, admission.PatientID);
            ViewData["PractitionerID"] = new SelectList(_context.Users.Where(w => w.AssistType == AssistType.Practitioner)
                .Select(fl => new PersonFullName { PersonID = fl.Id, FullName = fl.LastName + ' ' + fl.FirstName + ' ' + fl.RegisterationNo }), "PersonID", "FullName");

            return View();
        }

        // POST: UserPanel/Admissions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdmissionCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var admit = new Admission
                    {
                        AdmissionType = AdmissionType.OutPatient,
                        AdmissionStatus = AdmissionStatus.Admit,
                        DateIn = DateTime.Now,
                        Description = "",
                        //Description = model.Description,
                        DoctorID = model.DoctorID,
                        LocationID = model.LocationID,
                        PatientID = model.PatientID,
                        PractitionerID = model.PractitionerID,
                        //UserID = model.UserID,
                        UserID = 1,
                    };
                    _context.Add(admit);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {

                    return RedirectToAction("Index", new { Msg = "Failed" });
                }                
            }
            //ViewData["DoctorID"] = new SelectList(_context.Doctors, "DoctorsID", "RegisterationNo");
            //ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "LocationName");//, admission.LocationID);
            ////ViewData["PatientID"] = new SelectList(_context.Patients, "PatientID", "BirthPlace")//, admission.PatientID);
            //ViewData["PractitionerID"] = new SelectList(_context.Users.Where(w => w.AssistType == AssistType.Practitioner)
            //    .Select(fl => new PersonFullName { PersonID = fl.Id, FullName = fl.LastName + ' ' + fl.FirstName + ' ' + fl.RegisterationNo }), "PersonID", "FullName"); 
            ////, admission.PractitionerID);
            //ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", admission.UserID);
            ///ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["DoctorID"] = new SelectList(_context.Doctors.Where(w => w.IsActive == true)
                .Select(fl => new PersonFullName { PersonID = fl.DoctorsID, FullName = fl.LastName + ' ' + fl.FirstName + ' ' + fl.RegisterationNo }), "PersonID", "FullName");
            ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "LocationName");//, admission.LocationID);
            //ViewData["PatientID"] = new SelectList(_context.Patients, "PatientID", "BirthPlace")//, admission.PatientID);
            ViewData["PractitionerID"] = new SelectList(_context.Users.Where(w => w.AssistType == AssistType.Practitioner)
                .Select(fl => new PersonFullName { PersonID = fl.Id, FullName = fl.LastName + ' ' + fl.FirstName + ' ' + fl.RegisterationNo }), "PersonID", "FullName");

            return View(model);
        }

        // GET: UserPanel/Admissions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admission = await _context.Admissions.FindAsync(id);
            if (admission == null)
            {
                return NotFound();
            }
            ViewData["DoctorID"] = new SelectList(_context.Doctors, "DoctorsID", "RegisterationNo", admission.DoctorID);
            ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "LocationName", admission.LocationID);
            ViewData["PatientID"] = new SelectList(_context.Patients, "PatientID", "BirthPlace", admission.PatientID);
            ViewData["PractitionerID"] = new SelectList(_context.Users, "Id", "Id", admission.PractitionerID);
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", admission.UserID);
            return View(admission);
        }

        // POST: UserPanel/Admissions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdmissionID,AdmissionType,DateIn,DateOut,AdmissionStatus,UserID,PractitionerID,PatientID,LocationID,DoctorID,Description,RowVersion")] Admission admission)
        {
            if (id != admission.AdmissionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdmissionExists(admission.AdmissionID))
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
            ViewData["DoctorID"] = new SelectList(_context.Doctors, "DoctorsID", "RegisterationNo", admission.DoctorID);
            ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "LocationName", admission.LocationID);
            ViewData["PatientID"] = new SelectList(_context.Patients, "PatientID", "BirthPlace", admission.PatientID);
            ViewData["PractitionerID"] = new SelectList(_context.Users, "Id", "Id", admission.PractitionerID);
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", admission.UserID);
            return View(admission);
        }

        // GET: UserPanel/Admissions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admission = await _context.Admissions
                .Include(a => a.Doctors)
                .Include(a => a.Locations)
                .Include(a => a.Patients)
                .Include(a => a.Practitioners)
                .Include(a => a.Users)
                .FirstOrDefaultAsync(m => m.AdmissionID == id);
            if (admission == null)
            {
                return NotFound();
            }

            return View(admission);
        }

        // POST: UserPanel/Admissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var admission = await _context.Admissions.FindAsync(id);
            _context.Admissions.Remove(admission);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdmissionExists(int id)
        {
            return _context.Admissions.Any(e => e.AdmissionID == id);
        }


        public async Task<IActionResult> PatientDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _uw.BaseRepository<Patient>().FindByIdAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return PartialView(patient);
        }
    }
}
