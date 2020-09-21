using Entities.HISEntities.PatientEntity;
using Entities.identity;
using Entities.LocationsEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ViewModels.CommonViewModels;

namespace ViewModels.HIS
{

    public class AdmissionCreateViewModel
    {

        [Display(Name = "شناسه پذیرش")]
        public int AdmissionID { get; set; }
        
        [Display(Name = "کد ملی")]
        public string NationalCode { get; set; }
        [Display(Name = "نام و نام خانوادگی بیمار")]
        public string FullName { get; set; }

        [Display(Name = "تاریخ مراجعه")]
        public DateTime DateIn { get; set; }

        /// <summary>
        /// پزشک انجام دهنده
        /// </summary>
        [Display(Name ="پزشک انجام دهنده")]
        public int PractitionerID { get; set; }

        [Display(Name = "کد بیمار")]
        public int PatientID { get; set; }
        [Display(Name = "مکان مراجعه")]
        public int LocationID { get; set; }

        [Display(Name = "پزشک درخواست کننده")]
        public int DoctorID { get; set; }

        [Display(Name =("توضیحات"))]
        public string Description { get; set; }
    }
    public class AdmissionViewModel : CommonViewmodel
    {
        [Display(Name = "شناسه پذیرش")]
        public int AdmissionID { get; set; }

        [Display(Name = "نوع پذیرش")]
        public AdmissionType? AdmissionType { get; set; }
        [Display(Name = "تاریخ مراجعه")]
        public DateTime DateIn { get; set; }
        [Display(Name = "تاریخ ترخیص")]
        public DateTime DateOut { get; set; }

        [Display(Name = "وضعیت مراجعه")]
        public AdmissionStatus AdmissionStatus { get; set; }


        [Display(Name = "پذیرش کننده")]
        public int UserID { get; set; }
        /// <summary>
        /// کاربر پذیرش کننده از جدول کاربران میخواند
        /// </summary>
        [Display(Name ="کاربر")]
        public string Users { get; set; }


        [Display(Name = "ش. انجام دهنده")]
        public int PractitionerID { get; set; }
        /// <summary>
        /// پزشک انجام دهنده ارجاع به جدول کاربران دارد.
        /// </summary>
        [Display(Name = "پزشک انجام دهنده")]
        public string Practitioners { get; set; }

        [Display(Name = "کد بیمار")]
        public int PatientID { get; set; }
        /// <summary>
        /// بیمار
        /// </summary>
        [Display(Name = "نام بیمار")]
        public string FirstName { get; set; }
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }

        [Display(Name = "شناسه مکان")]
        public int LocationID { get; set; }
        /// <summary>
        /// محل انجام
        /// </summary>
        [Display(Name = "نام مکان")]
        public string Locations { get; set; }

        [Display(Name = "ش درخواست کننده")]
        public int DoctorID { get; set; }
        /// <summary>
        /// پزشک درخواست کننده از جدول Doctors
        /// </summary>
        [Display(Name = "پزشک درخواست کننده")]
        public string Doctors { get; set; }


    }
}
