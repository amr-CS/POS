using appSERP.appCode.dbCode.ACC;
using appSERP.appCode.dbCode.INV;
using appSERP.appCode.dbCode.INV.Abstract;
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
    public class SizeTypeController : Controller
    {

        private IdbSizeType _dbSizeType;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public SizeTypeController(IdbSizeType dbSizeType, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _dbSizeType = dbSizeType;
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
        public string SizeTypeGET(
            int? pSizeTypeId = null,
            string pSizeTypeCode = null,
            string pSizeTypeNameL1 = null,
            string pSizeTypeNameL2 = null,
            string pNotes = null,
            bool? pSizeTypeIsActive = null,
            bool? pIsDeleted = false,
            int? pQueryTypeId = null)
        {
            // Data
            string vResult = string.Empty;
            // GET Data
            string vPath = appAPIDirectory.vAPISizeType;
            // Praremeter
            string vParameters =
                "?pSizeTypeId=" + pSizeTypeId +
                "&pSizeTypeCode=" + pSizeTypeCode +
                "&pSizeTypeNameL1=" + pSizeTypeNameL1 +
                "&pSizeTypeNameL2=" + pSizeTypeNameL2 +
                "&pNotes=" + pNotes +
                "&pSizeTypeIsActive=" + pSizeTypeIsActive +
               
                "&pIsDeleted=" + pIsDeleted +
                "&pQueryTypeId=" + pQueryTypeId;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);

            // JSON
            vResult = JsonConvert.SerializeObject(vDtData);

            // Return Result
            return vResult;
        }
        // Cash Desk GET
        public string SizeGET(
            int? pSizeId = null,
            string pSizeCode = null,
            string pSizeNameL1 = null,
            string pSizeNameL2 = null,
            int? pSizeTypeId = null,
            bool? pSizeIsActive = null,
            bool? pIsDetail = null,
            bool? pIsUnitDetail = null,
            bool? pIsDeleted = false,
            int? pQueryTypeId = null)
        {
            // Data
            string vResult = string.Empty;
            // GET Data
            string vPath = appAPIDirectory.vAPISize;
            // Praremeter
            string vParameters =
                "?pSizeId=" + pSizeId +
                "&pSizeCode=" + pSizeCode +
                "&pSizeNameL1=" + pSizeNameL1 +
                "&pSizeNameL2=" + pSizeNameL2 +
                "&pSizeTypeId=" + pSizeTypeId +
                "&pSizeIsActive=" + pSizeIsActive +
                "&pIsDetail=" + pIsDetail +
                "&pIsUnitDetail=" + pIsUnitDetail +
                "&pIsDeleted=" + pIsDeleted +
                "&pQueryTypeId=" + pQueryTypeId;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);

            // JSON
            vResult = JsonConvert.SerializeObject(vDtData);

            // Return Result
            return vResult;
        }
        public void ShowSimple()
        {
           
            DataTable DT = _dbSizeType.funGetSizeTypeReport();
            string vReportPath = Server.MapPath("~/Reports") + "//SizeTypeReport.rpt";
            ClsReport.Printreport(DT, vReportPath);
        }
        public ActionResult SizeTypeReport()
        {
        
            return View();
        }

    }
}
