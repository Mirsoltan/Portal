using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.HISEntities.PharmacyEntity
{
    public  class Prescription
    {
        [Key]
        public int PrescriptionId { get; set; }
        public int PatientID { get; set; }
        public int PharmacyId { get; set; }
        public int? InsurerID { get; set; }
        public DateTime PrescDate { get; set; }
        //public enum PhysicianFee { get; set; }
        //public double TotalPrice { get; set; }
        public double InsuranceShare { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        //public string CreatedBy { get; set; }
        //public string ApprovedBy { get; set; }
        //public DateTime? PrescDate { get; set; }
        public string InsNumber { get; set; }
        public string PageNo { get; set; }
        public int LocationID { get; set; }
    }
}
