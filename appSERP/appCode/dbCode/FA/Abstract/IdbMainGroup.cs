using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.FA.Abstract
{
    public interface IdbMainGroup
    {
        string funMainGroupGET(
        int? pMainGroupId = null,
        string pMainGroupNameL1 = null,
        string pMainGroupNameL2 = null,
        bool? pMainGroupIsActive = null,
        int? pFixedAssetMethodId = null,
        decimal? pMainGroupPercent = null,
        int? pMainGroupDebitAccount = null,
        int? pMainGroupCreditAccount = null,
        int? pMainGroupPurchaseAccount = null,
        int? pMainGroupSalesAccount = null,
        bool? pIsDeleted = null,
        int? pCompanyId = null,
        int? pBranchId = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pLanguageId = null,
        int? pQueryTypeId = null);

        DataTable funGetMainGroupsReport(bool? pIsActive = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
