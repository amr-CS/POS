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
    public class APIInvEquipmentController : ApiController
    {
        private IdbInvEquipment _dbInvEquipment;
        public APIInvEquipmentController(IdbInvEquipment dbInvEquipment) {
            _dbInvEquipment = dbInvEquipment;
        }

        [HttpGet]
        public string InvItemEquipmentGET(
   
            int? pEquipmentId = null,
           string pEquipmentCode = null,
          string pEquipmentNameL1 = null,
         string pEquipmentNameL2 = null,
          string pNotes = null,
          bool? pEquipmentIsActive = null,
          bool? pIsDeleted = false,
          int? pQueryTypeId = clsQueryType.qSelect
    )
        {
            // Get Data 
            string vData = _dbInvEquipment.funInvEquipmentGET(
            pEquipmentId: pEquipmentId,
            pEquipmentCode: pEquipmentCode,
            pEquipmentNameL1: pEquipmentNameL1,
            pEquipmentNameL2: pEquipmentNameL2,
            pNotes: pNotes,
            pEquipmentIsActive: pEquipmentIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
            );
            // Result
            return vData;
        }
    }
}
