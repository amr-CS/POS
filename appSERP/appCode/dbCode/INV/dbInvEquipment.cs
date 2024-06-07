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
    public class dbInvEquipment: IdbInvEquipment
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbInvEquipment(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funInvEquipmentGET(
        int? pEquipmentId = null,
        string pEquipmentCode = null,
        string pEquipmentNameL1 = null,
        string pEquipmentNameL2 = null,
        string pNotes = null,
        bool? pEquipmentIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("EquipmentId", pEquipmentId));
            vlstParam.Add(new SqlParameter("EquipmentCode", pEquipmentCode));
            vlstParam.Add(new SqlParameter("EquipmentNameL1", pEquipmentNameL1));
            vlstParam.Add(new SqlParameter("EquipmentNameL2", pEquipmentNameL2));
            vlstParam.Add(new SqlParameter("Notes", pNotes));
            vlstParam.Add(new SqlParameter("EquipmentIsActive", pEquipmentIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("INV.spInvEquipmentCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}