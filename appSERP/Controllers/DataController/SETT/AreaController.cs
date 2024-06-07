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
    // Belal 3:08:00
    //[NoDirectAccess]
    //[Authorize]
    public class AreaController : Controller
    {
        private IdbArea _dbArea;
        private IclsAPI _clsAPI;
        public AreaController(IdbArea dbArea, IclsAPI clsAPI)
        {
            _dbArea = dbArea;
            _clsAPI = clsAPI;
        }

        // GET: Area
        public ActionResult Index()
        {
            // API Path
            string vPath = appAPIDirectory.vAPIArea;
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
            AreaModel vAreaModel = new AreaModel();
            string vCityPath = @"/APICity/CityGet";
            string vCityParameters = "?pCityIsActive=True";
            DataTable dtCity = _clsAPI.funResultGet(vCityPath + vCityParameters);
            if (id == 0)
            {

                ViewBag.vbCityId = new SelectList(dtCity.AsDataView(), "CityId", "CityNameL1");
                ViewBag.vbcCityId = 0;
            }

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPIArea;
                string vParameters = "?pAreaId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                ViewBag.vbcCityId = Convert.ToInt32(vDtData.Rows[0]["CityId"]) ;
                ViewBag.vbCityId = new SelectList(dtCity.AsDataView(),
              "CityId", "CityNameL1",
              vDtData.Rows[0]["CityId"].ToString());
                // Set Model Data
                vAreaModel.AreaId = Convert.ToInt32(vDtData.Rows[0]["AreaId"]);
                vAreaModel.AreaNameL1 = vDtData.Rows[0]["AreaNameL1"].ToString();
                vAreaModel.AreaNameL2 = vDtData.Rows[0]["AreaNameL2"].ToString();
                vAreaModel.CityId = Convert.ToInt32(vDtData.Rows[0]["CityId"]);
                vAreaModel.AreaIsActive = Convert.ToBoolean(vDtData.Rows[0]["AreaIsActive"]); 
            }

            // Return Result
            return View(vAreaModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, AreaModel pAreaModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPIArea;
                string vParameters =
                    "?pAreaId=" + id +
                    "&pAreaNameL1=" + pAreaModel.AreaNameL1 +
                    "&pAreaNameL2=" + pAreaModel.AreaNameL2 +
                    "&pCityId=" + pAreaModel.CityId +
                    "&pAreaIsActive=" + pAreaModel.AreaIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;


                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbArea.vSQLResult = vDrwResult[0].ToString();
                _dbArea.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);
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
        // AREA Search
        public ActionResult SearchArea(string pCityId = "")
        {
            ViewBag.vbcCityId = pCityId;
            return View();
        }
    }
}