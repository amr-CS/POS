using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.RES.Abstract
{
    public interface IdbPrinterDTL
    {

        string funPrinterDTLGET(
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
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
