using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.ACC
{
    public class dbCustomerSite : IdbCustomerSite
    {
        // Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbCustomerSite(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funCustomerSiteGET(
        int? pCustomerSiteId = null,
        string pCustomerSiteCode = null,
        string pCustomerSiteNameL1 = null,
        string pCustomerSiteNameL2 = null,
        int? pCustomerId = null,
        int? pSiteId = null,
        bool? pCustomerSiteIsActive = null,
         bool? pIsDeleted = null,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();

            vlstParam.Add(new SqlParameter("CustomerSiteId", pCustomerSiteId));
            vlstParam.Add(new SqlParameter("CustomerSiteCode", pCustomerSiteCode));
            vlstParam.Add(new SqlParameter("CustomerSiteNameL1", pCustomerSiteNameL1));
            vlstParam.Add(new SqlParameter("CustomerSiteNameL2", pCustomerSiteNameL2));
            vlstParam.Add(new SqlParameter("CustomerId", pCustomerId));
            vlstParam.Add(new SqlParameter("SiteId", pSiteId));
            vlstParam.Add(new SqlParameter("CustomerSiteIsActive", pCustomerSiteIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("ACC.spCustomerSiteCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}