using appSERP.appCode.Setting.TimeSetting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace appSERP.appCode.Setting.CalendarSetting
{
    public static class clsCalendar
    {
        // DataTable
        public static List<int> funYear()
        {
            int vYearPM = 5;

            // Year
            int vYear = clsTimeSetting.funBranchTime().Year;

            List<int> vlstYear = new List<int>();

            for (int i = 0; i < (vYearPM * 2); i++)
            {
                vlstYear.Add((vYear + vYearPM) - i);
            }

            return vlstYear;
        }

         enum WeekDays_AR
        {
            يناير = 0,
            فبراير = 1,
            مارس = 2,
            ابريل = 3,
            يونيو = 4,
            يوليو  = 5,
            اغسطس = 6,
            سبتمبر = 6,
            اكتوبر  = 6,
            نوفمبر = 6,
            ديسمبر = 6
        }

        // List Months
        public static List<string> funMonth()
        {
            List<string> vLstMonth = Enum.GetNames(typeof(WeekDays_AR)).ToList();

            return vLstMonth;
        }


    }
}