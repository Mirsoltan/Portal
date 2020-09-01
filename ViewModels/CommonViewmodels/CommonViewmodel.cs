using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels.CommonViewModels
{
   public class CommonViewmodel
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string Title { get; set; }
        [Display(Name = "توضیحات")]
        //[Required(ErrorMessage = "وارد کردن {0} اجباری است")]

        public string Description { get; set; }
        [Display(Name = "زمان ایجاد")]
        public DateTime? InsertDate { get; set; }
        //public DateTime? InsertDate { get { return this.InsertDate; } set { this.InsertDate = DateTime.Now; } }


        [Display(Name = "ایجادکننده")]
        public string InsertBy { get; set; }
        [Display(Name = "زمان تغییر")]
        public DateTime? UpdateDate { get; set; }
        [Display(Name = "تغییردهنده")]
        public string UpdateBy { get; set; }
        [Display(Name = "زمان حذف")]
        public DateTime? DeleteDate { get; set; }
        [Display(Name = "حذف کننده")]
        public string DeleteBy { get; set; }
        [Display(Name = "فعال")]
        public bool IsActive { get; set; }
    }

    public class ChartResultViewModel
    {
        public double data { get; set; }
        public double value1 { get; set; }
        public double value2 { get; set; }
        public string label { get; set; }
    }
}
