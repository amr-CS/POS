using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.FA.Abstract
{
    public interface IdbFixedAssetCompany
    {
        string funFixedAssetCompanyGET(
        int? pFixedAssetCompanyId = null,
        string pFixedAssetCompanyCode = null,
        string pFixedAssetCompanyNameL1 = null,
        string pFixedAssetCompanyNameL2 = null,
        int? pFixedAssetCompanyTypeId = null,
        bool? pFixedAssetCompanyIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        DataTable funGetFixedAssetCompanyReport(bool? pIsActive = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
