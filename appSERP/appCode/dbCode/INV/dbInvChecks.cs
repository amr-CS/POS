using appSERP.appCode.dbCode.INV.Abstract;
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

namespace appSERP.appCode.dbCode.INV
{
    public class dbInvChecks: IdbInvChecks
    {
        private IclsADO _clsADO;
        public dbInvChecks(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funCheckGET(
        int? pCheckId = null,
        string pCheckCode = null,
        int? pInvId = null,
        int? pInvType = null,
        int? pYear = null,
        int? pCheckDtlId = null,
        int? pAccountId = null,
        int? pBankId = null,
        int? pBranchId = null,
        int? pCheckNo = null,
        DateTime? pCheckPayDate = null,
        int? pCostCenterId = null,
        float? pCheckCredit = null,
        float? pCheckDebit = null,
        float? pCurValue = null,
        float? pCheckBaseCredit = null,
        float? pCheckBaseDebit = null,
        bool? pIsPosted = null,
        bool? pPosting = null,
        int? pStoreId = null,
        string pNotes = null,
        float? pTransSeq = null,
        int? pCompanyId = null,
        bool? pIsDeleted = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pLanguageId = null,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("CheckId", pCheckId));
            vlstParam.Add(new SqlParameter("CheckCode", pCheckCode));
            vlstParam.Add(new SqlParameter("InvId", pInvId));
            vlstParam.Add(new SqlParameter("InvType", pInvType));
            vlstParam.Add(new SqlParameter("Year", pYear));
            vlstParam.Add(new SqlParameter("CheckDtlId", pCheckDtlId));
            vlstParam.Add(new SqlParameter("AccountId", pAccountId));
            vlstParam.Add(new SqlParameter("BankId", pBankId));
            vlstParam.Add(new SqlParameter("BranchId", pBranchId));
            vlstParam.Add(new SqlParameter("CheckNo", pCheckNo));
            vlstParam.Add(new SqlParameter("CheckPayDate", pCheckPayDate));
            vlstParam.Add(new SqlParameter("CostCenterId", pCostCenterId));
            vlstParam.Add(new SqlParameter("CheckCredit", pCheckCredit));
            vlstParam.Add(new SqlParameter("CheckDebit", pCheckDebit));
            vlstParam.Add(new SqlParameter("CurValue", pCurValue));
            vlstParam.Add(new SqlParameter("CheckBaseCredit", pCheckBaseCredit));
            vlstParam.Add(new SqlParameter("CheckBaseDebit", pCheckBaseDebit));
            vlstParam.Add(new SqlParameter("IsPosted", pIsPosted));
            vlstParam.Add(new SqlParameter("Posting", pPosting));
            vlstParam.Add(new SqlParameter("StoreId", pStoreId));
            vlstParam.Add(new SqlParameter("Notes", pNotes));
            vlstParam.Add(new SqlParameter("TransSeq", pTransSeq));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("INV.spCheckCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}