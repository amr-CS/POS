using appSERP.appCode.dbCode.FA;
using appSERP.appCode.dbCode.FA.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.FA
{
    public class APIAssetTransactionTypeController : ApiController
    {

        private IdbAssetTransactionType _dbAssetTransactionType;
        public APIAssetTransactionTypeController(IdbAssetTransactionType dbAssetTransactionType)
        {
            _dbAssetTransactionType = dbAssetTransactionType;
        }

        [HttpGet]
        public string TransactionTypeGET(
        int? pTransactionTypeId = null,
        string pTransactionTypeCode = null,
        string pTransactionTypeNameL1 = null,
        string pTransactionTypeNameL2 = null,
        bool? pTransactionTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // GET DATA 
            string vData = _dbAssetTransactionType.funTransactionTypeGET(
            pTransactionTypeId: pTransactionTypeId,
            pTransactionTypeCode: pTransactionTypeCode,
            pTransactionTypeNameL1: pTransactionTypeNameL1,
            pTransactionTypeNameL2: pTransactionTypeNameL2,
            pTransactionTypeIsActive: pTransactionTypeIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId);

            // Return Result
            return vData;
        }
    }
}
