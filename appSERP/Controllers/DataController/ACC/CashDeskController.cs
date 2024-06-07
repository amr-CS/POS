using appSERP.appCode.dbCode.ACC;
using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.appCode.Setting.ReportSetting;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Web.Mvc;

namespace appSERP.Controllers.DataControllers.ACC
{
    // Tarek - 13-03-2019 - 02:03 PM
   // [NoDirectAccess]
    [Authorize]
    public class CashDeskController : Controller
    {
        private IdbCashDesk _dbCashDesk;
        private IclsAPI _clsAPI;
        public CashDeskController(IdbCashDesk dbCashDesk, IclsAPI clsAPI)
        {
            _dbCashDesk = dbCashDesk;
            _clsAPI = clsAPI;
        }

        // Index
        public ActionResult Index()
        {
            return View();
        }

        // Cash Desk GET
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
            int? pQueryTypeId = null)
        {
            // Data
            string vResult = string.Empty;
            // GET Data
            string vPath = appAPIDirectory.vAPICashDesk;
            // Praremeter
            string vParameters =
                "?pCashDeskId=" + pCashDeskId +
                "&pCashDeskParentId=" + pCashDeskParentId +
                "&pCashDeskCode=" + pCashDeskCode +
                "&pCashDeskNameL1=" + pCashDeskNameL1 +
                "&pCashDeskNameL2=" + pCashDeskNameL2 +
                "&pCashDeskAccountNameL1=" + pCashDeskAccountNameL1 +
                "&pCashDeskAccountNameL2=" + pCashDeskAccountNameL2 +
                "&pCashDeskAccountIsActive=" + pCashDeskAccountIsActive +
                "&pCashDeskTypeId=" + pCashDeskTypeId +
                "&pCashDeskIsActive=" + pCashDeskIsActive +
                "&pIsDeleted=" + pIsDeleted +
                "&pCashDeskAccountId=" + pCashDeskAccountId +
                "&pAccountId=" + pAccountId +
                "&pIsAccountDetail=" + pIsAccountDetail +
                "&pQueryTypeId=" + pQueryTypeId;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
            // JSON
            vResult = JsonConvert.SerializeObject(vDtData);

            // Return Result
            return vResult;
        }
        public ActionResult SearchAccount()
        {
            // API Path
            string vPath = appAPIDirectory.vAPIAccount;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);
            ViewBag.vbAccount = vDtData.AsDataView();
            return View();
        }
        public void ShowSimpleCashDeskReport()
        {
            DataTable DT = _dbCashDesk.funCashDeskReportGET();
            string vFullPath = Server.MapPath("~/Reports") + "//CashDeskReport.rpt";
            ClsReport.Printreport(DT, vFullPath);
        }
        public ActionResult CashDeskReport()
        {

            //ViewBag.vbCostCenter = pGLVoucherId;
            //Session["SCostCenter"] = ViewBag.vbCostCenter;

            return View();
        }
        public ActionResult SearchCashDesk()
        {


            return View();
        }
        public string FilterCashDesks(string pCashDeskCode = null, string pCashDeskNameL1 = null, string pCashDeskNameL2 = null, string pType = null)
        {
            // Data
            string vResult = string.Empty;
            // GET Data
            string vPath = appAPIDirectory.vAPICashDesk;
            // Praremeter
            string vParameters =
                "?pCashDeskCode=" + pCashDeskCode +
                "&pCashDeskNameL1=" + pCashDeskNameL1 +
                "&pCashDeskNameL2=" + pCashDeskNameL2 +
                 "&pLstType=" + pType +
                "&pQueryTypeId=" + 401;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
            // JSON
            vResult = JsonConvert.SerializeObject(vDtData);

            // Return Result
            return vResult;
        }
        public string GetCashDeskByList(string pCashDeskList = null)
        {
            // Data
            string vResult = string.Empty;
            // GET Data
            string vPath = appAPIDirectory.vAPICashDesk;
            // Praremeter
            string vParameters =
                "?pQueryTypeId=" + 402 +
                "&pCashDeskList=" + pCashDeskList;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
            // JSON
            vResult = JsonConvert.SerializeObject(vDtData);

            // Return Result
            return vResult;
        }
    }
}