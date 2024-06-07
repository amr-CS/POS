using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbCurrencyGender
    {
        string funCurrencyGenderGET(
        int? pCurrencyGenderId = null,
        string pCurrencyGenderCode = null,
        string pCurrencyGenderNameL1 = null,
        string pCurrencyGenderNameL2 = null,
        bool? pCurrencyGenderIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        DataTable funGetCurrencyGenderReport(bool? pIsActive = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
