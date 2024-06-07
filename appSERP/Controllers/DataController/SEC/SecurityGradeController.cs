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
    public class SecurityGradeController : Controller
    {

        private IdbSecurityGrade _dbSecurityGrade;
        private IclsAPI _clsAPI;
        public SecurityGradeController(IdbSecurityGrade dbSecurityGrade, IclsAPI clsAPI)
        {
            _dbSecurityGrade = dbSecurityGrade;
            _clsAPI = clsAPI;
        }

        // GET: SecurityGrade
        public ActionResult Index()
        {
            // API Path
            string vPath = appAPIDirectory.vAPISecurityGrade;
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
            SecurityGradeModel vSecurityGradeModel = new SecurityGradeModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPISecurityGrade;
                string vParameters = "?pSecurityGradeId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vSecurityGradeModel.SecurityGradeId = Convert.ToInt32(vDtData.Rows[0]["SecurityGradeId"]);
                vSecurityGradeModel.SecurityGradeCode = vDtData.Rows[0]["SecurityGradeCode"].ToString();
                vSecurityGradeModel.SecurityGradeNameL1 = vDtData.Rows[0]["SecurityGradeNameL1"].ToString();
                vSecurityGradeModel.SecurityGradeNameL2 = vDtData.Rows[0]["SecurityGradeNameL2"].ToString();
                vSecurityGradeModel.SecurityGradeIsActive = Convert.ToBoolean(vDtData.Rows[0]["SecurityGradeIsActive"]);
            }

            // Return Result
            return View(vSecurityGradeModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, SecurityGradeModel pSecurityGradeModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            try
            {

                // API Path
                string vPath = appAPIDirectory.vAPISecurityGrade;
                string vParameters =
                    "?pSecurityGradeId=" + id +
                      "&pSecurityGradeCode=" + pSecurityGradeModel.SecurityGradeCode +
                    "&pSecurityGradeNameL1=" + pSecurityGradeModel.SecurityGradeNameL1 +
                    "&pSecurityGradeNameL2=" + pSecurityGradeModel.SecurityGradeNameL2 +
                    "&pSecurityGradeIsActive=" + pSecurityGradeModel.SecurityGradeIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;

                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbSecurityGrade.vSQLResult = vDrwResult[0].ToString();
                _dbSecurityGrade.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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