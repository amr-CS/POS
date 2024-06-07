using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbCurrency
    {

        string funCurrencyGET(
        int? pCurrencyId = null,
        string pCurrencyCode = null,
        string pCurrencyNameL1 = null,
        string pCurrencyNameL2 = null,
        decimal? pCurrencyExchange = null,
        int? pCurrencyDecimal = null,
        int? pCurrencyFactorId = null,
        bool? pCurrencyIsDefault = null,
        int? pCurrencyGenderId = null,
        int? pBranchId = null,
        int? pCompanyId = null,
        bool? pCurrencyIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        DataTable funGetCurrencyReport(bool? pIsActive = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
