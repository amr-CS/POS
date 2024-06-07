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
    public class dbInvSubItem : IdbInvSubItem
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbInvSubItem(clsADO clsADO)
        {
            _clsADO = clsADO;
        }
        public string funInvSubItemGET(
         int?  pSubItemId  = null,
        string pSubItemCode  = null, 
       string pSubItemNameL1  = null, 
      string pSubItemNameL2  = null, 
      int? pPiecesCount  = null,
       int? pItemId     = null,
         string pNotes= null,
        bool? pSubItemIsActive  = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("SubItemId", pSubItemId));
            vlstParam.Add(new SqlParameter("SubItemCode", pSubItemCode));
            vlstParam.Add(new SqlParameter("SubItemNameL1", pSubItemNameL1));
            vlstParam.Add(new SqlParameter("SubItemNameL2", pSubItemNameL2));
            vlstParam.Add(new SqlParameter("PiecesCount", pPiecesCount));
            vlstParam.Add(new SqlParameter("ItemId", pItemId));
            vlstParam.Add(new SqlParameter("Notes", pNotes));
            vlstParam.Add(new SqlParameter("SubItemIsActive", pSubItemIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("INV.spInvSubItemCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}