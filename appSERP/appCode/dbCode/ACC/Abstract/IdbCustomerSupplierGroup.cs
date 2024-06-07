using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbCustomerSupplierGroup
    {
        string funCustomerSupplierGroupGET(
        int? pCSGroupId = null,
        string pCSGroupNameL1 = null,
        string pCSGroupNameL2 = null,
        decimal? pCSGroupCreditLimit = null,
        int? pCSGroupGracePeriodDays = null,
        bool? pCSGroupIsCustomerGroup = null,
        bool? pCSGroupIsDefault = null,
        int? pCompanyId = null,
        int? pBranchId = null,
        bool? pCSGroupIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
