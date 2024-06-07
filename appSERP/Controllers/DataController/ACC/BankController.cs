using appSERP.appCode.dbCode.ACC;
using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.GD.Abstract;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.appCode.Setting.ReportSetting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataController.ACC
{
    [NoDirectAccess]
    [Authorize]
    public class BankController : Controller
    {
        private IdbBank _dbBank;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public BankController(IdbBank dbBank, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _dbBank = dbBank;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }

        // Index
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            return View();
        }

        // Cash Desk GET
        public string BankGET(
            int? pBankId = null,
            int? pBankParentId = null,
            string pBankCode = null,
            string pBankNameL1 = null,
            string pBankNameL2 = null,
            string pBankAccountNameL1 = null,
            string pBankAccountNameL2 = null,
            string pBankAccountIsActive = null,
            int? pBankTypeId = null,
            bool? pBankIsActive = null,
            bool? pIsDeleted = false,
            int? pBankAccountId = null,
            string pAccountId = null,
            bool? pIsAccountDetail = null,
            int? pQueryTypeId = null)
        {
            // Data
            string vResult = string.Empty;
            // GET Data
            string vPath = appAPIDirectory.vAPIBank;
            // Praremeter
            string vParameters =
                "?pBankId=" + pBankId +
                "&pBankParentId=" + pBankParentId +
                "&pBankCode=" + pBankCode +
                "&pBankNameL1=" + pBankNameL1 +
                "&pBankNameL2=" + pBankNameL2 +
                "&pBankAccountNameL1=" + pBankAccountNameL1 +
                "&pBankAccountNameL2=" + pBankAccountNameL2 +
                "&pBankAccountIsActive=" + pBankAccountIsActive +
                "&pBankTypeId=" + pBankTypeId +
                "&pBankIsActive=" + pBankIsActive +
                "&pIsDeleted=" + pIsDeleted +
                "&pBankAccountId=" + pBankAccountId +
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
        public void ShowSimpleBankReport()
        {
            DataTable DT = _dbBank.funBankReportGET();
            string vFullPath = Server.MapPath("~/Reports") + "//BankReport.rpt";
            ClsReport.Printreport(DT, vFullPath);
        }
        public ActionResult BankReport()
        {

            //ViewBag.vbCostCenter = pGLVoucherId;
            //Session["SCostCenter"] = ViewBag.vbCostCenter;

            return View();
        }
    }
}
