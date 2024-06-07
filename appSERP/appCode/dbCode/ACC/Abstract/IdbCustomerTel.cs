using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbCustomerTel
    {

        string funCustomerTelGET(
        int? pCustomerTelId = null,
        string pCustomerTelCode = null,
        string pCustomerTelNo = null,
        int? pCustomerId = null,
        bool? pCustomerTelIsActive = null,
         bool? pIsDeleted = null,
        int? pQueryTypeId = clsQueryType.qSelect);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
