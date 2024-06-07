using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.SQL.QueryType;
using appSERP.appCode.dbCode.SEC;
using appSERP.Models.SEC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using appSERP.appCode.dbCode.SEC.Abstract;
using appSERP.appCode.Setting.APISetting.Abstract;

namespace appSERP.Controllers.DataControllers.SEC
{
    public class SecurityPolicyController : Controller
    {
        private IdbSecurityPolicy _dbSecurityPolicy;
        private IclsAPI _clsAPI;
        public SecurityPolicyController(IdbSecurityPolicy dbSecurityPolicy, IclsAPI clsAPI)
        {
            _dbSecurityPolicy = dbSecurityPolicy;
            _clsAPI = clsAPI;
        }

        // GET: SecurityPolicy
        public ActionResult Index()
        {
            // API Path
            string vPath = appAPIDirectory.vAPISecurityPolicy;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);

            if (Request.IsAjaxRequest())
            {
                return PartialView(vDtData);
            }
            // Return View
            return View(vDtData);
        }

        public ActionResult DataModel(int? id = 0)
        {
            // New Model
            SecurityPolicyModel vSecurityPolicyModel = new SecurityPolicyModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPISecurityPolicy;
                string vParameters = "?pSecurityPolicyId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vSecurityPolicyModel.SecurityPolicyId = Convert.ToInt32(vDtData.Rows[0]["SecurityPolicyId"]);
                vSecurityPolicyModel.SecurityPolicySeq = Convert.ToInt32(vDtData.Rows[0]["SecurityPolicySeq"]);
                vSecurityPolicyModel.SecurityPolicyNameL1 = vDtData.Rows[0]["SecurityPolicyNameL1"].ToString();
                vSecurityPolicyModel.SecurityPolicyNameL2 = vDtData.Rows[0]["SecurityPolicyNameL2"].ToString();
                vSecurityPolicyModel.SecurityPolicyIsActive = Convert.ToBoolean(vDtData.Rows[0]["SecurityPolicyIsActive"]);
            }

            // Return Result
            return View(vSecurityPolicyModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, SecurityPolicyModel pSecurityPolicyModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            try
            {

                // API Path
                string vPath = appAPIDirectory.vAPISecurityPolicy;
                string vParameters =
                    "?pSecurityPolicyId=" + id +
                     "&pSecurityPolicySeq=" + pSecurityPolicyModel.SecurityPolicySeq +
                    "&pSecurityPolicyNameL1=" + pSecurityPolicyModel.SecurityPolicyNameL1 +
                    "&pSecurityPolicyNameL2=" + pSecurityPolicyModel.SecurityPolicyNameL2 +
                    "&pSecurityPolicyIsActive=" + pSecurityPolicyModel.SecurityPolicyIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;

                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbSecurityPolicy.vSQLResult = vDrwResult[0].ToString();
                _dbSecurityPolicy.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

                // Go To Index
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}