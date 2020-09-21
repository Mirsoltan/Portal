using Entities.HISEntities.PatientEntity;
using Entities.Person;
using Entities.PersonEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.identity
{
    public class User : IdentityUser<int>, IPersonBaseEntitiy
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Image { get; set; }
        public DateTime? RegisterDateTime { get; set; }
        public bool IsActive { get; set; }
        public string Bio { get; set; }
        public virtual ICollection<UserRole> Roles { get; set; }
        public virtual ICollection<UserClaim> Claims { get; set; }
        public string NationalCode { get; set; }
        public string FatherName { get; set; }
        public string BirthPlace { get; set; }
        public string Address { get; set; }
        public string HomeTel { get; set; }
        public string TelNo1 { get; set; }
        public string Mobile { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public GenderType Gender { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public AssistType AssistType { get; set; }
        public string RegisterationNo { get; set; }

        /// <summary>
        /// کاربر پذیرش کننده
        /// </summary>
        public List<Admission> AdmissionUsers { get; set; }

        /// <summary>
        /// پزشک انجام دهنده
        /// </summary>
        public List<Admission> Practitioners { get; set; }

    }


}
