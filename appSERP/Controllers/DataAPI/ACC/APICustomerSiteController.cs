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
    public class APICustomerSiteController : ApiController
    {
        private IdbCustomerSite _dbCustomerSite;
        public APICustomerSiteController(IdbCustomerSite dbCustomerSite)
        {
            _dbCustomerSite = dbCustomerSite;

        }

        [HttpGet]
        public string CustomerSiteGET(
        int? pCustomerSiteId = null,
        string pCustomerSiteCode = null,
        string pCustomerSiteNameL1 = null,
        string pCustomerSiteNameL2 = null,
        int? pCustomerId = null,
        int? pSiteId = null,
        bool? pCustomerSiteIsActive = true,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data
            string vData = _dbCustomerSite.funCustomerSiteGET(
                pCustomerSiteId: pCustomerSiteId,
                pCustomerSiteCode: pCustomerSiteCode,
                pCustomerSiteNameL1: pCustomerSiteNameL1,
                pCustomerSiteNameL2: pCustomerSiteNameL2,
                pCustomerId: pCustomerId,
                pSiteId: pSiteId,
                pCustomerSiteIsActive: pCustomerSiteIsActive,
                pIsDeleted: pIsDeleted,
                pQueryTypeId: pQueryTypeId
                );
            // Return Data
            return vData;
        }
    }
}
