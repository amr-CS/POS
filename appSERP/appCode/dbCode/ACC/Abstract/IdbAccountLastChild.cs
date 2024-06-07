using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbAccountLastChild
    {
        string funAccountLastChildGET(
            int? pParentId = null,
            int? pAccountId = null,
            string pAccountNo = null,
            bool? AccountIsActive = null,
            int? pQueryTypeId = clsQueryType.qSelect);
    }
}
