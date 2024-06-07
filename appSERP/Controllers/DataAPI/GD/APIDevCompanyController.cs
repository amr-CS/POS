using appSERP.appCode.dbCode.CPanel.Abstract;
using appSERP.appCode.dbCode.GD;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.GD
{
    public class APIDevCompanyController : ApiController
    {
        private IdbDevCompany _dbDevCompany;
        public APIDevCompanyController(IdbDevCompany dbDevCompany) {
            _dbDevCompany = dbDevCompany;
        }
        [HttpGet]
        public string DevCompanyGET(
      int? pDevCompanyId = null,
      string pDevCompanyNameL1 = null,
      string pDevCompanyNameL2 = null,
      string pDevCompanyPhone = null, 
      string pDevCompanyPhone2 = null, 
      string pDevCompanyEmail = null, 
      string pDevCompanyWebsite = null, 
      string pDevCompanyAddress = null,
      string pDevCompanyImage = null,
      string pDevCompanyImageFull = null,
      string pDevAppNameL1 = null,
      string pDevAppNameL2 = null,
      string pDevAppImage = null,
      bool? pDevCompanyIsActive = null,
      bool? pIsDeleted = false,
      int? pQueryTypeId = clsQueryType.qSelect)
        {
            // GET DATA 
            string vData = _dbDevCompany.funDevCompanyGET
                (
            pDevCompanyId: pDevCompanyId,
            pDevCompanyNameL1 : pDevCompanyNameL1,
            pDevCompanyNameL2: pDevCompanyNameL2,
            pDevCompanyPhone: pDevCompanyPhone,
            pDevCompanyPhone2: pDevCompanyPhone2,
            pDevCompanyEmail: pDevCompanyEmail,
            pDevCompanyWebsite: pDevCompanyWebsite,
            pDevCompanyAddress: pDevCompanyAddress,
            pDevCompanyImage: pDevCompanyImage,
            pDevAppNameL1: pDevAppNameL1,
            pDevAppNameL2: pDevAppNameL2,
            pDevAppImage: pDevAppImage,
            pDevCompanyIsActive: pDevCompanyIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
                );

            // RESULT 
            return vData;
        }
    }
}
