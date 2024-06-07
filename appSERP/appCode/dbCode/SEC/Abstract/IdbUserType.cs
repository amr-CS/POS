using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.SEC.Abstract
{
    public interface IdbUserType
    {

        string funUserTypeGET(
        int? pUserTypeId = null,
        string pUserTypeCode = null,
        string pUserTypeNameL1 = null,
        string pUserTypeNameL2 = null,
        string pUserTypeMaxDis = null,
        bool? pUserTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        DataTable funGetUserTypeReport(bool? pIsActive = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
