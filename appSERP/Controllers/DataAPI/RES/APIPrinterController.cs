using appSERP.appCode.dbCode.RES;
using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.RES
{
    public class APIPrinterController : ApiController
    {
        private IdbPrinter _dbPrinter;
        public APIPrinterController(IdbPrinter dbPrinter) {
            _dbPrinter = dbPrinter;
        }

        [HttpGet]
        public string PrinterGET(
     int? pPrinterId = null,
         string pPrinterCode = null,
        int? pPrinterSeq = null,
        string pReportNameL1 = null,
        string pReportNameL2 = null,
        string pPrinterDescL1 = null,
        string pPrinterDescL2 = null,
        bool? pPrinterIsActive = true,
     bool? pIsDeleted = false,
     int? pQueryTypeId = clsQueryType.qSelect,
       string pPrintersList = null
     )
        {
            // Get Data 
            string vData = _dbPrinter.funPrinterGET(
            pPrinterId: pPrinterId,
            pPrinterCode: pPrinterCode,
            pPrinterSeq: pPrinterSeq,
            pReportNameL1: pReportNameL1,
           pReportNameL2: pReportNameL2,
            pPrinterDescL1: pPrinterDescL1,
            pPrinterDescL2 : pPrinterDescL2,
            pPrinterIsActive: pPrinterIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId,
            pPrintersList : pPrintersList
            );
            // Result
            return vData;
        }
    }
}
