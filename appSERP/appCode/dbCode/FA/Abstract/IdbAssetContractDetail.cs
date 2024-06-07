using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.FA.Abstract
{
    public interface IdbAssetContractDetail
    {
        string funAssetContractDetailGET(
        int? pAssetContractDetailId = null,
        int? pAssetContractDetailSeq = null,
        int? pAssetContractDetailQty = null,
        int? pAssetContractId = null,
        int? pAssetId = null,
        bool? pAssetContractDetailIsActive = null,
        bool? pIsDeleted = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pLanguageId = null,
        int? pQueryTypeId = null);

        DataTable funGetAssetContractDetailReport(bool? pIsActive = null);


        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
