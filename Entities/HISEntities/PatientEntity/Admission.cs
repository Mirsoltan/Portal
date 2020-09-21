using Entities.BaseEntities;
using Entities.HISEntities.PractitionerEntity;
using Entities.identity;
using Entities.LocationsEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace Entities.HISEntities.PatientEntity
{
    /// <summary>
    /// جدول پذیرش بیماران
    /// </summary>
    public class Admission : BaseEntity
    {
        [Key]
        public int AdmissionID { get; set; }
        public AdmissionType AdmissionType { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime? DateOut { get; set; }

        public AdmissionStatus AdmissionStatus { get; set; }


        public int UserID { get; set; }
        /// <summary>
        /// کاربر پذیرش کننده از جدول کاربران میخواند
        /// </summary>
        public User  Users { get; set; }


        public int PractitionerID { get; set; }
        /// <summary>
        /// پزشک انجام دهنده ارجاع به جدول کاربران دارد.
        /// </summary>
        public User Practitioners { get; set; }


        public int PatientID { get; set; }
        /// <summary>
        /// بیمار
        /// </summary>
        public Patient Patients { get; set; }

        public int LocationID { get; set; }
        /// <summary>
        /// محل انجام
        /// </summary>
        public Locations Locations { get; set; }

        public int DoctorID { get; set; }
        /// <summary>
        /// پزشک درخواست کننده از جدول Doctors
        /// </summary>
        public Doctors Doctors { get; set; }

    }

    /// <summary>
    /// نوع پذیرش
    /// سرپایی =1 
    /// بستری = 2
    /// انتقالی = 3
    /// اورژانسی = 4
    /// </summary>
    public enum AdmissionType
    {
        [Display(Name ="سرپایی")]
        OutPatient=1,
        [Display(Name = "بستری")]
        InPatient =2,
        [Display(Name = "انتقالی")]
        Transfer =3,
        [Display(Name = "اورژانسی")]
        EMG =4
    }

    /// <summary>
    /// وضعیت مراجعه
    /// در حال پذیرش = 1
    /// پذیرش شده = 2
    /// آماده ترخیص = 3
    /// مرخص = 4
    /// لغو شده = 5
    /// فوت = 10
    /// </summary>
    public enum AdmissionStatus
    {
        [Display(Name = "در حال پذیرش")]
        PreAdmit = 1,
        [Display(Name = "پذیرش شده")]
        Admit = 2,
        [Display(Name = "آماده ترخیص")]
        PreDischarge = 3,
        [Display(Name = "مرخص")]
        Discharge = 4,
        [Display(Name = "لغو شده")]
        Cancel = 5,
        [Display(Name = "فوت")]
        Dead = 10,

    }

}
