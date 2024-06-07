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
    public class APIGroupController : ApiController
    {
        private IdbGroup _dbGroup;
        public APIGroupController(IdbGroup dbGroup) {
            _dbGroup = dbGroup;
        }

        [HttpGet]
        public string GroupGET(
       int? pGroupId = null,
       int? pMainGroupId = null,
       string pGroupNameL1 = null,
       string pGroupNameL2 = null,
       bool? pGroupIsActive = null,
       int? pFixedAssetMethodId = null,
       decimal? pGroupPercent = null,
       int? pGroupDebitAccount = null,
       int? pGroupCreditAccount = null,
       int? pGroupPurchaseAccount = null,
       int? pGroupSalesAccount = null,
       bool? pIsDeleted = false,
       int? pQueryTypeId = clsQueryType.qSelect)
        {
            string vData = _dbGroup.funGroupGET(
            pGroupId: pGroupId,
            pMainGroupId: pMainGroupId,
            pGroupNameL1: pGroupNameL1,
            pGroupNameL2: pGroupNameL2,
            pGroupIsActive: pGroupIsActive,
            pFixedAssetMethodId: pFixedAssetMethodId,
            pGroupPercent: pGroupPercent,
            pGroupDebitAccount: pGroupDebitAccount,
            pGroupCreditAccount: pGroupCreditAccount,
            pGroupPurchaseAccount: pGroupPurchaseAccount,
            pGroupSalesAccount: pGroupSalesAccount,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId);
            return vData;
        }
    }
}
