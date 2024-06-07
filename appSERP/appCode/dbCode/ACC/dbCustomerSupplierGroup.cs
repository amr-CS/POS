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
    public class dbCustomerSupplierGroup : IdbCustomerSupplierGroup
    {           
        // Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbCustomerSupplierGroup(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funCustomerSupplierGroupGET(
        int? pCSGroupId = null,
        string pCSGroupNameL1 = null,
        string pCSGroupNameL2 = null,
        decimal? pCSGroupCreditLimit = null,
        int? pCSGroupGracePeriodDays = null,
        bool? pCSGroupIsCustomerGroup = null,
        bool? pCSGroupIsDefault = null,
        int? pCompanyId = null,
        int? pBranchId = null,
        bool? pCSGroupIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("CSGroupId", pCSGroupId));
            vlstParam.Add(new SqlParameter("CSGroupNameL1", pCSGroupNameL1));
            vlstParam.Add(new SqlParameter("CSGroupNameL2", pCSGroupNameL2));
            vlstParam.Add(new SqlParameter("CSGroupCreditLimit", pCSGroupCreditLimit));
            vlstParam.Add(new SqlParameter("CSGroupGracePeriodDays", pCSGroupGracePeriodDays));
            vlstParam.Add(new SqlParameter("CSGroupIsCustomerGroup", pCSGroupIsCustomerGroup));
            vlstParam.Add(new SqlParameter("CSGroupIsDefault", pCSGroupIsDefault));
            vlstParam.Add(new SqlParameter("BranchId", clsCompany.vBranchId));
            vlstParam.Add(new SqlParameter("CSGroupIsActive", pCSGroupIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("ACC.spCustomerSupplierGroupCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}