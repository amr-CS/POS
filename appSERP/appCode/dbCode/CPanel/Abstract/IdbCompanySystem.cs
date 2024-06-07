using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.CPanel.Abstract
{
    public interface IdbCompanySystem
    {

        string funCompanySystemGET(
        int? pCompanySystemId = null,
        string pCompanySystemCode = null,
        int? pAccountId = null,
        int? pBranchId = null,
        int? pCompanyId = null,
        bool? pCompanySystemIsActive = null,
        int? pSystemId = null,
        bool? pIsDeleted = false,
        int? pLanguageId = null,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
