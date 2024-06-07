using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.RES.Abstract
{
    public interface IdbPortType
    {
        string funPortTypeGET(
        int? pPortTypeId = null,
        string pPortTypeCode = null,
        string pPortTypeNameL1 = null,
        string pPortTypeNameL2 = null,
        bool? pPortTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
