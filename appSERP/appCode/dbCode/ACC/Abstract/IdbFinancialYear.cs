using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbFinancialYear
    {
        string funFinancialYearGET(
        int? pFinancialYearId = null,
        string pFinancialYear = null,
        DateTime? pFinancialYearStart = null,
        DateTime? pFinancialYearEnd = null,
        int? pFinancialYearStatusId = null,
        DateTime? pDate = null,
        int? pBranchId = null,
        int? pCompanyId = null,
        bool? pFinancialYearIsActive = null,
        bool? pIsDeleted = false,
        int? pLanguageId = null,
        int? pQueryTypeId = null);

        DataTable funGetFinancialYearReport(bool? pIsActive = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
