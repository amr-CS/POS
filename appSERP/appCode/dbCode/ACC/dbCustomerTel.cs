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
    public class dbCustomerTel : IdbCustomerTel
    {
        // Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbCustomerTel(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funCustomerTelGET(
        int? pCustomerTelId = null,
        string pCustomerTelCode = null,
        string pCustomerTelNo = null,
        int? pCustomerId = null,
        bool? pCustomerTelIsActive = null,
         bool? pIsDeleted = null,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();

            vlstParam.Add(new SqlParameter("CustomerTelId", pCustomerTelId));
            vlstParam.Add(new SqlParameter("CustomerTelCode", pCustomerTelCode));
            vlstParam.Add(new SqlParameter("CustomerTelNo", pCustomerTelNo));
            vlstParam.Add(new SqlParameter("CustomerId", pCustomerId));
            vlstParam.Add(new SqlParameter("CustomerTelIsActive", pCustomerTelIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("ACC.spCustomerTelCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}