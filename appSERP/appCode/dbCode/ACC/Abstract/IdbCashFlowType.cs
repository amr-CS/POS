using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbCashFlowType
    {
        string funCashFlowTypeGET(
        int? pCashFlowTypeId = null,
        string pCashFlowTypeCode = null,
        string pCashFlowTypeNameL1 = null,
        string pCashFlowTypeNameL2 = null,
        int? pCompanyId = null,
        bool? pCashFlowTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        DataTable funGetCashFlowTypeReport(bool? pIsActive = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
