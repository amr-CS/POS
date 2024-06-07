using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.SYSSETT.Abstract
{
    public interface IdbCountryType
    {
        string funCountryTypeGET(
        int? pCountryTypeId = null,
        string pCountryTypeCode = null,
        string pCountryTypeNameL1 = null,
        string pCountryTypeNameL2 = null,
        int? pCompanyId = null,
        bool? pCountryTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
