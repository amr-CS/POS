using appSERP.Models.RES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.RES.Abstract
{
    public interface IdbMenuItem
    {
        DataTable funMenuItemGET(
      int? Id = null,
        int? SupplierId = null,
        int? MenuId = null,
        int? ItemId = null,
        float? Price = null,
       int? QueryTypeId = null);

        object spMenuItemInsertBulk(ICollection<MenuItemModel> MenuItem, int? Id);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}