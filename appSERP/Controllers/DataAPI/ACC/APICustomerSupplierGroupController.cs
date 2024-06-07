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
    public class APICustomerSupplierGroupController : ApiController
    {
        private IdbCustomerSupplierGroup _dbCustomerSupplierGroup;
        public APICustomerSupplierGroupController(IdbCustomerSupplierGroup dbCustomerSupplierGroup)
        {
            _dbCustomerSupplierGroup = dbCustomerSupplierGroup;
        }

        [HttpGet]
        public string CustomerSupplierGroupGET(
        int? pCSGroupId = null,
        string pCSGroupNameL1 = null,
        string pCSGroupNameL2 = null,
        decimal? pCSGroupCreditLimit = null,
        int? pCSGroupGracePeriodDays = null,
        bool? pCSGroupIsCustomerGroup = null,
        bool? pCSGroupIsDefault = null,
        bool? pCSGroupIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbCustomerSupplierGroup.funCustomerSupplierGroupGET(
            pCSGroupId: pCSGroupId,
            pCSGroupNameL1: pCSGroupNameL1,
            pCSGroupNameL2: pCSGroupNameL2,
            pCSGroupCreditLimit: pCSGroupCreditLimit,
            pCSGroupGracePeriodDays: pCSGroupGracePeriodDays,
            pCSGroupIsCustomerGroup: pCSGroupIsCustomerGroup,
            pCSGroupIsDefault: pCSGroupIsDefault,
            pCSGroupIsActive: pCSGroupIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId);
            // Result
            return vData;
        }
    }
}
