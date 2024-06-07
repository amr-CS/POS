using appSERP.appCode.dbCode.ACC;
using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.ACC
{
    public class APISellCostTypeController : ApiController
    {

        private IdbSellCostType _dbSellCostType;
        public APISellCostTypeController(IdbSellCostType dbSellCostType) {
            _dbSellCostType = dbSellCostType;
        }

        [HttpGet]
        public string SellCostTypeGET(
       int? pSellCostTypeId = null,
      string pSellCostTypeCode = null,
       string pSellCostTypeNameL1 = null,
       string pSellCostTypeNameL2 = null,
        bool? pSellCostTypeIsActive = true,
       bool? pIsDeleted = false,
   int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data
            string vData = _dbSellCostType.funSellCostTypeGET(
            pSellCostTypeId: pSellCostTypeId,
            pSellCostTypeCode: pSellCostTypeCode,
            pSellCostTypeNameL1: pSellCostTypeNameL1,
            pSellCostTypeNameL2: pSellCostTypeNameL2,
            pSellCostTypeIsActive: pSellCostTypeIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
               );
            // Return Data
            return vData;
        }
    }
}
