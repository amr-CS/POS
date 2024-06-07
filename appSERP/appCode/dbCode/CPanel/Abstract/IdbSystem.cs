using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.CPanel.Abstract
{
    public interface IdbSystem
    {
        string funSystemGET(
        int? pSystemId = null,
        string pSystemCode = null,
        string pSystemNameL1 = null,
        string pSystemNameL2 = null,
        string pSystemImageLogo = null,
        string pSystemVersion = null,
        DateTime? pSystemLastUpdated = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        DataTable funSystemDataGET();

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
