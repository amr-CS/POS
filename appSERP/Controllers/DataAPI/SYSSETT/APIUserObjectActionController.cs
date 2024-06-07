using appSERP.appCode.dbCode.SYSSETT;
using appSERP.appCode.dbCode.SYSSETT.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.SYSSETT
{
    public class APIUserObjectActionController : ApiController
    {
        private IdbUserObjectAction _dbUserObjectAction;
        public APIUserObjectActionController(IdbUserObjectAction dbUserObjectAction)
        {
            _dbUserObjectAction = dbUserObjectAction;
        }


        // UserObjectAction Load
        [HttpGet]
        public string UserObjectActionGET(
            int? pUserObjectActionId = null,
             int? pUserObjectActionSeq = null,
            int? pUserId = null,
            int? pObjectId = null,
            string pObjectProName = null,
            int? pObjectAction = null,
            int? pObjectActionId = null,
            bool? pObjectIsAdmin = null,
            bool? pIsDeleted = false,
            int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Declaration
            string vData = _dbUserObjectAction.funUserObjectActionGET(
             pUserObjectActionId: pUserObjectActionId,
             pUserObjectActionSeq: pUserObjectActionSeq,
             pUserId: pUserId,
             pObjectId: pObjectId,
             pObjectProName: pObjectProName,
             pObjectAction: pObjectAction,
             pObjectActionId: pObjectActionId,
             pObjectIsAdmin: pObjectIsAdmin,
             pIsDeleted: pIsDeleted,
             pQueryTypeId: pQueryTypeId
                );

            // Return Result
            return vData;
        }
    }
}
