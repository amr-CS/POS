using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbCashDesk
    {
        string funCashDeskGET(
           int? pCashDeskId = null,
           int? pCashDeskParentId = null,
           string pCashDeskCode = null,
           string pCashDeskNameL1 = null,
           string pCashDeskNameL2 = null,
           string pCashDeskAccountNameL1 = null,
           string pCashDeskAccountNameL2 = null,
           bool? pCashDeskAccountIsActive = null,
           int? pCashDeskTypeId = null,
           bool? pCashDeskIsActive = null,
           bool? pIsDeleted = false,
           int? pCashDeskAccountId = null,
           int? pAccountId = null,
           bool? pIsAccountDetail = null,
           int? pQueryTypeId = null,
           string pLstType = null,
           string pCashDeskList = null);

        DataTable funCashDeskReportGET(bool? pIsActive = null);
        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
