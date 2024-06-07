using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.ADO;
using System.Web;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using appSERP.appCode.dbCode.SYSSETT.Abstract;
using appSERP.appCode.SQL.Abstract;

namespace appSERP.appCode.dbCode.SYSSETT
{
    public class dbCountryType: IdbCountryType
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbCountryType(clsADO clsADO)
        {
            _clsADO = clsADO;
        }
        public string funCountryTypeGET(
        int? pCountryTypeId = null,
        string pCountryTypeCode = null,
        string pCountryTypeNameL1 = null,
        string pCountryTypeNameL2 = null,
        int? pCompanyId = null,
        bool? pCountryTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("CountryTypeId", pCountryTypeId));
            vlstParam.Add(new SqlParameter("CountryTypeCode", pCountryTypeCode));
            vlstParam.Add(new SqlParameter("CountryTypeNameL1", pCountryTypeNameL1));
            vlstParam.Add(new SqlParameter("CountryTypeNameL2", pCountryTypeNameL2));
            vlstParam.Add(new SqlParameter("CompanyId", pCompanyId));
            vlstParam.Add(new SqlParameter("CountryTypeIsActive", pCountryTypeIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("SYSSETT.spCountryTypeCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}