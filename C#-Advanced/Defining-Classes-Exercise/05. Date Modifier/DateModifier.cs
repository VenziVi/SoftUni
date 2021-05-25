using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    public static class DateModifier
    {
        public static int GetDiference(string dateOneStr, string dateTwoStr)
        {
            DateTime dateOne = DateTime.Parse(dateOneStr);
            DateTime dateTwo = DateTime.Parse(dateTwoStr);

            TimeSpan diff = dateOne - dateTwo;
            return diff.Days;
        }
       
    }
}
