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
    public class APICustomerSupplierController : ApiController
    {

        private IdbCustomerSupplier _dbCustomerSupplier;
        public APICustomerSupplierController(IdbCustomerSupplier dbCustomerSupplier) {
            _dbCustomerSupplier = dbCustomerSupplier;
        }

        [HttpGet]
        public string CustomerSupplierGET(
        int? pCSId = null,
        string pCSCode = null,
        string pCSNameL1 = null,
        string pCSNameL2 = null,
        string pCSAddress = null,
        string pCSPhone1 = null,
        string pCSPhone2 = null,
        string pCSEmail = null,
        string pCSContactPerson = null,
        string pCSSalesPurchasePerson = null,
        string pCSTaxNumber = null,
        int? pAreaId = null,
        string pCSCreditLimit = null,
        int? pCSGroupId = null,
        int? pGracePeriod = null,
        int? pAccountId = null,
        bool? pCSIsCustomer = null,
        bool? pCSIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
                // Get Data 
                string vData = _dbCustomerSupplier.funCustomerSupplierGET(
                pCSId : pCSId,
                pCSCode : pCSCode,
                pCSNameL1 : pCSNameL1,
                pCSNameL2 : pCSNameL2,
                pCSAddress : pCSAddress,
                pCSPhone1 : pCSPhone1,
                pCSPhone2 : pCSPhone2,
                pCSEmail : pCSEmail,
                pCSContactPerson : pCSContactPerson,
                pCSSalesPurchasePerson : pCSSalesPurchasePerson,
                pCSTaxNumber : pCSTaxNumber,
                pAreaId : pAreaId,
                pCSCreditLimit : pCSCreditLimit,
                pCSGroupId : pCSGroupId,
                pGracePeriod : pGracePeriod,
                pAccountId : pAccountId,
                pCSIsCustomer : pCSIsCustomer,
                pCSIsActive : pCSIsActive,
                pIsDeleted : pIsDeleted,
                pQueryTypeId : pQueryTypeId
                );
            // Result
            return vData;
        }
    }
}
