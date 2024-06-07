using appSERP.appCode.dbCode.FA;
using appSERP.appCode.dbCode.FA.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.SQL.QueryType;
using appSERP.Models.FA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataController.FA
{
    ///  Belal    4/3/2018
    public class TrustController : Controller
    {
        private IdbTrust _dbTrust;
        private IclsAPI _clsAPI;
        public TrustController(IdbTrust dbTrust, IclsAPI clsAPI)
        {
            _dbTrust = dbTrust;
            _clsAPI = clsAPI;
        }

        // GET: Trust
        public ActionResult Index()
        {
            // API Path
            string vPath = appAPIDirectory.vAPITrust;
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
            TrustModel vTrustModel = new TrustModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPITrust;
                string vParameters = "?pTrustId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vTrustModel.TrustId = Convert.ToInt32(vDtData.Rows[0]["TrustId"]);
                vTrustModel.TrustNameL1 = vDtData.Rows[0]["TrustNameL1"].ToString();
                vTrustModel.TrustNameL2 = vDtData.Rows[0]["TrustNameL2"].ToString();
                vTrustModel.TrustEmployeeId = Convert.ToInt32(vDtData.Rows[0]["TrustEmployeeId"]);
                vTrustModel.TrustPhone1 = vDtData.Rows[0]["TrustPhone1"].ToString();
                vTrustModel.TrustPhone2 = vDtData.Rows[0]["TrustPhone2"].ToString();
                vTrustModel.TrustEmail = vDtData.Rows[0]["TrustEmail"].ToString();
                vTrustModel.TrustIsActive = Convert.ToBoolean(vDtData.Rows[0]["TrustIsActive"]);
            }

            // Return Result
            return View(vTrustModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, TrustModel pTrustModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }
            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPITrust;
                string vParameters =
                    "?pTrustId=" + id +
                    "&pTrustNameL1=" + pTrustModel.TrustNameL1 +
                    "&pTrustNameL2= " + pTrustModel.TrustNameL2 +
                     "&pTrustEmployeeId= " + pTrustModel.TrustEmployeeId +
                     "&pTrustPhone1= " + pTrustModel.TrustPhone1 +
                     "&pTrustPhone2= " + pTrustModel.TrustPhone2 +
                      "&pTrustEmail= " + pTrustModel.TrustEmail +
                      "&pTrustIsActive=" + pTrustModel.TrustIsActive +
                      "&pIsDeleted=" + pIsDelete +
                      "&pQueryTypeId=" + vQueryTypeId;
                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbTrust.vSQLResult = vDrwResult[0].ToString();
                _dbTrust.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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