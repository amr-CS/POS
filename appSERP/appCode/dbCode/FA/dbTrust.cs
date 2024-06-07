using appSERP.appCode.dbCode.FA.Abstract;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.FA
{
    public class dbTrust : IdbTrust
    {
        // Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbTrust(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funTrustGET(
        int? pTrustId = null,
        string pTrustNameL1 = null,
        string pTrustNameL2 = null,
        int? pTrustEmployeeId = null,
        string pTrustPhone1 = null, 
        string pTrustPhone2 = null,  
        string pTrustEmail = null, 
        bool? pTrustIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("TrustId", pTrustId));
            vlstParam.Add(new SqlParameter("TrustNameL1", pTrustNameL1));
            vlstParam.Add(new SqlParameter("TrustNameL2", pTrustNameL2));
            vlstParam.Add(new SqlParameter("TrustEmployeeId", pTrustEmployeeId));
            vlstParam.Add(new SqlParameter("TrustPhone1", pTrustPhone1));
            vlstParam.Add(new SqlParameter("TrustPhone2", pTrustPhone2));
            vlstParam.Add(new SqlParameter("TrustEmail", pTrustEmail));
            vlstParam.Add(new SqlParameter("TrustIsActive", pTrustIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy",clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("FA.spTrustCRUD", vlstParam, "Data GET").ToString();
            return vData;

           
    }
    }
}