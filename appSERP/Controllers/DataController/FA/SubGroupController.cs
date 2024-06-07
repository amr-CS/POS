using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.SQL.QueryType;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataController.FA
{
    public class SubGroupController : Controller
    {
        private IclsAPI _clsAPI;

        public SubGroupController(IclsAPI clsAPI)
        {
            _clsAPI = clsAPI;
        }

        // GET: SubGroup
        public ActionResult Index()
        {
            return View();
        }



        // Master Detail For  Group
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
            // Data
            string vResult = string.Empty;
            // GET Data
            string vPath = appAPIDirectory.vAPIMainGroup;
            // Praremeter
            string vParameters =
            "?pMainGroupId=" + pMainGroupId +
            "&pMainGroupNameL1=" + pMainGroupNameL1 +
            "&pMainGroupNameL2=" + pMainGroupNameL2 +
            "&pMainGroupIsActive=" + pMainGroupIsActive +
            "&pFixedAssetMethodId=" + pFixedAssetMethodId +
            "&pMainGroupPercent=" + pMainGroupPercent +
            "&pMainGroupDebitAccount=" + pMainGroupDebitAccount +
            "&pMainGroupCreditAccount=" + pMainGroupCreditAccount +
            "&pMainGroupPurchaseAccount=" + pMainGroupPurchaseAccount +
            "&pMainGroupSalesAccount=" + pMainGroupSalesAccount +
            "&pIsDeleted=" + pIsDeleted +
            "&pQueryTypeId=" + pQueryTypeId;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
            // JSON
            vResult = JsonConvert.SerializeObject(vDtData);

            // Return Result
            return vResult;
        }





        // Master Detail For  Group
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
            // Data
            string vResult = string.Empty;
            // GET Data
            string vPath = appAPIDirectory.vAPIGroup;
            // Praremeter
            string vParameters =
                    "?pGroupId=" + pGroupId +
                    "&pMainGroupId=" + pMainGroupId +
                    "&pGroupNameL1=" + pGroupNameL1 +
                    "&pGroupNameL2= " + pGroupNameL2 +
                    "&pGroupIsActive=" + pGroupIsActive +
                    "&pFixedAssetMethodId=" + pFixedAssetMethodId +
                    "&pGroupPercent=" + pGroupPercent +
                    "&pGroupDebitAccount= " + pGroupDebitAccount +
                    "&pGroupCreditAccount=" + pGroupCreditAccount +
                    "&pGroupPurchaseAccount=" + pGroupPurchaseAccount +
                    "&pGroupSalesAccount= " + pGroupSalesAccount +
                    "&pIsDeleted=" + pIsDeleted +
                    "&pQueryTypeId=" + pQueryTypeId;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
            // JSON
            vResult = JsonConvert.SerializeObject(vDtData);

            // Return Result
            return vResult;
        }
    }
}