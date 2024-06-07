using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.INV.Abstract
{
    public interface IdbInvItemsUnitsPrice
    {
        string funInvItemsUnitsPriceGET(

        int? pPriceId = null,
        string pPriceCode = null,
        int? pItemId = null,
        int? pUnitId = null,
        int? pSellCostType = null,
         decimal? pPrice = null,
         int? pPriceCat = null,
        string pNotes = null,
        bool? pPriceIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
