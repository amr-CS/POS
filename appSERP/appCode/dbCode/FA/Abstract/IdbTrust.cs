using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.FA.Abstract
{
    public interface IdbTrust
    {
        string funTrustGET(
        int? pTrustId = null,
        string pTrustNameL1 = null,
        string pTrustNameL2 = null,
        int? pTrustEmployeeId = null,
        string pTrustPhone1 = null,
        string pTrustPhone2 = null,
        string pTrustEmail = null,
        bool? pTrustIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
