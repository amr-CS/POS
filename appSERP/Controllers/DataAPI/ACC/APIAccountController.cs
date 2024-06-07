using appSERP.appCode.dbCode.ACC;
using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.SQL.QueryType;
using appSERP.Models.ACC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.ACC
{
    public class APIAccountController : ApiController
    {
        private IdbAccount _dbAccount;
        public APIAccountController(IdbAccount dbAccount) {
            _dbAccount = dbAccount;
        }

        [HttpGet]
        public string AccountGET(
        int? pAccountId = null,
        string pAccountNo = null,
        string pAccountNameL1 = null,
        string pAccountNameL2 = null,
        int? pAccountTypeId = null,
        int? pAccountParentId = null,
        int? pAccountLevel = null,
        int? pCurrencyId = null,
        bool? pIsCostCenter = null,
        int? pCurrencyFactorId = null,
        int? pSecurityGradeId = null,
        bool? pAccountIsDebit = null,
        int? pAccountingReportId = null,
        bool? pAccountIsCumulative = null,
        int? pCashFlowTypeId = null,
        int? pAccountFrom = null,
        int? pAccountTo = null,
        int? pCostCenterId = null,
        int? pCustomerId = null,
        int? pAccountCategoryId = null,
        bool? pAccountIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // Get Data
            string vData = _dbAccount.funAccountGET(
            pAccountId: pAccountId,
            pAccountNo: pAccountNo,
            pAccountNameL1: pAccountNameL1,
            pAccountNameL2: pAccountNameL2,
            pAccountTypeId: pAccountTypeId,
            pAccountParentId: pAccountParentId,
            pAccountLevel: pAccountLevel,
            pCurrencyId: pCurrencyId,
            pIsCostCenter: pIsCostCenter,
            pCurrencyFactorId: pCurrencyFactorId,
            pSecurityGradeId: pSecurityGradeId,
            pAccountIsDebit: pAccountIsDebit,
            pAccountingReportId: pAccountingReportId,
            pAccountIsCumulative: pAccountIsCumulative,
            pCashFlowTypeId: pCashFlowTypeId,
            pAccountFrom: pAccountFrom,
            pAccountTo: pAccountTo,
            pCostCenterId: pCostCenterId,
            pCustomerId: pCustomerId,
            pAccountCategoryId: pAccountCategoryId,
            pAccountIsActive: pAccountIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
               );
            // Return Data
            return vData;
        }

        [HttpPost]
        public IHttpActionResult SaveChanges(ICollection<AccountModel> accountModels)
        {
            if (ModelState.IsValid)
            {
                return Ok(_dbAccount.spAccountInsertUpdateBulk(accountModels));
            }

            var error = ModelState.Select(x => new { x.Key, ErrorMessage = x.Value.Errors.Select(e => e.ErrorMessage) });
            return Ok(error);
        }
    }
}
