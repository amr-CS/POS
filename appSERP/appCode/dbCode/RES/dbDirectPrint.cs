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
    public class dbDirectPrint : IdbDirectPrint
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbDirectPrint(clsADO clsADO)
        {
            _clsADO = clsADO;
        }
        public string funDirectPrintGET(
        int? pDirectPrintId = null,
        string pDirectPrintCode = null,
        string pDirectPrintNameL1 = null,
        string pDirectPrintNameL2 = null,
        bool? pDirectPrintIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("DirectPrintId", pDirectPrintId));
            vlstParam.Add(new SqlParameter("DirectPrintCode", pDirectPrintCode));
            vlstParam.Add(new SqlParameter("DirectPrintNameL1", pDirectPrintNameL1));
            vlstParam.Add(new SqlParameter("DirectPrintNameL2", pDirectPrintNameL2));
            vlstParam.Add(new SqlParameter("DirectPrintIsActive", pDirectPrintIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("RES.spDirectPrintCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}