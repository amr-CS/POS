using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbFinancialYearStatus
    {

        string funFinancialYearStatusGET(
        int? pFinancialYearStatusId = null,
        string pFinancialYearStatusNameL1 = null,
        string pFinancialYearStatusNameL2 = null,
        bool? pFinancialYearStatusIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        DataTable funGetFinancialYearStatusReport(bool? pIsActive = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
