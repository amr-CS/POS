using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbCustomerCategory
    {

        string funCustomerCategoryGET(
         int? pCustomerCategoryId = null,
         string pCustomerCategoryCode = null,
         string pCustomerCategoryNameL1 = null,
         string pCustomerCategoryNameL2 = null,
         bool? pCustomerCategoryIsActive = null,
         bool? pIsDeleted = null,
        int? pQueryTypeId = clsQueryType.qSelect);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
