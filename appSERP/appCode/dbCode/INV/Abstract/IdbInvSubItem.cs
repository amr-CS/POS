using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.INV.Abstract
{
    public interface IdbInvSubItem
    {
        string funInvSubItemGET(
         int? pSubItemId = null,
        string pSubItemCode = null,
       string pSubItemNameL1 = null,
      string pSubItemNameL2 = null,
      int? pPiecesCount = null,
       int? pItemId = null,
         string pNotes = null,
        bool? pSubItemIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
