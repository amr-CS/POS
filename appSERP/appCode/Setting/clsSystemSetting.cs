using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace appSERP.appCode.Setting
{
    public static class clsSystemSetting
    {
        // Check DataTable
        public static bool funCheckDataTable(DataTable pDtCheck)
        {
            // Is Valid
            bool vIsValid = false;

            // Check DataTable
            if (pDtCheck != null)
            {
                if (pDtCheck.Rows.Count > 0)
                {
                    vIsValid = true;
                }
            }

            // Return Result
            return vIsValid;
        }
    }
}