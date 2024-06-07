using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.FA.Abstract
{
    public interface IdbFixedAssetMethod
    {

        string funFixedAssetMethodGET(
        int? pFixedAssetMethodId = null,
        string pFixedAssetMethodNameL1 = null,
        string pFixedAssetMethodNameL2 = null,
        bool? pFixedAssetMethodIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        DataTable funGetFixedAssetMethodReport(bool? pIsActive = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
