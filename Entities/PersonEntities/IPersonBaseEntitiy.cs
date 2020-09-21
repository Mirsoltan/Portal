using Entities.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.PersonEntities
{
    public interface IPersonBaseEntitiy
    {
        [MaxLength(10)]
        string NationalCode { get; set; }
        [MaxLength(50)]
        string FirstName { get; set; }
        [MaxLength(50)]
        string LastName { get; set; }
        [MaxLength(50)]
        string FatherName { get; set; }
        DateTime BirthDate { get; set; }
        [MaxLength(30)]
        string BirthPlace { get; set; }
        GenderType Gender { get; set; }
        [MaxLength(300)]
        string Address { get; set; }
        [MaxLength(11)]
        string HomeTel { get; set; }
        [MaxLength(11)]
        string TelNo1 { get; set; }
        [MaxLength(11)]
        string Mobile { get; set; }
        MaritalStatus MaritalStatus { get; set; }
        EducationLevel EducationLevel { get; set; }
    }
}
