using System;
using System.Collections.Generic;
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
        Requested = 1,
        Doing = 2,
        Done = 3,
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
        Low = 1,
        Normal = 2,
        High = 3,
        Urgent = 4,
    }

    /// <summary>
    /// ارجاعات یک درخواست
    /// 0 = رد شده یا ارجاع نشده
    /// 1 = ارجاع شده به بخش دیگر
    /// </summary>
    public enum RequestRefer
    {
        NoneRefered = 0,
        Refered = 1,
    }
}
