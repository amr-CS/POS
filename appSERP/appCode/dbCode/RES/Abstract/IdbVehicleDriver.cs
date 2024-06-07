using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.RES.Abstract
{
    public interface IdbVehicleDriver
    {
        string funVehicleDriverGET(
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
int? pQueryTypeId = null,
string pVecDescL1 = null,
string pResEmployeeNameL1 = null,
string pLstVehicleDriver = null,
string pVehicleCode = null,
string pResEmployeeCode = null,
string pSearchedDate = null,
string pLstVehicles = null,
string pLstDrivers = null
);

        DataTable funGetVehicleDriverReport(bool? pIsActive = null);
    }
}
