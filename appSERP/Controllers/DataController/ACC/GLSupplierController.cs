using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.GD.Abstract;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataController.ACC
{
    [NoDirectAccess]
    [Authorize]
    public class GLSupplierController : Controller
    {
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public GLSupplierController(IclsAPI clsAPI, IDevCompanySetting devCompanySetting)
        {
            _clsAPI = clsAPI;
            _DevCompanySetting = devCompanySetting;
        }

        // GET: GLSupplier
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            return View();
        }
        public string GetMasterAndDetails(string id = "1", int? pCustomerId = null)
        {
            string vAPIPath;

            vAPIPath = "/APIGLCustomer/GLCustomerGET?pCustomerId=" + pCustomerId+ "&&pIsCustomer="+ false + "&&pQueryTypeId=" + clsQueryType.qSelect;




            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);
            //DataTable vDtData = JsonConvert.DeserializeObject<DataTable>(vJSONResult);
            //ViewBag.vbData = vDtData;
            return vJSONResult;


        }
        public string GetFirst(string id = "1", bool? pIsCustomer = null)
        {
            string vAPIPath;

            vAPIPath = "/APIGLCustomer/GLCustomerGET?pIsCustomer=" + pIsCustomer + "&&pQueryTypeId=" + 401;




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


        public string SaveHeader(int? pCustomerId = null, string pCustomerCode = null, string pCustomerNameL1 = null, string pCustomerNameL2 = null, string pCustomerAddress = null, string pCustomerPhoneNumber = null, string pCustomerPostBox = null, 
            string pCustomerFax = null,
            string pCustomerEmail = null, string pAuthorizePerson = null, 
            int? pCustomerTypeId = null, int? pSalesId = null, int? pSellCostTypeId = null, 
            int? pCustomerDailyStopType = null, int? pCustomerDailyDay = null, int? pAreaId = null,
            int? pStatus = null, string pAuthorizePersonTel = null, int? pCustomerParentId = null, 
            int? pCountryId = null, int? pCityId = null, decimal? pCustomerAmountLimit = null, 
            int? pAccountId = null, int? pCategoryId = null, int? pIsParent = null, 
            int? pTypeId = null,
            bool? pIsBlackList = null,
            string pNotes = null,
           string pCustomerVATCode = null,
           int? pQueryTypeId=100)
        {
            string vAPIPath = "/APIGLCustomer/GLCustomerGET?pCustomerId=" + pCustomerId + "&&pCustomerCode=" + pCustomerCode + "&&pCustomerNameL1=" + pCustomerNameL1 + "&&pCustomerNameL2=" + pCustomerNameL2 + "&&pCustomerAddress=" + pCustomerAddress + "&&pCustomerPhoneNumber=" + pCustomerPhoneNumber + "&&pCustomerPostBox=" + pCustomerPostBox + "&&pCustomerFax=" + pCustomerFax + "&&pCustomerEmail=" + pCustomerEmail + "&&pAuthorizePerson=" + pAuthorizePerson + "&&pCustomerTypeId=" + pCustomerTypeId + "&&pSalesId=" + pSalesId + "&&pSellCostTypeId=" + pSellCostTypeId + "&&pCustomerDailyStopType=" + pCustomerDailyStopType + "&&pCustomerDailyDay=" + pCustomerDailyDay + "&&pAreaId=" + pAreaId + "&&pStatus=" + pStatus + "&&pAuthorizePersonTel=" + pAuthorizePersonTel + "&&pCustomerParentId=" + pCustomerParentId + "&&pCountryId=" + pCountryId + "&&pCityId=" + pCityId + "&&pCustomerAmountLimit=" + pCustomerAmountLimit + "&&pAccountId=" + pAccountId + "&&pCategoryId=" + pCategoryId + "&&pIsParent=" + pIsParent + "&&pTypeId=" + pTypeId + "&&pIsCustomer=" + false + "&&pCustomerIsActive=" + true + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + pQueryTypeId;
            string vParamters =
                "&pIsBlackList=" + pIsBlackList + "&&pCustomerVATCode=" + pCustomerVATCode +
                "&pNotes=" + pNotes;

            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath+ vParamters);

            return vJSONResult;
        }
        public string SaveDTL(int? pCustomerId = null, string pCustomerCode = null, string pCustomerNameL1 = null, string pCustomerNameL2 = null, string pCustomerAddress = null, string pCustomerPhoneNumber = null, string pCustomerPostBox = null, string pCustomerFax = null, string pCustomerEmail = null, string pAuthorizePerson = null, int? pCustomerTypeId = null, int? pSalesId = null, int? pSellCostTypeId = null, int? pCustomerDailyStopType = null, int? pCustomerDailyDay = null, int? pAreaId = null, int? pStatus = null, string pAuthorizePersonTel = null, int? pCustomerParentId = null, int? pCountryId = null, int? pCityId = null, decimal? pCustomerAmountLimit = null, int? pAccountId = null, int? pCategoryId = null, int? pIsParent = null)
        {
            string vAPIPath = "/APIGLCustomer/GLCustomerGET?pCustomerId=" + pCustomerId + "&&pCustomerCode=" + pCustomerCode + "&&pCustomerNameL1=" + pCustomerNameL1 + "&&pCustomerNameL2=" + pCustomerNameL2 + "&&pCustomerAddress=" + pCustomerAddress + "&&pCustomerPhoneNumber=" + pCustomerPhoneNumber + "&&pCustomerPostBox=" + pCustomerPostBox + "&&pCustomerFax=" + pCustomerFax + "&&pCustomerEmail=" + pCustomerEmail + "&&pAuthorizePerson=" + pAuthorizePerson + "&&pCustomerTypeId=" + pCustomerTypeId + "&&pSalesId=" + pSalesId + "&&pSellCostTypeId=" + pSellCostTypeId + "&&pCustomerDailyStopType=" + pCustomerDailyStopType + "&&pCustomerDailyDay=" + pCustomerDailyDay + "&&pAreaId=" + pAreaId + "&&pStatus=" + pStatus + "&&pAuthorizePersonTel=" + pAuthorizePersonTel + "&&pCustomerParentId=" + pCustomerParentId + "&&pCountryId=" + pCountryId + "&&pCityId=" + pCityId + "&&pCustomerAmountLimit=" + pCustomerAmountLimit + "&&pAccountId=" + pAccountId + "&&pCategoryId=" + pCategoryId + "&&pIsParent=" + pIsParent + "&&pIsCustomer=" + false + "&&pCustomerIsActive=" + false + "&&pIsDeleted=" + false + "&&pQueryTypeId=" + 100;
            //string vAPIPath = "/APIGLCustomer/GLCustomerGET?pCustomerId=" + pCustomerId + "&&pCustomerCode=" + pCustomerCode + "&&pCustomerNameL1=" + pCustomerNameL1 + "&&pCustomerNameL2=" + pCustomerNameL2 + "&&pCustomerAddress=" + pCustomerAddress + "&&pCustomerPhoneNumber=" + pCustomerPhoneNumber + "&&pCustomerPostBox=" + pCustomerPostBox + "&&pCustomerFax=" + pCustomerFax + "&&pCustomerEmail=" + pCustomerEmail + "&&pAuthorizePerson=" + pAuthorizePerson + "&&pCustomerTypeId=" + pCustomerTypeId + "&&pSalesId=" + pSalesId + "&&pSellCostTypeId=" + pSellCostTypeId + "&&pCustomerDailyStopType=" + pCustomerDailyStopType + "&&pCustomerDailyDay=" + pCustomerDailyDay + "&&pAreaId=" + pAreaId + "&&pStatus=" + pStatus + "&&pAuthorizePersonTel=" + pAuthorizePersonTel + "&&pCustomerParentId=" + pCustomerParentId + "&&pCountryId=" + pCountryId + "&&pCityId=" + pCityId + "&&pCustomerAmountLimit=" + pCustomerAmountLimit + "&&pAccountId=" + pAccountId + "&&pQueryTypeId=" + 100;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public ActionResult SupplierSearch()
        {

            return View();
        }
    }
}