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
    public class APIInvItemEquipmentController : ApiController
    {
        private IdbInvItemEquipment _dbInvItemEquipment;
        public APIInvItemEquipmentController(IdbInvItemEquipment dbInvItemEquipment) {
            _dbInvItemEquipment = dbInvItemEquipment;
        }
        [HttpGet]
        public string InvItemEquipmentGET(
              int? pInvItemEquipmentId = null,
        string pInvItemEquipmentCode = null,
        int? pItemId = null,
        int? pEquipmentId = null,
        int? pNotes = null,
        bool? pInvItemEquipmentIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect
      )
        {
            // Get Data 
            string vData = _dbInvItemEquipment.funInvItemEquipmentGET(
            pInvItemEquipmentId: pInvItemEquipmentId,
            pInvItemEquipmentCode: pInvItemEquipmentCode,
            pItemId: pItemId,
             pEquipmentId: pEquipmentId,
             pNotes: pNotes,
             pInvItemEquipmentIsActive: pInvItemEquipmentIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
