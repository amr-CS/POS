using appSERP.appCode.dbCode.SYSSETT;
using appSERP.appCode.dbCode.SYSSETT.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.User;
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
    public class UserFavoriteController : Controller
    {

        private IdbUserFavorite _dbUserFavorite;
        private IclsAPI _clsAPI;
        public UserFavoriteController(IdbUserFavorite dbUserFavorite, IclsAPI clsAPI)
        {
            _dbUserFavorite = dbUserFavorite;
            _clsAPI = clsAPI;
        }

        // GET: UserFavorite
        public ActionResult Index()
        {
            // API Path
            string vPath = appAPIDirectory.vAPIUserFavorite;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);
            // Return View
            if (Request.IsAjaxRequest())
            {
                return PartialView(vDtData);
            }
            return View(vDtData);
        }

        // GET: UserFavorite
        public ActionResult UserFavorite()
        {
            // API Path
            string vPath = appAPIDirectory.vAPIUserFavorite;
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
            UserFavoriteModel vUserFavoriteModel = new UserFavoriteModel();
            if (id == 0)
            {
                ViewBag.vbcUserId = 0;
                ViewBag.vbcObjectId = clsUser.ObjectId;
            }

                if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPIUserFavorite;
                string vParameters = "?pUserFavoriteId=" + id;
                    // Result
                 DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                ViewBag.vbcUserId = Convert.ToInt32(vDtData.Rows[0]["UserId"]);
                ViewBag.vbcObjectId = Convert.ToInt32(vDtData.Rows[0]["ObjectId"]);
                // Set Model Data
                vUserFavoriteModel.UserFavoriteId = Convert.ToInt32(vDtData.Rows[0]["UserFavoriteId"]);
                vUserFavoriteModel.UserId = Convert.ToInt32(vDtData.Rows[0]["UserId"].ToString());
                vUserFavoriteModel.ObjectId = Convert.ToInt32(vDtData.Rows[0]["ObjectId"].ToString());
              
            }

            // Return Result
              return View(vUserFavoriteModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, UserFavoriteModel pUserFavoriteModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            //if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPIUserFavorite;
                string vParameters =
                    "?pUserFavoriteId=" + id +
                    "&pUserId=" + clsUser.vUserId +
                    "&pObjectId=" + clsUser.ObjectId+
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;
                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbUserFavorite.vSQLResult = vDrwResult[0].ToString();
                _dbUserFavorite.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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