using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbTransactionSource
    {
        string funTransactionSourceGET(
        int? pTransactionSourceId = null,
        string pTransactionSourceCode = null,
        string pTransactionSourceNameL1 = null,
        string pTransactionSourceNameL2 = null,
        int? pCompanyId = null,
        bool? pTransactionSourceIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        DataTable funGetTransactionSourceReport(bool? pIsActive = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
