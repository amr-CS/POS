using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.FA.Abstract
{
    public interface IdbAssetTransactionType
    {

        string funTransactionTypeGET(
        int? pTransactionTypeId = null,
        string pTransactionTypeCode = null,
        string pTransactionTypeNameL1 = null,
        string pTransactionTypeNameL2 = null,
        bool? pTransactionTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
