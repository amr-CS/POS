using appSERP.appCode.dbCode.INV;
using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.GD.Abstract;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.appCode.Setting.ReportSetting;
using appSERP.appCode.SQL.QueryType;
using appSERP.Logger;
using appSERP.Models.INV;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataController.INV
{
    [NoDirectAccess]
    [Authorize]
    public class StoreConversionController : Controller
    {
        private ILog _ILog;
        private IdbStoreConversion _dbStoreConversion;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public StoreConversionController(ILog log, IdbStoreConversion dbStoreConversion, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _ILog = log;
            _dbStoreConversion = dbStoreConversion;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            _ILog.LogException(filterContext.Exception.ToString());
            filterContext.ExceptionHandled = true;
            this.View("Error").ExecuteResult(this.ControllerContext);
        }
        // GET: StoreConversion
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            //ViewBag.Title = "التحويل المخزني";
            return View();
        }
        public JsonResult StoreConversionBulk(ICollection<StoreConversion> StoreConversionDtls, 
            int? StoreConversionId, int? SourceBranchId, int? TargetBranchId, int? StoreId, DateTime? StoreConversionDate,
             int? SourceStoreId,string Notes, bool? StoreConversionIsActive, bool? IsDeleted,int?   CreatedBy,int ?LastUpdatedBy,int ? BranchId)
        {
            return Json(_dbStoreConversion.spStoreConversionBulk(StoreConversionDtls, 
                StoreConversionId,
                SourceBranchId, 
                TargetBranchId,
                StoreId,
                StoreConversionDate,
                SourceStoreId,
                Notes,
                StoreConversionIsActive,
                IsDeleted,
                CreatedBy,
                LastUpdatedBy,
                BranchId));

        }


        // Save Conversion 
        public string funSaveStoreConversion(
        int? pStoreConversionId = null,
        int? pStoreConversionCode = null,
        int? pSourceBranchId = null,
        int? pTargetBranchId = null,
        int? pStoreId = null,
        int? pStoreConversionType = null,
        int? pStoreConversionYear = null,
        string pStoreConversionDate = null,
        int? pSourceStoreId = null,
        string pNotes = null,
        int? pReqId = null,
        int? pReqYear = null,
        float? pReceivedQty = null,
        string pReceivedUser = null,
        string pReceivedDate = null,
        bool? pStoreConversionIsActive = null,
        bool? pIsDeleted = false,
        int? pStoreConversionDtlId = null,
        int? pdStoreId = null,
        int? pdStoreConversionId = null,
        int? pdStoreConversionType = null,
        int? pdStoreConversionYear = null,
        int? pdSoureStoreType = null,
        int? pdItemId = null,
        int? pdUnitId = null,
        DateTime? pdExpireDate = null,
        int? pdStoreSectId = null,
        float? pdItemQty = null,
        string pdNotes = null,
        bool? pdIsDeleted = null,
        int? pdCreatedBy = null,
        DateTime? pdCreatedOn = null,
        int? pdLastUpdatedBy = null,
        DateTime? pdLastUpdatedOn = null,
        int? pLanguageId = null,
        int? pCompanyId = null,
        bool? pIsStoreConversionDetail = true,
        int? pCreatedBy = null,
        int? pLastUpdatedBy = null,
        int? pQueryTypeId = clsQueryType.qSelect,
        string pLstConversionId = null
        )
        {
            // Data
            string vResult = string.Empty;
            string vPath = "/APIStoreConversion/StoreConversionGET";
            string vParam = "";
            if (pdExpireDate == null)
            {
                vParam =
     "?pStoreConversionId=" + pStoreConversionId +
     "&pCreatedBy=" + pCreatedBy +
     "&pLastUpdatedBy=" + pLastUpdatedBy +
     "&pStoreConversionCode=" + pStoreConversionCode +
     "&pSourceBranchId=" + pSourceBranchId +
     "&pTargetBranchId=" + pTargetBranchId +
     "&pStoreId=" + pStoreId +
     "&pStoreConversionType=" + pStoreConversionType +
     "&pStoreConversionYear=" + pStoreConversionYear +
     "&pStoreConversionDate=" + pStoreConversionDate +
     "&pSourceStoreId=" + pSourceStoreId +
     "&pIsDeleted=" + pIsDeleted +
     "&pNotes=" + pNotes +
     "&pReqId=" + pReqId +
     "&pReqYear=" + pReqYear +
     "&pReceivedQty=" + pReceivedQty +
     "&pReceivedUser=" + pReceivedUser +
     "&pReceivedDate=" + pReceivedDate +
     "&pStoreConversionIsActive=" + pStoreConversionIsActive +
     "&pStoreConversionDtlId=" + pStoreConversionDtlId +
     "&pdStoreId=" + pdStoreId +
     "&pdStoreConversionId=" + pdStoreConversionId +
     "&pdStoreConversionType=" + pdStoreConversionType +
     "&pdStoreConversionYear=" + pdStoreConversionYear +
     "&pdSoureStoreType=" + pdSoureStoreType +
     "&pdItemId=" + pdItemId +
     "&pdUnitId=" + pdUnitId +
     "&pdExpireDate=" + pdExpireDate +
     "&pdStoreSectId=" + pdStoreSectId +
     "&pdItemQty=" + pdItemQty +
     "&pdNotes=" + pdNotes +
     "&pdIsDeleted=" + pdIsDeleted +
     "&pdCreatedBy=" + pdCreatedBy +
     "&pdCreatedOn=" + pdCreatedOn +
     "&pdLastUpdatedBy=" + pdLastUpdatedBy +
     "&pdLastUpdatedOn=" + pdLastUpdatedOn +
     "&pLanguageId=" + pLanguageId +
     "&pCompanyId=" + pCompanyId +
     "&pIsStoreConversionDetail=" + pIsStoreConversionDetail +
     "&pQueryTypeId=" + pQueryTypeId +
      "&pLstConversionId=" + pLstConversionId ;
            }
            else
            {
                vParam =
     "?pStoreConversionId=" + pStoreConversionId +
     "&pStoreConversionCode=" + pStoreConversionCode +
     "&pSourceBranchId=" + pSourceBranchId +
     "&pTargetBranchId=" + pTargetBranchId +
     "&pStoreId=" + pStoreId +
     "&pStoreConversionType=" + pStoreConversionType +
     "&pStoreConversionYear=" + pStoreConversionYear +
     "&pStoreConversionDate=" + pStoreConversionDate +
     "&pSourceStoreId=" + pSourceStoreId +
     "&pIsDeleted=" + pIsDeleted +
     "&pNotes=" + pNotes +
     "&pReqId=" + pReqId +
     "&pReqYear=" + pReqYear +
     "&pReceivedQty=" + pReceivedQty +
     "&pReceivedUser=" + pReceivedUser +
     "&pReceivedDate=" + pReceivedDate +
     "&pStoreConversionIsActive=" + pStoreConversionIsActive +
     "&pStoreConversionDtlId=" + pStoreConversionDtlId +
     "&pdStoreId=" + pdStoreId +
     "&pdStoreConversionId=" + pdStoreConversionId +
     "&pdStoreConversionType=" + pdStoreConversionType +
     "&pdStoreConversionYear=" + pdStoreConversionYear +
     "&pdSoureStoreType=" + pdSoureStoreType +
     "&pdItemId=" + pdItemId +
     "&pdUnitId=" + pdUnitId +
     "&pdExpireDate=" + Convert.ToDateTime(pdExpireDate).Date.ToString("yyyy-MM-dd") +
     "&pdStoreSectId=" + pdStoreSectId +
     "&pdItemQty=" + pdItemQty +
     "&pdNotes=" + pdNotes +
     "&pdIsDeleted=" + pdIsDeleted +
     "&pdCreatedBy=" + pdCreatedBy +
     "&pdCreatedOn=" + pdCreatedOn +
     "&pdLastUpdatedBy=" + pdLastUpdatedBy +
     "&pdLastUpdatedOn=" + pdLastUpdatedOn +
     "&pLanguageId=" + pLanguageId +
     "&pCompanyId=" + pCompanyId +
     "&pIsStoreConversionDetail=" + pIsStoreConversionDetail +
     "&pQueryTypeId=" + pQueryTypeId+
       "&pLstConversionId=" + pLstConversionId;
            }





            // Result
            //DataTable vDtData = clsAPI.funResultGet(vPath + vParam);

            //// JSON
            //vResult = JsonConvert.SerializeObject(vDtData);

             vResult = _clsAPI.funResultGetJSON(vPath + vParam);

            // Return Result
            return vResult;

        }


        public ActionResult StoreConversionSearch()
        {


            return View();
        }
        public string GetStoreList()
            {
            string vPath = "/APIStore/StoreGET";
            string vParameters = "?pQueryTypeId=402";
            string vResult = _clsAPI.funResultGetJSON(vPath + vParameters);

            // Return Result
            return vResult;


        }
//        @LstStores NVARCHAR(500) = NULL,
//@LstSource NVARCHAR(500) = NULL
        public string FilterStoreConversion(int? pStoreConversionCode = null, string pStoreConversionDate = null, string pSearchDate = null, string pLstStores = null,string pLstSource = null)
        {
            string vPath = "/APIStoreConversion/StoreConversionGET";
            string vParameters = "?pStoreConversionCode="+ pStoreConversionCode + "&pSearchDate=" + pSearchDate + "&pLstStores=" + pLstStores + "&pLstSource=" + pLstSource + "&pQueryTypeId=409";
            string vResult = _clsAPI.funResultGetJSON(vPath + vParameters);

            // Return Result
            return vResult;


        }

        public void ShowSimple()
        {
            int vStoreConversionId = Convert.ToInt32(Session["StoreConversionId"]);
            DataTable DT = _dbStoreConversion.funGetStoreConversionReport(pStoreConversionId: vStoreConversionId);
            string vReportPath = Server.MapPath("~/Reports") + "//StoreConversionReport.rpt";
            ClsReport.Printreport(DT, vReportPath);


        }
        
        public ActionResult StoreConversionReport(int? pStoreConversionId = null)
        {
            ViewBag.vbStoreConversionId = pStoreConversionId;
            Session["StoreConversionId"] = ViewBag.vbStoreConversionId;
            return View();
        }    
        public ActionResult StoreConversionhtmlReport(int? pStoreConversionId = null)
        {
            DataTable DT = _dbStoreConversion.funGetStoreConversionReport(pStoreConversionId: pStoreConversionId);

            if (DT.Rows.Count > 0)
                {
                    DataRow dataRow = DT.Rows[0];
                    ViewBag.vDT = DT;
                    ViewBag.ReportName = "التحويل المخزني";
                    ViewBag.DateTo = dataRow["StoreConversionDate"];
                    ViewBag.DateFrom = dataRow["StoreConversionDate"];
                    ViewBag.CompanyBranchNameL2 = dataRow["CompanyBranchNameL2"];
                    ViewBag.CompanyBranchNameL1 = dataRow["CompanyBranchNameL1"];
                    ViewBag.CompanyBranchTel = dataRow["CompanyBranchTel"];
                }
                return View();
            
        }
    }
}


