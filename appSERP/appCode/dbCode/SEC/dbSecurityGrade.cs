using appSERP.appCode.dbCode.SEC.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.Company;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.SEC
{
    public class dbSecurityGrade: IdbSecurityGrade
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbSecurityGrade(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public string funSecurityGradeGET(
        int? pSecurityGradeId = null,
        string pSecurityGradeCode = null,
        string pSecurityGradeNameL1 = null,
        string pSecurityGradeNameL2 = null,
        bool? pCompanyId = null,
        bool? pSecurityGradeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("SecurityGradeId", pSecurityGradeId));
            vlstParam.Add(new SqlParameter("SecurityGradeCode", pSecurityGradeCode));
            vlstParam.Add(new SqlParameter("SecurityGradeNameL1", pSecurityGradeNameL1));
            vlstParam.Add(new SqlParameter("SecurityGradeNameL2", pSecurityGradeNameL2));
            vlstParam.Add(new SqlParameter("SecurityGradeIsActive", pSecurityGradeIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("SEC.spSecurityGradeCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
    }
}