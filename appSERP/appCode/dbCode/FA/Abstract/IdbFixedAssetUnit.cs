using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.FA.Abstract
{
    public interface IdbFixedAssetUnit
    {
        string funFixedAssetUnitGET(
        int? pFixedAssetUnitId = null,
        string pFixedAssetUnitCode = null,
        string pFixedAssetUnitNameL1 = null,
        string pFixedAssetUnitNameL2 = null,
        bool? pFixedAssetUnitIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        DataTable funGetFixedAssetUnitReport(bool? pIsActive = null);


        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
