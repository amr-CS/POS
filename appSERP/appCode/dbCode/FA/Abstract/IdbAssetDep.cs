using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.FA.Abstract
{
    public interface IdbAssetDep
    {
        string funAssetDepGET(
        int? pAssetDepId = null,
        int? pCompanyId = null,
        DateTime? pAssetLastDepDate = null,
        DateTime? pAssetDepDate = null,
        bool? pAssetDepIsActive = null,
        bool? pIsDeleted = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pLanguageId = null,
        int? pQueryTypeId = null);

        DataTable funGetAssetDepReport(bool? pIsActive = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
