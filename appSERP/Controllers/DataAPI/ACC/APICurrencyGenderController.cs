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
    public class APICurrencyGenderController : ApiController
    {

        private IdbCurrencyGender _dbCurrencyGender;
        public APICurrencyGenderController(IdbCurrencyGender dbCurrencyGender)
        {
            _dbCurrencyGender = dbCurrencyGender;
        }
        [HttpGet]
        public string CurrencyGenderGET(
        int? pCurrencyGenderId = null,
        string pCurrencyGenderCode = null,
        string pCurrencyGenderNameL1 = null,
        string pCurrencyGenderNameL2 = null,
        bool? pCurrencyGenderIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {   // Get Data
            string vData = _dbCurrencyGender.funCurrencyGenderGET(
            pCurrencyGenderId: pCurrencyGenderId,
            pCurrencyGenderCode: pCurrencyGenderCode,
            pCurrencyGenderNameL1: pCurrencyGenderNameL1,
            pCurrencyGenderNameL2: pCurrencyGenderNameL2,
            pCurrencyGenderIsActive: pCurrencyGenderIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId);
            // Result
            return vData;
        }
    }
}
