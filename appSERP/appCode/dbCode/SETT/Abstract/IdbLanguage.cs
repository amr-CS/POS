using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.SETT.Abstract
{
    public interface IdbLanguage
    {
        string funLanguageGET(
            int? pLanguageId = null,
            string pLanguageCode = null,
            string pLanguageNameL1 = null,
            string pLanguageNameL2 = null,
            string pCultureName = null,
            string pLanguageImage = null,
            int? pDefaultFontId = null,
            bool? pLanguageIsActive = null,
            bool? pIsDeleted = false,
            int? pQueryTypeId = clsQueryType.qSelect);

        DataTable funUserLanguageGET();

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
