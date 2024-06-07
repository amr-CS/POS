using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.INV.Abstract
{
    public interface IdbStoreSetting
    {
        string funStoreSettingGET(

        int? pStoreSettingId = null,
        string pStoreSettingCode = null,
        string pStoreSettingNameL1 = null,
        string pStoreSettingNameL2 = null,
        string pStoreSettingNotes = null,
        int? pStoreId = null,
        bool? pStoreSettingIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
