using appSERP.appCode.dbCode.ACC;
using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.GD.Abstract;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.QueryType;
using appSERP.Models.ACC;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataControllers.ACC
{
    ///  AMR    21/1/2018   
    //[NoDirectAccess]
    [Authorize]
    public class AccountController : Controller
    {
        private IdbAccount _dbAccount;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public AccountController(IdbAccount dbAccount, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _dbAccount = dbAccount;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }

        // GET: Account
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";
            string cookie = "There is no cookie!";
            if (Request.Cookies.AllKeys.Contains("Cookie"))
            {
                cookie = "Yeah - Cookie: " + this.ControllerContext.HttpContext.Request.Cookies["Cookie"].Value;
            }
            ViewData["Cookie"] = cookie;
          

            // API Path
            string vPath = appAPIDirectory.vAPIAccount;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);
           if(Request.IsAjaxRequest())
            {
                return PartialView(vDtData);
            }
            return View(vDtData);
        }
        public ActionResult Account()
        {
            return View();
        }


        public ActionResult DataModel(int? id = 0)
        {
            // New Model
            AccountModel vAccountModel = new AccountModel();
            if (id == 0)
            {
            
                ViewBag.vbcCurrencyId = 0;
                ViewBag.vbcCurrencyFactorId = 0;
                ViewBag.vbcAccountTypeId = 0;
                ViewBag.vbcSecurityGradeId = 0;
                ViewBag.vbcCashFlowTypeId = 0;
            }
            // Edit Case
            if (id > 0)
            {
             
                // API Path
                string vPath = appAPIDirectory.vAPIAccount;
                string vParameters = "?pAccountId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                ViewBag.vbcCurrencyId = Convert.ToInt32(vDtData.Rows[0]["CurrencyId"].ToString());
                ViewBag.vbcCurrencyFactorId = Convert.ToInt32(vDtData.Rows[0]["CurrencyFactorId"].ToString());
                ViewBag.vbcAccountTypeId = Convert.ToInt32(vDtData.Rows[0]["AccountTypeId"].ToString());
                ViewBag.vbcSecurityGradeId = Convert.ToInt32(vDtData.Rows[0]["SecurityGradeId"].ToString());
                ViewBag.vbcCashFlowTypeId = Convert.ToInt32(vDtData.Rows[0]["CashFlowTypeId"].ToString());
                // Set Model Data
                vAccountModel.AccountId = Convert.ToInt32(vDtData.Rows[0]["AccountId"]);
                vAccountModel.AccountNo = vDtData.Rows[0]["AccountNo"].ToString();
                vAccountModel.AccountNameL1 = vDtData.Rows[0]["AccountNameL1"].ToString();
                vAccountModel.AccountNameL2 = vDtData.Rows[0]["AccountNameL2"].ToString();
                vAccountModel.AccountParentId = Convert.ToInt32(vDtData.Rows[0]["AccountParentId"]);
                vAccountModel.AccountLevel = Convert.ToInt32(vDtData.Rows[0]["AccountLevel"].ToString());
                vAccountModel.CurrencyId = Convert.ToInt32(vDtData.Rows[0]["CurrencyId"]);
                vAccountModel.CurrencyFactorId = Convert.ToInt32(vDtData.Rows[0]["CurrencyFactorId"].ToString());
                vAccountModel.SecurityGradeId = Convert.ToInt32(vDtData.Rows[0]["SecurityGradeId"]);
                vAccountModel.AccountIsDebit = Convert.ToBoolean(vDtData.Rows[0]["AccountIsDebit"].ToString());
                vAccountModel.AccountTypeId = Convert.ToInt32(vDtData.Rows[0]["AccountTypeId"]);
                vAccountModel.AccountingReportId = Convert.ToInt32(vDtData.Rows[0]["AccountingReportId"].ToString());
                vAccountModel.AccountIsCumulative = Convert.ToBoolean(vDtData.Rows[0]["AccountIsCumulative"]);
                vAccountModel.CashFlowTypeId = Convert.ToInt32(vDtData.Rows[0]["CashFlowTypeId"].ToString());
                vAccountModel.AccountIsActive = Convert.ToBoolean(vDtData.Rows[0]["AccountIsActive"]);
            }
            // Return Result
            return View(vAccountModel);
        }
        [HttpPost]
        public ActionResult DataModel(int? id = 0,  AccountModel pAccountModel = null, bool? pIsDelete = false)
        {
           

            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPIAccount;
                string vParameters =
                    "?pAccountId=" + id +
                    "&pAccountNo=" + pAccountModel.AccountNo +
                    "&pAccountNameL1=" + pAccountModel.AccountNameL1 +
                    "&pAccountNameL2= " + pAccountModel.AccountNameL2 +
                    "&pAccountTypeId= " + pAccountModel.AccountTypeId +
                    "&pAccountParentId=" + pAccountModel.AccountParentId +
                    "&pAccountLevel= " + pAccountModel.AccountLevel +
                    "&pCurrencyId= " + pAccountModel.CurrencyId +
                    "&pCurrencyFactorId=" + pAccountModel.CurrencyFactorId +
                    "&pSecurityGradeId=" + pAccountModel.SecurityGradeId +
                    "&pAccountIsDebit=" + pAccountModel.AccountIsDebit +
                    "&pAccountingReportId=" + pAccountModel.AccountingReportId +
                    "&pAccountIsCumulative=" + pAccountModel.AccountIsCumulative +
                    "&pCashFlowTypeId=" + pAccountModel.CashFlowTypeId +
                    "&pAccountIsActive=" + pAccountModel.AccountIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;

                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbAccount.vSQLResult = vDrwResult[0].ToString();
                _dbAccount.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

                if (Convert.ToBoolean(pIsDelete)) { return null; }
                else
                { // Go To Index
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        // Chart Of Account
        public ActionResult ChartAccounts(string id = null, string AccountNo = null, int? AccountLevel=null , int ParentId = 0)
        {
            // ViewBag AccountTypeId
            DataTable vDtAccountType = _clsAPI.funResultGet(appAPIDirectory.vAPIAccountType);
            ViewBag.vbAccountType = new SelectList(vDtAccountType.AsDataView(), "AccountTypeId", "AccountTypeNameL1",1);
            // ViewBag CurrencyId
            DataTable vDtCurrency = _clsAPI.funResultGet(appAPIDirectory.vAPICurrency);
            ViewBag.vbCurrency = new SelectList(vDtCurrency.AsDataView(), "CurrencyId", "CurrencyNameL1",1);
            // ViewBag SecurityGradeId
            DataTable vDtSecurityGrade = _clsAPI.funResultGet(appAPIDirectory.vAPISecurityGrade);
            ViewBag.vbSecurityGrade = new SelectList(vDtSecurityGrade.AsDataView(), "SecurityGradeId", "SecurityGradeNameL1", 1);
            // ViewBag Account
            DataTable vDtAccountReport = _clsAPI.funResultGet(appAPIDirectory.vAPIAccount+"?pQueryTypeId=450");
            ViewBag.vbAccountReport = new SelectList(vDtAccountReport.AsDataView(), "AccountReportId", "AccountReportNameL1", 1);

            ViewBag.DevCompanySetting = _DevCompanySetting;

            // Set Parent Id
            _dbAccount.vParentId = id;
            // SET Level AND Parent Id
            ViewBag.vbLevel = AccountLevel ;
            ViewBag.vParentId = ParentId;
            // API Path
            string vPath = appAPIDirectory.vAPIAccount;
            string vParamParent = "?pQueryTypeId=" + 407;
            string vParamChild = "?pQueryTypeId=" + 408 + "&pAccountNo=" + AccountNo + "&pAccountId=" + id + "&pAccountLevel=" + AccountLevel;


            if (id != "0")
            {
                //GET Account No From Parent
                string vParent = "?pQueryTypeId=" + 403 + "&pAccountId=" + id;
                DataTable vDTParent = _clsAPI.funResultGet(vPath + vParent);
                if (vDTParent.Rows.Count > 0)
                {
                    _dbAccount.vAccountNo = vDTParent.Rows[0]["AccountNo"].ToString();
                    _dbAccount.vAccountName = vDTParent.Rows[0]["AccountNameL1"].ToString();
                    _dbAccount.vAccountLevel = Convert.ToInt32(vDTParent.Rows[0]["AccountLevel"].ToString());
                    _dbAccount.vBranchId = vDTParent.Rows[0]["CompanyId"].ToString();
                    _dbAccount.vBranchName = vDTParent.Rows[0]["CompanyBranchNameL1"].ToString();

                }
            }
            if (id == "0")
            {
                vParamChild = "?pQueryTypeId=" + 407+ "&pAccountNo=" + AccountNo;
                // Get All Parents
                DataTable vDtParents = _clsAPI.funResultGet(vPath + vParamParent);
                _dbAccount.vAccountNo = vDtParents.Rows[0]["AccountNo"].ToString();
                _dbAccount.vAccountName = vDtParents.Rows[0]["AccountNameL1"].ToString();
                _dbAccount.vAccountLevel = Convert.ToInt32(vDtParents.Rows[0]["AccountLevel"].ToString());
                _dbAccount.vBranchId = vDtParents.Rows[0]["CompanyId"].ToString();
                _dbAccount.vBranchName = vDtParents.Rows[0]["CompanyBranchNameL1"].ToString();
            }
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);

           
            // Get All Childs
            DataTable vDtChilds = _clsAPI.funResultGet(vPath + vParamChild);
            ViewBag.vbChilds = vDtChilds.AsDataView();
            // Return View
            return View(vDtChilds);
        }

        [HttpPost]
        public ActionResult funSaveAccount(int? id = 0,int? AccountLevel=0 ,int? ParentId=0, AccountModel[] vAccount = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId;
            try
            {
                if (Convert.ToBoolean(pIsDelete))
                {
                    vQueryTypeId = clsQueryType.qDelete;
                    string vPath = appAPIDirectory.vAPIAccount;
                    string vParameters =
                    "?pAccountId=" + id +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;
                    // SQL Result
                    DataRow vDrwResultV = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                    _dbAccount.vSQLResult = vDrwResultV[0].ToString();
                    _dbAccount.vSQLResultTypeId = Convert.ToInt32(vDrwResultV[1]);
                }
                else
                {

                    foreach (var pAccountModel in vAccount)
                    {
                        if (ParentId == 0)
                        {
                            AccountLevel = 0;
                        }


                        int? vAccountLevel = AccountLevel + 1;
                        if (pAccountModel.AccountId > 0) { vQueryTypeId = clsQueryType.qUpdate; }
                        else { vQueryTypeId = clsQueryType.qInsert; };
                        // API Path
                        string vPath = appAPIDirectory.vAPIAccount;
                        string vParameters =
                        "?pAccountId=" + pAccountModel.AccountId +
                        "&pAccountNo=" + pAccountModel.AccountNo +
                        "&pAccountNameL1=" + pAccountModel.AccountNameL1 +
                        "&pAccountNameL2=" + pAccountModel.AccountNameL2 +
                        "&pAccountTypeId=" + pAccountModel.AccountTypeId +
                        "&pAccountParentId=" + ParentId +
                        "&pAccountLevel=" + vAccountLevel +
                        "&pCurrencyId=" + pAccountModel.CurrencyId +
                        "&pIsCostCenter=" + pAccountModel.IsCostCenter +
                        "&pCurrencyFactorId=" + pAccountModel.CurrencyFactorId +
                        "&pSecurityGradeId=" + pAccountModel.SecurityGradeId +
                        "&pAccountIsDebit=" + pAccountModel.AccountIsDebit +
                        "&pAccountingReportId=" + pAccountModel.AccountingReportId +
                        "&pAccountIsCumulative=" + pAccountModel.AccountIsCumulative +
                        "&pCashFlowTypeId=" + pAccountModel.CashFlowTypeId +
                        "&pAccountIsActive=" + pAccountModel.AccountIsActive +
                        "&pIsDeleted=" + pIsDelete +
                        "&pQueryTypeId=" + vQueryTypeId;
                        // SQL Result
                        DataRow vDrwResultV = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                        _dbAccount.vSQLResult = vDrwResultV[0].ToString();
                        _dbAccount.vSQLResultTypeId = Convert.ToInt32(vDrwResultV[1]);
                    }
                }
                // Go To Index
                 return RedirectToAction("ChartAccounts");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // Account Search
        public ActionResult SearchAccount()
        {
            return View();
        }
        // Account Search
        public ActionResult SearchAccountBranches()
        {
            return View();
        }
        public void ShowSimple()
        {
            using (ReportClass rp = new ReportClass())
            {
                int vCompany = Convert.ToInt32(Session["SCompany"]);
                DataTable DT = _dbAccount.funGetAccountReport(pCompanyId: vCompany);
                rp.FileName = Server.MapPath("~/Reports") + "//AccountReport.rpt";
                rp.Load();
                /*Get data from detatbase using Data layer via business layer*/
                rp.SetDataSource(DT);
                rp.ExportToHttpResponse(ExportFormatType.PortableDocFormat,
 System.Web.HttpContext.Current.Response, false, "crReport");
            }
        }
        public ActionResult ChartAccountReport(int? pCompanyId = null)
        {
            ViewBag.vbCompanyId = pCompanyId;
            Session["SCompany"] = ViewBag.vbCompanyId;
            return View();
        }


        // Account Search
        public ActionResult SearchAccountModal()
        {
            return View();
        }
        [HttpPost]
        public string FilterAccounts(int? id = 0, string pAccountNo = null)
        {
            string vAPIPath = appAPIDirectory.vAPIAccount;
            string vparam = "";

                vparam = "?pIsDeleted=0" + "&&pAccountNo=" + pAccountNo + "&&pQueryTypeId=" + 522;
          

            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath + vparam);

            return vJSONResult;


        }



    }
}
    
