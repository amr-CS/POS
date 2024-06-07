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
    public class APIUnitController : ApiController
    {
        private IdbUnit _dbUnit;
        public APIUnitController(IdbUnit dbUnit)
        {
            _dbUnit = dbUnit;
        }


        [HttpGet]
        public string UnitGET(
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
      bool? pUnitIsActive = null,
      bool? pIsDeleted = false,
      int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbUnit.funUnitGET(
            pUnitId: pUnitId,
            pUnitCode: pUnitCode,
            pUnitNameL1: pUnitNameL1,
            pUnitNameL2: pUnitNameL2,
            pUnitParentId: pUnitParentId,
            pPartsInParents: pPartsInParents,
            pUnitPrice: pUnitPrice,
            pNotes: pNotes,
            pCurrencyId: pCurrencyId,
            pPriceCurrency: pPriceCurrency,
            pDefaultUnit: pDefaultUnit,
            pUnitOrderLimit: pUnitOrderLimit,
            pItemId: pItemId,
            pUnitIsActive: pUnitIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
