using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.FA.Abstract
{
    public interface IdbSite
    {
        string funSiteGET(
        int? pSiteId = null,
        string pSiteCode = null,
        string pSiteNameL1 = null,
        string pSiteNameL2 = null,
        string pSiteLat = null,
        string pSiteLng = null,
        int? pCustomerId = null,
        bool? pSiteIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        DataTable funGetSiteReport(bool? pIsActive = null);


        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }

    }
}
