using Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.HISEntities.ServicesEvents
{
    public class RVU_Services 
    {
        [Key]
        public int ServiceID { get; set; }

        [Display(Name ="دستگاه بدن")]
        public string Systems { get; set; }
        [Display(Name = "دستگاه بدن")]
        public string TopGrp { get; set; }
        public string Grp { get; set; }
        public string Attrib { get; set; }
        public string Attr { get; set; }
        public string NationalCode { get; set; }
        public string Description { get; set; }
        public string Kol { get; set; }
        public string KP { get; set; }
        public string KT { get; set; }
        public string anes { get; set; }
    }
}
