using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.FA.Abstract
{
    public interface IdbSiteDetail
    {
        string funSiteDetailGET(
        int? pSiteDetailId = null,
        string pSiteDetailNameL1 = null,
        string pSiteDetailNameL2 = null,
         int? pSiteDetailLat = null,
        int? pCompanyId = null,
        int? pSiteDetailLng = null,
        int? pSiteId = null,
        bool? pSiteDetailIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        DataTable funGetSiteDetailReport(bool? pIsActive = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
