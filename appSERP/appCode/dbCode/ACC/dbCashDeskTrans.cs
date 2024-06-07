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
    public class dbCashDeskTrans: IdbCashDeskTrans
    {
        // System Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }
        public object vCashDeskTransId { get; set; }
        public bool vIsCashDeskTransIn { get; set; }

        private IclsADO _clsADO;
        public dbCashDeskTrans(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funCashDeskTransGET(
        string pCashDeskTransId = null,
        string pCashDeskTransCode = null,
        string pCashDeskTransNameL1 = null,
        string pCashDeskTransNameL2 = null,
        string pCashDeskTransNo = null,
        int? pCompanyId = null,
        int? pBranchId = null,
        int? pVoucherTypeId = null,
        int? pFinancialYearId = null,
        int? pSystemId = null,
        int? pCashDeskId = null,
        int? pMainCashDeskId = null,
        string pGLVoucherId = null,
        DateTime? pCashDeskTransDate = null,
        DateTime? pCashDeskTransTime = null,
        int? pCashDeskTransRef = null,
        DateTime? pCashDeskTransRefDate = null,
        int? pPaymentTypeId = null,
        bool? pIsPosted = null,
        bool? pIsIssued = null,
        bool? pDateFrom = null,
        bool? pDateTo = null,
        bool? pIsCashDeskIn = null,
        string pCashDeskTransNote = null,
        int? pUserId = null,
        string pUserFullNameL1 = null,
        string pUserFullNameL2 = null,
        string pUserName = null,
        bool? pDocIsCancelled = null,
        bool? pDocIsWait = null,
        bool? pCashDeskTransIsRepeated = null,
        int? pGLIdPayType = null,
        int? pCashDeskTransCategoryId = null,
        decimal? pGLOppsVoucherValue = null,
        int? pGLOppsVoucherId = null,
        int? pGLOppsVoucherYearId = null,
        int? pStoreId = null,
        int? pInvTransactionTypeId = null,
        int? pCSId = null,
        int? pVoucherSeq = null,
        bool? pCashDeskTransIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("CashDeskTransId", pCashDeskTransId));
            vlstParam.Add(new SqlParameter("CashDeskTransCode", pCashDeskTransCode));
            vlstParam.Add(new SqlParameter("CashDeskTransNameL1", pCashDeskTransNameL1));
            vlstParam.Add(new SqlParameter("CashDeskTransNameL2", pCashDeskTransNameL2));
            vlstParam.Add(new SqlParameter("CashDeskTransNo", pCashDeskTransNo));
            vlstParam.Add(new SqlParameter("BranchId", clsCompany.vBranchId));
            vlstParam.Add(new SqlParameter("VoucherTypeId", pVoucherTypeId));
            vlstParam.Add(new SqlParameter("FinancialYearId", pFinancialYearId));
            vlstParam.Add(new SqlParameter("SystemId", pSystemId));
            vlstParam.Add(new SqlParameter("CashDeskId", pCashDeskId));
            vlstParam.Add(new SqlParameter("IsCashDeskIn", pIsCashDeskIn));
            vlstParam.Add(new SqlParameter("MainCashDeskId", pMainCashDeskId));
            vlstParam.Add(new SqlParameter("GLVoucherId", pGLVoucherId));
            vlstParam.Add(new SqlParameter("CashDeskTransDate", pCashDeskTransDate));
            vlstParam.Add(new SqlParameter("CashDeskTransTime", pCashDeskTransTime));
            vlstParam.Add(new SqlParameter("CashDeskTransRef", pCashDeskTransRef));
            vlstParam.Add(new SqlParameter("CashDeskTransRefDate", pCashDeskTransRefDate));
            vlstParam.Add(new SqlParameter("PaymentTypeId", pPaymentTypeId));
            vlstParam.Add(new SqlParameter("IsPosted", pIsPosted));
            vlstParam.Add(new SqlParameter("IsIssued", pIsIssued));
            vlstParam.Add(new SqlParameter("DateFrom", pDateFrom));
            vlstParam.Add(new SqlParameter("DateTo", pDateTo));
            vlstParam.Add(new SqlParameter("CashDeskTransNote", pCashDeskTransNote));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("UserFullNameL1", clsUser.vUserFullName));
            vlstParam.Add(new SqlParameter("UserFullNameL2", clsUser.vUserFullName));
            vlstParam.Add(new SqlParameter("UserName", clsUser.vUserName));
            vlstParam.Add(new SqlParameter("DocIsCancelled", pDocIsCancelled));
            vlstParam.Add(new SqlParameter("DocIsWait", pDocIsWait));
            vlstParam.Add(new SqlParameter("CashDeskTransIsRepeated", pCashDeskTransIsRepeated));
            vlstParam.Add(new SqlParameter("GLIdPayType", pGLIdPayType));
            vlstParam.Add(new SqlParameter("CashDeskTransCategoryId", pCashDeskTransCategoryId));
            vlstParam.Add(new SqlParameter("GLOppsVoucherValue", pGLOppsVoucherValue));
            vlstParam.Add(new SqlParameter("GLOppsVoucherId", pGLOppsVoucherId));
            vlstParam.Add(new SqlParameter("GLOppsVoucherYearId", pGLOppsVoucherYearId));
            vlstParam.Add(new SqlParameter("StoreId", pStoreId));
            vlstParam.Add(new SqlParameter("InvTransactionTypeId", pInvTransactionTypeId));
            vlstParam.Add(new SqlParameter("CSId", pCSId));
            vlstParam.Add(new SqlParameter("VoucherSeq", pVoucherSeq));
            vlstParam.Add(new SqlParameter("CashDeskTransIsActive", pCashDeskTransIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("ACC.spCashDeskTransCRUD", vlstParam, "Data GET").ToString();
            return vData;

        }
    }
}