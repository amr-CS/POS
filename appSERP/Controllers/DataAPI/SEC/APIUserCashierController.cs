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
    public class APIUserCashierController : ApiController
    {
        private IdbUserCashier _dbUserCashier;
        public APIUserCashierController(IdbUserCashier dbUserCashier) {
            _dbUserCashier = dbUserCashier;
        }
        [HttpGet]
        public string UserCashierGET(
       int? pUserCashierId = null,
       int? pUserId = null,
       int? pCashierId = null,
       bool? pModifyInvoice = null,
       bool? pCancelInvoice = null,
       bool? pRePrintInvoice = null,
       bool? pIsCashierDelivery = null,
       bool? pPcVerfiy = null,
       bool? pReturnInsurance = null,
       bool? pSearchInvoice = null,
       bool? pHoldInvoice = null,
       bool? Discount = null,
       int? pInsuranceLimit = null,
       int? ReportPeriod = null,
       bool? pIsDeleted = null,
       int? pQueryTypeId = clsQueryType.qSelect)
        {
            string vData = _dbUserCashier.funUserCashierGET(
            pUserCashierId: pUserCashierId,
            pUserId: pUserId,
            pCashierId: pCashierId,
            pModifyInvoice: pModifyInvoice,
            pCancelInvoice: pCancelInvoice,
            pRePrintInvoice: pRePrintInvoice,
            pIsCashierDelivery: pIsCashierDelivery,
            pPcVerfiy: pPcVerfiy,
            pReturnInsurance: pReturnInsurance,
            pSearchInvoice: pSearchInvoice,
            pHoldInvoice: pHoldInvoice,
            Discount: Discount,
            pInsuranceLimit: pInsuranceLimit,
            pIsDeleted: pIsDeleted,
            ReportPeriod: ReportPeriod,
            pQueryTypeId: pQueryTypeId);
            return vData;
        }
    }
}
