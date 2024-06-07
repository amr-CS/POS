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
    public class APIBankController : ApiController
    {
        private IdbBank _dbBank;
        public APIBankController(IdbBank dbBank) {
            _dbBank = dbBank;
        }

        // Amr 1:35 PM 24/3
        [HttpGet]
        public string BankGET(
            int? pBankId = null,
            int? pBankParentId = null,
            string pBankCode = null,
            string pBankNameL1 = null,
            string pBankNameL2 = null,
            string pBankAccountNameL1 = null,
            string pBankAccountNameL2 = null,
            bool? pBankAccountIsActive = null,
            int? pBankTypeId = null,
            bool? pBankIsActive = null,
            bool? pIsDeleted = false,
            int? pBankAccountId = null,
            string pAccountId = null,
            bool? pIsAccountDetail = null,
            int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data
            string vData = _dbBank.funBankGET(
                pBankId: pBankId,
                pBankParentId: pBankParentId,
                pBankCode: pBankCode,
                pBankNameL1: pBankNameL1,
                pBankNameL2: pBankNameL2,
                pBankAccountNameL1: pBankAccountNameL1,
                pBankAccountNameL2: pBankAccountNameL2,
                pBankAccountIsActive : pBankAccountIsActive,
                pBankTypeId: pBankTypeId,
                pBankIsActive: pBankIsActive,
                pIsDeleted: pIsDeleted,
                pBankAccountId: pBankAccountId,
                pAccountId: pAccountId,
                pIsAccountDetail: pIsAccountDetail,
                pQueryTypeId: pQueryTypeId
                );

            // Result
            return vData;
        }
    }
}
