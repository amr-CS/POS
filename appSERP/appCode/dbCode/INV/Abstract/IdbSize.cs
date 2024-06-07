using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.INV.Abstract
{
    public interface IdbSize
    {

        string funSizeGET(
        int? pSizeId = null,
        string pSizeCode = null,
        string pSizeNameL1 = null,
        string pSizeNameL2 = null,
        int? pSizeTypeId = null,
        int? pUnitId = null,
        int? pBranchId = null,
        bool? pSizeIsActive = null,
        bool? pIsDetail = null,
        bool? pIsUnitDetail = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
