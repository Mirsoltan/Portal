using Data.UnitOfWork;
using Entities.HISEntities.PatientEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.HIS;

namespace Data.HIS.Repositories
{
    public class AdmissionReposotories
    {
        private readonly IUnitOfWork _uw;
        private readonly PortalDbContext _context;

        public AdmissionReposotories(IUnitOfWork uw, PortalDbContext context)
        {
            _uw = uw;
            _context = context;
        }

        public List<AdmissionViewModel> GetClinicAdmisions
            (string firstname = "", string lastname = "", int? pracid = null, DateTime? datein = null, DateTime? dateout = null,
            int? userid = null, int? locationid = null, int? admitstatus = null)

        {
            List<Admission> viewmodel = new List<Admission>();

            firstname = String.IsNullOrEmpty(firstname) ? "" : firstname;
            lastname = String.IsNullOrEmpty(lastname) ? "" : lastname;

            var model = _context.Admissions.Include(a => a.Doctors)
                .Include(a => a.Locations).Include(a => a.Patients)
                .Include(a => a.Practitioners).Include(a => a.Users)
                .Where(w => w.Patients.FirstName.Contains(firstname.TrimStart().TrimEnd())
                && w.Patients.LastName.Contains(lastname.Trim())
                && w.LocationID == locationid
                )
                .Select(x => new AdmissionViewModel
                {
                    AdmissionID = x.AdmissionID,
                    AdmissionStatus = x.AdmissionStatus,
                    AdmissionType = x.AdmissionType,
                    DateIn = x.DateIn,
                    DateOut = (DateTime)x.DateOut,
                    Description = x.Description,
                    DoctorID = x.DoctorID,
                    Doctors = x.Doctors.LastName + ' ' + x.Doctors.FirstName + ':' + x.Doctors.RegisterationNo,
                    FirstName = x.Patients.FirstName,
                    LastName = x.Patients.LastName,
                    PatientID = x.PatientID,
                    Locations = x.Locations.LocationName,
                    LocationID = x.LocationID,
                    PractitionerID = x.PractitionerID,
                    Practitioners = x.Practitioners.LastName + ' ' + x.Practitioners.FirstName + ':' + x.Practitioners.RegisterationNo,
                    Users = x.Users.LastName + ' ' + x.Users.FirstName,
                    UserID = x.UserID,
                }).ToList();

            return model;
        }
    }
}
