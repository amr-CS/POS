using appSERP.appCode.dbCode.ACC;
using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.GD.Abstract;
using appSERP.appCode.Setting.ReportSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.QueryType;
using Newtonsoft.Json;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataController.ACC.Report
{
    public class AccountStatementReportController : Controller
    {

        private IdbGLTransaction _dbGLTransaction;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public AccountStatementReportController(IdbGLTransaction dbGLTransaction, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _dbGLTransaction = dbGLTransaction;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }
        // GET: AccountAtatementReport
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AccountStatementReport(string id = "1", int? pAccountId = null, DateTime? pDateFrom = null,DateTime? pDateTo = null)
        {
            clsUser.vUserFullName = "محمد عبد الرحمن";


            string vAPIPath = "/APIGLTransaction/GLTransactionReportGET?pAccountId=" + pAccountId + "&&pDateFrom=" + pDateFrom.Value.Date.ToString("yyyy-MM-dd") + "&&pDateTo=" + pDateTo.Value.Date.ToString("yyyy-MM-dd") + "&&pQueryTypeId="+ clsQueryType.qSelect;

            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            DataTable vDtData = JsonConvert.DeserializeObject<DataTable>(vJSONResult);
            ViewBag.vbData = vDtData;
            return View();

        }
        public string GetAccountStatementReport(string id = "1", string pAccountId = null, DateTime? pDateFrom = null, DateTime? pDateTo = null, string pAccountFrom = null , string pAccountTo = null,string pChildAccounts = null,int pQueryTypeId= 406)
        {
            string vAPIPath;
            if (pAccountFrom == null && pAccountTo == null)
            {
                if (pAccountId == "")
                {
                    vAPIPath = "/APIGLTransaction/GLTransactionReportGET?pDateFrom=" + pDateFrom.Value.Date.ToString("yyyy-MM-dd") + "&&pDateTo=" + pDateTo.Value.Date.ToString("yyyy-MM-dd") + "&&pChildAccounts=" + pChildAccounts + "&&pIsDeleted=0" + "&&pQueryTypeId=" + pQueryTypeId;
                }
                else
                {
                    vAPIPath = "/APIGLTransaction/GLTransactionReportGET?pAccountId=" + pAccountId + "&&pDateFrom=" + pDateFrom.Value.Date.ToString("yyyy-MM-dd") + "&&pDateTo=" + pDateTo.Value.Date.ToString("yyyy-MM-dd") + "&&pChildAccounts=" + pChildAccounts + "&&pIsDeleted=0" + "&&pQueryTypeId=" + pQueryTypeId;
                }
              
            }
            else 
            {
                vAPIPath = "/APIGLTransaction/GLTransactionReportGET?pAccountFrom=" + pAccountFrom + "&&pAccountTo="+ pAccountTo + "&&pDateFrom=" + pDateFrom.Value.Date.ToString("yyyy-MM-dd") + "&&pDateTo=" + pDateTo.Value.Date.ToString("yyyy-MM-dd") + "&&pIsDeleted=0" + "&&pQueryTypeId=" + pQueryTypeId;
            }
          

            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            //DataTable vDtData = JsonConvert.DeserializeObject<DataTable>(vJSONResult);
            //ViewBag.vbData = vDtData;
            return vJSONResult;
        

        }
        public string GetAccounts(string id = "1", DateTime? pDateFrom = null, DateTime? pDateTo = null, string pAccountFrom = null, string pAccountTo = null)
        {
           

            string vAPIPath = "/APIGLTransaction/GLTransactionReportGET?pAccountFrom=" + pAccountFrom + "&&pAccountTo=" + pAccountTo + "&&pDateFrom=" + pDateFrom.Value.Date.ToString("yyyy-MM-dd") + "&&pDateTo=" + pDateTo.Value.Date.ToString("yyyy-MM-dd") + "&&pQueryTypeId=" + 401;
        


            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            //DataTable vDtData = JsonConvert.DeserializeObject<DataTable>(vJSONResult);
            //ViewBag.vbData = vDtData;
            return vJSONResult;


        }
        public string GetAccountsChilds(string id = "1", int? pAccountParentId = null)
        {

            //string vAPIPath = "/APIAccount/AccountGET?pAccountParentId=" + pAccountParentId + "&&pQueryTypeId=" + clsQueryType.qSelect;
            string vAPIPath = "/APIGLVoucher/AccountLastChildGET?pParentId=" + pAccountParentId + "&&pQueryTypeId=" + clsQueryType.qSelect;

            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            //DataTable vDtData = JsonConvert.DeserializeObject<DataTable>(vJSONResult);
            //ViewBag.vbData = vDtData;
            return vJSONResult;


        }

        public ActionResult AccountStatement()
        {
            return View();
        }
        // GET: AccountAtatementReport
        public ActionResult AccStatementReport()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            return View();
        }
        public ActionResult PrintPDF()
        {
            // Rotativa report
           var vReport=new Rotativa.ActionAsPdf("AccStatementReport");

            // Get Result
            return vReport;
        }
        public string GetAccountsByType(int? pAccountTypeId = null , int? pAccountFrom = null, int? pAccountTo = null,int? pCostCenterId = null, int? pCustomerId = null, int? pAccountCategoryId = null)
        {
            string vAPIPath = appAPIDirectory.vAPIAccount;
            string vparam = "";
            //if (pAccountTypeId != 0)
                if (pAccountCategoryId != 0)
                {
                ////vparam = "?pIsDeleted=0" + "&&pAccountTypeId=" + pAccountTypeId + "&&pQueryTypeId=" + 470;
                //vparam = "?pIsDeleted=0" + "&&pAccountCategoryId=" + pAccountCategoryId + "&&pQueryTypeId=" + 470;
                vparam = "?pIsDeleted=0" + "&&pAccountCategoryId=" + pAccountCategoryId + "&&pQueryTypeId=" + 523;
            }
            else if (pAccountFrom != 0 && pAccountTo != 0)
            {
                vparam = "?pIsDeleted=0" + "&&pAccountFrom=" + pAccountFrom+ "&&pAccountTo=" + pAccountTo + "&&pQueryTypeId=" + 480;
            }
            else if (pCostCenterId !=0)
            {
                vparam = "?pIsDeleted=0" + "&&pCostCenterId=" + pCostCenterId + "&&pQueryTypeId=" + 490;
            }
            else if (pCustomerId != 0)
            {
                vparam = "?pIsDeleted=0" + "&&pCustomerId=" + pCustomerId + "&&pQueryTypeId=" + 470;
            }

            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath + vparam);

            return vJSONResult;

        }


        public string GetAllAccounts()
        {
            string vAPIPath = appAPIDirectory.vAPIAccount;
            string vparam = "?pQueryTypeId=" + 491;

            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath + vparam);

            return vJSONResult;
        }

        public void ShowGLReport()
        {
           
            //int vGl = Convert.ToInt32(Session["SCN"]);

            DateTime vDateFrom = Convert.ToDateTime(Session["DateFrom"]);
            DateTime vDateTo = Convert.ToDateTime(Session["DateTo"]);
            string vList = Session["List"].ToString();
            //DateTime vDateFrom2 = vDateFrom.Date.ToString("yyyy-MM-dd");


            //DataTable DT = dbGLVoucherOld.funGetGlVoucherReport(pGLVoucherId: vGl, VoucherTypeId: 5);
            DataTable DT = _dbGLTransaction.funGetGLTransactionReport(pDateFrom: vDateFrom,pDateTo: vDateTo,pChildAccounts: vList);
            string vFullPath = Server.MapPath("~/Reports") + "//GLDetailsReport.rpt";
            ClsReport.Printreport(DT, vFullPath);
        }
        //txtDocId
        public ActionResult GLReport(DateTime? pDateFrom = null, DateTime? pDateTo = null, string pChildAccounts = null )
        {

            //ViewBag.vbCNVoucherId = pGLVoucherId;

            //Session["SCN"] = ViewBag.vbCNVoucherId;
            Session["DateFrom"] =  Convert.ToDateTime( pDateFrom).Date.ToString("yyyy-MM-dd");
            Session["DateTo"] = Convert.ToDateTime(pDateTo).Date.ToString("yyyy-MM-dd");
            Session["List"] = pChildAccounts;

            return View();
        }
        public void ShowGLTotalReport()
        {

            //int vGl = Convert.ToInt32(Session["SCN"]);

            DateTime vDateFrom = Convert.ToDateTime(Session["TotalDateFrom"]);
            DateTime vDateTo = Convert.ToDateTime(Session["TotalDateTo"]);
            string vList = Session["TotalList"].ToString();
            //DateTime vDateFrom2 = vDateFrom.Date.ToString("yyyy-MM-dd");


            //DataTable DT = dbGLVoucherOld.funGetGlVoucherReport(pGLVoucherId: vGl, VoucherTypeId: 5);
            DataTable DT = _dbGLTransaction.funGetGLTransactionReportTotal(pDateFrom: vDateFrom, pDateTo: vDateTo, pChildAccounts: vList);
            string vFullPath = Server.MapPath("~/Reports") + "//GLTotalReport.rpt";
            ClsReport.Printreport(DT, vFullPath);
        }
        //txtDocId
        public ActionResult GLTotalReport(DateTime? pDateFrom = null, DateTime? pDateTo = null, string pChildAccounts = null)
        {
            Session["TotalDateFrom"] = Convert.ToDateTime(pDateFrom).Date.ToString("yyyy-MM-dd");
            Session["TotalDateTo"] = Convert.ToDateTime(pDateTo).Date.ToString("yyyy-MM-dd");
            Session["TotalList"] = pChildAccounts;

            return View();
        }

        public void ShowGLTotalCostCenterReport()
        {

            //int vGl = Convert.ToInt32(Session["SCN"]);

            DateTime vDateFrom = Convert.ToDateTime(Session["TotalCostCenterDateFrom"]);
            DateTime vDateTo = Convert.ToDateTime(Session["TotalCostCenterDateTo"]);
            string vList = Session["TotalCostCenterList"].ToString();
            //DateTime vDateFrom2 = vDateFrom.Date.ToString("yyyy-MM-dd");


            //DataTable DT = dbGLVoucherOld.funGetGlVoucherReport(pGLVoucherId: vGl, VoucherTypeId: 5);
            DataTable DT = _dbGLTransaction.funGetGLTransactionReportTotalCostCenter(pDateFrom: vDateFrom, pDateTo: vDateTo, pChildAccounts: vList);
          
            string vFullPath = Server.MapPath("~/Reports") + "//GLTotalCostGLTotalCostReportReport.rpt";
            ClsReport.Printreport(DT, vFullPath);
        }
        //txtDocId
        public ActionResult GLTotalCostCenterReport(DateTime? pDateFrom = null, DateTime? pDateTo = null, string pChildAccounts = null)
        {
            Session["TotalCostCenterDateFrom"] = Convert.ToDateTime(pDateFrom).Date.ToString("yyyy-MM-dd");
            Session["TotalCostCenterDateTo"] = Convert.ToDateTime(pDateTo).Date.ToString("yyyy-MM-dd");
            Session["TotalCostCenterList"] = pChildAccounts;

            return View();
        }
        public void ShowGLDetailsCostCenterReport()
        {

            //int vGl = Convert.ToInt32(Session["SCN"]);

            DateTime vDateFrom = Convert.ToDateTime(Session["DetailsCostCenterDateFrom"]);
            DateTime vDateTo = Convert.ToDateTime(Session["DetailsCostCenterDateTo"]);
            string vList = Session["DetailsCostCenterList"].ToString();


            DataTable DT = _dbGLTransaction.funGetGLTransactionReportDetailsCostCenter(pDateFrom: vDateFrom, pDateTo: vDateTo, pChildAccounts: vList);

            string vFullPath = Server.MapPath("~/Reports") + "//GLDetailsCostCenterReport.rpt";
            ClsReport.Printreport(DT, vFullPath);
        }
        //txtDocId  
        public ActionResult GLDetailsCostCenterReport(DateTime? pDateFrom = null, DateTime? pDateTo = null, string pChildAccounts = null)
        {
            Session["DetailsCostCenterDateFrom"] = Convert.ToDateTime(pDateFrom).Date.ToString("yyyy-MM-dd");
            Session["DetailsCostCenterDateTo"] = Convert.ToDateTime(pDateTo).Date.ToString("yyyy-MM-dd");
            Session["DetailsCostCenterList"] = pChildAccounts;

            return View();
        }


    }
}