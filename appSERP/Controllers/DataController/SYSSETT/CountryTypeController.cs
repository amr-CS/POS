using appSERP.appCode.dbCode.SYSSETT;
using appSERP.appCode.dbCode.SYSSETT.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
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
    public class CountryTypeController : Controller
    {

        private IdbCountryType _dbCountryType;
        private IclsAPI _clsAPI;
        public CountryTypeController(IdbCountryType dbCountryType, IclsAPI clsAPI)
        {
            _dbCountryType = dbCountryType;
            _clsAPI = clsAPI;
        }

        // GET: CountryType
        public ActionResult Index()
        {
            // API Path
            string vPath = appAPIDirectory.vAPICountryType;
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
            CountryTypeModel vCountryTypeModel = new CountryTypeModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPICountryType;
                string vParameters = "?pCountryTypeId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vCountryTypeModel.CountryTypeId = Convert.ToInt32(vDtData.Rows[0]["CountryTypeId"]);
                vCountryTypeModel.CountryTypeCode = vDtData.Rows[0]["CountryTypeCode"].ToString();
                vCountryTypeModel.CountryTypeNameL1 = vDtData.Rows[0]["CountryTypeNameL1"].ToString();
                vCountryTypeModel.CountryTypeNameL2 = vDtData.Rows[0]["CountryTypeNameL2"].ToString();
                vCountryTypeModel.CountryTypeIsActive = Convert.ToBoolean(vDtData.Rows[0]["CountryTypeIsActive"]);
                


            }

            // Return Result
            return View(vCountryTypeModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, CountryTypeModel pCountryTypeModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPICountryType;
                string vParameters =
                    "?pCountryTypeId=" + id +
                     "&pCountryTypeCode=" + pCountryTypeModel.CountryTypeCode +
                    "&pCountryTypeNameL1=" + pCountryTypeModel.CountryTypeNameL1 +
                    "&pCountryTypeNameL2=" + pCountryTypeModel.CountryTypeNameL2 +
                    "&pCountryTypeIsActive=" + pCountryTypeModel.CountryTypeIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;


                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbCountryType.vSQLResult = vDrwResult[0].ToString();
                _dbCountryType.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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
    }
}