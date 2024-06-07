using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.ACC
{
    public class dbCommunicationType: IdbCommunicationType
    {
        // Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbCommunicationType(clsADO clsADO)
        {
            _clsADO = clsADO;
        }
        public string funCommunicationTypeGET(
        int? pTypeId = null,
        string pTypeCode = null,
        string pTypeNameL1 = null,
        string pTypeNameL2 = null,
        bool? pTypeIsActive = null,
         bool? pIsDeleted = null,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();

            vlstParam.Add(new SqlParameter("TypeId", pTypeId));
            vlstParam.Add(new SqlParameter("TypeCode", pTypeCode));
            vlstParam.Add(new SqlParameter("TypeNameL1", pTypeNameL1));
            vlstParam.Add(new SqlParameter("TypeNameL2", pTypeNameL2));
            vlstParam.Add(new SqlParameter("TypeIsActive", pTypeIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("ACC.spCommunicationTypeCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}