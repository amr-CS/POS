using appSERP.appCode.dbCode.INV;
using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.INV
{
    public class APIInvItemsEquipController : ApiController
    {
        private IdbInvItemsEquip _dbInvItemsEquip;
        public APIInvItemsEquipController(IdbInvItemsEquip dbInvItemsEquip) {
            _dbInvItemsEquip = dbInvItemsEquip;
        }

        [HttpGet]
        public string InvItemsEquipGET(
       int? pEquipId = null,
        string pEquipCode = null,
        string pEquipName = null,
         int? pItemId = null,
        string pNotes = null,
        bool? pEquipIsActive = true,
     bool? pIsDeleted = false,
     int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data 
            string vData = _dbInvItemsEquip.funInvItemsEquipGET(
                pEquipId : pEquipId,
         pEquipCode : pEquipCode,
        pEquipName : pEquipName,
         pItemId : pItemId,
       pNotes : pNotes,
        pEquipIsActive: pEquipIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
