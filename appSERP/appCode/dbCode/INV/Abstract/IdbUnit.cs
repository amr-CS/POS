using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.INV.Abstract
{
    public interface IdbUnit
    {
        string funUnitGET(

        int? pUnitId = null,
        string pUnitCode = null,
        string pUnitNameL1 = null,
        string pUnitNameL2 = null,
        int? pUnitParentId = null,
        int? pPartsInParents = null,
        decimal? pUnitPrice = null,
        string pNotes = null,
        int? pCurrencyId = null,
        int? pPriceCurrency = null,
        int? pDefaultUnit = null,
        decimal? pUnitOrderLimit = null,
         int? pItemId = null,
        int? pBranchId = null,
        bool? pUnitIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
