using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.Setting.Company;
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

namespace appSERP.appCode.dbCode.RES.Order
{
    public class dbResOrder : IdbResOrder
    {
        private IclsADO _clsADO;
        public dbResOrder(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funResOrderGET(
        int? pOrderId = null,
        int? pORDER_SEQ = null,
        int? pCOMP_ID = null,
        int? pORDER_TYPE = null,
        int? pSUB_SEQ = null,
        DateTime? pORDER_DATE = null,
        DateTime? pDELIVERY_DATE = null,
        int? pCUST_SEQ = null,
        string pADDRESS = null,
        int? pORDER_STATUS = null,
        int? pPERIOD_TYPE = null,
        int? pCOST_ID = null,
        string pNOTES = null,
        DateTime? pDELIVERY_DATE2 = null,
        bool? pMULTI_DAY = null,
        bool? pDELIVERY = null,
        float? pPAY_CASH = null,
        float? pPAY_NET = null,
        float? pCREDIT = null,
        string pORDER_PHONE_NO = null,
        string pORDER_PHONE_NUMBER = null,
        string phNumbers = null,
        float? pDISCOUNT = null,
        float? pPRICE_CAT = null,
        float? pDISCOUNT_SELL = null,
        float? pCASH_DISCOUNT = null,
        bool? pIsDeleted = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pLanguageId = null,
        int? pQueryTypeId = clsQueryType.qSelect,int? branchId=null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("OrderId", pOrderId));
            vlstParam.Add(new SqlParameter("ORDER_SEQ", pORDER_SEQ));
            vlstParam.Add(new SqlParameter("COMP_ID", clsUser.vUserCompanyId));
            vlstParam.Add(new SqlParameter("ORDER_TYPE", pORDER_TYPE));
            vlstParam.Add(new SqlParameter("SUB_SEQ", pSUB_SEQ));
            vlstParam.Add(new SqlParameter("ORDER_DATE", pORDER_DATE));
            vlstParam.Add(new SqlParameter("DELIVERY_DATE", pDELIVERY_DATE));
            vlstParam.Add(new SqlParameter("CUST_SEQ", pCUST_SEQ));
            vlstParam.Add(new SqlParameter("ADDRESS", pADDRESS));
            vlstParam.Add(new SqlParameter("ORDER_STATUS", pORDER_STATUS));
            vlstParam.Add(new SqlParameter("PERIOD_TYPE", pPERIOD_TYPE));
            vlstParam.Add(new SqlParameter("COST_ID", pCOST_ID));
            vlstParam.Add(new SqlParameter("NOTES", pNOTES));
            vlstParam.Add(new SqlParameter("DELIVERY_DATE2", pDELIVERY_DATE2));
            vlstParam.Add(new SqlParameter("MULTI_DAY", pMULTI_DAY));
            vlstParam.Add(new SqlParameter("DELIVERY", pDELIVERY));
            vlstParam.Add(new SqlParameter("PAY_CASH", pPAY_CASH));
            vlstParam.Add(new SqlParameter("PAY_NET", pPAY_NET));
            vlstParam.Add(new SqlParameter("CREDIT", pCREDIT));
            vlstParam.Add(new SqlParameter("ORDER_PHONE_NO", pORDER_PHONE_NO));
            vlstParam.Add(new SqlParameter("ORDER_PHONE_NUMBER", pORDER_PHONE_NUMBER));
            vlstParam.Add(new SqlParameter("DISCOUNT", pDISCOUNT));
            vlstParam.Add(new SqlParameter("PRICE_CAT", pPRICE_CAT));
            vlstParam.Add(new SqlParameter("DISCOUNT_SELL", pDISCOUNT_SELL));
            vlstParam.Add(new SqlParameter("CASH_DISCOUNT", pCASH_DISCOUNT));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", pCreatedBy));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", pLastUpdatedBy));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("hNumbers", phNumbers));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vlstParam.Add(new SqlParameter("BranchId", branchId));
            vData = _clsADO.funExecuteScalar("RES.spResOrder", vlstParam, "Data GET").ToString();
            return vData;
        }
        public DataTable MovementOrderGET(
            int? pOrderId = null,int?BranchId=null)
        {
            // Declaration 
            DataTable vData = new DataTable();
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("OrderId", pOrderId));
            vlstParam.Add(new SqlParameter("IsDeleted", 0));
            vlstParam.Add(new SqlParameter("BranchId", BranchId));
            vlstParam.Add(new SqlParameter("QueryTypeId", 500));
            vData = _clsADO.funFillDataTable("RES.spResOrder", vlstParam, "Data GET");
            return vData;
        }

        public DataTable funResOrderReport(int? id=null)
        {
            // Declaration 
            DataTable vData;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
           /* vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL2));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));*/
            vlstParam.Add(new SqlParameter("orderId", id));

            vData = _clsADO.funFillDataTable("RES.spResOrderReport", vlstParam, "Data GET");


            return vData;
        }

        const string tableName = "res.tblRESOrder";
        public DataTable GetOrderById(int orderId)
        {
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            string strWhere = "OrderId=@orderId";
            vlstParam.Add(new SqlParameter("@orderId", orderId));
            string queryText = $"select * from {tableName} where {strWhere}";
            var dt = _clsADO.funFillDataTableQuery(queryText, vlstParam);
            return dt;
        }

        

    }
}