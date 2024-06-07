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
    public class dbCustomerCategory: IdbCustomerCategory
    {
        // Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbCustomerCategory(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funCustomerCategoryGET(
         int? pCustomerCategoryId = null,
         string pCustomerCategoryCode = null,
         string pCustomerCategoryNameL1 = null,
         string pCustomerCategoryNameL2 = null,
         bool? pCustomerCategoryIsActive = null,
         bool? pIsDeleted = null,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();

            vlstParam.Add(new SqlParameter("CustomerCategoryId", pCustomerCategoryId));
            vlstParam.Add(new SqlParameter("CustomerCategoryCode", pCustomerCategoryCode));
            vlstParam.Add(new SqlParameter("CustomerCategoryNameL1", pCustomerCategoryNameL1));
            vlstParam.Add(new SqlParameter("CustomerCategoryNameL2", pCustomerCategoryNameL2));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("ACC.spCustomerCategoryCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}