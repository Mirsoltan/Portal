using Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.HISEntities.PatientEntity
{
    public class PatientRecord : BaseEntity
    {
        [Key]
        public int PatientRecordID { get; set; }
        public Patient Patient { get; set; }
    }
}
