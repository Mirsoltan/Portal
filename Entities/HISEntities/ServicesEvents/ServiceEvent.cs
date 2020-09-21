using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.HISEntities.ServicesEvents
{
    public class ServiceEvent
    {
        [Key]
        public int ServiceEventID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }


    }
}
