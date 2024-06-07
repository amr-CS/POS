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
    public class dbInvItemsEquip: IdbInvItemsEquip
    {
        private IclsADO _clsADO;
        public dbInvItemsEquip(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funInvItemsEquipGET(
        int? pEquipId = null,
        string pEquipCode = null,
        string pEquipName = null,
         int? pItemId = null,
        string pNotes = null,
        bool? pEquipIsActive = true,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("EquipId", pEquipId));
            vlstParam.Add(new SqlParameter("EquipCode", pEquipCode));
            vlstParam.Add(new SqlParameter("EquipName", pEquipName));
            vlstParam.Add(new SqlParameter("ItemId", pItemId));
            vlstParam.Add(new SqlParameter("Notes", pNotes));
            vlstParam.Add(new SqlParameter("EquipIsActive", pEquipIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("INV.spInvItemsEquipsCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}