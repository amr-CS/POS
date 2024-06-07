using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbAccountType
    {

        string funAccountTypeGET(

        int? pAccountTypeId = null,
        string pAccountTypeCode = null,
        string pAccountTypeNameL1 = null,
        string pAccountTypeNameL2 = null,
        int? pCompanyId = null,
        int? pBranchId = null,
        bool? pAccountTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        DataTable funGetAccountTypeReport(bool? pIsActive = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
