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
    public class dbInvType : IdbInvType
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbInvType(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funInvTypeGET(
        int? pInvTypeId = null,
        string pInvTypeCode = null,
        string pInvTypeNameL1 = null,
        string pInvTypeNameL2 = null,
        bool? pInvTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("InvTypeId", pInvTypeId));
            vlstParam.Add(new SqlParameter("InvTypeCode", pInvTypeCode));
            vlstParam.Add(new SqlParameter("InvTypeNameL1", pInvTypeNameL1));
            vlstParam.Add(new SqlParameter("InvTypeNameL2", pInvTypeNameL2));
            vlstParam.Add(new SqlParameter("InvTypeIsActive", pInvTypeIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("RES.spInvTypeCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}