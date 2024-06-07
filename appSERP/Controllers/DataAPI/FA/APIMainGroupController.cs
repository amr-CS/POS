using appSERP.appCode.dbCode.FA;
using appSERP.appCode.dbCode.FA.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.FA
{
    public class APIMainGroupController : ApiController
    {
        private IdbMainGroup _dbMainGroup;
        public APIMainGroupController(IdbMainGroup dbMainGroup)
        {
            _dbMainGroup = dbMainGroup;
        }

        [HttpGet]
        public string MainGroupGET(
        int? pMainGroupId = null,
        string pMainGroupNameL1 = null,
        string pMainGroupNameL2 = null,
        bool? pMainGroupIsActive = null,
        int? pFixedAssetMethodId = null,
        decimal? pMainGroupPercent = null,
        int? pMainGroupDebitAccount = null,
        int? pMainGroupCreditAccount = null,
        int? pMainGroupPurchaseAccount = null,
        int? pMainGroupSalesAccount = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            string vData = _dbMainGroup.funMainGroupGET(
            pMainGroupId: pMainGroupId,
            pMainGroupNameL1: pMainGroupNameL1,
            pMainGroupNameL2: pMainGroupNameL2,
            pMainGroupIsActive: pMainGroupIsActive,
            pFixedAssetMethodId: pFixedAssetMethodId,
            pMainGroupPercent: pMainGroupPercent,
            pMainGroupDebitAccount: pMainGroupDebitAccount,
            pMainGroupCreditAccount: pMainGroupCreditAccount,
            pMainGroupPurchaseAccount: pMainGroupPurchaseAccount,
            pMainGroupSalesAccount: pMainGroupSalesAccount,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId);
            return vData;


        }
    }
}
