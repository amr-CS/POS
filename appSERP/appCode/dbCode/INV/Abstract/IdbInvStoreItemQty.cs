using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.INV.Abstract
{
    public interface IdbInvStoreItemQty
    {
        DataTable funInvStoreItemQtyGET(

        int? pInvStoreItemQtyId = null,
        int? pStoreId = null,
       int? pItemId = null,
        DateTime? pExpireDate = null,
        float? pItemOpenQty = null,
        float? pItemQty = null,
        int? IsZero = null,
        int? ReportTypeId = null,
        float? pItemReservedQty = null,
        string pNotes = null,
       string pUSERNAME = null,
       float? pItemOpenCost = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null,
        int? pUnitId = null,
        int? pItemType = null);

        DataTable funGetProductionQtyReport(int? pStoreId = null, int? pItemId = null, int? pItemType = null, int? pUnitId = null, string pType = null,
                int? IsZero = null,
        int? ReportTypeId = null,int?BranchId=null
            );

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
