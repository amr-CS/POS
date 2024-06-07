using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.Setting.Company;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.RES
{
    public class dbCashier : IdbCashier
    {
        private IclsADO _clsADO;
        public dbCashier(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funCashierGET(
        int? pCashId = null,
        bool? pIsCashComp = null,
        string pNetAcc = null,
        int? pCostCenterId = null,
        string pNOTES = null,
        string pCashAcc = null,
        bool? pCashStatus = null,
        string pCashNameL2 = null,
        string pUserName = null,
        string pCashPassword = null,
        int? pEmpId = null,
        string pCashNameL1 = null,
        int? pCompanyId = null,
        int? pCashCode = null,
        bool? pIsDeleted = null,
        int? pLanguageId = null,
        int? Credit = null,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("IsCashComp", pIsCashComp));
            vlstParam.Add(new SqlParameter("NetAcc", pNetAcc));
            vlstParam.Add(new SqlParameter("CostCenterId", pCostCenterId));
            vlstParam.Add(new SqlParameter("NOTES", pNOTES));
            vlstParam.Add(new SqlParameter("CashAcc", pCashAcc));
            vlstParam.Add(new SqlParameter("CashStatus", pCashStatus));
            vlstParam.Add(new SqlParameter("CashNameL2", pCashNameL2));
            vlstParam.Add(new SqlParameter("UserName", pUserName));
            vlstParam.Add(new SqlParameter("CashPassword", pCashPassword));
            vlstParam.Add(new SqlParameter("EmpId", pEmpId));
            vlstParam.Add(new SqlParameter("CashNameL1", pCashNameL1));
            vlstParam.Add(new SqlParameter("CashId", pCashId));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("CashCode", pCashCode));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("Credit", Credit));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("RES.spCashierCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}