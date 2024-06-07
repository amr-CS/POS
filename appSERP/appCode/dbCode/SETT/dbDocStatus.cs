using appSERP.appCode.dbCode.SETT.Abstract;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace appSERP.appCode.dbCode.SETT
{
    public class dbDocStatus: IdbDocStatus
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbDocStatus(clsADO clsADO)
        {
            _clsADO = clsADO;
        }
        public string funDocStatusGET(
        int? pDocStatusId = null,
        string pDocStatusCode = null,
        string pDocStatusNameL1 = null,
        string pDocStatusNameL2 = null,
        bool? pDocStatusIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("DocStatusId", pDocStatusId));
            vlstParam.Add(new SqlParameter("DocStatusCode", pDocStatusCode));
            vlstParam.Add(new SqlParameter("DocStatusNameL1", pDocStatusNameL1));
            vlstParam.Add(new SqlParameter("DocStatusNameL2", pDocStatusNameL2));
            vlstParam.Add(new SqlParameter("DocStatusIsActive", pDocStatusIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("SETT.spDocStatusCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}