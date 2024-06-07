using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbPaymentType
    {
        string funPaymentTypeGET(
        int? pPaymentTypeId = null,
        string pPaymentTypeCode = null,
        string pPaymentTypeNameL1 = null,
        string pPaymentTypeNameL2 = null,
        int? pCompanyId = null,
        bool? pPaymentTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        DataTable funGetPaymentTypeReport(bool? pIsActive = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
