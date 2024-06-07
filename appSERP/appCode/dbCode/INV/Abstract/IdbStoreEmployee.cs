using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.INV.Abstract
{
    public interface IdbStoreEmployee
    {
        string funStoreEmployeeGET(
       int? pStoreEmployeeId = null,
     string pStoreEmployeeCode = null,
   string pStoreEmployeeName = null,
   int? pGeneralNumber = null,
   string pJob = null,
  decimal? pProfit = null,
 DateTime? pEmployeeStartDate = null,
 DateTime? pEmployeeEndDate = null,
 string pNotes = null,
 int? pBranchId = null,
 bool? pStoreEmployeeIsActive = null,
 bool? pIsDeleted = null,
 int? pCreatedBy = null,
 DateTime? pCreatedOn = null,
 int? pLastUpdatedBy = null,
 DateTime? pLastUpdatedOn = null,
 int? pLanguageId = null,
    int? pQueryTypeId = null,
   string pSearchStartDate = null,
      string pSearchEndDate = null,
      string pList = null
    );

        DataTable funGetStoreEmployeeReport(bool? pIsActive = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
