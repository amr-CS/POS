using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbCustomerSite
    {

        string funCustomerSiteGET(
        int? pCustomerSiteId = null,
        string pCustomerSiteCode = null,
        string pCustomerSiteNameL1 = null,
        string pCustomerSiteNameL2 = null,
        int? pCustomerId = null,
        int? pSiteId = null,
        bool? pCustomerSiteIsActive = null,
         bool? pIsDeleted = null,
        int? pQueryTypeId = clsQueryType.qSelect);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
