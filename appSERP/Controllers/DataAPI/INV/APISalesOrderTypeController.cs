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
    public class APISalesOrderTypeController : ApiController
    {
        private IdbSalesOrderType _dbSalesOrderType;
        public APISalesOrderTypeController(IdbSalesOrderType dbSalesOrderType)
        {
            _dbSalesOrderType = dbSalesOrderType;
        }

        [HttpGet]
        public string SalesOrderTypeGET(
      int? pSalesOrderTypeId = null,
      string pSalesOrderTypeCode = null,
      string pSalesOrderTypeNameL1 = null,
      string pSalesOrderTypeNameL2 = null,
      string pAbbr = null,
      bool? pIsDefault = null,
      bool? pSalesOrderTypeIsActive = null,
      bool? pIsDeleted = false,
      int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbSalesOrderType.funSalesOrderTypeGET(
            pSalesOrderTypeId: pSalesOrderTypeId,
            pSalesOrderTypeCode: pSalesOrderTypeCode,
            pSalesOrderTypeNameL1: pSalesOrderTypeNameL1,
            pSalesOrderTypeNameL2: pSalesOrderTypeNameL2,
            pAbbr: pAbbr,
            pIsDefault: pIsDefault,
            pSalesOrderTypeIsActive: pSalesOrderTypeIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
