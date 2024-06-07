using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.Setting.Company;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;

namespace appSERP.appCode.dbCode.ACC.Doc
{
    public class dbGLVoucher : IdbGLVoucher
    {
        // Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbGLVoucher(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        // FinancialDateCheck
        public string funFinancialDateCheckGET(
            DateTime? pDate = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("Date", pDate));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vData = _clsADO.funExecuteScalar("ACC.spFinancialDateCheck", vlstParam, "Data GET").ToString();
            return vData;
        }

        public string funGLVoucherGET(

            // Head Parameters
            int? phGLVoucherId = null,
            int? phVoucherTypeId = null,
            int? phFinancialYearId = null,
            int? phSystemId = null,
            int? phCashDeskId = null,
            DateTime? phGLVoucherDate = null,
            TimeSpan? phGLVoucherTime = null,
            string phGLVoucherRef = null,
            DateTime? phGLVoucherRefDate = null,
            int? phPaymentTypeId = null,
            bool? phIsPosted = null,
            bool? phIsIssued = null,
            bool? phIsOpps = null,
            string phGLVoucherNote = null,
            bool? phDocIsCancelled = null,
            bool? phDocIsWait = null,
            bool? phGLVoucherIsRepeated = null,
            string phGLIdPayType = null,
            int? phGLVoucherCategoryId = null,
            decimal? phGLOppsVoucherValue = null,
            int? phGLOppsVoucherId = null,
            int? phGLOppsVoucherYearId = null,
            int? phStoreId = null,
            int? phInvTransactionTypeId = null,
            string phNumbers=null,
            int? phCSId = null,
            int? phVoucherSeq = null,
            string phPerson = null,
            int? phSalesId = null,
            bool? phGLVoucherIsActive = null,
            bool? phIsDeleted = null,

            // Detail Parameters
            int? pdGLVoucherDtlId = null,
            int? pdGLVoucherId = null,
            int? pdGLVoucherTypeId = null,
            int? pdFinancialYearId = null,
            int? pdAccountId = null,
            int? pdCashDeskId = null,
            int? pdCurrencyId = null,
            decimal? pdGLVoucherDtlDebit = null,
            decimal? pdGLVoucherDtlCredit = null,
            decimal? pdGLVoucherDtlDebitBase = null,
            decimal? pdGLVoucherDtlCreditBase = null,
            decimal? pdBaseCurrencyValue = null,
            decimal? pdGLVoucherDtlPayDebit = null,
            decimal? pdGLVoucherDtlPayCredit = null,
            decimal? pdPayCurrencyValue = null,
            string pdGLVoucherDtlNote = null,
            int? pdCostCenterId = null,
            bool? pdIsPosted = null,
            int? pdGLVoucherDtlTransSeq = null,
            bool? pdIsDeleted = null,

            // Search Parameters
            string psGLVoucherNo = null,
            DateTime? psDateFrom = null,
            DateTime? psDateTo = null,

            // Main Parameters
            bool? pIsGLVoucherDetail =null,
            int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();


            // Head Parameters
            vlstParam.Add(new SqlParameter("hGLVoucherId", phGLVoucherId));

            vlstParam.Add(new SqlParameter("hCompanyId", clsUser.vUserCompanyId));
            vlstParam.Add(new SqlParameter("hBranchId", clsUser.vUserBranchId));
            vlstParam.Add(new SqlParameter("hVoucherTypeId", phVoucherTypeId));
            vlstParam.Add(new SqlParameter("hFinancialYearId", phFinancialYearId));
            vlstParam.Add(new SqlParameter("hSystemId", phSystemId));
            vlstParam.Add(new SqlParameter("hCashDeskId", phCashDeskId));
            vlstParam.Add(new SqlParameter("hGLVoucherDate", phGLVoucherDate));
            vlstParam.Add(new SqlParameter("hGLVoucherTime", phGLVoucherTime));
            vlstParam.Add(new SqlParameter("hGLVoucherRef", phGLVoucherRef));
            vlstParam.Add(new SqlParameter("hGLVoucherRefDate", phGLVoucherRefDate));
            vlstParam.Add(new SqlParameter("hPaymentTypeId", phPaymentTypeId));
            vlstParam.Add(new SqlParameter("hIsPosted", phIsPosted));
            vlstParam.Add(new SqlParameter("hIsIssued", phIsIssued));
            vlstParam.Add(new SqlParameter("hDocIsOpps", phIsOpps));
            vlstParam.Add(new SqlParameter("hGLVoucherNote", phGLVoucherNote));
            vlstParam.Add(new SqlParameter("hUserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("hDocIsCancelled", phDocIsCancelled));
            vlstParam.Add(new SqlParameter("hDocIsWait", phDocIsWait));
            vlstParam.Add(new SqlParameter("hGLVoucherIsRepeated", phGLVoucherIsRepeated));
            vlstParam.Add(new SqlParameter("hGLIdPayType", phGLIdPayType));
            vlstParam.Add(new SqlParameter("hGLVoucherCategoryId", phGLVoucherCategoryId));
            vlstParam.Add(new SqlParameter("hGLOppsVoucherValue", phGLOppsVoucherValue));
            vlstParam.Add(new SqlParameter("hGLOppsVoucherId", phGLOppsVoucherId));
            vlstParam.Add(new SqlParameter("hGLOppsVoucherYearId", phGLOppsVoucherYearId));
            vlstParam.Add(new SqlParameter("hStoreId", phStoreId));
            vlstParam.Add(new SqlParameter("hInvTransactionTypeId", phInvTransactionTypeId));
            vlstParam.Add(new SqlParameter("hCSId", phCSId));
            vlstParam.Add(new SqlParameter("hPerson", phPerson));
            vlstParam.Add(new SqlParameter("hSalesId", phSalesId));
            vlstParam.Add(new SqlParameter("hVoucherSeq", phVoucherSeq));
            vlstParam.Add(new SqlParameter("hGLVoucherIsActive", phGLVoucherIsActive));
            vlstParam.Add(new SqlParameter("hIsDeleted", phIsDeleted));
            vlstParam.Add(new SqlParameter("hCreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("hCreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("hLastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("hLastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("hNumbers", phNumbers));


            // Detail Parameters
            vlstParam.Add(new SqlParameter("dGLVoucherDtlId", pdGLVoucherDtlId));
            vlstParam.Add(new SqlParameter("dGLVoucherId", pdGLVoucherId));
            vlstParam.Add(new SqlParameter("dGLVoucherTypeId", pdGLVoucherTypeId));
            vlstParam.Add(new SqlParameter("dFinancialYearId", pdFinancialYearId));
            vlstParam.Add(new SqlParameter("dAccountId", pdAccountId));
            vlstParam.Add(new SqlParameter("dCashDeskId", pdCashDeskId));
            vlstParam.Add(new SqlParameter("dCurrencyId", pdCurrencyId));
            vlstParam.Add(new SqlParameter("dGLVoucherDtlDebit", pdGLVoucherDtlDebit));
            vlstParam.Add(new SqlParameter("dGLVoucherDtlCredit", pdGLVoucherDtlCredit));
            vlstParam.Add(new SqlParameter("dGLVoucherDtlDebitBase", pdGLVoucherDtlDebitBase));
            vlstParam.Add(new SqlParameter("dGLVoucherDtlCreditBase", pdGLVoucherDtlCreditBase));
            vlstParam.Add(new SqlParameter("dBaseCurrencyValue", pdBaseCurrencyValue));
            vlstParam.Add(new SqlParameter("dGLVoucherDtlPayDebit", pdGLVoucherDtlPayDebit));
            vlstParam.Add(new SqlParameter("dGLVoucherDtlPayCredit", pdGLVoucherDtlPayCredit));
            vlstParam.Add(new SqlParameter("dPayCurrencyValue", pdPayCurrencyValue));
            vlstParam.Add(new SqlParameter("dGLVoucherDtlNote", pdGLVoucherDtlNote));
            vlstParam.Add(new SqlParameter("dCostCenterId", pdCostCenterId));
            vlstParam.Add(new SqlParameter("dIsPosted", pdIsPosted));
            vlstParam.Add(new SqlParameter("dUserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("dGLVoucherDtlTransSeq", pdGLVoucherDtlTransSeq));
            vlstParam.Add(new SqlParameter("dIsDeleted", pdIsDeleted));
            vlstParam.Add(new SqlParameter("dCreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("dCreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("dLastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("dLastUpdatedOn", clsTimeSetting.funBranchTime()));
            
            // Search Parameters
            vlstParam.Add(new SqlParameter("sGLVoucherNo", psGLVoucherNo));
            vlstParam.Add(new SqlParameter("sDateFrom", psDateFrom));
            vlstParam.Add(new SqlParameter("sDateTo", psDateTo));

            // Main Parameters
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("IsGLVoucherDetail", pIsGLVoucherDetail));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));

            vData = _clsADO.funExecuteScalar("ACC.spGLVoucherDoc", vlstParam, "Data GET").ToString();
            return vData;
        }


    }
}