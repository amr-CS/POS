using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.INV.Abstract
{
    public interface IdbStoreDepartment
    {

        string funStoreDepartmentGET(

        int? pStoreDepartmentId = null,
        string pStoreDepartmentCode = null,
        string pStoreDepartmentNameL1 = null,
        string pStoreDepartmentNameL2 = null,
        int? pBranchId = null,
        bool? pStoreDepartmentIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        DataTable funGetStoreDepartmentReport(bool? pIsActive = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
