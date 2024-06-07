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
    public class APIFinancialYearStatusController : ApiController
    {
        private IdbFinancialYearStatus _dbFinancialYearStatus;
        public APIFinancialYearStatusController(IdbFinancialYearStatus dbFinancialYearStatus) {
            _dbFinancialYearStatus = dbFinancialYearStatus;
        }

        [HttpGet]
        public  string FinancialYearStatusGET(
        int? pFinancialYearStatusId = null,
        string pFinancialYearStatusNameL1 = null,
        string pFinancialYearStatusNameL2 = null,
        bool? pFinancialYearStatusIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
        // Get Data 
        string vData = _dbFinancialYearStatus.funFinancialYearStatusGET(
        pFinancialYearStatusId : pFinancialYearStatusId,
        pFinancialYearStatusNameL1 : pFinancialYearStatusNameL1,
        pFinancialYearStatusNameL2 : pFinancialYearStatusNameL2,
        pFinancialYearStatusIsActive : pFinancialYearStatusIsActive,
        pIsDeleted : pIsDeleted,
        pQueryTypeId : pQueryTypeId);

        // Result
        return vData;
        }
    }
}
