using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbCostCenter
    {
        string funCostCenterGET(
        int? pCostCenterId = null,
        string pCostCenterCode = null,
        string pCostCenterNameL1 = null,
        string pCostCenterNameL2 = null,
        int? pCostCenterParentId = null,
        int? pCostCenterLevel = null,
        bool? pCostCenterIsAccumulative = null,
        int? pBranchId = null,
        int? pCompanyId = null,
        bool? pCostCenterIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        DataTable funCostCenterReportGET(bool? pIsActive = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
        string vParentId { get; set; }
        int? vLevel { get; set; }
        string vCostCenterCode { get; set; }
        string vCostCenterName { get; set; }
        string vBranchId { get; set; }
        string vBranchName { get; set; }
        int vCostCenterLevel { get; set; }
    }
}
