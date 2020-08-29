using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DateTimeControl
{
    public interface IConvertDates
    {
        DateTime ConvertShamsiToMiladi(string Date);
        string ConvertMiladiToShamsi(DateTime Date, string Format);
    }
}
