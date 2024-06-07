using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.INV.Abstract
{
    public interface IdbStoreKeeper
    {
        string funStoreKeeperGET(

        int? pStoreKeeperId = null,
        string pStoreKeeperCode = null,
        string pStoreKeeperNameL1 = null,
        string pStoreKeeperNameL2 = null,
        int? pStoreId = null,
        bool? pStoreKeeperIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
