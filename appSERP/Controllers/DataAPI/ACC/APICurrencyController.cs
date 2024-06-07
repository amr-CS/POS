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
    public class APICurrencyController : ApiController
    {
        private IdbCurrency _dbCurrency;
        public APICurrencyController(IdbCurrency dbCurrency) {
            _dbCurrency = dbCurrency;
        }

        [HttpGet]
        public string CurrencyGET(
        int? pCurrencyId = null,
        string pCurrencyCode = null,
        string pCurrencyNameL1 = null,
        string pCurrencyNameL2 = null,
        decimal? pCurrencyExchange = null,
        int? pCurrencyDecimal = null,
        int? pCurrencyFactorId = null,
        bool? pCurrencyIsDefault = null,
        int? pCurrencyGenderId = null,
        bool? pCurrencyIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // GET DATA
            string vData = _dbCurrency.funCurrencyGET(
            pCurrencyId         : pCurrencyId,
            pCurrencyCode       : pCurrencyCode,
            pCurrencyNameL1     : pCurrencyNameL1,
            pCurrencyNameL2     : pCurrencyNameL2,
            pCurrencyExchange   : pCurrencyExchange,
            pCurrencyDecimal    : pCurrencyDecimal,
            pCurrencyFactorId   : pCurrencyFactorId,
            pCurrencyIsDefault  : pCurrencyIsDefault,
            pCurrencyGenderId   : pCurrencyGenderId,
            pCurrencyIsActive   : pCurrencyIsActive,
            pIsDeleted          : pIsDeleted,
            pQueryTypeId        : pQueryTypeId
                );
            // Result
            return vData;
        }
    }
}
