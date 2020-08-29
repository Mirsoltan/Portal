using Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.SupervisionEntities
{
    /// <summary>
    /// اطلاعات کلی حوزه سرپرستی
    /// اطلاعات هر مرکز
    /// </summary>
    public class SupervisionEntity : BaseEntities<int>
    {
        [Display(Name ="نام شرکت")]
        public string Name { get; set; }
        public string Code { get; set; }
        public string  Detailes { get; set; }
    }


}
