using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbEstimatedBudgetAccount
    {

        string funEstimatedBudgetAccountGET(
       int? pEstimatedBudgetAccountId = null,
       int? pAccountId = null,
       int? pMonthId = null,
       int? pYearId = null,
       string pDateFrom = null,
       string pDateTo = null,
       decimal? pEstimatedBudgetAccountValue = null,
       int? pCompanyId = null,
       int? pBranchId = null,
       bool? pIsDeleted = false,
       int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
