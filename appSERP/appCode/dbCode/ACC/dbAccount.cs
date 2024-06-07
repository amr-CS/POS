using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.Company;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using appSERP.appCode.SQL.QueryType;
using appSERP.appCode.Utils;
using appSERP.Models.ACC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.ACC
{
    public class dbAccount: IdbAccount
    {
            // Message
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }
        //Account Setting
        public string vParentId { get; set; }
        public int? vLevel { get; set; }
        public string vAccountNo { get; set; }
        public string vAccountName { get; set; }
        public string vBranchId { get; set; }
        public string vBranchName { get; set; }
        public int vAccountLevel { get; set; }
        public string vIsCostCenter { get; set; }

        private IclsADO _clsADO;
        private IclsAPI _clsAPI;
        public dbAccount(clsADO clsADO, IclsAPI clsAPI)
        {
            _clsADO = clsADO;
            _clsAPI = clsAPI;
        }

        public string funAccountGET(
            int? pAccountId = null,
            string pAccountNo = null,
            string pAccountNameL1 = null,
            string pAccountNameL2 = null,
            int? pAccountTypeId = null,
            int? pAccountParentId = null,
            int? pAccountLevel = null,
            int? pCurrencyId = null,
            bool? pIsCostCenter = null,
            int? pCurrencyFactorId = null,
            int? pSecurityGradeId = null,
            bool? pAccountIsDebit = null,
            int? pAccountingReportId = null,
            bool? pAccountIsCumulative = null,
            int? pCompanyId = null,
            int? pCashFlowTypeId = null,
            int? pAccountFrom = null,
            int? pAccountTo = null,
            int? pCostCenterId = null,
              int? pCustomerId = null,
              int? pAccountCategoryId = null,
            bool? pAccountIsActive = null,
            bool? pIsDeleted = false,
            int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("AccountId", pAccountId));
            vlstParam.Add(new SqlParameter("AccountNo", pAccountNo));
            vlstParam.Add(new SqlParameter("AccountNameL1", pAccountNameL1));
            vlstParam.Add(new SqlParameter("AccountNameL2", pAccountNameL2));
            vlstParam.Add(new SqlParameter("AccountTypeId", pAccountTypeId));
            vlstParam.Add(new SqlParameter("AccountParentId", pAccountParentId));
            vlstParam.Add(new SqlParameter("AccountLevel", pAccountLevel));
            vlstParam.Add(new SqlParameter("CurrencyId", pCurrencyId));
            vlstParam.Add(new SqlParameter("IsCostCenter", pIsCostCenter));
            vlstParam.Add(new SqlParameter("CurrencyFactorId", pCurrencyFactorId));
            vlstParam.Add(new SqlParameter("SecurityGradeId", pSecurityGradeId));
            vlstParam.Add(new SqlParameter("AccountIsDebit", pAccountIsDebit));
            vlstParam.Add(new SqlParameter("AccountingReportId", pAccountingReportId));
            vlstParam.Add(new SqlParameter("AccountIsCumulative", pAccountIsCumulative));
            vlstParam.Add(new SqlParameter("CashFlowTypeId", pCashFlowTypeId));
            vlstParam.Add(new SqlParameter("AccountFrom", pAccountFrom));
            vlstParam.Add(new SqlParameter("AccountTo", pAccountTo));
            vlstParam.Add(new SqlParameter("CostCenterId", pCostCenterId));
            vlstParam.Add(new SqlParameter("CustomerId", pCustomerId));
            vlstParam.Add(new SqlParameter("AccountCategoryId", pAccountCategoryId));

            vlstParam.Add(new SqlParameter("AccountIsActive", pAccountIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vData = _clsADO.funExecuteScalar("ACC.spAccountCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }
        // Function Get AccountId
        public string funGetAccountIdByNo(string pAccountNo)
        {
            string vPath = appAPIDirectory.vAPIAccount;
            string vparam= "?pQueryTypeId=" + 400 + "&pAccountNo=" + pAccountNo;
            DataTable vDTParent = _clsAPI.funResultGet(vPath + vparam);
            string vId = vDTParent.Rows[0]["AccountId"].ToString();
            return vId;
        }
        public DataTable funGetAccountReport(int? pCompanyId = null,bool ? pIsActive = null)
        {
            // Declaration 
            DataTable vData;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("CompanyId", pCompanyId));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));
            vlstParam.Add(new SqlParameter("IsActive", pIsActive));

            vData = _clsADO.funFillDataTable("dbo.spgetAccounts", vlstParam, "Data GET");


            return vData;
        }

        public object spAccountInsertUpdateBulk(ICollection<AccountModel> accountModels)
        {
            foreach (var item in accountModels)
            {
                item.CompanyId = clsCompany.vCompanyId;
            }
            CustomXmlWriter xmlWriter = new CustomXmlWriter();
            string xml = xmlWriter.GetXml("Accounts", accountModels);
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("Accounts", xml));

            return _clsADO.funExecuteScalar("ACC.AccountChart_IntsertUpdateBulk", vlstParam, "Data GET");
        }

    }
}