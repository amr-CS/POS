using appSERP.appCode.dbCode.ACC.Abstract;
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
    public class dbVoucherType : IdbVoucherType
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbVoucherType(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funVoucherTypeGET(
        int? pVoucherTypeId = null,
        string pVoucherTypeCode = null,
        string pVoucherTypeNameL1 = null,
        string pVoucherTypeNameL2 = null,
        bool? pVoucherTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("VoucherTypeId", pVoucherTypeId));
            vlstParam.Add(new SqlParameter("VoucherTypeCode", pVoucherTypeCode));
            vlstParam.Add(new SqlParameter("VoucherTypeNameL1", pVoucherTypeNameL1));
            vlstParam.Add(new SqlParameter("VoucherTypeNameL2", pVoucherTypeNameL2));
            vlstParam.Add(new SqlParameter("VoucherTypeIsActive", pVoucherTypeIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("ACC.spVoucherTypeCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}