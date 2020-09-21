using Data.UnitOfWork;
using Entities.HISEntities.PatientEntity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.HIS
{
    public class PatientInfo
    {
        private readonly IUnitOfWork _uw;
        public PatientInfo(IUnitOfWork uw)
        {
            _uw = uw;
        }

        public async Task<Patient> GetPatientInfo(string stringNationalCode)
        {
            if (stringNationalCode==null)
            {
                
            }

            try
            {
                var pt = await _uw.BaseRepository<Patient>().FindByConditionAsync(w => w.NationalCode == stringNationalCode);
                if (pt!=null)
                {
                    var ptinfo = pt.Select(x => new Patient
                    {
                        Address = x.Address,
                        BirthDate = x.BirthDate,
                        EducationLevel = x.EducationLevel,
                        FatherName = x.FatherName,
                        Gender = x.Gender,
                        Mobile = x.Mobile,
                        BirthPlace = x.BirthPlace,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        MaritalStatus = x.MaritalStatus,
                        HomeTel = x.HomeTel,
                        NationalCode = x.NationalCode,
                        PatientID = x.PatientID,
                        TelNo1 = x.TelNo1,
                        Description = x.Description,
                    });
                    return ptinfo.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                var address = ex.ToString();
                var data = ex.GetType();
                throw;
            }
            return null;
        }
    }
}
