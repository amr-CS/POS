
using appSERP.appCode.dbCode.ACC;
using appSERP.appCode.dbCode.RES;
using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI
{
    public class BoardController : ApiController
    {
        private IdbDashBoard _dbDashBoard;
        public BoardController(IdbDashBoard dbDashBoard) {
            _dbDashBoard = dbDashBoard;
        }


        [HttpGet]
        public string DashBoardGET()
        {
            string vData = _dbDashBoard.funDashBoardGET();
            return vData;

        }
    }
}
