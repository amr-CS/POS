using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.FA.Abstract
{
    public interface IdbAssetTrans
    {
        string funAssetTransGET(
        int? pAssetTransId = null,
        DateTime? pAssetTransDate = null,
        decimal? pAssetTransValue = null,
        decimal? pAssetTransValueBase = null,
        int? pCurrencyId = null,
        string pAssetReasonTypeNote = null,
        string pAssetTransNote = null,
        int? pAssetId = null,
        int? pTransactionTypeId = null,
        int? pAssetReasonTypeId = null,
        bool? pAssetTransIsActive = null,
        bool? pIsDeleted = null,
        int? pCompanyId = null,
        int? pBranchId = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pLanguageId = null,
        int? pQueryTypeId = null);


        DataTable funGetAssetTransReport(bool? pIsActive = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
