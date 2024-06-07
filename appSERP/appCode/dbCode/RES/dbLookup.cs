using appSERP.appCode.dbCode.RES.Abstract;
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

namespace appSERP.appCode.dbCode.RES
{
    public class dbLookup : IdbLookup
    {
        private IclsADO _clsADO;
        public dbLookup(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funLookupGET(
        int? pLookupId = null,
        int? pLookupParentId = null,
        string pLookupCode = null,
        float? pLookupSeq = null,
        string pLookupDescL1 = null,
        string pLookupDescL2 = null,
        int? pParentId = null,
        int? pLookupGroup = null,
        bool? pLookupStatus = null,
        int? pHC = null,
        string pNotes = null,
        int? pUserPriv = null,
        int? pCompanyId = null,
        int? pParentIdDtl = null,
        bool? pIsDeleted = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pLookupDtlId = null,
        string pdLookupDtlCode = null,
        string pdLookupDtlDesc = null,
        string pdLookupDtlDescL = null,
        string pdLookupDtlDescShort = null,
        string pdLookupDtlDescShortL = null,
        string pdLookupDtlDesc2 = null,
        string pdLookupDtlDesc2L = null,
        float? pdLookupDtlSeq = null,
        float? pdTypeSeq = null,
        int? pdORD = null,
        bool? pdDflt = null,
        bool? pdLookupDtlStatus = null,
        string pdNotes = null,
        decimal? pdValue1 = null,
        decimal? pdValue2 = null,
        decimal? pdValue3 = null,
        int? pdValLink = null,
        DateTime? pdDate1 = null,
        DateTime? pdDate2 = null,
        string pdText = null,
        string pdAccountId = null,
        string pdAccountId2 = null,
        bool? pdIsDeleted = null,
        int? pLanguageId = null,
        bool? pIsDetail = null,
        int? pQueryTypeId = null,
        string pSelectList = null,
        int?BranchId=null

        )
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("LookupId", pLookupId));
            vlstParam.Add(new SqlParameter("LookupParentId", pLookupParentId));
            vlstParam.Add(new SqlParameter("LookupCode", pLookupCode));
            vlstParam.Add(new SqlParameter("LookupSeq", pLookupSeq));
            vlstParam.Add(new SqlParameter("LookupDescL1", pLookupDescL1));
            vlstParam.Add(new SqlParameter("LookupDescL2", pLookupDescL2));
            vlstParam.Add(new SqlParameter("ParentId", pParentId));
            vlstParam.Add(new SqlParameter("LookupGroup", pLookupGroup));
            vlstParam.Add(new SqlParameter("LookupStatus", pLookupStatus));
            vlstParam.Add(new SqlParameter("HC", pHC));
            vlstParam.Add(new SqlParameter("Notes", pNotes));
            vlstParam.Add(new SqlParameter("UserPriv", pUserPriv));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("ParentIdDtl", pParentIdDtl));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LookupDtlId", pLookupDtlId));
            vlstParam.Add(new SqlParameter("dLookupDtlCode", pdLookupDtlCode));
            vlstParam.Add(new SqlParameter("dLookupDtlDesc", pdLookupDtlDesc));
            vlstParam.Add(new SqlParameter("dLookupDtlDescL", pdLookupDtlDescL));
            vlstParam.Add(new SqlParameter("dLookupDtlDescShort", pdLookupDtlDescShort));
            vlstParam.Add(new SqlParameter("dLookupDtlDescShortL", pdLookupDtlDescShortL));
            vlstParam.Add(new SqlParameter("dLookupDtlDesc2", pdLookupDtlDesc2));
            vlstParam.Add(new SqlParameter("dLookupDtlDesc2L", pdLookupDtlDesc2L));
            vlstParam.Add(new SqlParameter("dLookupDtlSeq", pdLookupDtlSeq));
            vlstParam.Add(new SqlParameter("dTypeSeq", pdTypeSeq));
            vlstParam.Add(new SqlParameter("dORD", pdORD));
            vlstParam.Add(new SqlParameter("dDflt", pdDflt));
            vlstParam.Add(new SqlParameter("dLookupDtlStatus", pdLookupDtlStatus));
            vlstParam.Add(new SqlParameter("dNotes", pdNotes));
            vlstParam.Add(new SqlParameter("dValue1", pdValue1));
            vlstParam.Add(new SqlParameter("dValue2", pdValue2));
            vlstParam.Add(new SqlParameter("dValue3", pdValue3));
            vlstParam.Add(new SqlParameter("dValLink", pdValLink));
            vlstParam.Add(new SqlParameter("dDate1", pdDate1));
            vlstParam.Add(new SqlParameter("dDate2", pdDate2));
            vlstParam.Add(new SqlParameter("dText", pdText));
            vlstParam.Add(new SqlParameter("dAccountId", pdAccountId));
            vlstParam.Add(new SqlParameter("dAccountId2", pdAccountId2));
            vlstParam.Add(new SqlParameter("dIsDeleted", pdIsDeleted));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("IsDetail", pIsDetail));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vlstParam.Add(new SqlParameter("SelectList", pSelectList));
            vlstParam.Add(new SqlParameter("BranchId", BranchId));
            vData = _clsADO.funExecuteScalar("RES.spLookupCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
        public DataTable funGetLookupReport()
        {
            // Declaration 
            DataTable vData;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();

            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));

            vData = _clsADO.funFillDataTable("RES.spLookupReport", vlstParam, "Data GET");
            return vData;
        }


        public DataTable funtblLookupGET(
        int? pLookupId = null,
        int? pLookupParentId = null,
        string pLookupCode = null,
        float? pLookupSeq = null,
        string pLookupDescL1 = null,
        string pLookupDescL2 = null,
        int? pParentId = null,
        int? pLookupGroup = null,
        bool? pLookupStatus = null,
        int? pHC = null,
        string pNotes = null,
        int? pUserPriv = null,
        int? pCompanyId = null,
        int? pParentIdDtl = null,
        bool? pIsDeleted = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pLookupDtlId = null,
        string pdLookupDtlCode = null,
        string pdLookupDtlDesc = null,
        string pdLookupDtlDescL = null,
        string pdLookupDtlDescShort = null,
        string pdLookupDtlDescShortL = null,
        string pdLookupDtlDesc2 = null,
        string pdLookupDtlDesc2L = null,
        float? pdLookupDtlSeq = null,
        float? pdTypeSeq = null,
        int? pdORD = null,
        bool? pdDflt = null,
        bool? pdLookupDtlStatus = null,
        string pdNotes = null,
        decimal? pdValue1 = null,
        decimal? pdValue2 = null,
        decimal? pdValue3 = null,
        int? pdValLink = null,
        DateTime? pdDate1 = null,
        DateTime? pdDate2 = null,
        string pdText = null,
        string pdAccountId = null,
        string pdAccountId2 = null,
        bool? pdIsDeleted = null,
        int? pLanguageId = null,
        bool? pIsDetail = null,
        int? pQueryTypeId = null,
        string pSelectList = null,
        int? BranchId = null

        )
        {
            // Declaration 
            DataTable vData = null;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("LookupId", pLookupId));
            vlstParam.Add(new SqlParameter("LookupParentId", pLookupParentId));
            vlstParam.Add(new SqlParameter("LookupCode", pLookupCode));
            vlstParam.Add(new SqlParameter("LookupSeq", pLookupSeq));
            vlstParam.Add(new SqlParameter("LookupDescL1", pLookupDescL1));
            vlstParam.Add(new SqlParameter("LookupDescL2", pLookupDescL2));
            vlstParam.Add(new SqlParameter("ParentId", pParentId));
            vlstParam.Add(new SqlParameter("LookupGroup", pLookupGroup));
            vlstParam.Add(new SqlParameter("LookupStatus", pLookupStatus));
            vlstParam.Add(new SqlParameter("HC", pHC));
            vlstParam.Add(new SqlParameter("Notes", pNotes));
            vlstParam.Add(new SqlParameter("UserPriv", pUserPriv));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("ParentIdDtl", pParentIdDtl));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LookupDtlId", pLookupDtlId));
            vlstParam.Add(new SqlParameter("dLookupDtlCode", pdLookupDtlCode));
            vlstParam.Add(new SqlParameter("dLookupDtlDesc", pdLookupDtlDesc));
            vlstParam.Add(new SqlParameter("dLookupDtlDescL", pdLookupDtlDescL));
            vlstParam.Add(new SqlParameter("dLookupDtlDescShort", pdLookupDtlDescShort));
            vlstParam.Add(new SqlParameter("dLookupDtlDescShortL", pdLookupDtlDescShortL));
            vlstParam.Add(new SqlParameter("dLookupDtlDesc2", pdLookupDtlDesc2));
            vlstParam.Add(new SqlParameter("dLookupDtlDesc2L", pdLookupDtlDesc2L));
            vlstParam.Add(new SqlParameter("dLookupDtlSeq", pdLookupDtlSeq));
            vlstParam.Add(new SqlParameter("dTypeSeq", pdTypeSeq));
            vlstParam.Add(new SqlParameter("dORD", pdORD));
            vlstParam.Add(new SqlParameter("dDflt", pdDflt));
            vlstParam.Add(new SqlParameter("dLookupDtlStatus", pdLookupDtlStatus));
            vlstParam.Add(new SqlParameter("dNotes", pdNotes));
            vlstParam.Add(new SqlParameter("dValue1", pdValue1));
            vlstParam.Add(new SqlParameter("dValue2", pdValue2));
            vlstParam.Add(new SqlParameter("dValue3", pdValue3));
            vlstParam.Add(new SqlParameter("dValLink", pdValLink));
            vlstParam.Add(new SqlParameter("dDate1", pdDate1));
            vlstParam.Add(new SqlParameter("dDate2", pdDate2));
            vlstParam.Add(new SqlParameter("dText", pdText));
            vlstParam.Add(new SqlParameter("dAccountId", pdAccountId));
            vlstParam.Add(new SqlParameter("dAccountId2", pdAccountId2));
            vlstParam.Add(new SqlParameter("dIsDeleted", pdIsDeleted));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("IsDetail", pIsDetail));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vlstParam.Add(new SqlParameter("SelectList", pSelectList));
            vlstParam.Add(new SqlParameter("BranchId", BranchId));
            vData = _clsADO.funFillDataTable("RES.spLookupCRUD", vlstParam, "Data GET");
            return vData;
        }
    }
}