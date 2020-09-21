using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.HISEntities.ServicesEvents
{
    public class MasterService
    {
        [Key]
        public int MasterServiceID { get; set; }
        public string MasterServiceName { get; set; }
        public string ServiceDisplayName { get; set; }
        public string NationalCode { get; set; }

        public int ServiceGroupCategoryID { get; set; }
        public MasterServiceGroupCategory ServiceGroupCategory { get; set; }
        public bool IsActive { get; set; }

        public int MSParentID { get; set; }
        public MasterService MasterServices { get; set; }
        public List<MasterService> MServices { get; set; }

 
    }

    /// <summary>
    /// تعریف کد دلخواه برای ثبت خدمت
    /// هر مرکز میتواند برای خودش کد تعریف کند که مثلا ویزیت
    /// با کد 900 درج بشود
    /// </summary>
    public class MasterServiceDetails
    {
        [Key]
        public int MSDID { get; set; }
        public int  UserCode { get; set; }
        public int  LocationID { get; set; }
    }

    /// <summary>
    /// گروه های خدمت
    /// </summary>
    public class MasterServiceGroupCategory
    {
        [Key]
        public int MSGID { get; set; }
        public string MSCategoryName { get; set; }
        public bool IsActive { get; set; }

        public int MSGParentID { get; set; }
        public MasterServiceGroupCategory Category { get; set; }
        public List<MasterServiceGroupCategory> SubCategory { get; set; }
        public List<MasterService> MasterService { get; set; }
    }
}
