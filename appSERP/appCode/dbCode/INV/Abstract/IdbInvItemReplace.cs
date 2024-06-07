using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.INV.Abstract
{
    public interface IdbInvItemReplace
    {
        string funInvItemReplaceGET(
        int? pInvItemReplaceId = null,
        string pInvItemReplaceCode = null,
        int? pItemId = null,
        int? pReplaceItemId = null,
        string pNotes = null,
        bool? pInvItemReplaceIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
