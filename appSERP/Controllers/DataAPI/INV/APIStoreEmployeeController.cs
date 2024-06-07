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
    public class APIStoreEmployeeController : ApiController
    {
        private IdbStoreEmployee _dbStoreEmployee;
        public APIStoreEmployeeController(IdbStoreEmployee dbStoreEmployee)
        {
            _dbStoreEmployee = dbStoreEmployee;
        }

        [HttpGet]
        public string StoreEmployeeGET(
         int? pStoreEmployeeId = null,
     string pStoreEmployeeCode = null,
   string pStoreEmployeeName = null,
   int? pGeneralNumber = null,
   string pJob = null,
  decimal? pProfit = null,
 DateTime? pEmployeeStartDate = null,
 DateTime? pEmployeeEndDate = null,
 string pNotes = null,
 bool? pStoreEmployeeIsActive = null,
 bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect,
           string pSearchStartDate = null,
      string pSearchEndDate = null,
     string pList = null

            )
        {
            // GET Data 
            string vData = _dbStoreEmployee.funStoreEmployeeGET(
            pStoreEmployeeId: pStoreEmployeeId,
            pStoreEmployeeCode : pStoreEmployeeCode,
            pStoreEmployeeName : pStoreEmployeeName,
            pGeneralNumber : pGeneralNumber,
            pJob : pJob,
            pProfit : pProfit,
            pEmployeeStartDate : pEmployeeStartDate,
            pEmployeeEndDate : pEmployeeEndDate,
            pNotes : pNotes,
            pStoreEmployeeIsActive: pStoreEmployeeIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId,
            pSearchStartDate: pSearchStartDate,
            pSearchEndDate: pSearchEndDate,
            pList: pList
            );
            // Result
            return vData;
        }
    }
}
