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
    public class APITransactionSourceController : ApiController
    {
        private IdbTransactionSource _dbTransactionSource;
        public APITransactionSourceController(IdbTransactionSource dbTransactionSource) {
            _dbTransactionSource = dbTransactionSource;
        }

       [HttpGet]
       public  string TransactionSourceGET(
       int? pTransactionSourceId = null,
       string pTransactionSourceCode = null,
       string pTransactionSourceNameL1 = null,
       string pTransactionSourceNameL2 = null,
       bool? pTransactionSourceIsActive = null,
       bool? pIsDeleted = false,
       int? pQueryTypeId = clsQueryType.qSelect)
        {
               // Get Data 
               string vData = _dbTransactionSource.funTransactionSourceGET(
               pTransactionSourceId : pTransactionSourceId,
               pTransactionSourceCode : pTransactionSourceCode,
               pTransactionSourceNameL1 : pTransactionSourceNameL1,
               pTransactionSourceNameL2 : pTransactionSourceNameL2,
               pTransactionSourceIsActive : pTransactionSourceIsActive,
               pIsDeleted : pIsDeleted,
               pQueryTypeId : pQueryTypeId
                );

            // Result
            return vData;
        }
    }
}
