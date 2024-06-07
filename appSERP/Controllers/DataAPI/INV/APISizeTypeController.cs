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
    public class APISizeTypeController : ApiController
    {
        private IdbSizeType _dbSizeType;
        public APISizeTypeController(IdbSizeType dbSizeType) {
            _dbSizeType = dbSizeType;
        }

        [HttpGet]
        public string SizeTypeGET(
  int? pSizeTypeId = null,
  string pSizeTypeCode = null,
  string pSizeTypeNameL1 = null,
  string pSizeTypeNameL2 = null,
  string pNotes = null,
  bool? pSizeTypeIsActive = null,
  bool? pIsDeleted = false,
  int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbSizeType.funSizeTypeGET(
            pSizeTypeId: pSizeTypeId,
            pSizeTypeCode: pSizeTypeCode,
            pSizeTypeNameL1: pSizeTypeNameL1,
            pSizeTypeNameL2: pSizeTypeNameL2,
            pNotes: pNotes,
            pSizeTypeIsActive: pSizeTypeIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
