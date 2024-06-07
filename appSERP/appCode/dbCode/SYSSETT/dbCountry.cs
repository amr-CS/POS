using appSERP.appCode.dbCode.SYSSETT.Abstract;
using appSERP.appCode.Setting.Company;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;

namespace appSERP.appCode.dbCode.SYSSETT
{
    public class dbCountry: IdbCountry
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbCountry(clsADO clsADO)
        {
            _clsADO = clsADO;
        }
        public string funCountryGET(
        int? pCountryId = null,
        string pCountryCode = null,
        string pCountryNameL1 = null,
        string pCountryNameL2 = null,
        string pCountryPhoneCode = null,
        string pCountryNationalityNameL1 = null,
        string pCountryNationalityNameL2 = null,
        string pCountryImage = null,
        int? pCountryTypeId = null,
        int? pCompanyId = null,
        bool? pCountryIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("CountryId", pCountryId));
            vlstParam.Add(new SqlParameter("CountryCode", pCountryCode));
            vlstParam.Add(new SqlParameter("CountryNameL1", pCountryNameL1));
            vlstParam.Add(new SqlParameter("CountryNameL2", pCountryNameL2));
            vlstParam.Add(new SqlParameter("CountryPhoneCode", pCountryPhoneCode));
            vlstParam.Add(new SqlParameter("CountryNationalityNameL1", pCountryNationalityNameL1));
            vlstParam.Add(new SqlParameter("CountryNationalityNameL2", pCountryNationalityNameL2));
            vlstParam.Add(new SqlParameter("CountryImage", pCountryImage));
            vlstParam.Add(new SqlParameter("CountryTypeId", pCountryTypeId));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("CountryIsActive", pCountryIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("SYSSETT.spCountryCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}