using appSERP.appCode.dbCode.INV;
using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.INV
{
    public class APIInvItemsUnitsPriceController : ApiController
    {
        private IdbInvItemsUnitsPrice _dbInvItemsUnitsPrice;
        public APIInvItemsUnitsPriceController(IdbInvItemsUnitsPrice dbInvItemsUnitsPrice) {
            _dbInvItemsUnitsPrice = dbInvItemsUnitsPrice;
        }

        [HttpGet]
        public string InvItemsUnitsPriceGET(
        int? pPriceId = null,
        string pPriceCode = null,
        int? pItemId = null,
        int? pUnitId = null,
        int? pSellCostType = null,
        decimal? pPrice = null,
        int? pPriceCat = null,
        string pNotes = null,
        bool? pPriceIsActive = true,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbInvItemsUnitsPrice.funInvItemsUnitsPriceGET(
            pPriceId: pPriceId,
            pPriceCode: pPriceCode,
            pItemId: pItemId,
            pUnitId: pUnitId,
            pSellCostType: pSellCostType,
            pPrice: pPrice,
            pPriceCat : pPriceCat,
            pNotes: pNotes,
            pPriceIsActive: pPriceIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
