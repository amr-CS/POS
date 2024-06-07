using appSERP.appCode.dbCode.SEC;
using appSERP.appCode.dbCode.SEC.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.SQL.QueryType;
using appSERP.Models.SEC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataController.SEC
{
    public class SecurityRoleExceptionController : Controller
    {
        private IdbSecurityRoleException _dbSecurityRoleException;
        private IclsAPI _clsAPI;
        public SecurityRoleExceptionController(IdbSecurityRoleException dbSecurityRoleException, IclsAPI clsAPI)
        {
            _dbSecurityRoleException = dbSecurityRoleException;
            _clsAPI = clsAPI;
        }

        // GET: SecurityRoleExceptionType
        public ActionResult Index()
        {
            // API Path
            string vPath = appAPIDirectory.vAPISecurityRoleException;
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
            SecurityRoleExceptionModel vSecurityRoleExceptionModel = new SecurityRoleExceptionModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPISecurityRoleException;
                string vParameters = "?pSecurityRoleExceptionId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vSecurityRoleExceptionModel.SecurityRoleExceptionId = Convert.ToInt32(vDtData.Rows[0]["SecurityRoleExceptionId"]);
                vSecurityRoleExceptionModel.SecurityRoleExceptionCode = vDtData.Rows[0]["SecurityRoleExceptionCode"].ToString();
                vSecurityRoleExceptionModel.SecurityRoleExceptionNameL1 = vDtData.Rows[0]["SecurityRoleExceptionNameL1"].ToString();
                vSecurityRoleExceptionModel.SecurityRoleExceptionNameL2 = vDtData.Rows[0]["SecurityRoleExceptionNameL2"].ToString();
                vSecurityRoleExceptionModel.SecurityRoleExceptionIsActive = Convert.ToBoolean(vDtData.Rows[0]["SecurityRoleExceptionIsActive"].ToString());

            }

            // Return Result
            return View(vSecurityRoleExceptionModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, SecurityRoleExceptionModel pSecurityRoleExceptionModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPISecurityRoleException;
                string vParameters =
                        "?pSecurityRoleExceptionId=" + id +
                         "&pSecurityRoleExceptionCode=" + pSecurityRoleExceptionModel.SecurityRoleExceptionCode +
                        "&pSecurityRoleExceptionNameL1=" + pSecurityRoleExceptionModel.SecurityRoleExceptionNameL1 +
                        "&pSecurityRoleExceptionNameL2=" + pSecurityRoleExceptionModel.SecurityRoleExceptionNameL2 +
                        "&pSecurityRoleExceptionIsActive=" + pSecurityRoleExceptionModel.SecurityRoleExceptionIsActive +
                        "&pIsDeleted=" + pIsDelete +
                        "&pQueryTypeId=" + vQueryTypeId;


                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbSecurityRoleException.vSQLResult = vDrwResult[0].ToString();
                _dbSecurityRoleException.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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