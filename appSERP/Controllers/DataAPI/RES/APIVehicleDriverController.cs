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
    public class APIVehicleDriverController : ApiController
    {
        private IdbVehicleDriver _dbVehicleDriver;
        public APIVehicleDriverController(IdbVehicleDriver dbVehicleDriver) {
            _dbVehicleDriver = dbVehicleDriver;
        }
        [HttpGet]
        public string VehicleDriverGET(
int? pVehicleDriverId = null,
string pVehicleDriverCode = null,
int? pVehicleId = null,
int? pDriverId = null,
DateTime? pTransactionDate = null,
int? pTransactionStatusId = null,
decimal? pCounter = null,
string pNotes = null,
bool? pVehicleDriverIsActive = null,
bool? pIsDeleted = false,
  int? pQueryTypeId = clsQueryType.qSelect,
  string pVecDescL1 = null,
  string pResEmployeeNameL1 = null,
 string  pLstVehicleDriver = null,
 string pVehicleCode = null,
string pResEmployeeCode = null,
string pSearchedDate = null,
string pLstVehicles = null,
string pLstDrivers = null
            )
        {
            // Get Data 
            string vData = _dbVehicleDriver.funVehicleDriverGET(
            pVehicleDriverId : pVehicleDriverId,
            pVehicleDriverCode : pVehicleDriverCode,
             pVehicleId : pVehicleId,
               pDriverId : pDriverId,
              pTransactionDate : pTransactionDate,
               pTransactionStatusId : pTransactionStatusId,
                pCounter : pCounter,
                 pNotes : pNotes,
            pVehicleDriverIsActive: pVehicleDriverIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId,
            pVecDescL1: pVecDescL1,
            pResEmployeeNameL1 : pResEmployeeNameL1,
            pLstVehicleDriver : pLstVehicleDriver,
             pVehicleCode : pVehicleCode,
 pResEmployeeCode : pResEmployeeCode,
 pSearchedDate : pSearchedDate,
 pLstVehicles: pLstVehicles,
 pLstDrivers: pLstDrivers
            );
            // Result
            return vData;
        }
    }
}
