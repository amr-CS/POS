using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.SETT.Abstract
{
    public interface IdbArea
    {
        string funAreaGET(
        int? pAreaId = null,
           string pAreaCode = null,
        string pAreaNameL1 = null,
        string pAreaNameL2 = null,
        int? pCityId = null,
        bool? pAreaIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
