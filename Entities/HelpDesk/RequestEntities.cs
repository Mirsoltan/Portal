using Entities.BaseEntities;
using Entities.LocationsEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.HelpDesk
{
    /// <summary>
    /// درخواستهای بخشها از همدیگر
    /// </summary>
    public class RequestWard : BaseEntity
    {
        [Key]
        public int RequestWardID { get; set; }
        public string Title { get; set; }

        public RequestStatusType RequestStatusType { get; set; }
        public RequestPriorityType RequestPriorityType { get; set; }




        /// <summary>
        /// درخواست کننده - فرستنده درخواست
        /// </summary>
        public int DemanderWardID { get; set; }
        public Locations DemanderWard { get; set; }
        /// <summary>
        /// پذیرنده - گیرنده درخواست
        /// </summary>
        public int RecepterWardID { get; set; }
        public Locations RecepterWard { get; set; }

        public RequestWard requestWard { get; set; }

        public int? ParentRequestWardID { get; set; }
        public List<RequestWard> ReferRequestWard { get; set; }


        public RequestRefer IsRefered { get; set; }
    }


}
