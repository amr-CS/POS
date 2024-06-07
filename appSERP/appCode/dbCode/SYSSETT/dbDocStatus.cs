using appSERP.appCode.dbCode.SYSSETT.Abstract;
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
        string pDocStatusId = null,
        string pDocStatusNameL1 = null,
        string pDocStatusNameL2 = null,
        string pDocStatusNameL3 = null,
        string pDocStatusNameL4 = null,
        string pDocStatusNameL5 = null,
        string pDocStatusNameL6 = null,
        string pDocStatusNameL7 = null,
        string pDocStatusNameL8 = null,
        string pDocStatusNameL9 = null,
        string pDocStatusNameL10 = null,
        string pDocStatusNext = null,
        string pDocStatusProName = null,
        bool? pDocStatusIsActive = null,
        bool? pIsDeleted = false,
        int? pLanguageId = null,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("DocStatusId", pDocStatusId));
            vlstParam.Add(new SqlParameter("DocStatusNameL1", pDocStatusNameL1));
            vlstParam.Add(new SqlParameter("DocStatusNameL2", pDocStatusNameL2));
            vlstParam.Add(new SqlParameter("DocStatusNameL3", pDocStatusNameL3));
            vlstParam.Add(new SqlParameter("DocStatusNameL4", pDocStatusNameL4));
            vlstParam.Add(new SqlParameter("DocStatusNameL5", pDocStatusNameL5));
            vlstParam.Add(new SqlParameter("DocStatusNameL6", pDocStatusNameL6));
            vlstParam.Add(new SqlParameter("DocStatusNameL7", pDocStatusNameL7));
            vlstParam.Add(new SqlParameter("DocStatusNameL8", pDocStatusNameL8));
            vlstParam.Add(new SqlParameter("DocStatusNameL9", pDocStatusNameL9));
            vlstParam.Add(new SqlParameter("DocStatusNameL10", pDocStatusNameL10));
            vlstParam.Add(new SqlParameter("DocStatusNext", pDocStatusNext));
            vlstParam.Add(new SqlParameter("DocStatusProName", pDocStatusProName));
            vlstParam.Add(new SqlParameter("DocStatusIsActive", pDocStatusIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("SYSSETT.spDocStatusCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}