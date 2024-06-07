using appSERP.appCode.dbCode.RES;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.RES
{
    public class APIPeriodController : ApiController
    {
        [HttpGet]
        public string PeriodGET(
       int? pPeriodId = null,
          DateTime? pFromDate = null,
         DateTime? pToDate = null,
        bool? pIsPosted = null,
       bool? pIsPostedStore = null,
       bool? pIsDeleted = null,
      int? pLanguageId = null,
      int? pQueryTypeId = clsQueryType.qSelect)
        {
           // string Data = dbPeriod.funPeriodGET(
           //pPeriodId: pPeriodId,
           //pFromDate: pFromDate,
           //pToDate: pToDate,
           //pIsPosted: pIsPosted,
           //pIsPostedStore: pIsPostedStore,

           // pIsDeleted: pIsDeleted,
           // pQueryTypeId: pQueryTypeId
           //    );
           // // Result
            return null;
        }
    }
}
