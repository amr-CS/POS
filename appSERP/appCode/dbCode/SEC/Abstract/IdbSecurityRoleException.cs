using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.SEC.Abstract
{
    public interface IdbSecurityRoleException
    {
        string funSecurityRoleExceptionGET(
        int? pSecurityRoleExceptionId = null,
        string pSecurityRoleExceptionCode = null,
        string pSecurityRoleExceptionNameL1 = null,
        string pSecurityRoleExceptionNameL2 = null,
        bool? pSecurityRoleExceptionIsActive = null,
        bool? pIsDeleted = null,
        int? pCompanyId = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pLanguageId = null,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
