using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.INV.Abstract
{
    public interface IdbStoreType
    {
        string funStoreTypeGET(

        int? pStoreTypeId = null,
        string pStoreTypeCode = null,
        string pStoreTypeNameL1 = null,
        string pStoreTypeNameL2 = null,
        int? pStoreId = null,
        bool? pStoreTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
