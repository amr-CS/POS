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
    public class APICurrencyFactorController : ApiController
    {
        private IdbCurrencyFactor _dbCurrencyFactor;
        public APICurrencyFactorController(IdbCurrencyFactor dbCurrencyFactor) {
            _dbCurrencyFactor = dbCurrencyFactor;
        }

        [HttpGet]
        public  string CurrencyFactorGET(
        int? pCurrencyFactorId = null,
        string pCurrencyFactorCode = null,
        string pCurrencyFactorNameL1 = null,
        string pCurrencyFactorNameL2 = null,
        decimal? pCurrencyFactorValue = null,
        bool? pCurrencyFactorIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // GET DATA 
            string vData = _dbCurrencyFactor.funCurrencyFactorGET(
            pCurrencyFactorId : pCurrencyFactorId,
            pCurrencyFactorCode : pCurrencyFactorCode,
            pCurrencyFactorNameL1 : pCurrencyFactorNameL1,
            pCurrencyFactorNameL2 : pCurrencyFactorNameL2,
            pCurrencyFactorValue : pCurrencyFactorValue,
            pCurrencyFactorIsActive : pCurrencyFactorIsActive,
            pIsDeleted : pIsDeleted,
            pQueryTypeId : pQueryTypeId);

           // RETURN RESULT
            return vData;
        }
    }
}
