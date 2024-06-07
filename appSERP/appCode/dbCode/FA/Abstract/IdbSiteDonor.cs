using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.FA.Abstract
{
    public interface IdbSiteDonor
    {
        string funSiteDonorGET(
        int? pSiteDonorId = null,
        string pSiteDonorCode = null,
        string pSiteDonorNameL1 = null,
        string pSiteDonorNameL2 = null,
        bool? pSiteDonorIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        DataTable funGetSiteDonorReport(bool? pIsActive = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
