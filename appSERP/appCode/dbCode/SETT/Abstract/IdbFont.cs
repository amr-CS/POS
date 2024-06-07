using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.SETT.Abstract
{
    public interface IdbFont
    {
        string funFontGET(
        int? pFontId = null,
        string pFontName = null,
        string pFontPath = null,
        bool? pFontIsActive = null,
        bool? pIsDeleted = false,
        int? pLanguageId = null,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
