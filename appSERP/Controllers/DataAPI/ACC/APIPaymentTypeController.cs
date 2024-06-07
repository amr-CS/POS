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
    public class APIPaymentTypeController : ApiController
    {

        private IdbPaymentType _dbPaymentType;
        public APIPaymentTypeController(IdbPaymentType dbPaymentType){
            _dbPaymentType = dbPaymentType;
        }

       [HttpGet]
       public string PaymentTypeGET(
       int? pPaymentTypeId = null,
       string pPaymentTypeCode = null,
       string pPaymentTypeNameL1 = null,
       string pPaymentTypeNameL2 = null,
       bool? pPaymentTypeIsActive = null,
       bool? pIsDeleted = false,
       int? pQueryTypeId = clsQueryType.qSelect)
        {
           // GET DATA 
           string vData = _dbPaymentType.funPaymentTypeGET(
           pPaymentTypeId : pPaymentTypeId,
           pPaymentTypeCode : pPaymentTypeCode,
           pPaymentTypeNameL1 : pPaymentTypeNameL1,
           pPaymentTypeNameL2 : pPaymentTypeNameL2,
           pPaymentTypeIsActive : pPaymentTypeIsActive,
           pIsDeleted : pIsDeleted,
           pQueryTypeId : pQueryTypeId
                    );

            // Result
            return vData;
        }
    }
}
