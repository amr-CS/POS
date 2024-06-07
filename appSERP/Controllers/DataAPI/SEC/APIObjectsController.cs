using appSERP.appCode.dbCode.SEC;
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
    public class APIObjectsController : ApiController
    {
        private IdbObjects _dbObjects;
        public APIObjectsController(IdbObjects dbObjects) {
            _dbObjects = dbObjects;
        }

        [HttpGet]
        public string ObjectsGET(
        int? pObjectId = null,
        int? pObjectSeq = null,
        string pObjectProName = null,
        string pObjectCode = null,
        string pObjectNameL1 = null,
        string pObjectNameL2 = null,
        string pObjectNameL3 = null,
        string pObjectNameL4 = null,
        string pObjectNameL5 = null,
        string pObjectNameL6 = null,
        string pObjectNameL7 = null,
        string pObjectNameL8 = null,
        string pObjectNameL9 = null,
        string pObjectNameL10 = null,
        string pObjectIconW = null,
        string pObjectIconB = null,
        string pObjectAction = null,
        string pObjectImage = null,
        string pObjectURL = null,
        bool? pObjectIsMainMenu = null,
        bool? pObjectIsActive = null,
        int? pObjectTypeId = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // GET DATA
         string vData = _dbObjects.funObjectsGET(
         pObjectId : pObjectId,
         pObjectSeq: pObjectSeq,
         pObjectProName : pObjectProName,
         pObjectCode : pObjectCode,
         pObjectNameL1 : pObjectNameL1,
         pObjectNameL2 : pObjectNameL2,
         pObjectNameL3 : pObjectNameL3,
         pObjectNameL4 : pObjectNameL4,
         pObjectNameL5 : pObjectNameL5,
         pObjectNameL6 : pObjectNameL6,
         pObjectNameL7 : pObjectNameL7,
         pObjectNameL8 : pObjectNameL8,
         pObjectNameL9 : pObjectNameL9,
         pObjectNameL10 : pObjectNameL10,
         pObjectIconW : pObjectIconW,
         pObjectIconB : pObjectIconB,
         pObjectAction : pObjectAction,
         pObjectImage : pObjectImage,
         pObjectURL : pObjectURL,
         pObjectIsMainMenu : pObjectIsMainMenu,
         pObjectIsActive : pObjectIsActive,
         pObjectTypeId : pObjectTypeId,
         pIsDeleted : pIsDeleted,
         pQueryTypeId : pQueryTypeId
                );
            // RESULT
            return vData;
        }
    }
}