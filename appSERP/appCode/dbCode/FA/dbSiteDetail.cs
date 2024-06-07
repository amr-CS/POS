using appSERP.appCode.dbCode.FA.Abstract;
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
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace appSERP.appCode.dbCode.FA
{
    public class dbSiteDetail : IdbSiteDetail
    {
        // Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbSiteDetail(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funSiteDetailGET(
        int? pSiteDetailId = null,
        string pSiteDetailNameL1 = null,
        string pSiteDetailNameL2 = null,
         int? pSiteDetailLat = null,
        int? pCompanyId = null,
        int? pSiteDetailLng = null,
        int? pSiteId = null,
        bool? pSiteDetailIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("SiteDetailId", pSiteDetailId));
            vlstParam.Add(new SqlParameter("SiteDetailNameL1", pSiteDetailNameL1));
            vlstParam.Add(new SqlParameter("SiteDetailNameL2", pSiteDetailNameL2));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("SiteDetailLat", pSiteDetailLat));
            vlstParam.Add(new SqlParameter("SiteDetailLng", pSiteDetailLng));
            vlstParam.Add(new SqlParameter("SiteId", pSiteId));
            vlstParam.Add(new SqlParameter("SiteDetailIsActive", pSiteDetailIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("FA.spSiteDetailCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
        public DataTable funGetSiteDetailReport(bool? pIsActive = null)
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

            vData = _clsADO.funFillDataTable("FA.spSiteDetailReport", vlstParam, "Data GET");


            return vData;
        }
    }
}
