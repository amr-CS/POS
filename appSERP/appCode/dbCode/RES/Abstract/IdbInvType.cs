using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.RES.Abstract
{
    public interface IdbInvType
    {

        string funInvTypeGET(
        int? pInvTypeId = null,
        string pInvTypeCode = null,
        string pInvTypeNameL1 = null,
        string pInvTypeNameL2 = null,
        bool? pInvTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
