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
    public class APIProductTypeController : ApiController
    {
        private IdbProductType _dbProductType;
        public APIProductTypeController(IdbProductType dbProductType) {
            _dbProductType = dbProductType;
        }

        [HttpGet]
        public string ProductTypeGET(
      int? pProductTypeId = null,
      string pProductTypeCode = null,
      string pProductTypeNameL1 = null,
      string pProductTypeNameL2 = null,
      string pShortName = null,
      string pProductTypeLevel = null,
      int? pProductTypeParentId = null,
      bool? pProductTypeIsActive = null,
      bool? pIsDeleted = false,
      int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbProductType.funProductTypeGET(
            pProductTypeId: pProductTypeId,
            pProductTypeCode: pProductTypeCode,
            pProductTypeNameL1: pProductTypeNameL1,
            pProductTypeNameL2: pProductTypeNameL2,
            pShortName: pShortName,
            pProductTypeLevel: pProductTypeLevel,
            pProductTypeParentId: pProductTypeParentId,
            pProductTypeIsActive: pProductTypeIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
