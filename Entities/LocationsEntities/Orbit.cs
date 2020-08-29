using Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.LocationsEntities
{
    /// <summary>
    ///  سرشاخه هر زیر مجموعه
    /// </summary>
    public class Orbit : BaseEntities<int>
    {
        public string OrbitName { get; set; }
        public string TelNo1 { get; set; }
        public string TelNo2 { get; set; }
        public OrbitType OrbitType { get; set; }
        //public int OrbitalId { get; set; }
        //public Orbit Orbital { get; set; }

        public List<LocationEntity> locationEntities { get; set; }
    }

    public enum OrbitType
    {
        Hospital=1,
        Clinic=2,
        Pharmacy=3,
        Ortez=4,
    }

}
