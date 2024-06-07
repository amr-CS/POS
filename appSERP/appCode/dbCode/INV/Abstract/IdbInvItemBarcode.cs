using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.INV.Abstract
{
    public interface IdbInvItemBarcode
    {

        string funInvItemBarcodeGET(
        int? pInvItemBarcodeId = null,
        string pInvItemBarcodeCode = null,
        int? pItemId = null,
         int? pUnitId = null,
        string pItemBarCode = null,
        bool? pInvItemBarcodeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
