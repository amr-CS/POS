using appSERP.appCode.dbCode.ACC;
using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.ACC
{
    // Tarek - 13-03-2019 - 01:59 PM
    public class APICashDeskController : ApiController
    {
        private IdbCashDesk _dbCashDesk;
        public APICashDeskController(IdbCashDesk dbCashDesk)
        {
            _dbCashDesk = dbCashDesk;
        }

        [HttpGet]
        public string CashDeskGET(
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
            int? pQueryTypeId = clsQueryType.qSelect,
            string pLstType = null,
             string pCashDeskList = null)
        {
            // Get Data
            string vData = _dbCashDesk.funCashDeskGET(
                pCashDeskId: pCashDeskId,
                pCashDeskParentId: pCashDeskParentId,
                pCashDeskCode: pCashDeskCode,
                pCashDeskNameL1: pCashDeskNameL1,
                pCashDeskNameL2: pCashDeskNameL2,
                pCashDeskAccountNameL1: pCashDeskAccountNameL1,
                pCashDeskAccountNameL2: pCashDeskAccountNameL2,
                pCashDeskAccountIsActive: pCashDeskAccountIsActive,
                pCashDeskTypeId: pCashDeskTypeId,
                pCashDeskIsActive: pCashDeskIsActive,
                pIsDeleted: pIsDeleted,
                pCashDeskAccountId: pCashDeskAccountId,
                pAccountId: pAccountId,
                pIsAccountDetail: pIsAccountDetail,
                pQueryTypeId: pQueryTypeId,
                pLstType: pLstType,
               pCashDeskList: pCashDeskList
                );

            // Result
            return vData;
        }
    }
}
