using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.SYSSETT.Abstract
{
    public interface IdbObjects
    {
        string funObjectsGET(
        int? pObjectId = null,
         int? pObjectSeq = null,
        string pObjectProName = null,
        string pObjectCode = null,
        string pObjectNameL1 = null,
        string pObjectNameL2 = null,
        string pObjectNameL3 = null,
        string pObjectNameL4 = null,
        string pObjectNameL5 = null,
        string pObjectNameL6 = null,
        string pObjectNameL7 = null,
        string pObjectNameL8 = null,
        string pObjectNameL9 = null,
        string pObjectNameL10 = null,
        string pObjectIconW = null,
        string pObjectIconB = null,
        string pObjectAction = null,
        string pObjectImage = null,
        string pObjectURL = null,
        bool? pObjectIsMainMenu = null,
        bool? pObjectIsActive = null,
        int? pObjectTypeId = null,
        int? pCompanyId = null,
        int? pLanguageId = null,
        bool? pIsDeleted = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pQueryTypeId = null);


        string vSQLResult { get; set; }
        string vSQLResultTypeId { get; set; }
        string vObjectName { get; set; }
    }
}
