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
    public class APISalesMenController : ApiController
    {
        private IdbSalesMen _dbSalesMen;
        public APISalesMenController(IdbSalesMen dbSalesMen) {
            _dbSalesMen = dbSalesMen;
        }

        [HttpGet]
        public string SalesMenGET(
  int? pCodeId = null,
int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbSalesMen.funSalesMenGET(
           pCodeId: pCodeId,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
