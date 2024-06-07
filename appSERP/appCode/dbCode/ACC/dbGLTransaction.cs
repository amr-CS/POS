using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.Setting.Company;
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

namespace appSERP.appCode.dbCode.ACC
{
    public class dbGLTransaction : IdbGLTransaction
    {
        private IclsADO _clsADO;
        public dbGLTransaction(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string vSQLResult { get; set; }
        public  int vSQLResultTypeId { get; set; }
        public  string funGLTransactionGET(
        int? pTransactionId = null,
        string pTransactionCode = null,
        string pTransactionNameL1 = null,
        string pTransactionNameL2 = null,
        int? pTransactionTypeId = null,
        int? pFinancialYearId = null,
        int? pBranchId = null,
        int? pGLVoucherDtlId = null,
        int? pTransactionSoruceId = null,
        int? pCashDeskId = null,
        int? pAccountId = null,
        int? pTransactionSeq = null,
        int? pTransactionDate = null,
        decimal? pTransactionDebit = null,
        decimal? pTransactionCredit = null,
        decimal? pTransactionDebitBase = null,
        decimal? pTransactionCreditBase = null,
        string pTransactionNote = null,
        int? pIsPosted = null,
        int? pCostCenterId = null,
        string pUserFullName = null,
        string pUserName = null,
        int? pStoreId = null,
        string pTransactionDescription = null,
        int? pTransactionRef = null,
        int? pTransactionSeqDtl = null,
        int? pCurrencyId = null,
        decimal? pTransactionHdDebit = null,
        decimal? pTransactionHdCredit = null,
        string pTransactionHdNote = null,
        int? pCSId = null,
        int? pAccountingPeriodId = null,
        bool? pIsTransfered = null,
        string  pChildAccounts = null,
        bool? pTransactionIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("TransactionId", pTransactionId));
            vlstParam.Add(new SqlParameter("TransactionCode", pTransactionCode));
            vlstParam.Add(new SqlParameter("TransactionNameL1", pTransactionNameL1));
            vlstParam.Add(new SqlParameter("TransactionNameL2", pTransactionNameL2));
            vlstParam.Add(new SqlParameter("TransactionTypeId", pTransactionTypeId));
            vlstParam.Add(new SqlParameter("FinancialYearId", pFinancialYearId));
            vlstParam.Add(new SqlParameter("BranchId", clsCompany.vBranchId));
            vlstParam.Add(new SqlParameter("GLVoucherDtlId", pGLVoucherDtlId));
            vlstParam.Add(new SqlParameter("TransactionSoruceId", pTransactionSoruceId));
            vlstParam.Add(new SqlParameter("CashDeskId", pCashDeskId));
            vlstParam.Add(new SqlParameter("AccountId", pAccountId));
            vlstParam.Add(new SqlParameter("TransactionSeq", pTransactionSeq));
            vlstParam.Add(new SqlParameter("TransactionDate", pTransactionDate));
            vlstParam.Add(new SqlParameter("TransactionDebit", pTransactionDebit));
            vlstParam.Add(new SqlParameter("TransactionCredit", pTransactionCredit));
            vlstParam.Add(new SqlParameter("TransactionDebitBase", pTransactionDebitBase));
            vlstParam.Add(new SqlParameter("TransactionCreditBase", pTransactionCreditBase));
            vlstParam.Add(new SqlParameter("TransactionNote", pTransactionNote));
            vlstParam.Add(new SqlParameter("IsPosted", pIsPosted));
            vlstParam.Add(new SqlParameter("CostCenterId", pCostCenterId));
            vlstParam.Add(new SqlParameter("UserFullName", pUserFullName));
            vlstParam.Add(new SqlParameter("UserName", pUserName));
            vlstParam.Add(new SqlParameter("StoreId", pStoreId));
            vlstParam.Add(new SqlParameter("TransactionDescription", pTransactionDescription));
            vlstParam.Add(new SqlParameter("TransactionRef", pTransactionRef));
            vlstParam.Add(new SqlParameter("TransactionSeqDtl", pTransactionSeqDtl));
            vlstParam.Add(new SqlParameter("CurrencyId", pCurrencyId));
            vlstParam.Add(new SqlParameter("TransactionHdDebit", pTransactionHdDebit));
            vlstParam.Add(new SqlParameter("TransactionHdCredit", pTransactionHdCredit));
            vlstParam.Add(new SqlParameter("TransactionHdNote", pTransactionHdNote));
            vlstParam.Add(new SqlParameter("CSId", pCSId));
            vlstParam.Add(new SqlParameter("AccountingPeriodId", pAccountingPeriodId));
            vlstParam.Add(new SqlParameter("IsTransfered", pIsTransfered)); 
            vlstParam.Add(new SqlParameter("ChildAccounts", pChildAccounts));
            vlstParam.Add(new SqlParameter("TransactionIsActive", pTransactionIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("ACC.spGLTransactionCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }

        public  string funGLTransactionReportGET(
      int? pTransactionId = null,
      string pTransactionCode = null,
      string pTransactionNameL1 = null,
      string pTransactionNameL2 = null,
      int? pTransactionTypeId = null,
      int? pFinancialYearId = null,
      int? pBranchId = null,
      int? pGLVoucherDtlId = null,
      int? pTransactionSoruceId = null,
      int? pCashDeskId = null,
      string pAccountId = null,
      int? pTransactionSeq = null,
      int? pTransactionDate = null,
      decimal? pTransactionDebit = null,
      decimal? pTransactionCredit = null,
      decimal? pTransactionDebitBase = null,
      decimal? pTransactionCreditBase = null,
      string pTransactionNote = null,
      int? pIsPosted = null,
      int? pCostCenterId = null,
      string pUserFullName = null,
      string pUserName = null,
      int? pStoreId = null,
      string pTransactionDescription = null,
      int? pTransactionRef = null,
      int? pTransactionSeqDtl = null,
      int? pCurrencyId = null,
      decimal? pTransactionHdDebit = null,
      decimal? pTransactionHdCredit = null,
      string pTransactionHdNote = null,
      int? pCSId = null,
      int? pAccountingPeriodId = null,
      bool? pIsTransfered = null,
      string pChildAccounts = null,
      bool? pTransactionIsActive = null,
      bool? pIsDeleted = false,
      int? pQueryTypeId = null,
      DateTime? pDateFrom = null,
      DateTime? pDateTo  = null,
      string pAccountFrom = null,
      string pAccountTo  = null
            )
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("TransactionId", pTransactionId));
            vlstParam.Add(new SqlParameter("TransactionCode", pTransactionCode));
            vlstParam.Add(new SqlParameter("TransactionNameL1", pTransactionNameL1));
            vlstParam.Add(new SqlParameter("TransactionNameL2", pTransactionNameL2));
            vlstParam.Add(new SqlParameter("TransactionTypeId", pTransactionTypeId));
            vlstParam.Add(new SqlParameter("FinancialYearId", pFinancialYearId));
            vlstParam.Add(new SqlParameter("BranchId", clsCompany.vBranchId));
            vlstParam.Add(new SqlParameter("GLVoucherDtlId", pGLVoucherDtlId));
            vlstParam.Add(new SqlParameter("TransactionSoruceId", pTransactionSoruceId));
            vlstParam.Add(new SqlParameter("CashDeskId", pCashDeskId));
            vlstParam.Add(new SqlParameter("AccountId", pAccountId));
            vlstParam.Add(new SqlParameter("TransactionSeq", pTransactionSeq));
            vlstParam.Add(new SqlParameter("TransactionDate", pTransactionDate));
            vlstParam.Add(new SqlParameter("TransactionDebit", pTransactionDebit));
            vlstParam.Add(new SqlParameter("TransactionCredit", pTransactionCredit));
            vlstParam.Add(new SqlParameter("TransactionDebitBase", pTransactionDebitBase));
            vlstParam.Add(new SqlParameter("TransactionCreditBase", pTransactionCreditBase));
            vlstParam.Add(new SqlParameter("TransactionNote", pTransactionNote));
            vlstParam.Add(new SqlParameter("IsPosted", pIsPosted));
            vlstParam.Add(new SqlParameter("CostCenterId", pCostCenterId));
            vlstParam.Add(new SqlParameter("UserFullName", pUserFullName));
            vlstParam.Add(new SqlParameter("UserName", pUserName));
            vlstParam.Add(new SqlParameter("StoreId", pStoreId));
            vlstParam.Add(new SqlParameter("TransactionDescription", pTransactionDescription));
            vlstParam.Add(new SqlParameter("TransactionRef", pTransactionRef));
            vlstParam.Add(new SqlParameter("TransactionSeqDtl", pTransactionSeqDtl));
            vlstParam.Add(new SqlParameter("CurrencyId", pCurrencyId));
            vlstParam.Add(new SqlParameter("TransactionHdDebit", pTransactionHdDebit));
            vlstParam.Add(new SqlParameter("TransactionHdCredit", pTransactionHdCredit));
            vlstParam.Add(new SqlParameter("TransactionHdNote", pTransactionHdNote));
            vlstParam.Add(new SqlParameter("CSId", pCSId));
            vlstParam.Add(new SqlParameter("AccountingPeriodId", pAccountingPeriodId));
            vlstParam.Add(new SqlParameter("IsTransfered", pIsTransfered));
            vlstParam.Add(new SqlParameter("ChildAccounts", pChildAccounts));
            vlstParam.Add(new SqlParameter("TransactionIsActive", pTransactionIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vlstParam.Add(new SqlParameter("DateFrom", pDateFrom));
            vlstParam.Add(new SqlParameter("DateTo", pDateTo));
            vlstParam.Add(new SqlParameter("AccountFrom", pAccountFrom));
            vlstParam.Add(new SqlParameter("AccountTo", pAccountTo));
            vData = _clsADO.funExecuteScalar("ACC.spGLTransactionReport", vlstParam, "Data GET").ToString();
            return vData;
        }
        public  DataTable funTransactionReport(int? ItemId = null, DateTime? DateFrom = null, DateTime? DateTo = null, int? InvTypeId = null,
          int? StoreId = null, int? reportTypeId = null)
        {
            // Declaration 
            DataTable vData;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("DateFrom", DateFrom));
            vlstParam.Add(new SqlParameter("DateTo", DateTo));
            vlstParam.Add(new SqlParameter("ItemId", ItemId));
            vlstParam.Add(new SqlParameter("InvTypeId", InvTypeId));
            vlstParam.Add(new SqlParameter("StoreId", StoreId));
            vlstParam.Add(new SqlParameter("reportTypeId", reportTypeId));
            
            vData = _clsADO.funFillDataTable("RES.spTransaction", vlstParam, "Data GET");
            return vData;
        }

        public  DataTable funGetGLTransactionReport( DateTime? pDateFrom = null, DateTime? pDateTo = null, string pChildAccounts = null)
        {
            // Declaration 
            DataTable vData;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("DateFrom", pDateFrom));
            vlstParam.Add(new SqlParameter("DateTo", pDateTo));
            vlstParam.Add(new SqlParameter("ChildAccounts", pChildAccounts));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));

            vData = _clsADO.funFillDataTable("ACC.spGetGLTransactionReport", vlstParam, "Data GET");
            return vData;
        }



        public  DataTable funGetGLTransactionReportTotal(DateTime? pDateFrom = null, DateTime? pDateTo = null, string pChildAccounts = null)
        {
            // Declaration 
            DataTable vData;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("DateFrom", pDateFrom));
            vlstParam.Add(new SqlParameter("DateTo", pDateTo));
            vlstParam.Add(new SqlParameter("ChildAccounts", pChildAccounts));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));

            vData = _clsADO.funFillDataTable("ACC.spGetGLTransactionReportByTotal", vlstParam, "Data GET");


            return vData;
        }
        public  DataTable funGetGLTransactionReportTotalCostCenter(DateTime? pDateFrom = null, DateTime? pDateTo = null, string pChildAccounts = null)
        {
            // Declaration 
            DataTable vData;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("DateFrom", pDateFrom));
            vlstParam.Add(new SqlParameter("DateTo", pDateTo));
            vlstParam.Add(new SqlParameter("ChildAccounts", pChildAccounts));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));

            vData = _clsADO.funFillDataTable("ACC.spGetGLTransactionReportByTotalCostCenter", vlstParam, "Data GET");


            return vData;
        }
        public  DataTable funGetGLTransactionReportDetailsCostCenter(DateTime? pDateFrom = null, DateTime? pDateTo = null, string pChildAccounts = null)
        {
            // Declaration 
            DataTable vData;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("DateFrom", pDateFrom));
            vlstParam.Add(new SqlParameter("DateTo", pDateTo));
            vlstParam.Add(new SqlParameter("ChildAccounts", pChildAccounts));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));

            vData = _clsADO.funFillDataTable("ACC.spGetGLTransactionReportDetailCostCenter", vlstParam, "Data GET");


            return vData;
        }
    }
}