using appSERP.appCode.dbCode.INV;
using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.INV
{
    public class APICategoryAccountController : ApiController
    {
        private IdbCategoryAccount _dbCategoryAccount;
        public APICategoryAccountController(IdbCategoryAccount dbCategoryAccount) {
            _dbCategoryAccount = dbCategoryAccount;
        }

        [HttpGet]
        public string CategoryAccountGET(
        int? pCategoryAccountId = null,
        string pCategoryAccountCode = null,
        string pCategoryAccountNameL1 = null,
        string pCategoryAccountNameL2 = null,
        int? pCurrencyId = null,
        int? pAccountId = null,
        int? pSalesAccountId = null,
        int? pReturnSalesAccountId = null,
        int? pDiscountReceivedId = null,
        int? pDiscountAllowedId = null,
        int? pTaxAccountId = null,
        int? pGroupAccountId = null,
        int? pReturnPurchasesAccountId = null,
        int? pSalesCostAccountId = null,
        int? pProductTypeId = null,
        bool? pCategoryAccountIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbCategoryAccount.funCategoryAccountGET(
            pCategoryAccountId: pCategoryAccountId,
            pCategoryAccountCode: pCategoryAccountCode,
            pCategoryAccountNameL1: pCategoryAccountNameL1,
            pCategoryAccountNameL2: pCategoryAccountNameL2,
            pCurrencyId: pCurrencyId,
            pAccountId: pAccountId,
           pSalesAccountId: pSalesAccountId,
           pReturnSalesAccountId: pReturnSalesAccountId,
           pDiscountReceivedId: pDiscountReceivedId,
           pDiscountAllowedId: pDiscountAllowedId,
          pTaxAccountId: pTaxAccountId,
          pGroupAccountId : pGroupAccountId,
          pReturnPurchasesAccountId : pReturnPurchasesAccountId,
          pSalesCostAccountId : pSalesCostAccountId,
          pProductTypeId: pProductTypeId,
            pCategoryAccountIsActive: pCategoryAccountIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
