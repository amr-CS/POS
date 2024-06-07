using appSERP.appCode.dbCode.SYSSETT;
using appSERP.appCode.dbCode.SYSSETT.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.SYSSETT
{
    public class APIDocStatusController : ApiController
    {
        private IdbDocStatus _dbDocStatus;
        public APIDocStatusController(IdbDocStatus dbDocStatus) {
            _dbDocStatus = dbDocStatus;
        }
        [HttpGet]
        public  string DocStatusGET(
        string pDocStatusId = null,
        string pDocStatusNameL1 = null,
        string pDocStatusNameL2 = null,
        string pDocStatusNameL3 = null,
        string pDocStatusNameL4 = null,
        string pDocStatusNameL5 = null,
        string pDocStatusNameL6 = null,
        string pDocStatusNameL7 = null,
        string pDocStatusNameL8 = null,
        string pDocStatusNameL9 = null,
        string pDocStatusNameL10 = null,
        string pDocStatusNext = null,
        string pDocStatusProName = null,
        bool? pDocStatusIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // GET DATA 
            string vData = _dbDocStatus.funDocStatusGET(
            pDocStatusId : pDocStatusId,
            pDocStatusNameL1 : pDocStatusNameL1,
            pDocStatusNameL2 : pDocStatusNameL2,
            pDocStatusNameL3 : pDocStatusNameL3,
            pDocStatusNameL4 : pDocStatusNameL4,
            pDocStatusNameL5 : pDocStatusNameL5,
            pDocStatusNameL6 : pDocStatusNameL6,
            pDocStatusNameL7 : pDocStatusNameL7,
            pDocStatusNameL8 : pDocStatusNameL8,
            pDocStatusNameL9 : pDocStatusNameL9,
            pDocStatusNameL10 : pDocStatusNameL10,
            pDocStatusNext : pDocStatusNext,
            pDocStatusProName : pDocStatusProName,
            pDocStatusIsActive : pDocStatusIsActive,
            pIsDeleted : pIsDeleted,
            pQueryTypeId : pQueryTypeId);

            // Result
            return vData;
        }
    }
}
