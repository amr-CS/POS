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
    public class dbEPaymentType: IdbEPaymentType
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbEPaymentType(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funEPaymentTypeGET(
        int? pEPaymentTypeId = null,
        int? pPaymentTypeId = null,
        string pEPaymentTypeCode = null,
        string pEPaymentTypeNameL1 = null,
        string pEPaymentTypeNameL2 = null,
        int? pBranchId = null,
        bool? pEPaymentTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("EPaymentTypeId", pEPaymentTypeId));
            vlstParam.Add(new SqlParameter("PaymentTypeId", pPaymentTypeId));
            vlstParam.Add(new SqlParameter("EPaymentTypeCode", pEPaymentTypeCode));
            vlstParam.Add(new SqlParameter("EPaymentTypeNameL1", pEPaymentTypeNameL1));
            vlstParam.Add(new SqlParameter("EPaymentTypeNameL2", pEPaymentTypeNameL2));
            vlstParam.Add(new SqlParameter("EPaymentTypeIsActive", pEPaymentTypeIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("ACC.spEPaymentTypeCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}