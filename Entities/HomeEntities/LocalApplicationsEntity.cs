using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.HomeEntities
{
    public class LocalApplications
    {
        [Key]
        public int LocalAppID { get; set; }
        public string Title { get; set; }
        public bool IsLocalApp { get; set; }
        public string ApplicationPath { get; set; }
        public string ImageName { get; set; }
        [Column(TypeName = "image")]
        public byte[] Image { get; set; }
        public string Description { get; set; }
    }
}
