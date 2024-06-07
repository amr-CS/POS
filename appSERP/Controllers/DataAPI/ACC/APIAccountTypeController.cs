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
    public class APIAccountTypeController : ApiController
    {
        private IdbAccountType _dbAccountType;
        public APIAccountTypeController(IdbAccountType dbAccountType) {
            _dbAccountType = dbAccountType;
        }


       [HttpGet]
       public string AccountTypeGET(
       int? pAccountTypeId = null,
       string pAccountTypeCode = null,
       string pAccountTypeNameL1 = null,
       string pAccountTypeNameL2 = null,
       bool? pAccountTypeIsActive = null,
       bool? pIsDeleted = false,
       int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbAccountType.funAccountTypeGET(
            pAccountTypeId : pAccountTypeId,
            pAccountTypeCode : pAccountTypeCode,
            pAccountTypeNameL1 : pAccountTypeNameL1,
            pAccountTypeNameL2 : pAccountTypeNameL2,
            pAccountTypeIsActive : pAccountTypeIsActive,
            pIsDeleted : pIsDeleted,
            pQueryTypeId : pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
