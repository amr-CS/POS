using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.INV
{
    public class dbInvItemReplace : IdbInvItemReplace
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbInvItemReplace(clsADO clsADO)
        {
            _clsADO = clsADO;
        }
        public string funInvItemReplaceGET(
        int? pInvItemReplaceId = null,
        string pInvItemReplaceCode = null,
        int? pItemId = null,
        int? pReplaceItemId = null,
        string pNotes = null,
        bool? pInvItemReplaceIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("InvItemReplaceId", pInvItemReplaceId));
            vlstParam.Add(new SqlParameter("InvItemReplaceCode", pInvItemReplaceCode));
            vlstParam.Add(new SqlParameter("ItemId", pItemId));
            vlstParam.Add(new SqlParameter("ReplaceItemId", pReplaceItemId));
            vlstParam.Add(new SqlParameter("Notes", pNotes));
            vlstParam.Add(new SqlParameter("InvItemReplaceIsActive", pInvItemReplaceIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("INV.spInvItemReplaceCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}