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
    public class APIUserTypeController : ApiController
    {
        private IdbUserType _dbUserType;
        public APIUserTypeController(IdbUserType dbUserType)
        {
            _dbUserType = dbUserType;
        }
        [HttpGet]
        public string UserTypeGET(
        int? pUserTypeId = null,
        string pUserTypeCode = null,
        string pUserTypeNameL1 = null,
        string pUserTypeNameL2 = null,
        string pUserTypeMaxDis = null,
        bool? pUserTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // GET DATA 
            string vData = _dbUserType.funUserTypeGET(
            pUserTypeId: pUserTypeId,
            pUserTypeCode: pUserTypeCode,
            pUserTypeNameL1: pUserTypeNameL1,
            pUserTypeNameL2: pUserTypeNameL2,
            pUserTypeMaxDis: pUserTypeMaxDis,
            pUserTypeIsActive: pUserTypeIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
                );

            // RESULT
            return vData;
        }
    }
}
