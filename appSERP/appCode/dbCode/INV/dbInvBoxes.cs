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
    public class dbInvBoxes: IdbInvBoxes
    {
        private IclsADO _clsADO;
        public dbInvBoxes(clsADO clsADO)
        {
            _clsADO = clsADO;
        }


        public string funBoxGET(
        int? pBoxId = null,
        string pBoxCode = null,
        int? pInvId = null,
        int? pInvType = null,
        int? pYear = null,
        int? pBoxDtlId = null,
        int? pAccountId = null,
        int? pCostCenterId = null,
        float? pBoxCredit = null,
        float? pBoxDebit = null,
        float? pCurValue = null,
        float? pBoxBaseCredit = null,
        float? pBoxBaseDebit = null,
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
            vlstParam.Add(new SqlParameter("BoxId", pBoxId));
            vlstParam.Add(new SqlParameter("BoxCode", pBoxCode));
            vlstParam.Add(new SqlParameter("InvId", pInvId));
            vlstParam.Add(new SqlParameter("InvType", pInvType));
            vlstParam.Add(new SqlParameter("Year", pYear));
            vlstParam.Add(new SqlParameter("BoxDtlId", pBoxDtlId));
            vlstParam.Add(new SqlParameter("AccountId", pAccountId));
            vlstParam.Add(new SqlParameter("CostCenterId", pCostCenterId));
            vlstParam.Add(new SqlParameter("BoxCredit", pBoxCredit));
            vlstParam.Add(new SqlParameter("BoxDebit", pBoxDebit));
            vlstParam.Add(new SqlParameter("CurValue", pCurValue));
            vlstParam.Add(new SqlParameter("BoxBaseCredit", pBoxBaseCredit));
            vlstParam.Add(new SqlParameter("BoxBaseDebit", pBoxBaseDebit));
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
            vData = _clsADO.funExecuteScalar("INV.spBoxCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}