using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.RES.Abstract
{
    public interface IdbDirectPrint
    {
        string funDirectPrintGET(
        int? pDirectPrintId = null,
        string pDirectPrintCode = null,
        string pDirectPrintNameL1 = null,
        string pDirectPrintNameL2 = null,
        bool? pDirectPrintIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
