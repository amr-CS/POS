using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.SEC.Abstract
{
    public interface IdbSecurityRole
    {
        string funSecurityRoleGET(
        int? pSecurityRoleId = null,
        string pSecurityRoleNameL1 = null,
        string pSecurityRoleNameL2 = null,
        bool? pSecurityRoleIsActive = null,
        bool? pIsMaster = null,
        int? pCompanyId = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pSecurityRoleObjectId = null,
        int? pObjectId = null,
        int? pUserId = null,
        string pObjectAction = null,
        int? pQueryTypeId = null);


        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
        string vSecurityRoleId { get; set; }
    }
}
