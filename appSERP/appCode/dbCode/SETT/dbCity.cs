using appSERP.appCode.dbCode.SETT.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.APIDirectory;
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

namespace appSERP.appCode.dbCode.SETT
{
    public class dbCity: IdbCity
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbCity(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funCityGET(
        int? pCityId = null,
        string pCityCode = null,
        string pCityNameL1 = null,
        string pCityNameL2 = null,
        int? pCountryId = null,
        string pCityCenterLat = null,
        string pCityCenterLng = null,
        bool? pCityIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("CityId", pCityId));
            vlstParam.Add(new SqlParameter("CityCode", pCityCode));
            vlstParam.Add(new SqlParameter("CityNameL1", pCityNameL1));
            vlstParam.Add(new SqlParameter("CityNameL2", pCityNameL2));
            vlstParam.Add(new SqlParameter("CountryId", pCountryId));
            vlstParam.Add(new SqlParameter("CityCenterLat", pCityCenterLat));
            vlstParam.Add(new SqlParameter("CityCenterLng", pCityCenterLng));
            vlstParam.Add(new SqlParameter("CityIsActive", pCityIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("SETT.spCityCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}