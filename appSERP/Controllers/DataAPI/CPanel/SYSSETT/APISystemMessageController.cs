using appSERP.appCode.dbCode.SYSSETT;
using appSERP.appCode.dbCode.SYSSETT.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.SYSSETT
{
    public class APISystemMessageController : ApiController
    {
        private IdbSystemMessage _dbSystemMessage;
        public APISystemMessageController(IdbSystemMessage dbSystemMessage) {
            _dbSystemMessage = dbSystemMessage;
        }

        [HttpGet]
        public  string SystemMessageGET(
        int? pSystemMessageId = null,
        int? pSystemMessageTypeId = null,
        string pSystemMessageText = null,
        string pSystemMessagePath = null,
        bool? pSystemMessageIsActive = null,
        int? pLanguageId = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
                 //Get Data
                string vData = _dbSystemMessage.funSystemMessageGET(
                pSystemMessageId : pSystemMessageId,
                pSystemMessageTypeId : pSystemMessageTypeId,
                pSystemMessageText : pSystemMessageText,
                pSystemMessagePath : pSystemMessagePath,
                pSystemMessageIsActive : pSystemMessageIsActive,
                pLanguageId: pLanguageId,
                pIsDeleted : pIsDeleted,
                pQueryTypeId : pQueryTypeId
                );
            return vData;

        }
    }
}
