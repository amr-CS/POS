using appSERP.appCode.dbCode.RES;
using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.RES
{
    public class APIDirectPrintController : ApiController
    {
        private IdbDirectPrint _dbDirectPrint;
        public APIDirectPrintController(IdbDirectPrint dbDirectPrint) {
            _dbDirectPrint = dbDirectPrint;
        }
        [HttpGet]
        public string DirectPrintGET(
  int? pDirectPrintId = null,
      string pDirectPrintCode = null,
      string pDirectPrintNameL1 = null,
      string pDirectPrintNameL2 = null,
      bool? pDirectPrintIsActive = true,
   bool? pIsDeleted = false,
   int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbDirectPrint.funDirectPrintGET(
            pDirectPrintId: pDirectPrintId,
            pDirectPrintCode: pDirectPrintCode,
            pDirectPrintNameL1: pDirectPrintNameL1,
            pDirectPrintNameL2: pDirectPrintNameL2,
            pDirectPrintIsActive: pDirectPrintIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
