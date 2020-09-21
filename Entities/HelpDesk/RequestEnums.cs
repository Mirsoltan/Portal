using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.HelpDesk
{
    /// <summary>
    /// وضعیت درخواست
    /// 1 = درخواست شده
    /// 2 = در حال انحام
    /// 3 = انچام شده
    /// 4 = رد شده
    /// </summary>
    public enum RequestStatusType
    {
        [Display(Name = "درخواست شده")]
        Requested = 1,
        [Display(Name = "در حال انجام")]
        Doing = 2,
        [Display(Name = "انجام شده")]
        Done = 3,
        [Display(Name = "رد شده")]
        Rejected = 5,
    }

    /// <summary>
    /// اولیت درخواست
    /// 1 = کم
    /// 2 = عادی
    /// 3 = بالا
    /// 4 = اورژانسی
    /// </summary>
    public enum RequestPriorityType
    {
        [Display(Name ="کم")]
        Low = 1,
        [Display(Name = "عادی")]
        Normal = 2,
        [Display(Name = "فوری")]
        High = 3,
        [Display(Name = "بحرانی")]
        Urgent = 4,
    }

    /// <summary>
    /// ارجاعات یک درخواست
    /// 0 = رد شده یا ارجاع نشده
    /// 1 = ارجاع شده به بخش دیگر
    /// </summary>
    public enum RequestRefer
    {
        [Display(Name = "ارجاع شده")]
        NoneRefered = 0,
        [Display(Name = "ارجاع نشده")]
        Refered = 1,
    }
}
