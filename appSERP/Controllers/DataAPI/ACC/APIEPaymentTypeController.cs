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
    public class APIEPaymentTypeController : ApiController
    {
        private IdbEPaymentType _dbEPaymentType;
        public APIEPaymentTypeController(IdbEPaymentType dbEPaymentType)
        {
            _dbEPaymentType = dbEPaymentType;
        }

        [HttpGet]
        public string EPaymentTypeGET(
        int? pEPaymentTypeId = null,
        int? pPaymentTypeId = null,
        string pEPaymentTypeCode = null,
        string pEPaymentTypeNameL1 = null,
        string pEPaymentTypeNameL2 = null,
        bool? pEPaymentTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbEPaymentType.funEPaymentTypeGET(
            pEPaymentTypeId: pEPaymentTypeId,
             pPaymentTypeId: pPaymentTypeId,
            pEPaymentTypeCode: pEPaymentTypeCode,
            pEPaymentTypeNameL1: pEPaymentTypeNameL1,
            pEPaymentTypeNameL2: pEPaymentTypeNameL2,
            pEPaymentTypeIsActive: pEPaymentTypeIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
