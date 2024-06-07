using appSERP.appCode.SQL.QueryType;
using appSERP.Models.ACC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbAccount
    {
        string funAccountGET(
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
            int? pQueryTypeId = clsQueryType.qSelect);
        string funGetAccountIdByNo(string pAccountNo);
        DataTable funGetAccountReport(int? pCompanyId = null, bool? pIsActive = null);
        object spAccountInsertUpdateBulk(ICollection<AccountModel> accountModels);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }

        string vParentId { get; set; }
        int? vLevel { get; set; }
        string vAccountNo { get; set; }
        string vAccountName { get; set; }
        string vBranchId { get; set; }
        string vBranchName { get; set; }
        int vAccountLevel { get; set; }
        string vIsCostCenter { get; set; }
    }
}
