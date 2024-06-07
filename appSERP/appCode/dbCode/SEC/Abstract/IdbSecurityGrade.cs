using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.SEC.Abstract
{
    public interface IdbSecurityGrade
    {
        string funSecurityGradeGET(
        int? pSecurityGradeId = null,
        string pSecurityGradeCode = null,
        string pSecurityGradeNameL1 = null,
        string pSecurityGradeNameL2 = null,
        bool? pCompanyId = null,
        bool? pSecurityGradeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
