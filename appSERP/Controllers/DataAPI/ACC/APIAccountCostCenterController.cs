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
    public class APIAccountCostCenterController : ApiController
    {
        private IdbAccountCostCenter _dbAccountCostCenter;
        public APIAccountCostCenterController(IdbAccountCostCenter dbAccountCostCenter)
        {
            _dbAccountCostCenter = dbAccountCostCenter;
        }

        [HttpGet]
        public string AccountCostCenterGET(
        int? pAccountCostCenterId = null,
        int? pAccountId = null,
        int? pCostCenterId = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbAccountCostCenter.funAccountCostCenterGET(
             pAccountCostCenterId: pAccountCostCenterId,
             pAccountId: pAccountId,
             pCostCenterId: pCostCenterId,
             pIsDeleted: pIsDeleted,
             pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }

    }
}
