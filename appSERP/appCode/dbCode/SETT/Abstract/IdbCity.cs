using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.SETT.Abstract
{
    public interface IdbCity
    {
        string funCityGET(
        int? pCityId = null,
        string pCityCode = null,
        string pCityNameL1 = null,
        string pCityNameL2 = null,
        int? pCountryId = null,
        string pCityCenterLat = null,
        string pCityCenterLng = null,
        bool? pCityIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
