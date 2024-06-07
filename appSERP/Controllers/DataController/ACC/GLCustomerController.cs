using appSERP.appCode.dbCode.ACC;
using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.GD.Abstract;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.appCode.Setting.ReportSetting;
using appSERP.appCode.SQL.QueryType;
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
    public class GLCustomerController : Controller
    {
        private IdbGLCustomer _dbGLCustomer;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public GLCustomerController(IdbGLCustomer dbGLCustomer, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _dbGLCustomer = dbGLCustomer;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }

        // GET: GLCustomer
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            return View();
        }
        public string GetMasterAndDetails(string id = "1", int? pCustomerId = null)
        {
            string vAPIPath;

            vAPIPath = "/APIGLCustomer/GLCustomerGET?pCustomerId=" + pCustomerId + "&&pIsCustomer=" + true + "&&pQueryTypeId=" + clsQueryType.qSelect;




            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            //DataTable vDtData = JsonConvert.DeserializeObject<DataTable>(vJSONResult);
            //ViewBag.vbData = vDtData;
            return vJSONResult;


        }
        public string CheckPhone(string id = "1", string pCustomerPhoneNumber = null)
        {
            string vAPIPath;

            vAPIPath = "/APIGLCustomer/GLCustomerGET?pCustomerPhoneNumber=" + pCustomerPhoneNumber + "&&pIsCustomer=" + true + "&&pQueryTypeId=" + 411;




            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            //DataTable vDtData = JsonConvert.DeserializeObject<DataTable>(vJSONResult);
            //ViewBag.vbData = vDtData;
            return vJSONResult;


        }
        public string GetFirst(string id = "1", bool? pIsCustomer = null )
        {
            string vAPIPath;

            vAPIPath = "/APIGLCustomer/GLCustomerGET?pIsCustomer="+ pIsCustomer + "&&pQueryTypeId=" + 401;




            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            //DataTable vDtData = JsonConvert.DeserializeObject<DataTable>(vJSONResult);
            //ViewBag.vbData = vDtData;
            return vJSONResult;


        }
        public string GetLast(string id = "1", bool? pIsCustomer = null)
        {
            string vAPIPath;

            vAPIPath = "/APIGLCustomer/GLCustomerGET?pIsCustomer=" + pIsCustomer + "&&pQueryTypeId=" + 402;




            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            //DataTable vDtData = JsonConvert.DeserializeObject<DataTable>(vJSONResult);
            //ViewBag.vbData = vDtData;
            return vJSONResult;


        }
        public string GetPrevious(string id = "1", int? pCustomerId = null, bool? pIsCustomer = null)
        {
            string vAPIPath;

            vAPIPath = "/APIGLCustomer/GLCustomerGET?pIsCustomer=" + pIsCustomer + "&&pCustomerId=" + pCustomerId + "&&pQueryTypeId=" + 403;




            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            //DataTable vDtData = JsonConvert.DeserializeObject<DataTable>(vJSONResult);
            //ViewBag.vbData = vDtData;
            return vJSONResult;


        }
        public string GetNext(string id = "1", int? pCustomerId = null, bool? pIsCustomer = null)
        {
            string vAPIPath;

            vAPIPath = "/APIGLCustomer/GLCustomerGET?pIsCustomer=" + pIsCustomer + "&&pCustomerId=" + pCustomerId + "&&pQueryTypeId=" + 404;
            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            //DataTable vDtData = JsonConvert.DeserializeObject<DataTable>(vJSONResult);
            //ViewBag.vbData = vDtData;
            return vJSONResult;


        }
       
            
        public string SaveHeader(int? pCustomerId = null,
            
            string pCustomerCode = null,string pCustomerNameL1 = null,string pCustomerNameL2 = null,string pCustomerAddress = null,string pCustomerPhoneNumber = null, string pCustomerTaxNumber = null, string pCustomerPostBox = null,string  pCustomerFax = null,string pCustomerEmail = null,string pAuthorizePerson = null,int? pCustomerTypeId = null,int? pSalesId = null,int? pSellCostTypeId = null,int? pCustomerDailyStopType = null,int? pCustomerDailyDay = null,int? pAreaId = null,int? pStatus = null,string pAuthorizePersonTel = null,int? pCustomerParentId = null,int? pCountryId = null,int? pCityId = null,decimal? pCustomerAmountLimit = null,int? pAccountId = null, int? pCategoryId = null,
           string pCustomerVATCode = null,
            int? pIsParent = null, int? pTypeId = null,
            int? pDelivaryCompanyType = null,
           float? pDelivaryCompanyValue = null
            )
        {
            string vAPIPath = "/APIGLCustomer/GLCustomerGET?pCustomerId=" + pCustomerId + "&&pCustomerCode=" + pCustomerCode + "&&pCustomerNameL1=" + pCustomerNameL1+ "&&pCustomerNameL2="+ pCustomerNameL2 + "&&pCustomerAddress="+ pCustomerAddress+ "&&pCustomerPhoneNumber="+ pCustomerPhoneNumber+ 
"&&pCustomerTaxNumber=" + pCustomerTaxNumber + "&&pCustomerPostBox=" + pCustomerPostBox+ "&&pCustomerFax="+ pCustomerFax+ "&&pCustomerEmail="+ pCustomerEmail+ "&&pAuthorizePerson="+ pAuthorizePerson+ "&&pCustomerTypeId="+ pCustomerTypeId+ "&&pSalesId="+ pSalesId+ "&&pSellCostTypeId="+ pSellCostTypeId+ "&&pCustomerDailyStopType="+ pCustomerDailyStopType+ "&&pCustomerDailyDay="+ pCustomerDailyDay+ "&&pAreaId="+ pAreaId+ "&&pStatus="+ pStatus+ "&&pAuthorizePersonTel="+ pAuthorizePersonTel+ "&&pCustomerParentId="+ pCustomerParentId+ "&&pCountryId="+ pCountryId + "&&pCityId="+ pCityId+ "&&pCustomerAmountLimit="+ pCustomerAmountLimit+ "&&pAccountId="+ pAccountId+ "&&pCategoryId=" + pCategoryId + "&&pCustomerVATCode=" + pCustomerVATCode + "&&pIsParent=" + pIsParent+ "&&pTypeId=" + pTypeId+"&&pIsCustomer="+true+ "&&pCustomerIsActive=" +true+"&&pIsDeleted="+false+"&&pQueryTypeId=" + 100 + "&&pDelivaryCompanyType=" + pDelivaryCompanyType + "&&pDelivaryCompanyValue=" + pDelivaryCompanyValue;
         
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }


        public string SavePOSHeader(int? pCustomerId = null, string pCustomerCode = null, string pCustomerNameL1 = null, string pCustomerNameL2 = null, string pCustomerAddress = null, string pCustomerTaxNumber = null, string pCustomerPhoneNumber = null, string pCustomerPostBox = null, string pCustomerFax = null, string pCustomerEmail = null, string pAuthorizePerson = null, int? pCustomerTypeId = null, int? pSalesId = null, int? pSellCostTypeId = null, int? pCustomerDailyStopType = null, int? pCustomerDailyDay = null, int? pAreaId = null, int? pStatus = null, string pAuthorizePersonTel = null, int? pCustomerParentId = null, int? pCountryId = null, int? pCityId = null, decimal? pCustomerAmountLimit = null, int? pAccountId = null, int? pCategoryId = null, int? pIsParent = null, int? pTypeId = null,
            int? pDelivaryCompanyType = null,
           float? pDelivaryCompanyValue = null)
        {
            string vAPIPath = "/APIGLCustomer/GLCustomerGET?pCustomerId=" + pCustomerId + "&&pCustomerCode=" + pCustomerCode + "&&pCustomerNameL1=" + pCustomerNameL1 + "&&pCustomerNameL2=" + pCustomerNameL2 + "&&pCustomerAddress=" + pCustomerAddress + "&&pCustomerPhoneNumber=" + pCustomerPhoneNumber + "&&pCustomerPostBox=" + pCustomerPostBox + "&&pCustomerFax=" + pCustomerFax + "&&pCustomerEmail=" + pCustomerEmail + "&&pAuthorizePerson=" + pAuthorizePerson + "&&pCustomerTypeId=" + pCustomerTypeId + "&&pSalesId=" + pSalesId + "&&pSellCostTypeId=" + pSellCostTypeId + "&&pCustomerDailyStopType=" + pCustomerDailyStopType + "&&pCustomerDailyDay=" + pCustomerDailyDay + "&&pAreaId=" + pAreaId + "&&pStatus=" + pStatus + "&&pAuthorizePersonTel=" + pAuthorizePersonTel + "&&pCustomerParentId=" + pCustomerParentId + "&&pCountryId=" + pCountryId + "&&pCityId=" + pCityId + "&&pCustomerAmountLimit=" + pCustomerAmountLimit + "&&pAccountId=" + pAccountId + "&&pCategoryId=" + pCategoryId + "&&pIsParent=" + pIsParent + "&&pTypeId=" + pTypeId + "&&pIsCustomer=" + true + "&&pCustomerIsActive=" + true + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + 101 + "&&pDelivaryCompanyType=" + pDelivaryCompanyType + "&&pDelivaryCompanyValue=" + pDelivaryCompanyValue;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }


        public string SaveDTL(int? pCustomerId = null, string pCustomerCode = null, string pCustomerNameL1 = null, string pCustomerNameL2 = null, string pCustomerAddress = null, string pCustomerPhoneNumber = null, string pCustomerTaxNumber = null, string pCustomerPostBox = null, string pCustomerFax = null, string pCustomerEmail = null, string pAuthorizePerson = null, int? pCustomerTypeId = null, int? pSalesId = null, int? pSellCostTypeId = null, int? pCustomerDailyStopType = null, int? pCustomerDailyDay = null, int? pAreaId = null, int? pStatus = null, string pAuthorizePersonTel = null, int? pCustomerParentId = null, int? pCountryId = null, int? pCityId = null, decimal? pCustomerAmountLimit = null, int? pAccountId = null, int? pCategoryId = null, int? pIsParent = null,int? pDelivaryCompanyType = null,
           float? pDelivaryCompanyValue = null)
        {
            string vAPIPath = "/APIGLCustomer/GLCustomerGET?pCustomerId=" + pCustomerId + "&&pCustomerCode=" + pCustomerCode + "&&pCustomerNameL1=" + pCustomerNameL1 + "&&pCustomerNameL2=" + pCustomerNameL2 + "&&pCustomerAddress=" + pCustomerAddress + "&&pCustomerPhoneNumber=" + pCustomerPhoneNumber +
"&&pCustomerTaxNumber=" + pCustomerTaxNumber + 
"&&pCustomerPostBox=" + pCustomerPostBox + "&&pCustomerFax=" + pCustomerFax + "&&pCustomerEmail=" + pCustomerEmail + "&&pAuthorizePerson=" + pAuthorizePerson + "&&pCustomerTypeId=" + pCustomerTypeId + "&&pSalesId=" + pSalesId + "&&pSellCostTypeId=" + pSellCostTypeId + "&&pCustomerDailyStopType=" + pCustomerDailyStopType + "&&pCustomerDailyDay=" + pCustomerDailyDay + "&&pAreaId=" + pAreaId + "&&pStatus=" + pStatus + "&&pAuthorizePersonTel=" + pAuthorizePersonTel + "&&pCustomerParentId=" + pCustomerParentId + "&&pCountryId=" + pCountryId + "&&pCityId=" + pCityId + "&&pCustomerAmountLimit=" + pCustomerAmountLimit + "&&pAccountId=" + pAccountId + "&&pCategoryId=" + pCategoryId + "&&pIsParent=" + pIsParent+"&&pIsCustomer=" + true + "&&pCustomerIsActive=" + true + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + 100 + "&&pDelivaryCompanyType=" + pDelivaryCompanyType + "&&pDelivaryCompanyValue=" + pDelivaryCompanyValue;
            //string vAPIPath = "/APIGLCustomer/GLCustomerGET?pCustomerId=" + pCustomerId + "&&pCustomerCode=" + pCustomerCode + "&&pCustomerNameL1=" + pCustomerNameL1 + "&&pCustomerNameL2=" + pCustomerNameL2 + "&&pCustomerAddress=" + pCustomerAddress + "&&pCustomerPhoneNumber=" + pCustomerPhoneNumber + "&&pCustomerPostBox=" + pCustomerPostBox + "&&pCustomerFax=" + pCustomerFax + "&&pCustomerEmail=" + pCustomerEmail + "&&pAuthorizePerson=" + pAuthorizePerson + "&&pCustomerTypeId=" + pCustomerTypeId + "&&pSalesId=" + pSalesId + "&&pSellCostTypeId=" + pSellCostTypeId + "&&pCustomerDailyStopType=" + pCustomerDailyStopType + "&&pCustomerDailyDay=" + pCustomerDailyDay + "&&pAreaId=" + pAreaId + "&&pStatus=" + pStatus + "&&pAuthorizePersonTel=" + pAuthorizePersonTel + "&&pCustomerParentId=" + pCustomerParentId + "&&pCountryId=" + pCountryId + "&&pCityId=" + pCityId + "&&pCustomerAmountLimit=" + pCustomerAmountLimit + "&&pAccountId=" + pAccountId + "&&pQueryTypeId=" + 100;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string SaveSite(int? pCustomerSiteId = null, string pCustomerSiteCode = null, string pCustomerSiteNameL1 = null, string pCustomerSiteNameL2 = null,int? pCustomerId = null, int? pSiteId = null)
        {
            string vAPIPath = "/APICustomerSite/CustomerSiteGET?pCustomerSiteId=" + pCustomerSiteId + "&&pCustomerSiteCode=" + pCustomerSiteCode + "&&pCustomerSiteNameL1=" + pCustomerSiteNameL1 + "&&pCustomerSiteNameL2=" + pCustomerSiteNameL2 + "&&pCustomerId=" + pCustomerId +"&&pSiteId=" + pSiteId + "&&pCustomerSiteIsActive=" + true + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + 100;
         
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string SaveTel(int? pCustomerTelId = null, string pCustomerTelCode = null, string pCustomerTelNo = null, int? pCustomerId = null)
        {
            string vAPIPath = "/APICustomerTel/CustomerTelGET?pCustomerTelId=" + pCustomerTelId + "&&pCustomerTelCode=" + pCustomerTelCode + "&&pCustomerTelNo=" + pCustomerTelNo + "&&pCustomerId=" + pCustomerId  +"&&pCustomerTelIsActive=" + true + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + 100;

            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string DeleteSite(int? pCustomerSiteId = null)
        {
            string vAPIPath = "/APICustomerSite/CustomerSiteGET?pCustomerSiteId=" + pCustomerSiteId + "&&pIsDeleted=" + true + "&&pQueryTypeId=" + 300;

            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string DeleteTel(int? pCustomerTelId = null)
        {
            string vAPIPath = "/APICustomerTel/CustomerTelGET?pCustomerTelId=" + pCustomerTelId + "&&pIsDeleted=" + true + "&&pQueryTypeId=" + 100;

            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetCountry(string pCountryId = null)
        {
            string vAPIPath = "/APICountry/CountryGET?pCountryCode=" + pCountryId +"&&pQueryTypeId=" + clsQueryType.qSelect;
           
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetCity(string pCityId = null)
        {
            string vAPIPath = "/APICity/CityGET?pCityCode=" + pCityId + "&&pQueryTypeId=" + clsQueryType.qSelect;

            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetArea(string pAreaId = null)
        {
            string vAPIPath = "/APIArea/AreaGET?pAreaCode=" + pAreaId + "&&pQueryTypeId=" + clsQueryType.qSelect;

            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetAccount(string pAccountId = null)
        {
            //string vAPIPath = "/APIAccount/AccountGET?pAccountNo=" + pAccountId + "&&pQueryTypeId=" + 460;
            string vAPIPath = "/APIAccount/AccountGET?pAccountNo=" + pAccountId + "&&pQueryTypeId=" + 511;

            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetSupplier(string pSupplierId = null)
        {
            string vAPIPath = "/APICustomerSupplier/CustomerSupplierGET?pCSCode=" + pSupplierId + "&&pCSIsCustomer=" + false +"&&pQueryTypeId=" + +clsQueryType.qSelect;

            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
 
        public string GetSellCostType(string pSellCostTypeId = null)
        {
            string vAPIPath = "/APISellCostType/SellCostTypeGET?pSellCostTypeCode=" + pSellCostTypeId + "&&pQueryTypeId=" + +clsQueryType.qSelect;

            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetCustomerCategory(string pCustomerCategoryId = null)
        {
            string vAPIPath = "/APICustomerCategory/CustomerCategoryGET?pCustomerCategoryCode=" + pCustomerCategoryId + "&&pQueryTypeId=" + +clsQueryType.qSelect;

            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string DeleteCustomerDTL(int? pCustomerId = null)
        {
            string vAPIPath = "/APIGLCustomer/GLCustomerGET?pCustomerId=" + pCustomerId + "&&pIsDeleted=" + true + "&&pQueryTypeId=" + 300;
            //string vAPIPath = "/APIGLCustomer/GLCustomerGET?pCustomerId=" + pCustomerId + "&&pCustomerCode=" + pCustomerCode + "&&pCustomerNameL1=" + pCustomerNameL1 + "&&pCustomerNameL2=" + pCustomerNameL2 + "&&pCustomerAddress=" + pCustomerAddress + "&&pCustomerPhoneNumber=" + pCustomerPhoneNumber + "&&pCustomerPostBox=" + pCustomerPostBox + "&&pCustomerFax=" + pCustomerFax + "&&pCustomerEmail=" + pCustomerEmail + "&&pAuthorizePerson=" + pAuthorizePerson + "&&pCustomerTypeId=" + pCustomerTypeId + "&&pSalesId=" + pSalesId + "&&pSellCostTypeId=" + pSellCostTypeId + "&&pCustomerDailyStopType=" + pCustomerDailyStopType + "&&pCustomerDailyDay=" + pCustomerDailyDay + "&&pAreaId=" + pAreaId + "&&pStatus=" + pStatus + "&&pAuthorizePersonTel=" + pAuthorizePersonTel + "&&pCustomerParentId=" + pCustomerParentId + "&&pCountryId=" + pCountryId + "&&pCityId=" + pCityId + "&&pCustomerAmountLimit=" + pCustomerAmountLimit + "&&pAccountId=" + pAccountId + "&&pQueryTypeId=" + 100;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string DeleteCustomer(int? pCustomerId = null)
        {
            string vAPIPath = "/APIGLCustomer/GLCustomerGET?pCustomerId=" + pCustomerId + "&&pIsDeleted=" + true + "&&pQueryTypeId=" + 300;
          
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetCommunicationType()
        {
            string vAPIPath = "/APICommunicationType/CommunicationTypeGET?pQueryTypeId=" + +clsQueryType.qSelect;

            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public ActionResult CustomerSearch()
        {

            return View();
        }
        public ActionResult SearchCustomerModal()
        {

            return View();
        }
        public string FilterCustomers(string id = "1", int? pCustomerCode = null)
        {
            string vAPIPath;

            vAPIPath = "/APIGLCustomer/GLCustomerGET?pCustomerCode=" + pCustomerCode + "&&pQueryTypeId=" + 412;




            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            //DataTable vDtData = JsonConvert.DeserializeObject<DataTable>(vJSONResult);
            //ViewBag.vbData = vDtData;
            return vJSONResult;


        }
        public string SearchCustomerByCode(string id = "1", int? pCustomerCode = null)
        {
            string vAPIPath;

            vAPIPath = "/APIGLCustomer/GLCustomerGET?pCustomerCode=" + pCustomerCode + "&&pQueryTypeId=" + 413;
            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            return vJSONResult;


        }
        public void ShowSimple()
        {
            int vCustomerId = Convert.ToInt32(Session["CustomerId"]);
            DataTable DT = _dbGLCustomer.funGetGLCustomerReport(pCustomerId: vCustomerId);
            string vReportPath = Server.MapPath("~/Reports") + "//GLCustomerReport.rpt";
            ClsReport.Printreport(DT, vReportPath);
        }
        public ActionResult GLCustomerReport(int? pCustomerId = null)
        {
            ViewBag.vbCustomerId = pCustomerId;
            Session["CustomerId"] = ViewBag.vbCustomerId;

            return View();
        }


    }
}