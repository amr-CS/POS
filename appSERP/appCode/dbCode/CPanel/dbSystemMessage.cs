using appSERP.appCode.dbCode.SYSSETT.Abstract;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.SYSSETT
{
    public class dbSystemMessage : IdbSystemMessage
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbSystemMessage(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funSystemMessageGET(
        int? pSystemMessageId = null,
        int? pSystemMessageTypeId = null,
        string pSystemMessageText = null,
        string pSystemMessagePath = null,
        bool? pSystemMessageIsActive = null,
        bool? pIsDeleted = false,
        int? pLanguageId = null,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("SystemMessageId", pSystemMessageId));
            vlstParam.Add(new SqlParameter("SystemMessageTypeId", pSystemMessageTypeId));
            vlstParam.Add(new SqlParameter("SystemMessageText", pSystemMessageText));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", DateTime.Now));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", DateTime.Now));
            vlstParam.Add(new SqlParameter("LanguageId", pLanguageId));
            vlstParam.Add(new SqlParameter("UserLanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("SYSSETT.spSystemMessageCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}