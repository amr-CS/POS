using appSERP.appCode.dbCode.SEC.Abstract;
using appSERP.appCode.Setting.Company;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.SEC
{
    public class dbUserSecurityLog : IdbUserSecurityLog
    {
        //Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }
        // Seach Data
        public DataTable vDTUserLog { get; set; }

        private IclsADO _clsADO;
        public dbUserSecurityLog(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        
        // GET 
        public string funUserSecurityLogGET(
        int? pSecurityLogId = null,
        string pSecurityLogLat = null,
        string pSecurityLogLng = null,
        string pSecurityLogLocation = null,
        string pSecurityLogDevice = null,
        bool? pSecurityLogDeviceIsMobile = null,
        DateTime? pSecurityLogDate = null,
        TimeSpan? pSecurityLogTime = null,
        string pOldPassword = null,
        string pNewPassword = null,
        int? pUserId = null,
        int? pUserSecurityTransactionTypeId = null,
        int? pCompanyId = null,
        bool? pSecurityLogIsActive = null,
        string pDateFrom=null,
        string pDateTo = null,
        string pTimeFrom=null,
        string pTimeTo =null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        bool? pIsDeleted = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pLanguageId = null,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("SecurityLogId", pSecurityLogId));
            vlstParam.Add(new SqlParameter("SecurityLogLat", pSecurityLogLat));
            vlstParam.Add(new SqlParameter("SecurityLogLng", pSecurityLogLng));
            vlstParam.Add(new SqlParameter("SecurityLogLocation", pSecurityLogLocation));
            vlstParam.Add(new SqlParameter("SecurityLogDevice", pSecurityLogDevice));
            vlstParam.Add(new SqlParameter("SecurityLogDeviceIsMobile", pSecurityLogDeviceIsMobile));
            vlstParam.Add(new SqlParameter("SecurityLogDate", pSecurityLogDate));
            vlstParam.Add(new SqlParameter("SecurityLogTime", pSecurityLogTime));
            vlstParam.Add(new SqlParameter("OldPassword", pOldPassword));
            vlstParam.Add(new SqlParameter("NewPassword", pNewPassword));
            vlstParam.Add(new SqlParameter("UserId", pUserId));
            vlstParam.Add(new SqlParameter("UserSecurityTransactionTypeId", pUserSecurityTransactionTypeId));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("DateFrom", pDateFrom));
            vlstParam.Add(new SqlParameter("DateTo", pDateTo));
            vlstParam.Add(new SqlParameter("TimeFrom", pTimeFrom));
            vlstParam.Add(new SqlParameter("TimeTo", pTimeTo));
            vlstParam.Add(new SqlParameter("SecurityLogIsActive", pSecurityLogIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("SEC.spUserSecurityLogCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}