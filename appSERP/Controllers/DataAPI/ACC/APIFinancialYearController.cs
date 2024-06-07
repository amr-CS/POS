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
    public class APIFinancialYearController : ApiController
    {
        private IdbFinancialYear _dbFinancialYear;
        public APIFinancialYearController(IdbFinancialYear dbFinancialYear) {
            _dbFinancialYear = dbFinancialYear;
        }

        [HttpGet]
        public string FinancialYearGET(
        int? pFinancialYearId = null,
        string pFinancialYear = null,
        DateTime? pFinancialYearStart = null ,
        DateTime? pFinancialYearEnd = null,
        int? pFinancialYearStatusId = null,
        bool? pFinancialYearIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
                // GET Data 
                string vData = _dbFinancialYear.funFinancialYearGET(
                pFinancialYearId : pFinancialYearId,
                pFinancialYear : pFinancialYear,
                pFinancialYearStart : pFinancialYearStart,
                pFinancialYearEnd : pFinancialYearEnd,
                pFinancialYearStatusId : pFinancialYearStatusId,
                pFinancialYearIsActive : pFinancialYearIsActive,
                pIsDeleted : pIsDeleted,
                pQueryTypeId : pQueryTypeId
                );
            // Result
            return vData;
        }
    }
}
