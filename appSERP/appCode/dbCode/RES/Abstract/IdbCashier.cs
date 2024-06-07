using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.RES.Abstract
{
    public interface IdbCashier
    {
        string funCashierGET(
        int? pCashId = null,
        bool? pIsCashComp = null,
        string pNetAcc = null,
        int? pCostCenterId = null,
        string pNOTES = null,
        string pCashAcc = null,
        bool? pCashStatus = null,
        string pCashNameL2 = null,
        string pUserName = null,
        string pCashPassword = null,
        int? pEmpId = null,
        string pCashNameL1 = null,
        int? pCompanyId = null,
        int? pCashCode = null,
        bool? pIsDeleted = null,
        int? pLanguageId = null,
        int? Credit = null,
        int? pQueryTypeId = clsQueryType.qSelect);
    }
}
