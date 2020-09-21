using Entities.BaseEntities;
using Entities.PersonEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Person
{
    public class PersonBaseEntity : BaseEntity, IPersonBaseEntitiy
    {
        //public DegreeType DegreeType { get; set; }
        public string NationalCode { get; set; }
        [Required,MinLength(3)]
        public string FirstName { get; set; }
        [Required, MinLength(3)]
        public string LastName { get; set; }
        [Required, MinLength(3)]
        public string FatherName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required,MinLength(3)]
        public string BirthPlace { get; set; }
        public GenderType Gender { get; set; }
        public string Address { get; set; }
        public string HomeTel { get; set; }
        public string TelNo1 { get; set; }
        [Required, MinLength(3)]
        public string Mobile { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public EducationLevel EducationLevel { get; set; }
    }

    public class PersonFullName
    {
        public int PersonID { get; set; }
        public string FullName { get; set; }

    }
    public enum GenderType
    {
        Male = 1,
        Female = 2,
        [Display(Name = "دو جنسیتی / نامشخص")]
        UnkNown = 3,
        [Display(Name = "تعیین نشده")]
        UnDefined = 9,
    }
    /// <summary>
    /// وضعیت تاهل
    /// </summary>

    public enum MaritalStatus
    {
        [Display(Name = "طلاق")]
        Divorce = 1,
        [Display(Name = "متاهل")]
        Married = 2,
        [Display(Name = "مجرد")]
        UnMarried = 3,
        [Display(Name = "همسر فوت شده")]
        Lone = 4,
    }
    /// <summary>
    /// نوع همکاری
    /// </summary>
    public enum AssistType
    {
        [Display(Name = "کارمند")]
        Person = 1,
        [Display(Name = "پزشک")]
        Practitioner = 2,
        [Display(Name = "تکنسین و پرستار")]
        Nurse = 3,
        Phisio = 4,
        Lab = 5,
        Imaging = 6
    }
    public enum EducationLevel
    {
        [Display(Name = "بی سواد")]
        Bisavad = 1,
        [Display(Name = "ابتدایی")]
        Entedaei = 2,
        [Display(Name = "راهنمایی")]
        Rahnamaei = 3,
        [Display(Name = "متوسطه")]
        Motevaseteh = 4,
        [Display(Name = "دیپلم")]
        Diplom = 5,
        [Display(Name = "دانشجوی کاردانی")]
        KardaniStudent = 100,
        [Display(Name = "کاردانی")]
        Kardani = 101,
        [Display(Name = "دانشجوی کارشناسی")]
        LicenceStudent = 110,
        [Display(Name = "کارشناسی")]
        Licence = 111,
        [Display(Name = "دانشجوی کارشناسی ارشد")]
        ArshadStudent = 140,
        [Display(Name = "کارشناسی ارشد")]
        Arshad = 131,
        [Display(Name = "دانشجوی دکترای حرفه ای")]
        DoctorStudent = 150,
        [Display(Name = "دکترای حرفه ای")]
        Doctor = 151,
        [Display(Name = "دانشجوی تخصص")]
        BoardStudent = 170,
        [Display(Name = "تخصص")]
        Board = 171,
        [Display(Name = "دانشجوی فوق تخصص")]
        FoghStudent = 200,
        [Display(Name = "فوق تخصص")]
        Fogh = 201,
        [Display(Name = "دانشجوی فلوشیپ")]
        FeloshipStudent = 210,
        [Display(Name = "فلوشیپ")]
        Feloship = 211,
        [Display(Name = "دانشجوی دکتری تخصصی")]
        PHDStudent = 190,
        [Display(Name = "دکترای تخصصی")]
        PHD = 191
    }

    public enum PersonJob
    {
        [Display(Name = "بیکار")]
        Unemployed = 0000,
        [Display(Name = "از کار افتاده")]
        Sear = 9999,
        [Display(Name = "آزاد")]
        Free = 9997,
        [Display(Name = "پزشک")]
        Physician = 2038,
        [Display(Name = "دام پزشک")]
        Vet = 9007,

        [Display(Name = "خانه دار")]
        Housekeeper = 9996,
        [Display(Name = "نظامی و سرباز")]
        Martial = 510,
        [Display(Name = "بازنسشته")]
        Pensionary = 9998,
        [Display(Name = "محصل")]
        Student = 9995,
    }
}
