using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbSellCostType
    {
        string funSellCostTypeGET(
         int? pSellCostTypeId = null,
       string pSellCostTypeCode = null,
         string pSellCostTypeNameL1 = null,
         string pSellCostTypeNameL2 = null,
         bool? pSellCostTypeIsActive = null,
         bool? pIsDeleted = null,
        int? pQueryTypeId = clsQueryType.qSelect);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
