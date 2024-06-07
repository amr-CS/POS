using appSERP.appCode.dbCode.CPanel.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.Company;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using appSERP.appCode.SQL.QueryType;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.GD
{
    public class dbSystem : IdbSystem
    {   // Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbSystem(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funSystemGET(
        int? pSystemId = null,
        string pSystemCode = null,
        string pSystemNameL1 = null,
        string pSystemNameL2 = null,
        string pSystemImageLogo = null,
        string pSystemVersion = null,
        DateTime? pSystemLastUpdated = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("SystemId", pSystemId));
            vlstParam.Add(new SqlParameter("SystemCode", pSystemCode));
            vlstParam.Add(new SqlParameter("SystemNameL1", pSystemNameL1));
            vlstParam.Add(new SqlParameter("SystemNameL2", pSystemNameL2));
            vlstParam.Add(new SqlParameter("SystemImageLogo", pSystemImageLogo));
            vlstParam.Add(new SqlParameter("SystemVersion", pSystemVersion));
            vlstParam.Add(new SqlParameter("SystemLastUpdated", pSystemLastUpdated));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("GD.spSystemCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }

        // System [DataTable
        public DataTable funSystemDataGET()
        {
            // GET System
            string vSystemData = funSystemGET(pQueryTypeId: clsQueryType.qSelect);
            // CONVERT JSON TO DATATABLE
            DataTable vDtSystem = JsonConvert.DeserializeObject<DataTable>(vSystemData);
            // Return Result
            return vDtSystem;
        }
    }
}