using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;

namespace Data
{
    public static class Schemas
    {
        [Display(Name = "User Information System")]
        public const string SchemaUIS = "UIS" ;
        [Display(Name ="HIS")]
        public const string SchemaHIS = "HIS" ;
        [Display(Name = "MIS")]
        public const string SchemaMIS = "MIS" ;
        [Display(Name = "Human Resource Information System")]
        public const string SchemaHRIS = "HRIS" ;
        [Display(Name = "Medic Equipment Information System")]
        public const string SchemaMEIS = "MEIS" ;
        [Display(Name = "Pharmacy Information System")]
        public const string SchemaPhIS = "PhIS" ;
        [Display(Name = "Help Desk Information System")]
        public const string SchemaHDIS = "HDIS" ;
        
    }
}
