using appSERP.appCode.dbCode.RES;
using appSERP.appCode.dbCode.RES.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.RES
{
    public class APIDashBoardController : ApiController
    {

        private IdbDashBoard _dbDashBoard;
        public APIDashBoardController(IdbDashBoard dbDashBoard) {
            _dbDashBoard = dbDashBoard;
        }
        [HttpGet]
        public  object DashBoardGET()
        {
            object data = _dbDashBoard.funDashBoardGET();
            return data;
        }
    }
}
