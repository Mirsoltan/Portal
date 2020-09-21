using Entities.HelpDesk;
using Entities.HISEntities.PatientEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.LocationsEntities
{
    public class Locations
    {
        [Key]
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public int? ParentLocationID { get; set; }
        public Locations location { get; set; }
        public List<Locations> LocationS { get; set; }
        public string IconAddress { get; set; }

        public List<RequestWard> DemanderWards { get; set; }
        public List<RequestWard> RecepterWards { get; set; }
        public List<RequestWard> ReferRequestWards { get; set; }

        /// <summary>
        /// جدول پذیرش بیماران
        /// </summary>
        public List<Admission> Admissions { get; set; }

        public BaseLocationType? baseLocationType { get; set; }
        public SecondaryLocationType? SecondaryLocationType { get; set; }
    }

    public enum WardType
    {
        General = 000,
        GeneralVIP = 010,
        Inner = 012,
        SurgenVIP = 014,
        ICUGeneral = 020,
        ICU = 021,
    }

    /// <summary>
    /// درجه ارزشیابی مرکز
    /// </summary>
    public enum LocationDegreeType
    {
        Illustrious = 0,
        First = 1,
        Second = 2,
        Third = 3,
    }

    public enum BaseLocationType
    {
        Hospital = 1,
        Infirmary = 2,
        Ortez = 3,
        Pharmacy = 4,
        Imaging = 5,
        Labratoary = 6,
    }

    public enum SecondaryLocationType
    {
        ward = 100,
        Room = 101,
        Bed = 102,

        Clinic = 200,
        HeartClinic = 201,
        EyeClinic = 202,

        //        Imaging = 500,
        Rad = 501,
        Sono = 502,
        MRI = 503,
        CT = 504,

        Lab = 600,
        BloodBank = 601,

        Phisio = 700,
        Sleeping = 800,

    }

}
