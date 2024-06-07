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
    public class APICashFlowTypeController : ApiController
    {
        private IdbCashFlowType _dbCashFlowType;
        public APICashFlowTypeController(IdbCashFlowType dbCashFlowType)
        {
            _dbCashFlowType = dbCashFlowType;
        }

        [HttpGet]
       public  string CashFlowTypeGET(
       int? pCashFlowTypeId = null,
       string pCashFlowTypeCode = null,
       string pCashFlowTypeNameL1 = null,
       string pCashFlowTypeNameL2 = null,
       bool? pCashFlowTypeIsActive = null,
       bool? pIsDeleted = false,
       int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbCashFlowType.funCashFlowTypeGET(
            pCashFlowTypeId : pCashFlowTypeId,
            pCashFlowTypeCode : pCashFlowTypeCode,
            pCashFlowTypeNameL1 : pCashFlowTypeNameL1,
            pCashFlowTypeNameL2 : pCashFlowTypeNameL2,
            pCashFlowTypeIsActive : pCashFlowTypeIsActive,
            pIsDeleted : pIsDeleted,
            pQueryTypeId : pQueryTypeId
            );
            return vData;
        }
    }
}
