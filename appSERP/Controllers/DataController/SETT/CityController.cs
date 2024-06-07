using appSERP.appCode.dbCode.SETT;
using appSERP.appCode.dbCode.SETT.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.SQL.QueryType;
using appSERP.Models.SETT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataControllers.SETT
{
    //[NoDirectAccess]
    //[Authorize]
    public class CityController : Controller
    {
        private IdbCity _dbCity;
        private IclsAPI _clsAPI;
        public CityController(IdbCity dbCity, IclsAPI clsAPI)
        {
            _dbCity = dbCity;
            _clsAPI = clsAPI;
        }

        // GET: City
        public ActionResult Index()
        {
            // API Path
            string vPath = appAPIDirectory.vAPICity;
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
            CityModel vCityModel = new CityModel();
            if (id == 0)
            {
                ViewBag.vbcCountryId = 0;
            }

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPICity;
                string vParameters = "?pCityId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                ViewBag.vbcCountryId = Convert.ToInt32(vDtData.Rows[0]["CountryId"]);
                // Set Model Data
                vCityModel.CityId = Convert.ToInt32(vDtData.Rows[0]["CityId"]);
                vCityModel.CityNameL1 = vDtData.Rows[0]["CityNameL1"].ToString();
                vCityModel.CityNameL2 = vDtData.Rows[0]["CityNameL2"].ToString();
                vCityModel.CityCenterLng = vDtData.Rows[0]["CityCenterLng"].ToString();
                vCityModel.CityCenterLat = vDtData.Rows[0]["CityCenterLat"].ToString();
                vCityModel.CountryId = Convert.ToInt32(vDtData.Rows[0]["CountryId"]);
                vCityModel.CityIsActive = Convert.ToBoolean(vDtData.Rows[0]["CityIsActive"]); 
            }

            // Return Result
            return View(vCityModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, CityModel pCityModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPICity;
                string vParameters =
                    "?pCityId=" + id +
                    "&pCityNameL1=" + pCityModel.CityNameL1 +
                    "&pCityNameL2=" + pCityModel.CityNameL2 +
                    "&pCityCenterLat=" + pCityModel.CityCenterLat +
                    "&pCityCenterLng=" + pCityModel.CityCenterLng +
                    "&pCountryId=" + pCityModel.CountryId +
                    "&pCityIsActive=" + pCityModel.CityIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;


                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbCity.vSQLResult = vDrwResult[0].ToString();
                _dbCity.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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
        // City Search
        public ActionResult SearchCity(string pCountryId = "")
        {
            ViewBag.vbcCountryId = pCountryId;
            return View();
        }
    }
}