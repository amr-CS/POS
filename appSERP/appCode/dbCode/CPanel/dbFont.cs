using appSERP.appCode.dbCode.SETT.Abstract;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.SETT
{
    public class dbFont : IdbFont
    {
        // Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbFont(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funFontGET(
        int? pFontId = null,
        string pFontName = null,
        string pFontPath = null,
        bool? pFontIsActive = null,
        bool? pIsDeleted = false,
        int? pLanguageId = null,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("FontId", pFontId));
            vlstParam.Add(new SqlParameter("FontName", pFontName));
            vlstParam.Add(new SqlParameter("FontPath", pFontPath));
            vlstParam.Add(new SqlParameter("FontIsActive", pFontIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", DateTime.Now));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", DateTime.Now));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("SETT.spFontCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}