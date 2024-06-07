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
    public class dbArea: IdbArea
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbArea(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funAreaGET(
        int? pAreaId = null,
           string pAreaCode = null,
        string pAreaNameL1 = null,
        string pAreaNameL2 = null,
        int? pCityId = null,
        bool? pAreaIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("AreaId", pAreaId));
            vlstParam.Add(new SqlParameter("AreaCode", pAreaCode));
            vlstParam.Add(new SqlParameter("AreaNameL1", pAreaNameL1));
            vlstParam.Add(new SqlParameter("AreaNameL2", pAreaNameL2));
            vlstParam.Add(new SqlParameter("CityId", pCityId));
            vlstParam.Add(new SqlParameter("AreaIsActive", pAreaIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("SETT.spAreaCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}