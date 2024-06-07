using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbEPaymentType
    {

        string funEPaymentTypeGET(
        int? pEPaymentTypeId = null,
        int? pPaymentTypeId = null,
        string pEPaymentTypeCode = null,
        string pEPaymentTypeNameL1 = null,
        string pEPaymentTypeNameL2 = null,
        int? pBranchId = null,
        bool? pEPaymentTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
