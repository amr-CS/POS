using appSERP.Models.RES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.RES.Abstract
{
    public interface IdbSupplierMenu
    {
        DataTable SupplierMenu(
      int? Id = null,
        int? SupplierId = null,
        string Name = null,
       int? QueryTypeId = null);

        object spSupplierMenuInsertBulk(ICollection<SupplierMenuModel> MenuItem, int? Id);
        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}