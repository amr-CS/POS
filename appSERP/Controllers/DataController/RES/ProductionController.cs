using appSERP.appCode.dbCode.RES;
using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.GD.Abstract;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.appCode.Setting.ReportSetting;
using appSERP.appCode.SQL.QueryType;
using appSERP.Logger;
using appSERP.Models;
using appSERP.Models.RES;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataController.RES
{
    [NoDirectAccess]
    [Authorize]
    public class ProductionController : Controller
    {
        // GET: ResProduction
        private ILog _ILog;
        private IdbProduction _dbProduction;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        private IdbBranchSetting _dbBranchSetting;

        public ProductionController(ILog log, IdbProduction dbProduction, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting, IdbBranchSetting dbBranchSetting)
        {
            _ILog = log;
            _dbProduction = dbProduction;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
            _dbBranchSetting = dbBranchSetting;
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            _ILog.LogException(filterContext.Exception.ToString());
            filterContext.ExceptionHandled = true;
            this.View("Error").ExecuteResult(this.ControllerContext);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductionOrder()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            ViewBag.dbBranchSetting = _dbBranchSetting;
            return View();
        }
        public ActionResult ProductionTrans()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            return View();
        }
        public ActionResult MarkingSearch()
        {

            return View();
        }
        public ActionResult ProdLineSearch()
        {
            return View();
        }
        public ActionResult ProductSearch()
        {

            return View();
        }
        public ActionResult DestStoreSearch()
        {

            return View();
        }
        public ActionResult ProductionSearch()
        {
            return View();
        }

        // ADDQty View
        public ActionResult AddQty()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            return View();
        }
        public ActionResult AddQtySearch()
        {
            return View();
        } 
        public ActionResult Type()
        {
            return View();
        }

        public string funSaveProduction(
        int? pProductionId = null,
        string pProductionCode = null,
        int? pSubSeq = null,
        int? pTransId = null,
        string pTransDate = null,
        int? pTransStatus = null,
        int? pEmpId = null,
        int? pProdLine = null,
        bool? pIsPosted = null,
        int? pCompanyId = null,
        bool? pIsDeleted = null,
        int? pProductionDtlId = null,
        int? pItemId = null,
        int? pSourceStore = null,
        int? pDestStore = null,
        int? pSellStore = null,
        int? pAddId = null,
        int? pQTY = null,
        int? pUnitId = null,
        int? pTagId = null,
        string pNOTES = null,
        int? pRemainderQty = null,
        bool? pIsDetail = null,
       int? branchid = null,
        int? pQueryTypeId = clsQueryType.qSelect
        )
        {
            // Data
            string vResult = string.Empty;
            // GET Data
            string vPath = "/APIProduction/ProductionGet";
            // Praremeter
            string vParameters =
           "?pProductionId=" + pProductionId +
           "&pProductionCode=" + pProductionCode +
           "&pSubSeq=" + pSubSeq +
           "&pTransId=" + pTransId +
           "&pTransDate" + pTransDate +
           "&pTransStatus=" + pTransStatus +
           "&pEmpId=" + pEmpId +
           "&pProdLine=" + pProdLine +
           "&pIsPosted=" + pIsPosted +
           "&pProductionDtlId=" + pProductionDtlId +
           "&pItemId=" + pItemId +
           "&pSourceStore=" + pSourceStore +
           "&pDestStore=" + pDestStore +
           "&pSellStore=" + pSellStore +
           "&pAddId=" + pAddId +
           "&pQTY=" + pQTY +
           "&pUnitId=" + pUnitId +
           "&pTagId=" + pTagId +
           "&pNOTES=" + pNOTES +
           "&pRemainderQty=" + pRemainderQty +
           "&pIsDetail=" + pIsDetail +
           "&branchid=" + branchid +

           "&pQueryTypeId=" + pQueryTypeId;


            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);

            // JSON
            vResult = JsonConvert.SerializeObject(vDtData);

            // Return Result
            return vResult;
        }
        public void ShowSimpleProductionOrderReport()
        {
            int vProductionId = 0;
            DateTime? vDateFrom = DateTime.Now;
            DateTime? vDateTo = DateTime.Now;
            DataTable DT;
           
            vProductionId = Convert.ToInt32( Session["sProductionId"].ToString());
            vDateFrom = Convert.ToDateTime(Session["sDateFrom"]);
            vDateTo = Convert.ToDateTime(Session["sDateTo"]);
            if (Session["sDateFrom"] == null || Session["sDateTo"] == null)
            {
                DT = _dbProduction.funGetProductionOrderReport(pProductionId: vProductionId);
        }
            else
            {
                DT =_dbProduction.funGetProductionOrderReport(pProductionId: vProductionId, pDateFrom: vDateFrom, pDateTo: vDateTo);
            }



    string vFullPath = Server.MapPath("~/Reports") + "//ProductionOrderReport.rpt";
            ClsReport.Printreport(DT, vFullPath);
        }
      
              public ActionResult ProductionOrderReport(int? pProductionId = null, DateTime? pDateFrom = null, DateTime? pDateTo = null)
        {

            //ViewBag.vbCostCenter = pGLVoucherId;
            //Session["SCostCenter"] = ViewBag.vbCostCenter;
            Session["sProductionId"] = pProductionId;
            Session["sDateFrom"] = pDateFrom;
            Session["sDateTo"] = pDateTo;
            return View();
        }
        public void ShowSimpleProductionContentReport()
        {
            int vProductionId = 0;
            DateTime? vDateFrom = DateTime.Now;
            DateTime? vDateTo = DateTime.Now;
            DataTable DT;

            vProductionId = Convert.ToInt32(Session["sCProductionId"].ToString());
            vDateFrom = Convert.ToDateTime(Session["sCDateFrom"]);
            vDateTo = Convert.ToDateTime(Session["sCDateTo"]);
            if (Session["sCDateFrom"] == null || Session["sCDateTo"] == null)
            {
                DT = _dbProduction.funGetProductionContentReport(pProductionId: vProductionId);
            }
            else
            {
                DT = _dbProduction.funGetProductionContentReport(pProductionId: vProductionId, pDateFrom: vDateFrom, pDateTo: vDateTo);
            }



            string vFullPath = Server.MapPath("~/Reports") + "//ProductionContentReport.rpt";
            ClsReport.Printreport(DT, vFullPath);
        }

        public ActionResult ProductionContentReport(int? pProductionId = null, DateTime? pDateFrom = null, DateTime? pDateTo = null)
        {

            //ViewBag.vbCostCenter = pGLVoucherId;
            //Session["SCostCenter"] = ViewBag.vbCostCenter;
            Session["sCProductionId"] = pProductionId;
            Session["sCDateFrom"] = pDateFrom;
            Session["sCDateTo"] = pDateTo;
            return View();
        }


        public void ShowSimpleProductionOutReport()
        {
            int vProductionId = 0;
            DateTime? vDateFrom = DateTime.Now;
            DateTime? vDateTo = DateTime.Now;
            DataTable DT;

            vProductionId = Convert.ToInt32(Session["sOProductionId"].ToString());
            vDateFrom = Convert.ToDateTime(Session["sODateFrom"]);
            vDateTo = Convert.ToDateTime(Session["sODateTo"]);
            if (Session["sODateFrom"] == null || Session["sODateTo"] == null)
            {
                DT = _dbProduction.funGetProductionOutReport(pProductionId: vProductionId);
            }
            else
            {
                DT = _dbProduction.funGetProductionOutReport(pProductionId: vProductionId, pDateFrom: vDateFrom, pDateTo: vDateTo);
            }



            string vFullPath = Server.MapPath("~/Reports") + "//ProductionOutReport.rpt";
            ClsReport.Printreport(DT, vFullPath);
        }


        public ActionResult ProductionOutReport(int? pProductionId = null, DateTime? pDateFrom = null, DateTime? pDateTo = null)
        {

          
            Session["sOProductionId"] = pProductionId;
            Session["sODateFrom"] = pDateFrom;
            Session["sODateTo"] = pDateTo;
            return View();
        }


        public JsonResult funAddQtyBulk(ICollection<InvoiceDtl> InvoiceDtls, int? InvId,int? InvType,int? StoreId,DateTime? InvDate,int? UserId = null, int? BranchId = null)
        {
            return Json(_dbProduction.AddQtyBulk(InvoiceDtls, InvId,InvType,StoreId, InvDate,UserId ,  BranchId ));
        }

        public JsonResult funRemoveQtyBulk(ICollection<InvoiceDtl> InvoiceDtls, int? InvId, int? InvType, int? StoreId, DateTime? InvDate, int? UserId = null, int? BranchId = null)
        {
            return Json(_dbProduction.RemoveQtyBulk(InvoiceDtls, InvId, InvType, StoreId, InvDate, UserId, BranchId));
        }

        [HttpPost]
        public JsonResult InsertProductionTransInsertBulk(ICollection<Production> ProductionDtl, int? ProductionId)
        {

            return Json(_dbProduction.ProductionBulk(ProductionDtl, ProductionId));

        }

    }
}