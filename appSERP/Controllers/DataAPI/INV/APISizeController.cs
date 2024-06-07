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
    public class APISizeController : ApiController
    {
        private IdbSize _dbSize;
        public APISizeController(IdbSize dbSize)
        {

            _dbSize = dbSize;
        }
        [HttpGet]
        public string SizeGET(
  int? pSizeId = null,
  string pSizeCode = null,
  string pSizeNameL1 = null,
  string pSizeNameL2 = null,
  int? pSizeTypeId = null,
   int? pUnitId = null,
  bool? pSizeIsActive = null,
  bool? pIsDetail = true,
  bool? pIsUnitDetail = false,
  bool? pIsDeleted = false,
  int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbSize.funSizeGET(
            pSizeId: pSizeId,
            pSizeCode: pSizeCode,
            pSizeNameL1: pSizeNameL1,
            pSizeNameL2: pSizeNameL2,
            pSizeTypeId: pSizeTypeId,
            pUnitId: pUnitId,
            pSizeIsActive: pSizeIsActive,
            pIsDetail: pIsDetail,
            pIsUnitDetail: pIsUnitDetail,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
