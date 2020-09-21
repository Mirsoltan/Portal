using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Entities.HISEntities.PatientEntity;
using Data.UnitOfWork;
using System.Runtime.InteropServices.WindowsRuntime;
using Entities.Person;

namespace WebApp.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class PatientsController : Controller
    {
        private readonly IUnitOfWork _context;

        public PatientsController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: UserPanel/Patients
        public async Task<IActionResult> Index()
        {
            return View(await _context.BaseRepository<Patient>().FindAllAsync());
        }

        // GET: UserPanel/Patients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.BaseRepository<Patient>().FindByIdAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return PartialView(patient);
        }

        public async Task<IActionResult> DetailsByNationalCode(string strNationalCode)
        {
            if (strNationalCode == null)
            {
                return NotFound();
            }

            var patient = await _context.BaseRepository<Patient>().FindByConditionAsync(w=>w.NationalCode == strNationalCode);

            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // GET: UserPanel/Patients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserPanel/Patients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                Patient pt = new Patient
                {
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    FatherName = patient.FatherName,
                    BirthDate = (DateTime)patient.BirthDate,
                    BirthPlace = patient.BirthPlace,
                    Address = patient.Address,
                    HomeTel = patient.HomeTel,
                    MaritalStatus = patient.MaritalStatus,
                    Mobile = patient.Mobile,
                    NationalCode = patient.NationalCode,
                    TelNo1 = patient.TelNo1,
                    Description = patient.Description,
                    Gender = patient.Gender,
                };
                await _context.BaseRepository<Patient>().CreateAsync(pt);
                await _context.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        // GET: UserPanel/Patients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.BaseRepository<Patient>().FindByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        // POST: UserPanel/Patients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PatientID,NationalCode,FirstName,LastName,FatherName,BirthDate,BirthPlace,Gender,Address,HomeTel,TelNo1,Mobile,MaritalStatus,EducationLevel,Description,RowVersion")] Patient patient)
        {
            if (id != patient.PatientID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.BaseRepository<Patient>().Update(patient);

                    await _context.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.PatientID))
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
            return View(patient);
        }

        // GET: UserPanel/Patients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ////var patient = await _context.BaseRepository<Patient>().
            ////    .FirstOrDefaultAsync(m => m.PatientID == id);
            //if (patient == null)
            //{
            //    return NotFound();
            //}

            return View();
        }

        // POST: UserPanel/Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var patient = await _context.Patients.FindAsync(id);
            //_context.Patients.Remove(patient);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(int id)
        {
            return (_context.BaseRepository<Patient>().FindByIdAsync(id) != null);
        }


        private bool PatientExists(string strNationalCode)
        {
            if (string.IsNullOrEmpty(strNationalCode))
            {
                return false;
            }

            return (_context.BaseRepository<Patient>().FindByConditionAsync(w => w.NationalCode == strNationalCode) != null);
        }

        public async Task<JsonResult> FindePatientByNationalCode(string strNationalCode)
        {
            var pt = await _context.BaseRepository<Patient>().FindByConditionAsync(w => w.NationalCode == strNationalCode);
            if (pt != null)
            {

                return Json(pt.Select(x=> new PersonFullName { PersonID = x.PatientID , FullName = x.FirstName + ' ' + x.LastName }).FirstOrDefault());
            }
            else
            {
                return null;
            }

        }

    }
}
