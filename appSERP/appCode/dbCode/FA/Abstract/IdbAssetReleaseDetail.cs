using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.FA.Abstract
{
    public interface IdbAssetReleaseDetail
    {
        

        string funAssetReleaseDetailGET(
        int? pAssetReleaseDetailId = null,
        string pAssetReleaseDetailNameL1 = null,
        string pAssetReleaseDetailNameL2 = null,
        string pAssetReleaseDetailCode = null,
        int? pAssetReleaseQty = null,
        int? pAssetReleaseSeq = null,
        int? pAssetReleaseId = null,
        int? pAssetId = null,
        bool? pAssetReleaseDetailIsActive = null,
        bool? pIsDeleted = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pLanguageId = null,
        int? pQueryTypeId = null);

        DataTable funGetAssetReleaseDetailReport(bool? pIsActive = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
