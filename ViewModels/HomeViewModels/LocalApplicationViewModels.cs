using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ViewModels.CommonViewModels;

namespace ViewModels.HomeViewModels
{
      public class LocalApplicationsIndexedViewModels : CommonViewmodel
    {
        public int Id { get; set; }
        [Display(Name = "برنامه نصب شده روی سیستم")]
        public bool IsLocalApp { get; set; }

        [Display(Name = "مسیر جاری برنامه / لینک"), Required(ErrorMessage = "مسیر اجرای لینک را مشخص نمایید")]
        public string ApplicationPath { get; set; }
        public byte[] Image { get; set; }
        [Display(Name = "تصویر")]
        public IFormFile File { get; set; }
        [Display(Name = "فایل تصویر")]
        public string ImageName { get; set; }

    }
    public class LocalApplicationsCreateViewModels : CommonViewmodel
    {
        public int Id { get; set; }
        
        [Display(Name = "آیا برنامه کاربردی نصبی است؟")]
        public bool IsLocalApp { get; set; }
        [Display(Name = "مسیر جاری برنامه / لینک"), Required(ErrorMessage = "مسیر اجرای لینک را مشخص نمایید")]
        public string ApplicationPath { get; set; }
        public byte[] Image { get; set; }
        [Display(Name = "تصویر")]
        public IFormFile File { get; set; }
        [Display(Name = "فایل تصویر")]
        public string ImageName { get; set; }
    }
    public class LocalApplicationsEditViewModels : CommonViewmodel
    {
        public int Id { get; set; }
        [Display(Name = "آیا برنامه کاربردی نصبی است؟")]
        public bool IsLocalApp { get; set; }
        [Display(Name = "مسیر جاری برنامه / لینک"), Required(ErrorMessage = "مسیر اجرای لینک را مشخص نمایید")]
        public string ApplicationPath { get; set; }
        public byte[] Image { get; set; }
        [Display(Name = "تصویر")]
        public IFormFile File { get; set; }
        [Display(Name = "فایل تصویر")]
        public string ImageName { get; set; }
    }
}
