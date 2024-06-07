using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.FA.Abstract
{
    public interface IdbAssetReasonType
    {

        string funAssetReasonTypeGET(
        int? pAssetReasonTypeId = null,
        string pAssetReasonTypeNameL1 = null,
        string pAssetReasonTypeNameL2 = null,
        int? pCompanyId = null,
        bool? pAssetReasonTypeIsActive = null,
        bool? pIsDeleted = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pLanguageId = null,
        int? pQueryTypeId = null);

        DataTable funGetAssetReasonTypeReport(bool? pIsActive = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
