using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.INV.Abstract
{
    public interface IdbSalesOrderType
    {
        string funSalesOrderTypeGET(

        int? pSalesOrderTypeId = null,
        string pSalesOrderTypeCode = null,
        string pSalesOrderTypeNameL1 = null,
        string pSalesOrderTypeNameL2 = null,
        string pAbbr = null,
        bool? pIsDefault = null,
        int? pBranchId = null,
        bool? pSalesOrderTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        DataTable funGetSalesOrderTypeReport(bool? pIsActive = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
