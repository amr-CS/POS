using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbCurrencyFactor
    {
        string funCurrencyFactorGET(
        int? pCurrencyFactorId = null,
        string pCurrencyFactorCode = null,
        string pCurrencyFactorNameL1 = null,
        string pCurrencyFactorNameL2 = null,
        decimal? pCurrencyFactorValue = null,
        bool? pCurrencyFactorIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        DataTable funGetCurrencyFactorReport(bool? pIsActive = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
