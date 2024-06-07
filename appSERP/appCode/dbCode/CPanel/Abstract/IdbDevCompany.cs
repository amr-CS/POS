using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.CPanel.Abstract
{
    public interface IdbDevCompany
    {
        string funDevCompanyGET(
        int? pDevCompanyId = null,
        string pDevCompanyNameL1 = null,
        string pDevCompanyNameL2 = null,
        string pDevCompanyPhone = null,
        string pDevCompanyPhone2 = null,
        string pDevCompanyEmail = null,
        string pDevCompanyWebsite = null,
        string pDevCompanyAddress = null,
        object pDevCompanyImage = null,
        object pDevCompanyImageFull = null,
         string pDevAppNameL1 = null,
        string pDevAppNameL2 = null,
         object pDevAppImage = null,
        bool? pDevCompanyIsActive = null,
        bool? pIsDeleted = false,
        int? pLanguageId = null,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
