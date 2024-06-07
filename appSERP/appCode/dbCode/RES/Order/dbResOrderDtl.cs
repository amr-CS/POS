using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using appSERP.appCode.SQL.QueryType;
using appSERP.appCode.Utils;
using appSERP.Models.RES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.RES.Order
{
    public class dbResOrderDtl : IdbResOrderDtl
    {
        

        private IclsADO _clsADO;
        public dbResOrderDtl(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funResOrderDtlGET(
        int? pOrderDTLID = null,
        int? pOrderId = null,
        int? pORDER_LOC_SEQ = null,
        int? pITEM_UNIT_SEQ = null,
        int? pTAG = null,
        float? pQTY = null,
        int? pPRICE = null,
        string pNOTES = null,
        int? pSLICING_TYPE = null,
        int? pSHEEP_REMAINDER = null,
        int? pCUST_SHEEP = null,
        int? pCUST_PLATE = null,
        int? pQTY_PLATE = null,
        int? pTYP = null,
        float? pPRICE_INSUR = null,
        float? pUPDATE_PRICE = null,
        int? pDISC_AMT = null,
        float? pVAT_PRICE = null,
        float? pVAT_TOTAL = null,
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
            vlstParam.Add(new SqlParameter("OrderDTLID", pOrderDTLID));
            vlstParam.Add(new SqlParameter("OrderId", pOrderId));
            vlstParam.Add(new SqlParameter("ORDER_LOC_SEQ", pORDER_LOC_SEQ));
            vlstParam.Add(new SqlParameter("ITEM_UNIT_SEQ", pITEM_UNIT_SEQ));
            vlstParam.Add(new SqlParameter("TAG", pTAG));
            vlstParam.Add(new SqlParameter("QTY", pQTY));
            vlstParam.Add(new SqlParameter("PRICE", pPRICE));
            vlstParam.Add(new SqlParameter("NOTES", pNOTES));
            vlstParam.Add(new SqlParameter("SLICING_TYPE", pSLICING_TYPE));
            vlstParam.Add(new SqlParameter("SHEEP_REMAINDER", pSHEEP_REMAINDER));
            vlstParam.Add(new SqlParameter("CUST_SHEEP", pCUST_SHEEP));
            vlstParam.Add(new SqlParameter("CUST_PLATE", pCUST_PLATE));
            vlstParam.Add(new SqlParameter("QTY_PLATE", pQTY_PLATE));
            vlstParam.Add(new SqlParameter("TYP", pTYP));
            vlstParam.Add(new SqlParameter("PRICE_INSUR", pPRICE_INSUR));
            vlstParam.Add(new SqlParameter("UPDATE_PRICE", pUPDATE_PRICE));
            vlstParam.Add(new SqlParameter("DISC_AMT", pDISC_AMT));
            vlstParam.Add(new SqlParameter("VAT_PRICE", pVAT_PRICE));
            vlstParam.Add(new SqlParameter("VAT_TOTAL", pVAT_TOTAL));
            vlstParam.Add(new SqlParameter("COMP_ID", clsUser.vUserCompanyId));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("RES.spResOrderDtl", vlstParam, "Data GET").ToString();
            return vData;
        }
        const string tableName = "res.tblRESOrderDTL";
        public DataTable GetOrderDetails(int orderId)
        {
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            string strWhere = "OrderId=@orderId";
            vlstParam.Add(new SqlParameter("@orderId", orderId));
            string queryText = $"select * from {tableName} where {strWhere}";
            var dt = _clsADO.funFillDataTableQuery(queryText, vlstParam);
            return dt;
        }

        public object spResOrderDtlInsertBulk(ICollection<ResOrderDtl> resOrderDtls, int? orderId, int? branchId)
        {
            CustomXmlWriter xmlWriter = new CustomXmlWriter();
            string xml = xmlWriter.GetXml("ResOrderDtls", resOrderDtls);
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("ResOrderDtls", xml));
            vlstParam.Add(new SqlParameter("OrderId", orderId));
            vlstParam.Add(new SqlParameter("BranchId", branchId));
            return _clsADO.funExecuteScalar("[RES].[spResOrderDtl_Bulk]", vlstParam, "Data GET");
        }
    }
}