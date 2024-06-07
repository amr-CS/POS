using appSERP.appCode.dbCode.SEC;
using appSERP.appCode.dbCode.SEC.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.SEC
{
    public class APIUserSecurityTransactionTypeController : ApiController
    {
        private IdbUserSecurityTransactionType _dbUserSecurityTransactionType;
        public APIUserSecurityTransactionTypeController(IdbUserSecurityTransactionType dbUserSecurityTransactionType) {
            _dbUserSecurityTransactionType = dbUserSecurityTransactionType;
        }

        [HttpGet]
        public string UserSecurityTransactionTypeGET(
        string pUserSecurityTransactionTypeId = null,
        string pUserSecurityTransactionTypeNameL1 = null,
        string pUserSecurityTransactionTypeNameL2 = null,
        string pUserSecurityTransactionTypeNameL3 = null,
        string pUserSecurityTransactionTypeNameL4 = null,
        string pUserSecurityTransactionTypeNameL5 = null,
        string pUserSecurityTransactionTypeNameL6 = null,
        string pUserSecurityTransactionTypeNameL7 = null,
        string pUserSecurityTransactionTypeNameL8 = null,
        string pUserSecurityTransactionTypeNameL9 = null,
        string pUserSecurityTransactionTypeNameL10 = null,
        bool? pUserSecurityTransactionTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // GET DATA 
            string vData = _dbUserSecurityTransactionType.funUserSecurityTransactionTypeGET(
            pUserSecurityTransactionTypeId : pUserSecurityTransactionTypeId,
            pUserSecurityTransactionTypeNameL1 : pUserSecurityTransactionTypeNameL1,
            pUserSecurityTransactionTypeNameL2 : pUserSecurityTransactionTypeNameL2,
            pUserSecurityTransactionTypeNameL3 : pUserSecurityTransactionTypeNameL3,
            pUserSecurityTransactionTypeNameL4 : pUserSecurityTransactionTypeNameL4,
            pUserSecurityTransactionTypeNameL5 : pUserSecurityTransactionTypeNameL5,
            pUserSecurityTransactionTypeNameL6 : pUserSecurityTransactionTypeNameL6,
            pUserSecurityTransactionTypeNameL7 : pUserSecurityTransactionTypeNameL7,
            pUserSecurityTransactionTypeNameL8 : pUserSecurityTransactionTypeNameL8,
            pUserSecurityTransactionTypeNameL9 : pUserSecurityTransactionTypeNameL9,
            pUserSecurityTransactionTypeNameL10 : pUserSecurityTransactionTypeNameL10,
            pUserSecurityTransactionTypeIsActive : pUserSecurityTransactionTypeIsActive,
            pIsDeleted : pIsDeleted,
            pQueryTypeId : pQueryTypeId
                );

            // Result
            return vData;
        }
    }
}
