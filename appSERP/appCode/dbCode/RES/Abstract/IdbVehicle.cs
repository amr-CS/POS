using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.RES.Abstract
{
    public interface IdbVehicle
    {

        string funVehicleGET(
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
bool? pIsDeleted = null,
    int? pQueryTypeId = null,
    string pLstStatus = null,
    string pLstType = null,
    string pLstBrand = null,
    string pLstColor = null,
    string pSearchDate = null
    );
        DataTable funGetVehicleReport(bool? pIsActive = null);
        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
