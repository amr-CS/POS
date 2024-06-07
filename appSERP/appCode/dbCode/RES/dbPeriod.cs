using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.RES
{
    public class dbPeriod : IdbPeriod
    {
        private IclsADO _clsADO;
        public dbPeriod(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public DataTable funPeriodGET(
          int? pPeriodId  = null,
          DateTime? pFromDate  = null,
         DateTime? pToDate  = null,
        bool ? pIsPosted  = null,
       bool? pIsPostedStore  = null,
       bool? pIsDeleted  = null,
      int? pLanguageId  = null,
      int? pCreatedBy  = null,
      int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Declaration 
            DataTable vData ;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("PeriodId", pPeriodId));
            vlstParam.Add(new SqlParameter("FromDate", pFromDate));
            vlstParam.Add(new SqlParameter("ToDate", pToDate));
            vlstParam.Add(new SqlParameter("IsPosted", pIsPosted));
            vlstParam.Add(new SqlParameter("IsPostedStore", pIsPostedStore));

            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", pCreatedBy));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funFillDataTable("RES.spPeriodCRUD", vlstParam, "Data GET");
            return vData;
        }

        public string PostInvoice(int? InvId = null)
        {
            // Declaration 
            string vData;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("InvId", InvId));

            vData = _clsADO.funExecuteScalar("[dbo].[MigratInvoice]", vlstParam, "Data GET").ToString();

            return vData;

        }

        public string PostStorePeriodGET(DateTime? DateFrom = null, DateTime? DateTo = null)
        {
            // Declaration 
            string vData;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("DateFrom", DateFrom));
            vlstParam.Add(new SqlParameter("DateTo", DateTo));
            
            vData = _clsADO.funExecuteScalar("[ACC].[MigrateAccount]", vlstParam, "Data GET").ToString();
            
            return vData;
        }
        //public string    PostInvoice(int? InvId = null)
        //{
        //    // Declaration 
        //    string vData;
        //    // Parameters
        //    List<SqlParameter> vlstParam = new List<SqlParameter>();
        //    vlstParam.Add(new SqlParameter("InvId", InvId));
            
        //    vData = _clsADO.funExecuteScalar("[dbo].[MigratInvoice]", vlstParam, "Data GET").ToString();
            
        //    return vData;
        //}
    }
}