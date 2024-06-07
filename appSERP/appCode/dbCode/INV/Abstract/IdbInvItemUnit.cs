using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.INV.Abstract
{
    public interface IdbInvItemUnit
    {
        string funInvItemUnitGET(
         int? pInvItemUnitId = null,
        int? pUnitId = null,
        string pUnitCode = null,
        string pUnitNameL1 = null,
        string pUnitNameL2 = null,
        int? pUnitParentId = null,
        decimal? pUnitCost = null,
        float? pPartsInParents = null,
        decimal? pUnitPrice = null,
        string pNotes = null,
        int? pCurrencyId = null,
        int? pPriceCurrency = null,
        int? pDefaultUnit = null,
        decimal? pUnitOrderLimit = null,
        int? pItemId = null,
        int? pBranchId = null,
        string pBarcode = null,
        bool? pIsDecreasable = null,
        bool? pSellUnit = null,
        bool? pUnitProduction = null,
        bool? pIsDefault = null,
        bool? pUnitIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);
        DataTable GetItemUnits(int ItemId);
        DataTable GetItemUnitById(int InvItemUnitId);
        DataTable GetItemUnitParentBy(int UnitParentId, int ItemId);
        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
        DataTable vDtDataContent { get; set; }
        DataTable vDtDataItemPrice { get; set; }
        DataTable vDtDataUnit { get; set; }
    }
}
