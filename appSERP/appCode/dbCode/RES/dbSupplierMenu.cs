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
    public class dbSupplierMenu: IdbSupplierMenu
    {

        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbSupplierMenu(clsADO clsADO)
        {
            _clsADO = clsADO;
        }

        public DataTable SupplierMenu(
        int? Id = null,
        int? SupplierId = null,
        string Name = null,
       int? QueryTypeId=null
      )
        {
                       // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("Id", Id));
            vlstParam.Add(new SqlParameter("SupplierId", SupplierId));
            vlstParam.Add(new SqlParameter("Name", Name));
                       vlstParam.Add(new SqlParameter("QueryTypeId", QueryTypeId));
            return _clsADO.funFillDataTable("RES.spSupplierMenuCRUD", vlstParam, "Data GET");
        }

        public object spSupplierMenuInsertBulk(ICollection<SupplierMenuModel> MenuItem, int? Id)
        {
            CustomXmlWriter xmlWriter = new CustomXmlWriter();
            string xml = xmlWriter.GetXml("SupplierMenu", MenuItem);
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("SupplierMenu", xml));
            vlstParam.Add(new SqlParameter("Id", Id));
            return _clsADO.funExecuteScalar("[RES].[spSupplierMenu_Bulk]", vlstParam, "Data GET");
        }

      
    }
}