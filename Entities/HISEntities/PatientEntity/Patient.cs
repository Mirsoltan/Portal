using Entities.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.HISEntities.PatientEntity
{
    public class Patient : PersonBaseEntity

    {
        [Key]
        public int PatientID { get; set; }

        public List<Admission>  Admissions { get; set; }
    }
}
