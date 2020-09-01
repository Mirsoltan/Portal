using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.LocationsEntities
{
    public class Location
    {
        [Key]
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public int? ParentLocationID { get; set; }
        public Location location { get; set; }
        public List<Location> LocationS { get; set; }
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
        Room = 100,
        Bed = 101,

        Clinic = 200,
        HeartClinic=201,
        EyeClinic=202,

        //        Imaging = 500,
        Rad = 501,
        Sono = 502,
        MRI = 503,
        CT = 504,

        Lab = 600,
        BloodBank = 601, 

        Phisio = 700,
        Sleeping=800,

    }

}
