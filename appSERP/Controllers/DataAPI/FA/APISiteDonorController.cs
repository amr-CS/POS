using appSERP.appCode.dbCode.FA;
using appSERP.appCode.dbCode.FA.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.FA
{
    public class APISiteDonorController : ApiController
    {
        private IdbSiteDonor _dbSiteDonor;
        public APISiteDonorController(IdbSiteDonor dbSiteDonor) {
            _dbSiteDonor = dbSiteDonor;
        }

        [HttpGet]
        public string SiteDonorGET(
      int? pSiteDonorId = null,
      string pSiteDonorNameL1 = null,
      string pSiteDonorNameL2 = null,
      bool? pSiteDonorIsActive = null,
      bool? pIsDeleted = false,
      int? pQueryTypeId = clsQueryType.qSelect)
        {
            // GET DATA 
            string vData = _dbSiteDonor.funSiteDonorGET(
            pSiteDonorId: pSiteDonorId,
            pSiteDonorNameL1: pSiteDonorNameL1,
            pSiteDonorNameL2: pSiteDonorNameL2,
            pSiteDonorIsActive: pSiteDonorIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId);

            // Return Result
            return vData;
        }
    }
}
