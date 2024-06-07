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
    public class APIPlateController : ApiController
    {
        private IdbPlate _dbPlate;
        public APIPlateController(IdbPlate dbPlate) {
            _dbPlate = dbPlate;
        }
        [HttpGet]
        public  string funPlateItemGET(
       int? pPlateItemId = null,
       int? pItemId = null,
       int? pPlateId = null,
       int? pPlateQty = null,
       bool? pIsDeleted = false,
       bool? pIsActive = true,
       int? pQueryTypeId = clsQueryType.qSelect)
        {
          // Declaration 
          string vData = _dbPlate.funPlateItemGET(
          pPlateItemId: pPlateItemId,
          pItemId: pItemId,
          pPlateId: pPlateId,
          pPlateQty: pPlateQty,
          pIsDeleted: pIsDeleted,
          pIsActive: pIsActive,
          pQueryTypeId: pQueryTypeId
                );
            return vData;
        }
    }
}
