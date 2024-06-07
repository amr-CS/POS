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
    public class APIOfferTypeController : ApiController
    {
        private IdbOfferType _dbOfferType;
        public APIOfferTypeController(IdbOfferType dbOfferType)
        {
            _dbOfferType = dbOfferType;
        }

        [HttpGet]
        public string OfferTypeGET(
      int? pOfferTypeId = null,
      string pOfferTypeCode = null,
      string pOfferTypeNameL1 = null,
      string pOfferTypeNameL2 = null,
      string pAbbr = null,
      bool? pIsDefault = null,
      bool? pOfferTypeIsActive = null,
      bool? pIsDeleted = false,
      int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbOfferType.funOfferTypeGET(
            pOfferTypeId: pOfferTypeId,
            pOfferTypeCode: pOfferTypeCode,
            pOfferTypeNameL1: pOfferTypeNameL1,
            pOfferTypeNameL2: pOfferTypeNameL2,
            pAbbr: pAbbr,
            pIsDefault: pIsDefault,
            pOfferTypeIsActive: pOfferTypeIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
