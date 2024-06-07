using appSERP.appCode.dbCode.SYSSETT;
using appSERP.appCode.dbCode.SYSSETT.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.GSetting;
using appSERP.appCode.SQL.QueryType;
using appSERP.Models.SYSSETT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataControllers.SYSSETT
{
    //[NoDirectAccess]
    //[Authorize]
    public class CountryController : Controller
    {
        private IdbCountry _dbCountry;
        private IclsAPI _clsAPI;
        public CountryController(IdbCountry dbCountry, IclsAPI clsAPI)
        {
            _dbCountry = dbCountry;
            _clsAPI = clsAPI;
        }

        // GET: Country
        public ActionResult Index()
        {
            // API Path
            string vPath = appAPIDirectory.vAPICountry;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);
            // Return View
            if (Request.IsAjaxRequest())
            {
                return PartialView(vDtData);
            }
            return View(vDtData);


        }


        public ActionResult DataModel(int? id = 0)
        {
            // New Model
            CountryModel vCountryModel = new CountryModel();
            string vCountryTypePath = @"/APICountryType/CountryTypeGet";
            string vCountryTypeParameters = "?pCountryTypeIsActive=True";
            DataTable dtCountryType = _clsAPI.funResultGet(vCountryTypePath + vCountryTypeParameters);
            if (id == 0)
            {

                ViewBag.vbCountryTypeId = new SelectList(dtCountryType.AsDataView(), "CountryTypeId", "CountryTypeNameL1");
                ViewBag.vbcCountryTypeId = 0;
            }

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPICountry;
                string vParameters = "?pCountryId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                ViewBag.vbCountryTypeId = new SelectList(dtCountryType.AsDataView(),
               "CountryTypeId", "CountryTypeNameL1",
                vDtData.Rows[0]["CountryTypeId"].ToString());
                ViewBag.vbcCountryTypeId = Convert.ToInt32( vDtData.Rows[0]["CountryTypeId"].ToString());
                // Set Model Data
                vCountryModel.CountryId = Convert.ToInt32(vDtData.Rows[0]["CountryId"]);
                vCountryModel.CountryCode = vDtData.Rows[0]["CountryCode"].ToString();
                vCountryModel.CountryNameL1 = vDtData.Rows[0]["CountryNameL1"].ToString();
                vCountryModel.CountryNameL2 = vDtData.Rows[0]["CountryNameL2"].ToString();
                vCountryModel.CountryIsActive = Convert.ToBoolean(vDtData.Rows[0]["CountryIsActive"]);
                vCountryModel.CountryTypeId = Convert.ToInt32(vDtData.Rows[0]["CountryTypeId"]);
                vCountryModel.CountryPhoneCode = vDtData.Rows[0]["CountryPhoneCode"].ToString();
                vCountryModel.CountryNationalityNameL1 = vDtData.Rows[0]["CountryNationalityNameL1"].ToString();
                vCountryModel.CountryNationalityNameL2 = vDtData.Rows[0]["CountryNationalityNameL2"].ToString();
                vCountryModel.CountryImage = vDtData.Rows[0]["CountryImage"].ToString();


            }

            // Return Result
            return View(vCountryModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, CountryModel pCountryModel = null, bool? pIsDelete = false,
            HttpPostedFileBase pFile = null)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            // User Image
            if (pFile != null)
            {
                pCountryModel.CountryImage = clsFileSave.funFileSave(pFile, "/Image/DataImage/SYSSETT", pCountryModel.CountryImage);
            }

            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPICountry;
                string vParameters =
                    "?pCountryId=" + id +
                     "&pCountryCode=" + pCountryModel.CountryCode +
                    "&pCountryNameL1=" + pCountryModel.CountryNameL1 +
                    "&pCountryNameL2=" + pCountryModel.CountryNameL2 +
                    "&pCountryNationalityNameL1=" + pCountryModel.CountryNationalityNameL1 +
                    "&pCountryNationalityNameL2=" +pCountryModel.CountryNationalityNameL2 +
                    "&pCountryPhoneCode=" + pCountryModel.CountryPhoneCode +
                    "&pCountryTypeId=" + pCountryModel.CountryTypeId +
                    "&pCountryImage=" + pCountryModel.CountryImage +
                    "&pCountryIsActive=" + pCountryModel.CountryIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;


                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbCountry.vSQLResult = vDrwResult[0].ToString();
                _dbCountry.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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

        // Account Search
        public ActionResult SearchCountry()
        {
            return View();
        }
    }
}