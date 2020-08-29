using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ViewModels.BaseViewModels;

namespace ViewModels.MasterAdmin
{
    public class SupervisionViewModel : BaseViewmodel
    {
        [Display(Name = "نام موسسه")]
        public string Name { get; set; }
        [Display(Name = "کد")]
        public string Code { get; set; }
        [Display(Name = "توضیحات")]
        public string Detailes { get; set; }
    }
}
