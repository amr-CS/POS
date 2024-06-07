using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using appSERP.appCode.Utils;
using appSERP.Models.RES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.RES
{
    public class dbMenuItem:IdbMenuItem
    {
        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbMenuItem(clsADO clsADO)
        {
            _clsADO = clsADO;
        }


        public DataTable funMenuItemGET(int? Id = null, int? SupplierId = null, int? MenuId = null, int? ItemId = null, float? Price = null, int? QueryTypeId = null)
        {
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("Id", Id));
            vlstParam.Add(new SqlParameter("SupplierId", SupplierId));
            vlstParam.Add(new SqlParameter("MenuId", MenuId));
            vlstParam.Add(new SqlParameter("ItemId", ItemId));
            vlstParam.Add(new SqlParameter("Price", Price));
            vlstParam.Add(new SqlParameter("QueryTypeId", QueryTypeId));
            return _clsADO.funFillDataTable("RES.spMenuItemCRUD", vlstParam, "Data GET");

        }
        public object spMenuItemInsertBulk(ICollection<MenuItemModel> MenuItem, int? Id)
        {
            CustomXmlWriter xmlWriter = new CustomXmlWriter();
            string xml = xmlWriter.GetXml("MenuItem", MenuItem);
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("MenuItem", xml));
            vlstParam.Add(new SqlParameter("Id", Id));
            return _clsADO.funExecuteScalar("[RES].[spMenuItem_Bulk]", vlstParam, "Data GET");
        }
    }
}