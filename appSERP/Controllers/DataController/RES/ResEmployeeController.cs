using appSERP.appCode.dbCode.RES;
using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.GD.Abstract;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.appCode.Setting.ReportSetting;
using appSERP.Logger;
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
    public class ResEmployeeController : Controller
    {
        private ILog _ILog;
        private IdbResEmployee _dbResEmployee;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;

        public ResEmployeeController(ILog log, IdbResEmployee dbResEmployee, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _ILog = log;
            _dbResEmployee = dbResEmployee;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            _ILog.LogException(filterContext.Exception.ToString());
            filterContext.ExceptionHandled = true;
            this.View("Error").ExecuteResult(this.ControllerContext);
        }
        // GET: ResEmployee
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            return View();
        }
        public string GetResEmployee(bool? pResEmployeeIsActive = null)
        {
            string vAPIPath = "/APIResEmployee/ResEmployeeGET?pResEmployeeIsActive=" + pResEmployeeIsActive + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + 400;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetResEmployeeById(int? pResEmployeeId = null, bool? pResEmployeeIsActive = null)
        {
            string vAPIPath = "/APIResEmployee/ResEmployeeGET?pResEmployeeId=" + pResEmployeeId + "&&pResEmployeeIsActive=" + pResEmployeeIsActive + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + 400;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        } 
        public string GetResEmployeeByUserId(int? UserId = null )
        {
            string vAPIPath = "/APIResEmployee/ResEmployeeGET?UserId=" + UserId + "&&pQueryTypeId=" + 408;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetFirstEmp(bool? pResEmployeeIsActive = null)
        {
            string vAPIPath = "/APIResEmployee/ResEmployeeGET?pResEmployeeIsActive=" + pResEmployeeIsActive + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + 402;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetLastEmp(bool? pResEmployeeIsActive = null)
        {
            string vAPIPath = "/APIResEmployee/ResEmployeeGET?pResEmployeeIsActive=" + pResEmployeeIsActive + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + 403;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetPreviousEmp(int? pResEmployeeId = null,bool? pResEmployeeIsActive = null)
        {
            string vAPIPath = "/APIResEmployee/ResEmployeeGET?pResEmployeeId=" + pResEmployeeId + "&&pResEmployeeIsActive=" + pResEmployeeIsActive + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + 404;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetNextEmp(int? pResEmployeeId = null, bool? pResEmployeeIsActive = null)
        {
            string vAPIPath = "/APIResEmployee/ResEmployeeGET?pResEmployeeId=" + pResEmployeeId + "&&pResEmployeeIsActive=" + pResEmployeeIsActive + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + 405;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }

        public string SaveEmp(int? pResEmployeeId = null,string pResEmployeeCode = null,
            int? Credit = null,
            string pResEmployeeNameL1 = null,string pResEmployeeNameL2 = null,     DateTime? pHireDate = null,    int? pDeptSeq = null, int? pEmpStatusId = null, DateTime? pExitDate = null,  string pAddress = null,DateTime? pBirthDate = null, string pMobile = null,     int? pGender = null,  int? pIdentityTypeId = null, int? pIdentityNumber = null, DateTime? pIdentityDate = null,    int? pNationalityId = null,  decimal? pDeliveryValue = null,int? pValueTypeId = null,  decimal? pPercentageRange = null,    int? pExitTypeId = null,     string pExitReason = null,  bool? pResEmployeeIsActive = null)
        {
            
            string vAPIPath = "/APIResEmployee/ResEmployeeGET?pResEmployeeId=" + pResEmployeeId + "&&pResEmployeeCode="+ pResEmployeeCode +
                "&&Credit=" + Credit +
                "&&pResEmployeeNameL1=" + pResEmployeeNameL1+ "&&pResEmployeeNameL2="+ pResEmployeeNameL1 + "&&pHireDate="+ Convert.ToDateTime(pIdentityDate).ToString("yyyy-MM-dd") 
                + "&&pDeptSeq="+ pDeptSeq+ "&&pEmpStatusId="+ pEmpStatusId + "&&pExitDate=" + Convert.ToDateTime(pExitDate).ToString("yyyy-MM-dd")
                + "&&pAddress="+ pAddress + "&&pBirthDate="+ Convert.ToDateTime(pBirthDate).ToString("yyyy-MM-dd") + "&&pMobile=" + pMobile+ "&&pGender="+ pGender+ "&&pIdentityTypeId="+ pIdentityTypeId+ "&&pIdentityNumber="+ pIdentityNumber
                + "&&pIdentityDate="+ Convert.ToDateTime(pIdentityDate).ToString("yyyy-MM-dd") 
                +"&&pNationalityId="+ pNationalityId + "&&pDeliveryValue="+pDeliveryValue+ "&&pValueTypeId="+ pValueTypeId
                + "&&pPercentageRange="+ pPercentageRange+ "&&pExitTypeId="+ pExitTypeId+ "&&pExitReason="+ pExitReason
                + "&&pResEmployeeIsActive=" + pResEmployeeIsActive + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + 100;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string DeleteEmp(int? pResEmployeeId = null, bool? pResEmployeeIsActive = null)
        {

            string vAPIPath = "/APIResEmployee/ResEmployeeGET?pResEmployeeId=" + pResEmployeeId + "&&pResEmployeeIsActive=" + pResEmployeeIsActive + "&&pIsDeleted=" + true + "&&pQueryTypeId=" + 300;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public ActionResult SearchIdentityType()
        {
            return View();
        }
        public ActionResult SearchNationality()
        {
            return View();
        }
        public ActionResult SearchEmpStatus()
        {
            return View();
        }
        public ActionResult SearchValueType()
        {
            return View();
        }
        public ActionResult SearchExitType()
        {
            return View();
        }
        public string GetIdentityType(int? pCodeId = null)
        {
            string vAPIPath = "/APIIdentityType/IdentityTypeGET?pCodeId=" + pCodeId + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + 400;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetNationality(int? pCodeId = null)
        {
            string vAPIPath = "/APINationality/NationalityGET?pCodeId=" + pCodeId + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + 400;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetEmpStatus(int? pCodeId = null)
        {
            string vAPIPath = "/APIEmpStatus/EmpStatusGET?pCodeId=" + pCodeId + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + 400;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetValueType(int? pCodeId = null)
        {
            string vAPIPath = "/APIValueType/ValueTypeGET?pCodeId=" + pCodeId + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + 400;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetExitType(int? pCodeId = null)
        {
            string vAPIPath = "/APIExitType/ExitTypeGET?pCodeId=" + pCodeId + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + 400;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public ActionResult ResEmployeeSearch()
        {
            return View();
        }
        public ActionResult SearchResEmployeeModal()
        {
            return View();
        }
        public ActionResult SearchCredit()
        {
            return View();
        }
        public string GetResEmployeeByCode(string pResEmployeeCode = null)
        {
            string vAPIPath = "/APIResEmployee/ResEmployeeGET?pResEmployeeCode=" + pResEmployeeCode + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + 401;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string SearchResEmployeeById(int? pResEmployeeId = null, bool? pResEmployeeIsActive = null)
        {
            string vAPIPath = "/APIResEmployee/ResEmployeeGET?pResEmployeeId=" + pResEmployeeId + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + 401;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetSelectLists()
        {
            string vAPIPath = "/APIResEmployee/ResEmployeeGET?pQueryTypeId=" + 407;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
     
        public String FilterEmp(string pResEmployeeCode = null, string pLstNationality = null, string pLstIdentityType = null,   string pLstEmpStatus = null, string pLstValueType = null,string pLstExitType = null,string pMobile = null)
        {
            string vAPIPath = "/APIResEmployee/ResEmployeeGET?pResEmployeeCode=" + pResEmployeeCode + "&&pLstNationality=" + pLstNationality + "&&pLstIdentityType=" + pLstIdentityType + "&&pLstEmpStatus=" + pLstEmpStatus + "&&pLstValueType=" + pLstValueType + "&&pLstExitType=" + pLstExitType + "&&pMobile=" + pMobile + "&&pQueryTypeId=" + 408;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public String GetAllEmp(bool? pResEmployeeIsActive = null)
        {
            string vAPIPath = "/APIResEmployee/ResEmployeeGET?pResEmployeeIsActive=" + pResEmployeeIsActive + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + 409;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public void ShowSimple()
        {

            //int vCompany = Convert.ToInt32(Session["SCompany"]);
            DataTable DT = _dbResEmployee.funGetResEmployeeReport();
            string vReportPath = Server.MapPath("~/Reports") + "//ResEmployeeReport.rpt";
            ClsReport.Printreport(DT, vReportPath);


        }
        public ActionResult ResEmployeeReport(int? pCompanyId = null)
        {
            //ViewBag.vbCompanyId = pCompanyId;
            //Session["SCompany"] = ViewBag.vbCompanyId;
            return View();
        }
        public String CheckMobile(string pMobile = null)
        {
            string vAPIPath = "/APIResEmployee/ResEmployeeGET?pMobile=" + pMobile + "&&pQueryTypeId=" + 410;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }



    }
}