using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.FA.Abstract
{
    public interface IdbAssetRelease
    {
        string funAssetReleaseGET(
        int? pAssetReleaseId = null,
        string pAssetReleaseNameL1 = null,
        string pAssetReleaseNameL2 = null,
        string pAssetReleaseCode = null,
        DateTime? pAssetReleaseDate = null,
        int? pTrustId = null,
        int? pTransactionTypeId = null,
        string pNote = null,
        bool? pAssetReleaseIsActive = null,
        bool? pIsDeleted = null,
        int? pCompanyId = null,
        int? pBranchId = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pLanguageId = null,
        int? pQueryTypeId = null);

        DataTable funGetAssetReleaseReport(bool? pIsActive = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
