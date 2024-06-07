using appSERP.appCode.dbCode.SEC.Abstract;
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
    public class dbUserCashier : IdbUserCashier
    {    

        private IclsADO _clsADO;
        public dbUserCashier(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funUserCashierGET(
        int? pUserCashierId = null,
        int? pUserId = null,
        int? pCashierId = null,
        bool? pModifyInvoice = null,
        bool? pCancelInvoice = null,
        bool? pRePrintInvoice = null,
        bool? pIsCashierDelivery = null,
        bool? pPcVerfiy = null,
        bool? pReturnInsurance = null,
        bool? pSearchInvoice = null,
        bool? pHoldInvoice = null,
        bool? Discount = null,
        int? pInsuranceLimit = null,
        bool? pIsDeleted = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pLanguageId = null,
        int? ReportPeriod = null,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("UserCashierId", pUserCashierId));
            vlstParam.Add(new SqlParameter("UserId", pUserId));
            vlstParam.Add(new SqlParameter("CashierId", pCashierId));
            vlstParam.Add(new SqlParameter("ModifyInvoice", pModifyInvoice));
            vlstParam.Add(new SqlParameter("CancelInvoice", pCancelInvoice));
            vlstParam.Add(new SqlParameter("RePrintInvoice", pRePrintInvoice));
            vlstParam.Add(new SqlParameter("IsCashierDelivery", pIsCashierDelivery));
            vlstParam.Add(new SqlParameter("PcVerfiy", pPcVerfiy));
            vlstParam.Add(new SqlParameter("ReturnInsurance", pReturnInsurance));
            vlstParam.Add(new SqlParameter("SearchInvoice", pSearchInvoice));
            vlstParam.Add(new SqlParameter("HoldInvoice", pHoldInvoice));
            vlstParam.Add(new SqlParameter("Discount", Discount));
            vlstParam.Add(new SqlParameter("InsuranceLimit", pInsuranceLimit));
            vlstParam.Add(new SqlParameter("ReportPeriod", ReportPeriod));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("SEC.spUserCashierCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }

        public DataTable TableUserCashierGET(
        int? pUserCashierId = null,
        int? pUserId = null,
        int? pCashierId = null,
        bool? pModifyInvoice = null,
        bool? pCancelInvoice = null,
        bool? pRePrintInvoice = null,
        bool? pIsCashierDelivery = null,
        bool? pPcVerfiy = null,
        bool? pReturnInsurance = null,
        bool? pSearchInvoice = null,
        bool? pHoldInvoice = null,
        int? pInsuranceLimit = null,
        bool? pIsDeleted = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pLanguageId = null,
        int? ReportPeriod = null,
        int? pQueryTypeId = null)
        {
            // Declaration 
            DataTable vData = null;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("UserCashierId", pUserCashierId));
            vlstParam.Add(new SqlParameter("UserId", pUserId));
            vlstParam.Add(new SqlParameter("CashierId", pCashierId));
            vlstParam.Add(new SqlParameter("ModifyInvoice", pModifyInvoice));
            vlstParam.Add(new SqlParameter("CancelInvoice", pCancelInvoice));
            vlstParam.Add(new SqlParameter("RePrintInvoice", pRePrintInvoice));
            vlstParam.Add(new SqlParameter("IsCashierDelivery", pIsCashierDelivery));
            vlstParam.Add(new SqlParameter("PcVerfiy", pPcVerfiy));
            vlstParam.Add(new SqlParameter("ReturnInsurance", pReturnInsurance));
            vlstParam.Add(new SqlParameter("SearchInvoice", pSearchInvoice));
            vlstParam.Add(new SqlParameter("HoldInvoice", pHoldInvoice));
            vlstParam.Add(new SqlParameter("InsuranceLimit", pInsuranceLimit));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("ReportPeriod", ReportPeriod));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funFillDataTable("SEC.spUserCashierCRUD", vlstParam, "Data GET");
            return vData;
        }
    }
}