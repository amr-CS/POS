using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.SETT.Abstract
{
    public interface IdbDocStatus
    {
        string funDocStatusGET(
        int? pDocStatusId = null,
        string pDocStatusCode = null,
        string pDocStatusNameL1 = null,
        string pDocStatusNameL2 = null,
        bool? pDocStatusIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
