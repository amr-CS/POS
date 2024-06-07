using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.INV.Abstract
{
    public interface IdbProductType
    {

        string funProductTypeGET(

        int? pProductTypeId = null,
        string pProductTypeCode = null,
        string pProductTypeNameL1 = null,
        string pProductTypeNameL2 = null,
         string pShortName = null,
        string pProductTypeLevel = null,
        int? pProductTypeParentId = null,
        bool? pProductTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
