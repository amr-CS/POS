using appSERP.appCode.dbCode.ACC.Abstract;
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

namespace appSERP.appCode.dbCode.ACC
{
    public class dbGLVoucherCategory : IdbGLVoucherCategory
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbGLVoucherCategory(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funGLVoucherCategoryGET(
        int? pGLVoucherCategoryId = null,
        string pGLVoucherCategoryNameL1 = null,
        string pGLVoucherCategoryNameL2 = null,
        bool? pGLVoucherCategoryIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("GLVoucherCategoryId", pGLVoucherCategoryId));
            vlstParam.Add(new SqlParameter("GLVoucherCategoryNameL1", pGLVoucherCategoryNameL1));
            vlstParam.Add(new SqlParameter("GLVoucherCategoryNameL2", pGLVoucherCategoryNameL2));
            vlstParam.Add(new SqlParameter("GLVoucherCategoryIsActive", pGLVoucherCategoryIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("ACC.spGLVoucherCategoryCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}