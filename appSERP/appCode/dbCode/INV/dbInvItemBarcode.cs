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
    public class dbInvItemBarcode : IdbInvItemBarcode
    {

        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }
        private IclsADO _clsADO;
        public dbInvItemBarcode(clsADO clsADO)
        {
            _clsADO = clsADO;
        }


        public string funInvItemBarcodeGET(
        int? pInvItemBarcodeId = null,
        string pInvItemBarcodeCode = null,
        int? pItemId = null,
         int? pUnitId = null,
        string pItemBarCode = null,
        bool? pInvItemBarcodeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("InvItemBarcodeId", pInvItemBarcodeId));
            vlstParam.Add(new SqlParameter("InvItemBarcodeCode", pInvItemBarcodeCode));
            vlstParam.Add(new SqlParameter("ItemId", pItemId));
            vlstParam.Add(new SqlParameter("UnitId", pUnitId));
            vlstParam.Add(new SqlParameter("ItemBarCode", pItemBarCode));
            vlstParam.Add(new SqlParameter("InvItemBarcodeIsActive", pInvItemBarcodeIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("INV.spInvItemBarcodeCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}