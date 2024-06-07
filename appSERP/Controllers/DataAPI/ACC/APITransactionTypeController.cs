using appSERP.appCode.dbCode.ACC;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using appSERP.appCode.dbCode.ACC.Abstract;

namespace appSERP.Controllers.DataAPI.ACC
{
    public class APITransactionTypeController : ApiController
    {
        private IdbTransactionType _dbTransactionType;
        public APITransactionTypeController(IdbTransactionType dbTransactionType) {
            _dbTransactionType = dbTransactionType;
        }

        [HttpGet] 
        public string TransactionTypeGET(
        int? pTransactionTypeId = null,
        string pTransactionTypeCode = null,
        string pTransactionTypeNameL1 = null,
        string pTransactionTypeNameL2 = null,
        int? pSystemId = null,
        int? pSystemTransactionTypeId = null,
        bool? pTransactionTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // GET DATA 
            string vData = _dbTransactionType.funTransactionTypeGET(
            pTransactionTypeId : pTransactionTypeId,
            pTransactionTypeCode : pTransactionTypeCode,
            pTransactionTypeNameL1 : pTransactionTypeNameL1,
            pTransactionTypeNameL2 : pTransactionTypeNameL2,
            pSystemId: pSystemId,
            pSystemTransactionTypeId : pSystemTransactionTypeId,
            pTransactionTypeIsActive : pTransactionTypeIsActive,
            pIsDeleted : pIsDeleted,
            pQueryTypeId : pQueryTypeId);

            // Return Result
            return vData;
        }
    }
}
