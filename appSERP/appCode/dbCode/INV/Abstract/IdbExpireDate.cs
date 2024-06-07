using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.INV.Abstract
{
    public interface IdbExpireDate
    {
        string funExpireDateGET(
        int? pExpireDateId = null,
        string pExpireDateCode = null,
        DateTime? pExpireDate = null,
        int? pItemId = null,
       bool? pExpireDateIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
