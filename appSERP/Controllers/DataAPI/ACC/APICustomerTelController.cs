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
    public class APICustomerTelController : ApiController
    {
        private IdbCustomerTel _dbCustomerTel;
        public APICustomerTelController(IdbCustomerTel dbCustomerTel)
        {
            _dbCustomerTel = dbCustomerTel;
        }

        [HttpGet]
        public string CustomerTelGET(
      int? pCustomerTelId = null,
       string pCustomerTelCode = null,
       string pCustomerTelNo = null,
       string pCustomerTelNameL2 = null,
       int? pCustomerId = null,
     bool? pCustomerTelIsActive = true,
     bool? pIsDeleted = false,
 int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data
            string vData = _dbCustomerTel.funCustomerTelGET(
                pCustomerTelId: pCustomerTelId,
                pCustomerTelCode: pCustomerTelCode,
                pCustomerTelNo: pCustomerTelNo,
                pCustomerId: pCustomerId,
                pCustomerTelIsActive: pCustomerTelIsActive,
                pIsDeleted: pIsDeleted,
                pQueryTypeId: pQueryTypeId
                );
            // Return Data
            return vData;
        }
    }
}
