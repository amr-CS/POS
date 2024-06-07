using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.SEC.Abstract
{
    public interface IdbUser
    {
        string funUserGET(
        int? pUserId = null,
        string Printer = null,
        string pUserCode = null,
        string pUserFullName = null,
        string pUserAddress = null,
        string pUserPhone = null,
        string pUserEmail = null,
        string pUserName = null,
        string pUserPassword = null,
        bool? pIsUserLock = null,
        string pUserImage = null,
        int? pSecurityGradeId = null,
        int? pCountryId = null,
        int? pCompanyId = null,
        int? pBranchId = null,
        int? pFontSizeTypeId = null,
        int? pUserTypeId = null,
        int? pEmployeeId = null,
        int? pUserTimeZoneId = null,
        bool? pUserTimeZoneDST = null,
        bool? pUserIsActive = null,
        string phNumbers = null,
        bool? pIsDeleted = false,
        int? pLanguageId = null,
        int? pQueryTypeId = null);

        string funUserLogin(string pUserName = null, string pUserPassword = null, string pDevice = null, bool? pUserIsActive = null, bool? pIsDeleted = null, int? pQueryTypeId = null);

        string funGetLocalIPAddress();

        DataTable funUserData(string pUserName);

        void funUserDataSet(string pUserName);

        DataTable funGetUserReport(bool? pIsActive = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }


    }
}
