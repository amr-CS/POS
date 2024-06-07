using appSERP.appCode.dbCode.SEC;
using appSERP.appCode.dbCode.SEC.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.SEC
{
    public class APIFontSizeTypeController : ApiController
    {
        private IdbFontSizeType _dbFontSizeType;
        public APIFontSizeTypeController(IdbFontSizeType dbFontSizeType)
        {
            _dbFontSizeType = dbFontSizeType;
        }

        [HttpGet]
        public string FontSizeTypeGET(
        int? pFontSizeTypeId = null,
        string pFontSizeTypeNameL1 = null,
        string pFontSizeTypeNameL2 = null,
        int? pFontSizeTypeValue = null,
        bool? pFontSizeTypeIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // GET DATA 
            string vData = _dbFontSizeType.funFontSizeTypeGET(
            pFontSizeTypeId : pFontSizeTypeId,
            pFontSizeTypeNameL1 : pFontSizeTypeNameL1,
            pFontSizeTypeNameL2 : pFontSizeTypeNameL2,
            pFontSizeTypeValue : pFontSizeTypeValue,
            pFontSizeTypeIsActive : pFontSizeTypeIsActive,
            pIsDeleted : pIsDeleted,
            pQueryTypeId : pQueryTypeId);
            // RESULT
            return vData;
        }
    }
}
