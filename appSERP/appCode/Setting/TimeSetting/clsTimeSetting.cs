using appSERP.appCode.Setting.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.appCode.Setting.TimeSetting
{
    public static class clsTimeSetting
    {
        // Branch Time
        public static DateTime funBranchTime()
        {
            // Universal Time
            DateTime vDtUniversalTime = DateTime.Now.ToUniversalTime();

            // Get Offset Operand
            string vOffsetOperand = clsBranch.vBranchTimeZoneOffset.Substring(0, 1);

            // Time Span To Add
            string vTimeSpanStr = clsBranch.vBranchTimeZoneOffset.Substring(1, clsBranch.vBranchTimeZoneOffset.Length - 1);

            // Branch Time Zone Offset
            TimeSpan vDtBranchTimeZoneOffset = TimeSpan.Parse(vTimeSpanStr);


            // Branch Time
            DateTime vDtBranchTime;

            // Check Operand
            if (vOffsetOperand == "+")
            {
                // Branch
                vDtBranchTime = vDtUniversalTime.Add(vDtBranchTimeZoneOffset);
            }
            else
            {
                // Branch
                vDtBranchTime = vDtUniversalTime.Subtract(vDtBranchTimeZoneOffset);
            }
            // Return Result
            return vDtBranchTime;
        }
    }
}