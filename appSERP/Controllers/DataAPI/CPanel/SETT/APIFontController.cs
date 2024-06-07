using appSERP.appCode.dbCode.SETT;
using appSERP.appCode.dbCode.SETT.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.SETT
{
    public class APIFontController : ApiController
    {
        private IdbFont _dbFont;
        public APIFontController(IdbFont dbFont) {
            _dbFont = dbFont;
        }
        [HttpGet]
        public string FontGET(
        int? pFontId = null,
        string pFontName = null,
        string pFontPath = null,
        bool? pFontIsActive = null,
        bool? pIsDeleted = null,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            //  Get Data 
            string vData = _dbFont.funFontGET(
            pFontId : pFontId,
            pFontName : pFontName,
            pFontPath : pFontPath,
            pFontIsActive : pFontIsActive,
            pIsDeleted : pIsDeleted,
            pQueryTypeId : pQueryTypeId);
            // Result
            return vData;
        }
    }
}
