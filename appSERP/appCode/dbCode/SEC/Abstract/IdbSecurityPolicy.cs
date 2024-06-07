using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.SEC.Abstract
{
    public interface IdbSecurityPolicy
    {
        string funSecurityPolicyGET(
        int? pSecurityPolicyId = null,
        int? pSecurityPolicySeq = null,
        string pSecurityPolicyNameL1 = null,
        string pSecurityPolicyNameL2 = null,
        bool? pSecurityPolicyIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
