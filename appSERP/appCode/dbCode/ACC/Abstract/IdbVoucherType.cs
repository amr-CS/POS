using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbVoucherType
    {

        string funVoucherTypeGET(
        int? pVoucherTypeId = null,
        string pVoucherTypeCode = null,
        string pVoucherTypeNameL1 = null,
        string pVoucherTypeNameL2 = null,
        bool? pVoucherTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
