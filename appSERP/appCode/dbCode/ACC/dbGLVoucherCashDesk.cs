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
    public class dbGLVoucherCashDesk: IdbGLVoucherCashDesk
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbGLVoucherCashDesk(clsADO clsADO)
        {
            _clsADO = clsADO;
        }


        public string funGLVoucherCashDeskGET(
        int? pGLVoucherCashDeskId = null,
        string pGLVoucherCashDeskCode = null,
        string pGLVoucherCashDeskNameL1 = null,
        string pGLVoucherCashDeskNameL2 = null,
        int? pGLVoucherId = null,
        int? pCompanyId = null,
        int? pBranchId = null,
        int? pGLVoucherTypeId = null,
        int? pFinancialYearId = null,
        int? pCaskDeskId = null,
        int? pMainCashDeskId = null,
        int? pAccountId = null,
        int? pGLVoucherCashDeskDebit = null,
        int? pGLVoucherCashCredit = null,
        int? pGLVoucherCashDeskDebitBase = null,
        int? pGLVoucherCashDeskCreditBase = null,
        int? pBaseCurrencyValue = null,
        int? pPayDebit = null,
        int? pPayCredit = null,
        int? pCurrencyId = null,
        int? pCostCenterId = null,
        string pGLVoucherCashDeskNote = null,
        string pUserFullNameL1 = null,
        string pUserFullNameL2 = null,
        string pUserName = null,
        int? pTransSeq = null,
        bool? pGLVoucherCashDeskIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("GLVoucherCashDeskId", pGLVoucherCashDeskId));
            vlstParam.Add(new SqlParameter("GLVoucherCashDeskCode", pGLVoucherCashDeskCode));
            vlstParam.Add(new SqlParameter("GLVoucherCashDeskNameL1", pGLVoucherCashDeskNameL1));
            vlstParam.Add(new SqlParameter("GLVoucherCashDeskNameL2", pGLVoucherCashDeskNameL2));
            vlstParam.Add(new SqlParameter("GLVoucherId", pGLVoucherId));
            vlstParam.Add(new SqlParameter("BranchId", clsCompany.vBranchId));
            vlstParam.Add(new SqlParameter("GLVoucherTypeId", pGLVoucherTypeId));
            vlstParam.Add(new SqlParameter("FinancialYearId", pFinancialYearId));
            vlstParam.Add(new SqlParameter("CaskDeskId", pCaskDeskId));
            vlstParam.Add(new SqlParameter("MainCashDeskId", pMainCashDeskId));
            vlstParam.Add(new SqlParameter("AccountId", pAccountId));
            vlstParam.Add(new SqlParameter("GLVoucherCashDeskDebit", pGLVoucherCashDeskDebit));
            vlstParam.Add(new SqlParameter("GLVoucherCashCredit", pGLVoucherCashCredit));
            vlstParam.Add(new SqlParameter("GLVoucherCashDeskDebitBase", pGLVoucherCashDeskDebitBase));
            vlstParam.Add(new SqlParameter("GLVoucherCashDeskCreditBase", pGLVoucherCashDeskCreditBase));
            vlstParam.Add(new SqlParameter("BaseCurrencyValue", pBaseCurrencyValue));
            vlstParam.Add(new SqlParameter("PayDebit", pPayDebit));
            vlstParam.Add(new SqlParameter("PayCredit", pPayCredit));
            vlstParam.Add(new SqlParameter("CurrencyId", pCurrencyId));
            vlstParam.Add(new SqlParameter("CostCenterId", pCostCenterId));
            vlstParam.Add(new SqlParameter("GLVoucherCashDeskNote", pGLVoucherCashDeskNote));
            vlstParam.Add(new SqlParameter("UserFullNameL1", pUserFullNameL1));
            vlstParam.Add(new SqlParameter("UserFullNameL2", pUserFullNameL2));
            vlstParam.Add(new SqlParameter("UserName", pUserName));
            vlstParam.Add(new SqlParameter("TransSeq", pTransSeq));
            vlstParam.Add(new SqlParameter("GLVoucherCashDeskIsActive", pGLVoucherCashDeskIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("ACC.spGLVoucherCashDeskCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}