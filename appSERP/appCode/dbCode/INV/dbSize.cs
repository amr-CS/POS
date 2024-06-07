using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.Setting.Company;
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
    public class dbSize: IdbSize
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbSize(clsADO clsADO)
        {
            _clsADO = clsADO;
        }
        public string funSizeGET(
        int? pSizeId = null,
        string pSizeCode = null,
        string pSizeNameL1 = null,
        string pSizeNameL2 = null,
        int? pSizeTypeId = null,
        int? pUnitId = null,
        int? pBranchId = null,
        bool? pSizeIsActive = null,
        bool? pIsDetail = null,
        bool? pIsUnitDetail = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("SizeId", pSizeId));
            vlstParam.Add(new SqlParameter("SizeCode", pSizeCode));
            vlstParam.Add(new SqlParameter("SizeNameL1", pSizeNameL1));
            vlstParam.Add(new SqlParameter("SizeNameL2", pSizeNameL2));
            vlstParam.Add(new SqlParameter("SizeTypeId", pSizeTypeId));
            vlstParam.Add(new SqlParameter("UnitId", pUnitId));
            vlstParam.Add(new SqlParameter("SizeIsActive", pSizeIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("BranchId", clsCompany.vBranchId));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("IsDetail", pIsDetail));
            vlstParam.Add(new SqlParameter("IsUnitDetail", pIsUnitDetail));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("INV.spSizeCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
        public static int UserId;
 
        
       // object request = HttpContext.Current.Request;
    
    }
}