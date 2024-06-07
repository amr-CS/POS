using appSERP.appCode.dbCode.INV;
using appSERP.appCode.dbCode.INV.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.GD.Abstract;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.appCode.SQL.QueryType;
using appSERP.Models.INV;
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
    public class UnitController : Controller
    {

        private IdbUnit _dbUnit;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public UnitController(IdbUnit dbUnit, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _dbUnit = dbUnit;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }

        // GET: Unit
        public ActionResult Index()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            ViewBag.dbUnit = _dbUnit;

            // API Path
            string vPath = appAPIDirectory.vAPIUnit;
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
            UnitModel vUnitModel = new UnitModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPIUnit;
                string vParameters = "?pUnitId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vUnitModel.UnitId = Convert.ToInt32(vDtData.Rows[0]["UnitId"]);
                vUnitModel.UnitCode = vDtData.Rows[0]["UnitCode"].ToString();
                vUnitModel.UnitNameL1 = vDtData.Rows[0]["UnitNameL1"].ToString();
                vUnitModel.UnitNameL2 = vDtData.Rows[0]["UnitNameL2"].ToString();
                vUnitModel.UnitIsActive = Convert.ToBoolean(vDtData.Rows[0]["UnitIsActive"]);

            }

            // Return Result
            return View(vUnitModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, UnitModel pUnitModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qInsert; ; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPIUnit;
                string vParameters =
                    "?pUnitId=" + id +
                     "&pUnitCode=" + pUnitModel.UnitCode +
                    "&pUnitNameL1=" + pUnitModel.UnitNameL1 +
                    "&pUnitNameL2=" + pUnitModel.UnitNameL2 +
                    "&pUnitIsActive=" + pUnitModel.UnitIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;


                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbUnit.vSQLResult = vDrwResult[0].ToString();
                _dbUnit.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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
        public ActionResult SearchUnit()
        {
           return View();
        }
        public ActionResult SearchBasicUnit()
        {
            return View();
        }
        public string SearchUnitByCode(string pUnitCode = null)
        {
            //// API Path
            //string vPath = appAPIDirectory.vAPIUnit;
            // API Path
         
            string vPath = "/APIVUnit/VUnitGET";
            //string vParameters =
            //     "?pUnitCode=" + pUnitCode +
            //    "&pQueryTypeId=" + 400;
            string vParameters =
            "?pCodeId=" + pUnitCode +
           "&pQueryTypeId=" + 400;
            string vJSONResult = _clsAPI.funResultGetJSON(vPath + vParameters);
            return vJSONResult;
        }
    }
}