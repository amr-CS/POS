using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.RES
{
    public class dbPortType : IdbPortType
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbPortType(clsADO clsADO)
        {
            _clsADO = clsADO;
        }
        public string funPortTypeGET(
        int? pPortTypeId = null,
        string pPortTypeCode = null,
        string pPortTypeNameL1 = null,
        string pPortTypeNameL2 = null,
        bool? pPortTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("PortTypeId", pPortTypeId));
            vlstParam.Add(new SqlParameter("PortTypeCode", pPortTypeCode));
            vlstParam.Add(new SqlParameter("PortTypeNameL1", pPortTypeNameL1));
            vlstParam.Add(new SqlParameter("PortTypeNameL2", pPortTypeNameL2));
            vlstParam.Add(new SqlParameter("PortTypeIsActive", pPortTypeIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("RES.spPortTypeCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}