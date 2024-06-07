using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbTransactionType
    {
        string funTransactionTypeGET(
        int? pTransactionTypeId = null,
        string pTransactionTypeCode = null,
        string pTransactionTypeNameL1 = null,
        string pTransactionTypeNameL2 = null,
        int? pSystemId = null,
        int? pSystemTransactionTypeId = null,
        bool? pTransactionTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        DataTable funGetTransactionTypeReport(bool? pIsActive = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
