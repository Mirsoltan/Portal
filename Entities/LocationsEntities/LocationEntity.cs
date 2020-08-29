using Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.LocationsEntities
{
    public class LocationEntity : BaseEntities<int>
    {
        public int OrbitId { get; set; }
        public Orbit Orbit { get; set; }


        [Display(Name ="نام بخش")]
        public string Name { get; set; }
        public string Title { get; set; }
        public LocationRequestType LocationRequestType { get; set; }
        public int LocationCategoryId { get; set; }
        public LocationCategory LocationCategory { get; set; }
        public string strIcon { get; set; }

        public int LocationEntityID { get; set; }
        public LocationEntity subLocationEntities { get; set; }
    }

    public class LocationCategory : BaseEntities<int>
    {
        public List<LocationEntity> LocationEntities { get; set; }
        public string Title { get; set; }
    }


    /// <summary>
    /// نوع بخش
    /// پذیرنده = 1 
    /// درخواست کننده = 2
    /// در حالت اول هر دو حالت متصور است
    /// </summary>
    public enum LocationRequestType
    {
        [Display(Name = "پذیرنده")]
        Recepter = 1,
        [Display(Name = "درخواست کننده")]
        Demander = 2
    }

    /// <summary>
    /// انواع بخش
    /// </summary>
    public enum LocationCategory1
    {
        [Display(Name = "بخش درمانی")]
        MedicalLocation = 1,
        [Display(Name = "بخش اداری")]
        OfficeLocation = 2
    }
}
