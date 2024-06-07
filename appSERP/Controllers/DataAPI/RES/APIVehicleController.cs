using appSERP.appCode.dbCode.RES;
using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.RES
{
    public class APIVehicleController : ApiController
    {
        private IdbVehicle _dbVehicle;
        public APIVehicleController(IdbVehicle dbVehicle) {
            _dbVehicle = dbVehicle;
        }

        [HttpGet]
        public string VehicleGET(
   int? pVehicleId = null,
         string pVehicleCode = null,
   string pVecDescL1 = null,
   string pVecDescL2 = null,
    DateTime? pInitialDate = null,
  string pPanelNumber = null,
 int? pVecModelId = null,
    string pVecVINNO = null,
int? pVecTypeId = null,
int? pBrandId = null,
int? pVecColorId = null,
 string pComments = null,
   int? pVecStatus = null,
 string pVehicleImage = null,
  string pListVehicles = null,
bool? pVehicleIsActive = null,
bool? pIsDeleted = false,
int? pQueryTypeId = clsQueryType.qSelect,
   string pLstStatus = null,
    string pLstType = null,
    string pLstBrand = null,
    string pLstColor = null,
    string pSearchDate = null

)
        {
            // Get Data 
            string vData = _dbVehicle.funVehicleGET(
            pVehicleId: pVehicleId,
            pVehicleCode: pVehicleCode,
            pVecDescL1: pVecDescL1,
            pVecDescL2: pVecDescL2,
            pInitialDate : pInitialDate,
           pPanelNumber : pPanelNumber,
           pVecModelId : pVecModelId,
           pVecVINNO : pVecVINNO,
           pVecTypeId : pVecTypeId,
           pBrandId : pBrandId,
           pVecColorId : pVecColorId,
            pComments: pComments,
            pVecStatus: pVecStatus,
            pVehicleImage: pVehicleImage,
            pListVehicles: pListVehicles,
            pVehicleIsActive: pVehicleIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId,
            pLstStatus : pLstStatus,
            pLstType : pLstType,
            pLstBrand : pLstBrand,
            pLstColor : pLstColor,
            pSearchDate : pSearchDate
            );
            // Result
            return vData;
        }
    }
}
