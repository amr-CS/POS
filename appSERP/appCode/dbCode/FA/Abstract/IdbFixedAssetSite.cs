using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.FA.Abstract
{
    public interface IdbFixedAssetSite
    {
        string funFixedAssetSiteGET(
        int? pFixedAssetSiteId = null,
        int? pFixedAssetSiteQty = null,
        DateTime? pFixedAssetSiteTransDate = null,
        int? pCompanyId = null,
        int? pAssetId = null,
        int? pSiteDetailId = null,
        int? pTransactionTypeId = null,
        bool? pFixedAssetSiteIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        DataTable funGetFixedAssetSiteReport(bool? pIsActive = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
