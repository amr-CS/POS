using appSERP.appCode.dbCode.RES;
using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.RES
{
    public class APIVAccountCategoryController : ApiController
    {
        private IdbVAccountCategory _dbVAccountCategory;
        public APIVAccountCategoryController(IdbVAccountCategory dbVAccountCategory)
        {
            _dbVAccountCategory = dbVAccountCategory;
        }

        [HttpGet]
        public string VAccountCategoryGET(
int? pCodeId = null,
int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbVAccountCategory.funVAccountCategoryGET(
           pCodeId: pCodeId,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
