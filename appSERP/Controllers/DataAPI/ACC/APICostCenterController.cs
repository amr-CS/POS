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
    public class APICostCenterController : ApiController
    {
        private IdbCostCenter _dbCostCenter;
        public APICostCenterController(IdbCostCenter dbCostCenter) {
            _dbCostCenter = dbCostCenter;
        }

        [HttpGet]
        public  string CostCenterGET(
        int? pCostCenterId = null,
        string pCostCenterCode = null,
        string pCostCenterNameL1 = null,
        string pCostCenterNameL2 = null,
        int? pCostCenterParentId = null,
        int? pCostCenterLevel = null,
        bool? pCostCenterIsAccumulative = null,
        bool? pCostCenterIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // GET DATA 
            string vData = _dbCostCenter.funCostCenterGET(
            pCostCenterId: pCostCenterId,
            pCostCenterCode: pCostCenterCode,
            pCostCenterNameL1: pCostCenterNameL1,
            pCostCenterNameL2: pCostCenterNameL2,
            pCostCenterParentId: pCostCenterParentId,
            pCostCenterLevel: pCostCenterLevel,
            pCostCenterIsAccumulative: pCostCenterIsAccumulative,
            pCostCenterIsActive: pCostCenterIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId);
            // Result
            return vData;
        }
    }
}
