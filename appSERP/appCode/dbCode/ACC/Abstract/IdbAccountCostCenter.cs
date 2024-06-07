using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbAccountCostCenter
    {

        string funAccountCostCenterGET(
        int? pAccountCostCenterId = null,
        int? pAccountId = null,
        int? pCostCenterId = null,
        string pCostCenterCode = null,
        bool? pIsDeleted = false,
        int? pLanguageId = null,
        int? pQueryTypeId = clsQueryType.qSelect);

        DataTable funGetAccountCostCenterReport(bool? pIsActive = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
