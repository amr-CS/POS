using appSERP.appCode.dbCode.INV.Abstract;
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

namespace appSERP.appCode.dbCode.INV
{
    public class dbOfferType : IdbOfferType
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbOfferType(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funOfferTypeGET(

        int? pOfferTypeId = null,
        string pOfferTypeCode = null,
        string pOfferTypeNameL1 = null,
        string pOfferTypeNameL2 = null,
        string pAbbr = null,
        bool? pIsDefault = null,
        int? pBranchId = null,
        bool? pOfferTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("OfferTypeId", pOfferTypeId));
            vlstParam.Add(new SqlParameter("OfferTypeCode", pOfferTypeCode));
            vlstParam.Add(new SqlParameter("OfferTypeNameL1", pOfferTypeNameL1));
            vlstParam.Add(new SqlParameter("OfferTypeNameL2", pOfferTypeNameL2));
            vlstParam.Add(new SqlParameter("Abbr", pAbbr));
            vlstParam.Add(new SqlParameter("IsDefault", pIsDefault));
            vlstParam.Add(new SqlParameter("OfferTypeIsActive", pOfferTypeIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("BranchId", clsCompany.vBranchId));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("INV.spOfferTypeCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
        public DataTable funGetOfferTypeReport(bool? pIsActive = null)
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
            vlstParam.Add(new SqlParameter("IsActive", pIsActive));

            vData = _clsADO.funFillDataTable("INV.spOfferTypeReport", vlstParam, "Data GET");


            return vData;
        }
    }
}