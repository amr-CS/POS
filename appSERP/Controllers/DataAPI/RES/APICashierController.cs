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
    public class APICashierController : ApiController
    {

        private IdbCashier _dbCashier;
        public APICashierController(IdbCashier dbCashier) {
            _dbCashier = dbCashier;
        }

        [HttpGet]
       public  string CashierGET(
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
       int? pCashCode = null,
       int? Credit = null,
       bool? pIsDeleted = null,
       int? pQueryTypeId = clsQueryType.qSelect)
        {
            string Data = _dbCashier.funCashierGET(
            pIsCashComp: pIsCashComp,
            pNetAcc: pNetAcc,
            pCostCenterId: pCostCenterId,
            pNOTES: pNOTES,
            pCashAcc: pCashAcc,
            pCashStatus: pCashStatus,
            pUserName: pUserName,
            pCashNameL2: pCashNameL2,
            pCashPassword: pCashPassword,
            pEmpId: pEmpId,
            pCashNameL1: pCashNameL1,
            pCashId: pCashId,
            pCashCode: pCashCode,
            Credit: Credit,
            pIsDeleted: pIsDeleted,
            pQueryTypeId : pQueryTypeId
               );
            // Result
            return Data;
        }
    }
}
