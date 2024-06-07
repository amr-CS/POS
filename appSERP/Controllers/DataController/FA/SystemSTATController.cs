using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataController.FA
{
    public class SystemSTATController : Controller
    {

        private IclsAPI _clsAPI;

        public SystemSTATController(IclsAPI clsAPI)
        {
            _clsAPI = clsAPI;
        }

        // GET: SystemSTAT
        public ActionResult STAT()
    {
            // API Path
            string vPath = appAPIDirectory.vAPISystemSTAT;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);


            // Get All Data For DashBoard
            ViewBag.vbAssetCount = vDtData.Rows[0]["AssetCount"].ToString();
            ViewBag.vbAssetContractCount = vDtData.Rows[0]["AssetContractCount"].ToString();
            ViewBag.vbAssetContractDetailCount = vDtData.Rows[0]["AssetContractDetailCount"].ToString();
            ViewBag.vbAssetContractPayTypeCount = vDtData.Rows[0]["AssetContractPayTypeCount"].ToString();
            ViewBag.vbAssetDepCount = vDtData.Rows[0]["AssetDepCount"].ToString();
            ViewBag.vbAssetReasonTypeCount = vDtData.Rows[0]["AssetReasonTypeCount"].ToString();
            ViewBag.vbAssetReleaseCount = vDtData.Rows[0]["AssetReleaseCount"].ToString();
            ViewBag.vbAssetReleaseDetailCount = vDtData.Rows[0]["AssetReleaseDetailCount"].ToString();
            ViewBag.vbAssetTransCount = vDtData.Rows[0]["AssetTransCount"].ToString();
            ViewBag.vbAssetUnDepCount = vDtData.Rows[0]["AssetUnDepCount"].ToString();
            ViewBag.vbBuyGroupCount = vDtData.Rows[0]["BuyGroupCount"].ToString();
            ViewBag.vbFixedAssetCompanyCount = vDtData.Rows[0]["FixedAssetCompanyCount"].ToString();
            ViewBag.vbFixedAssetCompanyTypeCount = vDtData.Rows[0]["FixedAssetCompanyTypeCount"].ToString();
            ViewBag.vbFixedAssetUnitCount = vDtData.Rows[0]["FixedAssetUnitCount"].ToString();
            ViewBag.vbGroupCount = vDtData.Rows[0]["GroupCount"].ToString();
            ViewBag.vbMainGroupCount = vDtData.Rows[0]["MainGroupCount"].ToString();
            ViewBag.vbSite = vDtData.Rows[0]["Site"].ToString();
            ViewBag.vbSiteDetail = vDtData.Rows[0]["SiteDetail"].ToString();
            ViewBag.vbSiteDonor = vDtData.Rows[0]["Trust"].ToString();
            ViewBag.vbTrust = vDtData.Rows[0]["TransactionType"].ToString();


            // Return View
            if (Request.IsAjaxRequest())
        {
            return PartialView(vDtData);
        }
        return View(vDtData);
    }
}
}