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
    public class APIPrinterDTLController : ApiController
    {
        private IdbPrinterDTL _dbPrinterDTL;
        public APIPrinterDTLController(IdbPrinterDTL dbPrinterDTL)
        {
            _dbPrinterDTL = dbPrinterDTL;
        }

        [HttpGet]
        public string PrinterDTLGET(
     int? pPrinterDTLId = null,
        string pPrinterDTLCode = null,
        int? pPrinterDTLSeq = null,
        int? pInvTypeId = null,
        string pPrinterName = null,
        string pPrinterIP = null,
        int? pPortTypeId = null,
        int? pPortNo = null,
        int? pDirectPrintId = null,
        int? pPrintNum = null,
         int? pPrinterId = null,
        bool? pPrinterDTLIsActive = null,
     bool? pIsDeleted = false,
     int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbPrinterDTL.funPrinterDTLGET(
            pPrinterDTLId: pPrinterDTLId,
            pPrinterDTLCode: pPrinterDTLCode,
            pPrinterDTLSeq: pPrinterDTLSeq,
            pInvTypeId: pInvTypeId,
            pPrinterName: pPrinterName,
            pPrinterIP: pPrinterIP,
            pPortTypeId: pPortTypeId,
            pPortNo: pPortNo,
            pDirectPrintId: pDirectPrintId,
            pPrintNum: pPrintNum,
            pPrinterId: pPrinterId,
            pPrinterDTLIsActive: pPrinterDTLIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
