using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.RES.Abstract
{
    public interface IdbPrinter
    {
        string funPrinterGET(
         int? pPrinterId = null,
         string pPrinterCode = null,
        int? pPrinterSeq = null,
        string pReportNameL1 = null,
        string pReportNameL2 = null,
        string pPrinterDescL1 = null,
        string pPrinterDescL2 = null,
        bool? pPrinterIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null,
        string pPrintersList = null
        );

        DataTable funGetPrinterReport(bool? pIsActive = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
