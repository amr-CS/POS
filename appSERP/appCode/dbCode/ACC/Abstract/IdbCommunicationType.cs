using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbCommunicationType
    {
        string funCommunicationTypeGET(
        int? pTypeId = null,
        string pTypeCode = null,
        string pTypeNameL1 = null,
        string pTypeNameL2 = null,
        bool? pTypeIsActive = null,
         bool? pIsDeleted = null,
        int? pQueryTypeId = clsQueryType.qSelect);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
