using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.INV.Abstract
{
    public interface IdbPlate
    {
        string funPlateItemGET(
        int? pPlateItemId = null,
        int? pItemId = null,
        int? pPlateId = null,
        int? pPlateQty = null,
        bool? pIsDeleted = null,
        bool? pIsActive = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pLanguageId = null,
        int? pQueryTypeId = null);
    }
}
