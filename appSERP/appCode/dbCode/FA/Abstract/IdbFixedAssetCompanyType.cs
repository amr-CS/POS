using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.FA.Abstract
{
    public interface IdbFixedAssetCompanyType
    {

        string funFixedAssetCompanyTypeGET(
        int? pFixedAssetCompanyTypeId = null,
        string pFixedAssetCompanyTypeCode = null,
        string pFixedAssetCompanyTypeNameL1 = null,
        string pFixedAssetCompanyTypeNameL2 = null,
        bool? pFixedAssetCompanyTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        DataTable funGetFixedAssetCompanyTypeReport(bool? pIsActive = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
