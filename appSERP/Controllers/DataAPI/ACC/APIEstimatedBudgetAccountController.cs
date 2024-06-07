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
    public class APIEstimatedBudgetAccountController : ApiController
    {

        private IdbEstimatedBudgetAccount _dbEstimatedBudgetAccount;
        public APIEstimatedBudgetAccountController(IdbEstimatedBudgetAccount dbEstimatedBudgetAccount)
        {
            _dbEstimatedBudgetAccount = dbEstimatedBudgetAccount;
        }

        //[HttpGet]
        //public string EstimatedBudgetAccountGET(
        //int? pEstimatedBudgetAccountId = null,
        //int? pAccountId = null,
        //int? pEstimatedBudgetAccountValue = null,
        //bool? pIsDeleted = false,
        //int? pQueryTypeId = clsQueryType.qSelect)
        //{
        //    // Get Data 
        //    string vData = dbEstimatedBudgetAccount.funEstimatedBudgetAccountGET(
        //    pEstimatedBudgetAccountId: pEstimatedBudgetAccountId,
        //    pAccountId: pAccountId,
        //    pEstimatedBudgetAccountValue:pEstimatedBudgetAccountValue,
        //    pIsDeleted: pIsDeleted,
        //    pQueryTypeId: pQueryTypeId
        //    );
        //    // Result
        //    return vData;
        //}
        [HttpGet]
        public string EstimatedBudgetAccountGET(
      int? pEstimatedBudgetAccountId = null,
      int? pAccountId = null,
      int? pMonthId = null,
      int? pYearId = null,
      string pDateFrom = null,
      string pDateTo = null,
      int? pEstimatedBudgetAccountValue = null,
      bool? pIsDeleted = false,
      int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbEstimatedBudgetAccount.funEstimatedBudgetAccountGET(
            pEstimatedBudgetAccountId: pEstimatedBudgetAccountId,
            pAccountId: pAccountId,
            pMonthId: pMonthId,
            pYearId: pYearId,
            pDateFrom: pDateFrom,
            pDateTo: pDateTo,
            pEstimatedBudgetAccountValue: pEstimatedBudgetAccountValue,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }

    }
}
