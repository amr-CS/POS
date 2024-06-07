using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.Models.SEC;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using appSERP.appCode.dbCode.SEC;
using Newtonsoft.Json;
using appSERP.appCode.dbCode.SEC.Abstract;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.GD.Abstract;

namespace appSERP.Controllers.DataController.SEC
{
    public class SecurityRoleController : Controller
    {

        private IdbSecurityRole _dbSecurityRole;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;
        public SecurityRoleController(IdbSecurityRole dbSecurityRole, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _dbSecurityRole = dbSecurityRole;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }

        // GET: SecurityRole
        public ActionResult Index(string pSecurityRoleId)
        {
            // Set Security RoleId
            _dbSecurityRole.vSecurityRoleId = pSecurityRoleId;

            // API Path
            string vPath = appAPIDirectory.vAPISecurityRole;

            // API PARMETER Master
            string vParamter = "?pIsMaster=true";

            // API PARMETER Detail
            string vParamterDtl = "?pIsMaster=false&pSecurityRoleId="+pSecurityRoleId;

            // Result Master
            DataTable vDtData = _clsAPI.funResultGet(vPath+ vParamter);

            // Result Details
            ViewBag.vDtDataDtl = _clsAPI.funResultGet(vPath + vParamterDtl).AsDataView();

           

            // Return View
            if (Request.IsAjaxRequest())
            {
                return PartialView(vDtData);
            }
            return View(vDtData);
        }
        public ActionResult SecurityRole()
        {
            ViewBag.DevCompanySetting = _DevCompanySetting;
            // API Path
            string vPath = appAPIDirectory.vAPIObjects;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);
            ViewBag.vbDataObject = vDtData.AsDataView();
            return View();
        }

        public ActionResult Security()
        {

   
            return View();
        }
        public ActionResult ObjectSearch()
        {

            return View();
        }
        // Master
        public ActionResult DataModel(int? id = 0)
        {
            // New Model
            SecurityRoleModel vSecurityRoleModel = new SecurityRoleModel();


            // Edit Case
            if (id > 0)
            {

                // API Path
                string vPath = appAPIDirectory.vAPISecurityRole;
                string vParameters = "?pSecurityRoleId=" + id +"&pIsMaster="+ true;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
               
                    // Master
                    vSecurityRoleModel.SecurityRoleId = Convert.ToInt32(vDtData.Rows[0]["SecurityRoleId"]);
                    vSecurityRoleModel.SecurityRoleNameL1 = vDtData.Rows[0]["SecurityRoleNameL1"].ToString();
                    vSecurityRoleModel.SecurityRoleNameL2 = vDtData.Rows[0]["SecurityRoleNameL2"].ToString();
                    vSecurityRoleModel.SecurityRoleIsActive = Convert.ToBoolean(vDtData.Rows[0]["SecurityRoleIsActive"].ToString());
  
            }
            // Return Result
            return View(vSecurityRoleModel);
        }
     


        [HttpPost]
        public ActionResult DataModel(int? id = 0, SecurityRoleModel pSecurityRoleModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }
            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPISecurityRole;
                string vParameters =
                    // Master
                    "?pSecurityRoleId=" + id +
                    "&pSecurityRoleNameL1=" + pSecurityRoleModel.SecurityRoleNameL1 +
                    "&pSecurityRoleNameL2=" + pSecurityRoleModel.SecurityRoleNameL2 +
                    "&pSecurityRoleIsActive=" + pSecurityRoleModel.SecurityRoleIsActive +
                    "&pIsMaster=" + true +

                    // Details
                    "&pSecurityRoleObjectId=" + pSecurityRoleModel.SecurityRoleObjectId +
                    "&pObjectId=" + pSecurityRoleModel.ObjectId +
                    "&pObjectAction=" + pSecurityRoleModel.ObjectAction +
                    "&pQueryTypeId=" + vQueryTypeId;
                

                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbSecurityRole.vSQLResult = vDrwResult[0].ToString();
                _dbSecurityRole.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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

        // Detail
        public ActionResult SecurityRoleObjectDataModel(int? id = 0)
        {
            // New Model
            SecurityRoleModel vSecurityRoleModel = new SecurityRoleModel();


            // Edit Case
            if (id > 0)
            {

                // API Path
                string vPath = appAPIDirectory.vAPISecurityRole;
                string vParameters = "?pSecurityRoleObjectId=" + id + "&pIsMaster=" + false;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);

                // Detail
                vSecurityRoleModel.SecurityRoleObjectId = Convert.ToInt32(vDtData.Rows[0]["SecurityRoleObjectId"].ToString());
                vSecurityRoleModel.ObjectId = Convert.ToInt32(vDtData.Rows[0]["ObjectId"].ToString());
                vSecurityRoleModel.ObjectAction = vDtData.Rows[0]["ObjectAction"].ToString();

                // Get All Actions 
                string vPathA = appAPIDirectory.vAPISecurityRole;
                string vParametersA = "?pSecurityRoleId=" + _dbSecurityRole.vSecurityRoleId + "&pObjectId=" + vSecurityRoleModel.ObjectId+ "&pQueryTypeId=" + clsQueryType.qSelectAdvance;
                // Result
                ViewBag.vbDataA = _clsAPI.funResultGet(vPathA + vParametersA).AsDataView();



            }
            // Return Result
            return View(vSecurityRoleModel);
        }

        // Detail
        [HttpPost]
        public ActionResult SecurityRoleObjectDataModel(int? id = 0, SecurityRoleModel pSecurityRoleModel = null, bool? pIsDelete = false)
        {

            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }
            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPISecurityRole;
                string vParameters =
                    // Master
                    "?pSecurityRoleId=" + _dbSecurityRole.vSecurityRoleId +
                    "&pSecurityRoleNameL1=" + pSecurityRoleModel.SecurityRoleNameL1 +
                    "&pSecurityRoleNameL2=" + pSecurityRoleModel.SecurityRoleNameL2 +
                    "&pSecurityRoleIsActive=" + pSecurityRoleModel.SecurityRoleIsActive +
                    "&pIsMaster=" + false +

                    // Details
                    "&pSecurityRoleObjectId=" + pSecurityRoleModel.SecurityRoleObjectId +
                    "&pObjectId=" + pSecurityRoleModel.ObjectId +
                    "&pObjectAction=" + pSecurityRoleModel.ObjectAction +
                    "&pQueryTypeId=" + vQueryTypeId;


                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbSecurityRole.vSQLResult = vDrwResult[0].ToString();
                _dbSecurityRole.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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


        // Security Role GET
        public ActionResult SecurityRoleObjectGet()
        {
            // Return View
            return View();
        }

        // Security Role Object Data
        public string SecurityRoleObjectData()
        {
            // Get All Actions 
            string vPath = appAPIDirectory.vAPISecurityRole;
            string vParameter = "?pQueryTypeId=" + clsQueryType.qSelectExtraData;
            // Result
            string vResult = _clsAPI.funResultGetJSON(vPath + vParameter);
            // Return Result
            return vResult;
        }

        public string getSecurityRoleData(int pSecurityRoleId,bool pIsMaster,int pQueryTypeId)
        {
            // Set data
            string vData = _dbSecurityRole.funSecurityRoleGET(
            pSecurityRoleId: pSecurityRoleId,
            pIsMaster: pIsMaster,
            pQueryTypeId: pQueryTypeId);
            // Get Data
            return vData;
        }

    }
}