using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.INV.Abstract
{
    public interface IdbSizeType
    {
        string funSizeTypeGET(

        int? pSizeTypeId = null,
        string pSizeTypeCode = null,
        string pSizeTypeNameL1 = null,
        string pSizeTypeNameL2 = null,
        string pNotes = null,
        int? pBranchId = null,
        bool? pSizeTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        DataTable funGetSizeTypeReport(bool? pIsActive = null);
    }
}
