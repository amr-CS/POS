using appSERP.appCode.dbCode.RES.Abstract;
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

namespace appSERP.appCode.dbCode.RES.Order
{
    public class dbResOrderLocation : IdbResOrderLocation
    {       
        private IclsADO _clsADO;
        public dbResOrderLocation(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funResOrderLocationGET(
       int? pOrderLocId = null,
       int? pOrderId = null,
       int? pCUST_LOC_SEQ = null,
       string pADDRESS = null,
       string pNOTES = null,
       int? pCOMP_ID = null,
       bool? pIsDeleted = null,
       int? pCreatedBy = null,
       DateTime? pCreatedOn = null,
       int? pLastUpdatedBy = null,
       DateTime? pLastUpdatedOn = null,
       int? pLanguageId = null,
       int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("OrderLocId", pOrderLocId));
            vlstParam.Add(new SqlParameter("OrderId", pOrderId));
            vlstParam.Add(new SqlParameter("CUST_LOC_SEQ", pCUST_LOC_SEQ));
            vlstParam.Add(new SqlParameter("ADDRESS", pADDRESS));
            vlstParam.Add(new SqlParameter("NOTES", pNOTES));
            vlstParam.Add(new SqlParameter("COMP_ID", clsUser.vUserCompanyId));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("RES.spResOrderLocation", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}