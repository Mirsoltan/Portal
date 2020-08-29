﻿using MD.PersianDateTime.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DateTimeControl
{  
    public class ConvertDates : IConvertDates
    {
        public DateTime ConvertShamsiToMiladi(string Date)
        {
            PersianDateTime persianDateTime = PersianDateTime.Parse(Date);
            return persianDateTime.ToDateTime();
        }

        public string ConvertMiladiToShamsi(DateTime Date, string Format)
        {
            if (Date == null)
            {
                return "";
            }
            PersianDateTime persianDateTime = new PersianDateTime(Date);
            return persianDateTime.ToString(Format);
        }
    }
}
