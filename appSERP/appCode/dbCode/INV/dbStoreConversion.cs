using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.Setting.Company;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using appSERP.appCode.Utils;
using appSERP.Models.INV;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.INV
{
    public class dbStoreConversion: IdbStoreConversion
    {

        private IclsADO _clsADO;
        public dbStoreConversion(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funStoreConversionGET(
        int? pStoreConversionId = null,
        int? pStoreConversionCode = null,
        int? pSourceBranchId = null,
        int? pTargetBranchId = null,
        int? pStoreId = null,
        int? pStoreConversionType = null,
        int? pStoreConversionYear = null,
        DateTime? pStoreConversionDate = null,
        int? pSourceStoreId = null,
        string pNotes = null,
        int? pReqId = null,
        int? pReqYear = null,
        float? pReceivedQty = null,
        string pReceivedUser = null,
        DateTime? pReceivedDate = null,
        bool? pStoreConversionIsActive = null,
        bool? pIsDeleted = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pStoreConversionDtlId = null,
        int? pdStoreId = null,
        int? pdStoreConversionId = null,
        int? pdStoreConversionType = null,
        int? pdStoreConversionYear = null,
        int? pdSoureStoreType = null,
        int? pdItemId = null,
        int? pdUnitId = null,
        DateTime? pdExpireDate = null,
        int? pdStoreSectId = null,
        float? pdItemQty = null,
        string pdNotes = null,
        bool? pdIsDeleted = null,
        int? pdCreatedBy = null,
        DateTime? pdCreatedOn = null,
        int? pdLastUpdatedBy = null,
        DateTime? pdLastUpdatedOn = null,
        int? pLanguageId = null,
        int? pCompanyId = null,
        bool? pIsStoreConversionDetail = null,
        int? pQueryTypeId = null,
        string pLstStores = null,
        string pLstSource = null,
        string pLstConversionId = null,
        string pSearchDate = null

        )
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("StoreConversionId", pStoreConversionId));
            vlstParam.Add(new SqlParameter("StoreConversionCode", pStoreConversionCode));
            vlstParam.Add(new SqlParameter("SourceBranchId", pSourceBranchId));
            vlstParam.Add(new SqlParameter("TargetBranchId", pTargetBranchId));
            vlstParam.Add(new SqlParameter("StoreId", pStoreId));
            vlstParam.Add(new SqlParameter("StoreConversionType", pStoreConversionType));
            vlstParam.Add(new SqlParameter("StoreConversionYear", pStoreConversionYear));
            vlstParam.Add(new SqlParameter("StoreConversionDate", pStoreConversionDate));
            vlstParam.Add(new SqlParameter("SourceStoreId", pSourceStoreId));
            vlstParam.Add(new SqlParameter("Notes", pNotes));
            vlstParam.Add(new SqlParameter("ReqId", pReqId));
            vlstParam.Add(new SqlParameter("ReqYear", pReqYear));
            vlstParam.Add(new SqlParameter("ReceivedQty", pReceivedQty));
            vlstParam.Add(new SqlParameter("ReceivedUser", pReceivedUser));
            vlstParam.Add(new SqlParameter("ReceivedDate", pReceivedDate));
            vlstParam.Add(new SqlParameter("StoreConversionIsActive", pStoreConversionIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("StoreConversionDtlId", pStoreConversionDtlId));
            vlstParam.Add(new SqlParameter("dStoreId", pdStoreId));
            vlstParam.Add(new SqlParameter("dStoreConversionId", pdStoreConversionId));
            vlstParam.Add(new SqlParameter("dStoreConversionType", pdStoreConversionType));
            vlstParam.Add(new SqlParameter("dStoreConversionYear", pdStoreConversionYear));
            vlstParam.Add(new SqlParameter("dSoureStoreType", pdSoureStoreType));
            vlstParam.Add(new SqlParameter("dItemId", pdItemId));
            vlstParam.Add(new SqlParameter("dUnitId", pdUnitId));
            vlstParam.Add(new SqlParameter("dExpireDate", pdExpireDate));
            vlstParam.Add(new SqlParameter("dStoreSectId", pdStoreSectId));
            vlstParam.Add(new SqlParameter("dItemQty", pdItemQty));
            vlstParam.Add(new SqlParameter("dNotes", pdNotes));
            vlstParam.Add(new SqlParameter("dIsDeleted", pdIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", pCreatedBy));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", pLastUpdatedBy));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("IsStoreConversionDetail", pIsStoreConversionDetail));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vlstParam.Add(new SqlParameter("LstStores", pLstStores));
            vlstParam.Add(new SqlParameter("LstSource", pLstSource));
            vlstParam.Add(new SqlParameter("LstConversionId", pLstConversionId));
            vlstParam.Add(new SqlParameter("SearchDate", pSearchDate));



            vData = _clsADO.funExecuteScalar("INV.spStoreConversionCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }

        public object spStoreConversionBulk(ICollection<StoreConversion>  storeConversion, int? StoreConversionId, int? SourceBranchId, int? TargetBranchId, int? StoreId, DateTime? StoreConversionDate,
             int? SourceStoreId, string Notes, bool? StoreConversionIsActive, bool? IsDeleted, int? CreatedBy, int? LastUpdatedBy,int ?branchId)
        {
            CustomXmlWriter xmlWriter = new CustomXmlWriter();
            string xml = xmlWriter.GetXml("StoreConversionDtls", storeConversion);
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("StoreConversionId", StoreConversionId));
            vlstParam.Add(new SqlParameter("SourceBranchId", SourceBranchId));
            vlstParam.Add(new SqlParameter("TargetBranchId", TargetBranchId));
            vlstParam.Add(new SqlParameter("StoreId", StoreId));
            vlstParam.Add(new SqlParameter("StoreConversionDate", StoreConversionDate));
            vlstParam.Add(new SqlParameter("SourceStoreId", SourceStoreId));
            vlstParam.Add(new SqlParameter("Notes", Notes));
            vlstParam.Add(new SqlParameter("StoreConversionIsActive", StoreConversionIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", IsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", CreatedBy));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", LastUpdatedBy));
            vlstParam.Add(new SqlParameter("BranchId", branchId));
            vlstParam.Add(new SqlParameter("StoreConversionDtls", xml));
            return _clsADO.funExecuteScalar("[INV].[spStoreConversion_Bulk]", vlstParam, "Data GET");
        }
        public DataTable funGetStoreConversionReport(int? pStoreConversionId = null, bool? pIsActive = null)
        {
            // Declaration 
            DataTable vData;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("StoreConversionId", pStoreConversionId));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CompanyId", 1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));
            vlstParam.Add(new SqlParameter("IsActive", pIsActive));
            vData = _clsADO.funFillDataTable("INV.spStoreConversionReport", vlstParam, "Data GET");


            return vData;
        }
    }
}