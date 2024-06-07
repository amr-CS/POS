using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.FA.Abstract
{
    public interface IdbAssetContract
    {
        string funAssetContractGET(
       int? pAssetContractId = null,
       DateTime? pAssetContractDate = null,
       int? pAssetContractPeriod = null,
       int? pAssetContractRefNo = null,
       decimal? pAssetContractValue = null,
       int? pCurrencyId = null,
       string pAssetContractNote = null,
       int? pAssetContractNo = null,
       int? pFixedAssetCompanyId = null,
       int? pAssetContractPayTypeId = null,
       bool? pAssetContractIsActive = null,
       bool? pIsDeleted = null,
       int? pCreatedBy = null,
       DateTime? pCreatedOn = null,
       int? pLastUpdatedBy = null,
       DateTime? pLastUpdatedOn = null,
       int? pLanguageId = null,
       int? pQueryTypeId = null);

        DataTable funGetAssetContractReport(bool? pIsActive = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
