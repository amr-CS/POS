using appSERP.appCode.dbCode.FA;
using appSERP.appCode.dbCode.FA.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.FA
{
    public class APISystemSTATController : ApiController
    {
        private IdbSystemSTAT _dbSystemSTAT;
        public APISystemSTATController(IdbSystemSTAT dbSystemSTAT) {
            _dbSystemSTAT = dbSystemSTAT;
        }

        [HttpGet]
        public  string SystemSTATGET()
        {
            // Set Data
            string vData = _dbSystemSTAT.funSystemSTATGET();
            // Get Data
            return vData;
        }
    }
}
