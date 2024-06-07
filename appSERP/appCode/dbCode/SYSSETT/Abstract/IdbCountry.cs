using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.SYSSETT.Abstract
{
    public interface IdbCountry
    {
        string funCountryGET(
        int? pCountryId = null,
        string pCountryCode = null,
        string pCountryNameL1 = null,
        string pCountryNameL2 = null,
        string pCountryPhoneCode = null,
        string pCountryNationalityNameL1 = null,
        string pCountryNationalityNameL2 = null,
        string pCountryImage = null,
        int? pCountryTypeId = null,
        int? pCompanyId = null,
        bool? pCountryIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);
        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
