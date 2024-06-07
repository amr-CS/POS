using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.SYSSETT.Abstract
{
    public interface IdbDocStatus
    {
        string funDocStatusGET(
        string pDocStatusId = null,
        string pDocStatusNameL1 = null,
        string pDocStatusNameL2 = null,
        string pDocStatusNameL3 = null,
        string pDocStatusNameL4 = null,
        string pDocStatusNameL5 = null,
        string pDocStatusNameL6 = null,
        string pDocStatusNameL7 = null,
        string pDocStatusNameL8 = null,
        string pDocStatusNameL9 = null,
        string pDocStatusNameL10 = null,
        string pDocStatusNext = null,
        string pDocStatusProName = null,
        bool? pDocStatusIsActive = null,
        bool? pIsDeleted = false,
        int? pLanguageId = null,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
