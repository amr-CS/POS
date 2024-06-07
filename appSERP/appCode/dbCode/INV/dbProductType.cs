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
    public class dbProductType : IdbProductType
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbProductType(clsADO clsADO)
        {
            _clsADO = clsADO;
        }
        public string funProductTypeGET(

        int? pProductTypeId = null,
        string pProductTypeCode = null,
        string pProductTypeNameL1 = null,
        string pProductTypeNameL2 = null,
         string pShortName = null,
        string pProductTypeLevel = null,
        int? pProductTypeParentId = null,
        bool? pProductTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("ProductTypeId", pProductTypeId));
            vlstParam.Add(new SqlParameter("ProductTypeCode", pProductTypeCode));
            vlstParam.Add(new SqlParameter("ProductTypeNameL1", pProductTypeNameL1));
            vlstParam.Add(new SqlParameter("ProductTypeNameL2", pProductTypeNameL2));
            vlstParam.Add(new SqlParameter("ShortName", pShortName));
            vlstParam.Add(new SqlParameter("ProductTypeLevel", pProductTypeLevel)); 
            vlstParam.Add(new SqlParameter("ProductTypeParentId", pProductTypeParentId));
            vlstParam.Add(new SqlParameter("ProductTypeIsActive", pProductTypeIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("INV.spProductTypeCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}