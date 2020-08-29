using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.BaseEntities
{
    public class BaseEntities<T> : IBaseEntities
    {
        [Display(Name = "شناسه")]
        public T Id { get; set; }
        [MaxLength(500), Display(Name = "توضیحات : ")]
        public string Description { get; set; }

        [MaxLength(50), Display(Name = "ایجادکننده:")]
        public string InsertBy { get; set; }
        [Display(Name = "زمان ایجاد:")]
        [DefaultValue("CONVERT(datetime,GetDate())")]
        public DateTime? InsertDate { get; set; }


        [MaxLength(50), Display(Name = "بروز رسانی کننده:")]
        public string UpdateBy { get; set; }
        [Display(Name = "زمان بروزرسانی:")]
        public DateTime? UpdateDate { get; set; }

        [MaxLength(50), Display(Name = "حذف کننده:")]
        public string DeleteBy { get; set; }
        [Display(Name = "زمان حذف:")]
        public DateTime? DeleteDate { get; set; }

        [DefaultValue(1), Display(Name = "وضعیت فعال / غیر فعال")]
        public bool IsActive { get; set; }
    }
}
