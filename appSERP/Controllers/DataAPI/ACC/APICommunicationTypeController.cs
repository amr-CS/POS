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
    public class APICommunicationTypeController : ApiController
    {

        private IdbCommunicationType _dbCommunicationType;
        public APICommunicationTypeController(IdbCommunicationType dbCommunicationType) {
            _dbCommunicationType = dbCommunicationType;
        }

        [HttpGet]
        public string CommunicationTypeGET(
     int? pTypeId = null,
    string pTypeCode = null,
     string pTypeNameL1 = null,
     string pTypeNameL2 = null,
      bool? pTypeIsActive = true,
     bool? pIsDeleted = false,
 int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data
            string vData = _dbCommunicationType.funCommunicationTypeGET(
            pTypeId: pTypeId,
            pTypeCode: pTypeCode,
            pTypeNameL1: pTypeNameL1,
            pTypeNameL2: pTypeNameL2,
            pTypeIsActive: pTypeIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
               );
            // Return Data
            return vData;
        }
    }
}
