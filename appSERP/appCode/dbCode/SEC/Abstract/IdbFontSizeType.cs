using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.SEC.Abstract
{
    public interface IdbFontSizeType
    {

        string funFontSizeTypeGET(
        int? pFontSizeTypeId = null,
        string pFontSizeTypeNameL1 = null,
        string pFontSizeTypeNameL2 = null,
        int? pFontSizeTypeValue = null,
        bool? pFontSizeTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
