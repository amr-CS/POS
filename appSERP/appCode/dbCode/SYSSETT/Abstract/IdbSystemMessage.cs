using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.SYSSETT.Abstract
{
    public interface IdbSystemMessage
    {
        string funSystemMessageGET(
        int? pSystemMessageId = null,
        int? pSystemMessageTypeId = null,
        string pSystemMessageText = null,
        string pSystemMessagePath = null,
        bool? pSystemMessageIsActive = null,
        bool? pIsDeleted = false,
        int? pLanguageId = null,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
