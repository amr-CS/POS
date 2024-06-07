using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.FA.Abstract
{
    public interface IdbGroup
    {
        string funGroupGET(
        int? pGroupId = null,
        int? pMainGroupId = null,
        string pGroupNameL1 = null,
        string pGroupNameL2 = null,
        decimal? pGroupPercent = null,
        int? pFixedAssetMethodId = null,
        int? pGroupAssetAccount = null,
        int? pGroupDebitAccount = null,
        int? pGroupCreditAccount = null,
        int? pGroupPurchaseAccount = null,
        int? pGroupSalesAccount = null,
        bool? pGroupIsActive = null,
        bool? pIsDeleted = null,
        int? pCompanyId = null,
        int? pBranchId = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pLanguageId = null,
        int? pQueryTypeId = null);

        DataTable funGetGroupReport(bool? pIsActive = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
