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
    public class dbGLVoucherDtl : IdbGLVoucherDtl
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbGLVoucherDtl(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funGLVoucherDtlGET(
        int? pGLVoucherDtlId = null,
        string pGLVoucherDtlCode = null,
        string pGLVoucherDtlNameL1 = null,
        string pGLVoucherDtlNameL2 = null,
        string pGLVoucherId = null,
        int? pCompanyId = null,
        int? pBranchId = null,
        int? pGLVoucherTypeId = null,
        int? pFinancialYearId = null,
        int? pAccountId = null,
        int? pCashDeskId = null,
        int? pCurrencyId = null,
        decimal? pGLVoucherDtlDebit = null,
        decimal? pGLVoucherDtlCredit = null,
        decimal? pGLVoucherDtlDebitBase = null,
        decimal? pGLVoucherDtlCreditBase = null,
        decimal? pBaseCurrencyValue = null,
        decimal? pGLVoucherDtlPayDebit = null,
        decimal? pGLVoucherDtlPayCredit = null,
        decimal? pPayCurrencyValue = null,
        string pGLVoucherDtlNote = null,
        int? pCostCenterId = null,
        bool? pIsPosted = null,
        string pUserFullName = null,
        string pUserName = null,
        string pGLVoucherDtlTransSeq = null,
        bool? pGLVoucherDtlIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("GLVoucherDtlId", pGLVoucherDtlId));
            vlstParam.Add(new SqlParameter("GLVoucherDtlCode", pGLVoucherDtlCode));
            vlstParam.Add(new SqlParameter("GLVoucherDtlNameL1", pGLVoucherDtlNameL1));
            vlstParam.Add(new SqlParameter("GLVoucherDtlNameL2", pGLVoucherDtlNameL2));
            vlstParam.Add(new SqlParameter("GLVoucherId", pGLVoucherId));
            vlstParam.Add(new SqlParameter("BranchId", clsCompany.vBranchId));
            vlstParam.Add(new SqlParameter("GLVoucherTypeId", pGLVoucherTypeId));
            vlstParam.Add(new SqlParameter("FinancialYearId", pFinancialYearId));
            vlstParam.Add(new SqlParameter("AccountId", pAccountId));
            vlstParam.Add(new SqlParameter("CashDeskId", pCashDeskId));
            vlstParam.Add(new SqlParameter("CurrencyId", pCurrencyId));
            vlstParam.Add(new SqlParameter("GLVoucherDtlDebit", pGLVoucherDtlDebit));
            vlstParam.Add(new SqlParameter("GLVoucherDtlCredit", pGLVoucherDtlCredit));
            vlstParam.Add(new SqlParameter("GLVoucherDtlDebitBase", pGLVoucherDtlDebitBase));
            vlstParam.Add(new SqlParameter("GLVoucherDtlCreditBase", pGLVoucherDtlCreditBase));
            vlstParam.Add(new SqlParameter("BaseCurrencyValue", pBaseCurrencyValue));
            vlstParam.Add(new SqlParameter("GLVoucherDtlPayDebit", pGLVoucherDtlPayDebit));
            vlstParam.Add(new SqlParameter("GLVoucherDtlPayCredit", pGLVoucherDtlPayCredit));
            vlstParam.Add(new SqlParameter("PayCurrencyValue", pPayCurrencyValue));
            vlstParam.Add(new SqlParameter("GLVoucherDtlNote", pGLVoucherDtlNote));
            vlstParam.Add(new SqlParameter("CostCenterId", pCostCenterId));
            vlstParam.Add(new SqlParameter("IsPosted", pIsPosted));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));
            vlstParam.Add(new SqlParameter("UserName", clsUser.vUserName));
            vlstParam.Add(new SqlParameter("GLVoucherDtlTransSeq", pGLVoucherDtlTransSeq));
            vlstParam.Add(new SqlParameter("GLVoucherDtlIsActive", pGLVoucherDtlIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("ACC.spGLVoucherDtlCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}