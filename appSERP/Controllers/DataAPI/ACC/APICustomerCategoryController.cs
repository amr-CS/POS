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
    public class APICustomerCategoryController : ApiController
    {
        private IdbCustomerCategory _dbCustomerCategory;
        public APICustomerCategoryController(IdbCustomerCategory dbCustomerCategory) {
            _dbCustomerCategory = dbCustomerCategory;
        }

        [HttpGet]
        public string CustomerCategoryGET(
      int? pCustomerCategoryId = null,
     string pCustomerCategoryCode = null,
      string pCustomerCategoryNameL1 = null,
      string pCustomerCategoryNameL2 = null,
       bool? pCustomerCategoryIsActive = true,
      bool? pIsDeleted = false,
  int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data
            string vData = _dbCustomerCategory.funCustomerCategoryGET(
            pCustomerCategoryId: pCustomerCategoryId,
            pCustomerCategoryCode: pCustomerCategoryCode,
            pCustomerCategoryNameL1: pCustomerCategoryNameL1,
            pCustomerCategoryNameL2: pCustomerCategoryNameL2,
            pCustomerCategoryIsActive: pCustomerCategoryIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
               );
            // Return Data
            return vData;
        }
    }
}
