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
    public class dbGLVoucherOld : IdbGLVoucherOld
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }
        public object vGLVoucherId { get; set; }

        private IclsADO _clsADO;
        public dbGLVoucherOld(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funGLVoucherGET(
        string pGLVoucherId = null,
        string pGLVoucherCode = null,
        string pGLVoucherNameL1 = null,
        string pGLVoucherNameL2 = null,
        string pGLVoucherNo = null,
        int? pCompanyId = null,
        int? pBranchId = null,
        int? pVoucherTypeId = null,
        int? pFinancialYearId = null,
        int? pSystemId = null,
        int? pCashDeskId = null,
        DateTime? pGLVoucherDate = null,
        DateTime? pGLVoucherTime = null,
        int? pGLVoucherRef = null,
        DateTime? pGLVoucherRefDate = null,
        int? pPaymentTypeId = null,
        bool? pIsPosted = null,
         bool? pIsIssued = null,
        string pGLVoucherNote = null,
        int? pUserId = null,
        string pUserFullNameL1 = null,
        string pUserFullNameL2 = null,
        string pUserName = null,
        bool? pDocIsCancelled = null,
        bool? pDocIsWait = null,
        bool? pGLVoucherIsRepeated = null,
        int? pGLIdPayType = null,
        int? pGLVoucherCategoryId = null,
        decimal? pGLOppsVoucherValue = null,
        int? pGLOppsVoucherId = null,
        int? pGLOppsVoucherYearId = null,
        int? pStoreId = null,
        int? pInvTransactionTypeId = null,
        int? pCSId = null,
        int? pVoucherSeq = null,
        bool? pGLVoucherIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("GLVoucherId", pGLVoucherId));
            vlstParam.Add(new SqlParameter("GLVoucherCode", pGLVoucherCode));
            vlstParam.Add(new SqlParameter("GLVoucherNameL1", pGLVoucherNameL1));
            vlstParam.Add(new SqlParameter("GLVoucherNameL2", pGLVoucherNameL2));
            vlstParam.Add(new SqlParameter("GLVoucherNo", pGLVoucherNo));
            vlstParam.Add(new SqlParameter("BranchId", clsCompany.vBranchId));
            vlstParam.Add(new SqlParameter("VoucherTypeId", pVoucherTypeId));
            vlstParam.Add(new SqlParameter("FinancialYearId", pFinancialYearId));
            vlstParam.Add(new SqlParameter("SystemId", pSystemId));
            vlstParam.Add(new SqlParameter("CashDeskId", pCashDeskId));
            vlstParam.Add(new SqlParameter("GLVoucherDate", pGLVoucherDate));
            vlstParam.Add(new SqlParameter("GLVoucherTime", pGLVoucherTime));
            vlstParam.Add(new SqlParameter("GLVoucherRef", pGLVoucherRef));
            vlstParam.Add(new SqlParameter("GLVoucherRefDate", pGLVoucherRefDate));
            vlstParam.Add(new SqlParameter("PaymentTypeId", pPaymentTypeId));
            vlstParam.Add(new SqlParameter("IsPosted", pIsPosted));
            vlstParam.Add(new SqlParameter("IsIssued", pIsIssued));
            vlstParam.Add(new SqlParameter("GLVoucherNote", pGLVoucherNote));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("UserFullNameL1", clsUser.vUserFullName));
            vlstParam.Add(new SqlParameter("UserFullNameL2", clsUser.vUserFullName));
            vlstParam.Add(new SqlParameter("UserName", clsUser.vUserName));
            vlstParam.Add(new SqlParameter("DocIsCancelled", pDocIsCancelled));
            vlstParam.Add(new SqlParameter("DocIsWait", pDocIsWait));
            vlstParam.Add(new SqlParameter("GLVoucherIsRepeated", pGLVoucherIsRepeated));
            vlstParam.Add(new SqlParameter("GLIdPayType", pGLIdPayType));
            vlstParam.Add(new SqlParameter("GLVoucherCategoryId", pGLVoucherCategoryId));
            vlstParam.Add(new SqlParameter("GLOppsVoucherValue", pGLOppsVoucherValue));
            vlstParam.Add(new SqlParameter("GLOppsVoucherId", pGLOppsVoucherId));
            vlstParam.Add(new SqlParameter("GLOppsVoucherYearId", pGLOppsVoucherYearId));
            vlstParam.Add(new SqlParameter("StoreId", pStoreId));
            vlstParam.Add(new SqlParameter("InvTransactionTypeId", pInvTransactionTypeId));
            vlstParam.Add(new SqlParameter("CSId", pCSId));
            vlstParam.Add(new SqlParameter("VoucherSeq", pVoucherSeq));
            vlstParam.Add(new SqlParameter("GLVoucherIsActive", pGLVoucherIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("ACC.spGLVoucherCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
        public DataTable funGetGlVoucherReport( int? pGLVoucherId = null, int? VoucherTypeId = null , bool? pIsActive = null)
        {
            // Declaration 
            DataTable vData ;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("GLVoucherId", pGLVoucherId));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CompanyId", 1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));
            vlstParam.Add(new SqlParameter("VoucherTypeId", VoucherTypeId));
            vlstParam.Add(new SqlParameter("IsActive", pIsActive));
            //vData = clsADO.funFillDataTable("dbo.spgetVoucher", vlstParam, "Data GET");
            vData = _clsADO.funFillDataTable("ACC.spgetVoucher", vlstParam, "Data GET");


            return vData;
        }
        public DataTable funGetGlVoucherReceiptReport(string pGLVoucherNo = null, bool? pIsActive = null)
        {
            // Declaration 
            DataTable vData;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("GLVoucherNo", pGLVoucherNo));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CompanyId", 1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));
            vlstParam.Add(new SqlParameter("IsActive", pIsActive));
            vData = _clsADO.funFillDataTable("ACC.spGetReceiptVoucher", vlstParam, "Data GET");


            return vData;
        }
        public DataTable funGetGlVoucherPaymentReport(string pGLVoucherNo = null, bool? pIsActive = null)
        {
            // Declaration 
            DataTable vData;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("GLVoucherNo", pGLVoucherNo));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CompanyId", 1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));
            vlstParam.Add(new SqlParameter("IsActive", pIsActive));
            vData = _clsADO.funFillDataTable("ACC.spGetPaymentVoucher", vlstParam, "Data GET");


            return vData;
        }
    }
}