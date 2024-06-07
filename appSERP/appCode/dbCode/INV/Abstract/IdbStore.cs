using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.INV.Abstract
{
    public interface IdbStore
    {

        string funStoreGET(

        int? pStoreId = null,
        string pStoreCode = null,
        string pStoreNameL1 = null,
        string pStoreNameL2 = null,
        string pStoreShortName = null,
        int? pStoreTypeId = null,
        int? pCountryId = null,
        int? pCityId = null,
        string pStoreNotes = null,
        string pStorePhone = null,
        string pStoreAddress = null,
        bool? pStoreIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
