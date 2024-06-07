using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.Setting.Company;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.ACC
{
    public class dbCashDeskDtl: IdbCashDeskDtl
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbCashDeskDtl(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funCashDeskDtlGET(
        int? pCashDeskDtlId = null,
        string pCashDeskDtlCode = null,
        string pCashDeskDtlNameL1 = null,
        string pCashDeskDtlNameL2 = null,
        string pCashDeskTransId = null,
        int? pCompanyId = null,
        int? pBranchId = null,
        int? pGLVoucherTypeId = null,
        int? pFinancialYearId = null,
        int? pAccountId = null,
        int? pCashDeskId = null,
        int? pCurrencyId = null,
        decimal? pCashDeskDtlDebit = null,
        decimal? pCashDeskDtlCredit = null,
        decimal? pCashDeskDtlDebitBase = null,
        decimal? pCashDeskDtlCreditBase = null,
        decimal? pBaseCurrencyValue = null,
        decimal? pCashDeskDtlPayDebit = null,
        decimal? pCashDeskDtlPayCredit = null,
        decimal? pPayCurrencyValue = null,
        string pCashDeskDtlNote = null,
        int? pCostCenterId = null,
        bool? pIsPosted = null,
        string pUserFullName = null,
        string pUserName = null,
        string pCashDeskDtlTransSeq = null,
        bool? pCashDeskDtlIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("CashDeskDtlId", pCashDeskDtlId));
            vlstParam.Add(new SqlParameter("CashDeskDtlCode", pCashDeskDtlCode));
            vlstParam.Add(new SqlParameter("CashDeskDtlNameL1", pCashDeskDtlNameL1));
            vlstParam.Add(new SqlParameter("CashDeskDtlNameL2", pCashDeskDtlNameL2));
            vlstParam.Add(new SqlParameter("CashDeskTransId", pCashDeskTransId));
            vlstParam.Add(new SqlParameter("BranchId", clsCompany.vBranchId));
            vlstParam.Add(new SqlParameter("GLVoucherTypeId", pGLVoucherTypeId));
            vlstParam.Add(new SqlParameter("FinancialYearId", pFinancialYearId));
            vlstParam.Add(new SqlParameter("AccountId", pAccountId));
            vlstParam.Add(new SqlParameter("CashDeskId", pCashDeskId));
            vlstParam.Add(new SqlParameter("CurrencyId", pCurrencyId));
            vlstParam.Add(new SqlParameter("CashDeskDtlDebit", pCashDeskDtlDebit));
            vlstParam.Add(new SqlParameter("CashDeskDtlCredit", pCashDeskDtlCredit));
            vlstParam.Add(new SqlParameter("CashDeskDtlDebitBase", pCashDeskDtlDebitBase));
            vlstParam.Add(new SqlParameter("CashDeskDtlCreditBase", pCashDeskDtlCreditBase));
            vlstParam.Add(new SqlParameter("BaseCurrencyValue", pBaseCurrencyValue));
            vlstParam.Add(new SqlParameter("CashDeskDtlPayDebit", pCashDeskDtlPayDebit));
            vlstParam.Add(new SqlParameter("CashDeskDtlPayCredit", pCashDeskDtlPayCredit));
            vlstParam.Add(new SqlParameter("PayCurrencyValue", pPayCurrencyValue));
            vlstParam.Add(new SqlParameter("CashDeskDtlNote", pCashDeskDtlNote));
            vlstParam.Add(new SqlParameter("CostCenterId", pCostCenterId));
            vlstParam.Add(new SqlParameter("IsPosted", pIsPosted));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));
            vlstParam.Add(new SqlParameter("UserName", clsUser.vUserName));
            vlstParam.Add(new SqlParameter("CashDeskDtlTransSeq", pCashDeskDtlTransSeq));
            vlstParam.Add(new SqlParameter("CashDeskDtlIsActive", pCashDeskDtlIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("ACC.spCashDeskDtlCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}