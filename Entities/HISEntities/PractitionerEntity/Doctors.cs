using Entities.BaseEntities;
using Entities.HISEntities.PatientEntity;
using Entities.identity;
using Entities.Person;
using Entities.PersonEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.HISEntities.PractitionerEntity
{
    /// <summary>
    /// پزشکان خارج از مجموعه / پزشکان درخواست کننده خدمت
    /// </summary>
    public class Doctors : IPersonBaseEntitiy
    {
        [Key]
        public int DoctorsID { get; set; }

        public PractitionerSpeciality PractitionerSpeciality { get; set; }
        public PractitionerJobCategory PractitionerJobCategory { get; set; }

        //public bool? IsPreferred { get; set; }
        //public bool? IsfullTime { get; set; }

        public List<Admission> Admissions { get; set; }

        // Like that User class Entity
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public GenderType Gender { get; set; }


        [NotMapped]
        public DateTime BirthDate { get; set; }
        [NotMapped]
        public string Image { get; set; }
        [NotMapped]
        public DateTime? RegisterDateTime { get; set; }
        [NotMapped]
        public EducationLevel EducationLevel { get; set; }
        [Required]
        public string RegisterationNo { get; set; }
        [NotMapped]
        public string NationalCode { get ; set ; }
        [NotMapped]
        public string FatherName { get ; set ; }
        [NotMapped]
        public string BirthPlace { get ; set ; }
        [NotMapped]
        public string Address { get ; set ; }
        [NotMapped]
        public string HomeTel { get ; set ; }
        [NotMapped]
        public string TelNo1 { get ; set ; }
        [NotMapped]
        public string Mobile { get ; set ; }
        [NotMapped]
        public MaritalStatus MaritalStatus { get ; set ; }
    }

    public enum PractitionerSpeciality
    {
        [Display(Name = ("عمومی"))]
        General = 1,
        [Display(Name = "متخصص")]
        Skilled = 2,
        [Display(Name = "فلوشیپ")]
        Felo = 3,
        [Display(Name = "فوق تخصص")]
        PHD = 4,
    }

    public enum PractitionerJobCategory
    {
        [Display(Name = ("داخلی"))]
        Internist=1,
        [Display(Name = ("جراحی"))]
        Surgon=2,
        [Display(Name = ("بیهوشی"))]
        Anest=3,
    }


}
