using appSERP.appCode.dbCode.SEC;
using appSERP.appCode.dbCode.SEC.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.TimeSetting;
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
    public class UserSecurityLogController : Controller
    {
        private IdbUser _dbUser;
        private IdbUserSecurityLog _dbUserSecurityLog;
        private IclsAPI _clsAPI;
        public UserSecurityLogController(IdbUser dbUser, IdbUserSecurityLog dbUserSecurityLog
            , IclsAPI clsAPI)
        {
            _dbUser = dbUser;
            _dbUserSecurityLog = dbUserSecurityLog;
            _clsAPI = clsAPI;
        }


        // GET: UserSecurityLog
        public ActionResult Index()
        {
            // API Path
            string vPath = appAPIDirectory.vAPIUserSecurityLog;
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
            UserSecurityLogModel vUserSecurityLogModel = new UserSecurityLogModel();
       

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPIUserSecurityLog;
                string vParameters = "?pUserSecurityLogiD=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vUserSecurityLogModel.SecurityLogId = Convert.ToInt32(vDtData.Rows[0]["SecurityLogId"]);
                vUserSecurityLogModel.SecurityLogLat = vDtData.Rows[0]["SecurityLogLat"].ToString();
                vUserSecurityLogModel.SecurityLogLng = vDtData.Rows[0]["SecurityLogLng"].ToString();
                vUserSecurityLogModel.SecurityLogLocation = vDtData.Rows[0]["SecurityLogLocation"].ToString();
                vUserSecurityLogModel.SecurityLogDevice = vDtData.Rows[0]["SecurityLogDevice"].ToString();
                vUserSecurityLogModel.SecurityLogDeviceIsMobile =Convert.ToBoolean(vDtData.Rows[0]["SecurityLogDeviceIsMobile"].ToString());
                //vUserSecurityLogModel.SecurityLogDate =Convert.ToDateTime( vDtData.Rows[0]["SecurityLogDate"].ToString());
                //vUserSecurityLogModel.SecurityLogTime =TimeSpan.Parse( vDtData.Rows[0]["SecurityLogTime"].ToString());
                vUserSecurityLogModel.OldPassword = vDtData.Rows[0]["OldPassword"].ToString();
                vUserSecurityLogModel.NewPassword = vDtData.Rows[0]["NewPassword"].ToString();
                vUserSecurityLogModel.UserId = Convert.ToInt32(vDtData.Rows[0]["UserId"].ToString());
                vUserSecurityLogModel.UserSecurityTransactionTypeId = Convert.ToInt32(vDtData.Rows[0]["UserSecurityTransactionTypeId"]);
            }
            // Return Result
            return View(vUserSecurityLogModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, UserSecurityLogModel pUserSecurityLogModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }
            try { 
            // API Path
            string vPath = appAPIDirectory.vAPIUserSecurityLog;
                string vParameters =
                    "?pSecurityLogId=" + id +
                    "&pSecurityLogLat=" + pUserSecurityLogModel.SecurityLogLat +
                    "&pSecurityLogLng=" + pUserSecurityLogModel.SecurityLogLng +
                    "&pSecurityLogLocation=" + pUserSecurityLogModel.SecurityLogLocation +
                    "&pSecurityLogDevice=" + pUserSecurityLogModel.SecurityLogDevice +
                    "&pSecurityLogDeviceIsMobile=" + pUserSecurityLogModel.SecurityLogDeviceIsMobile +
                    "&pSecurityLogDate=" + clsTimeSetting.funBranchTime() +
                    "&pSecurityLogTime=" + clsTimeSetting.funBranchTime().ToLocalTime() +
                    "&pOldPassword=" + pUserSecurityLogModel.OldPassword +
                    "&pNewPassword=" + pUserSecurityLogModel.NewPassword +
                    "&pUserId=" + pUserSecurityLogModel.UserId +
                    "&pUserSecurityTransactionTypeId=" + pUserSecurityLogModel.UserSecurityTransactionTypeId +
                    "&pSecurityLogIsActive=" + pUserSecurityLogModel.SecurityLogIsActive +
                    "&pQueryTypeId=" + vQueryTypeId;
                  
                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbUserSecurityLog.vSQLResult = vDrwResult[0].ToString();
                _dbUser.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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
        // GET: UserSecurityLog
        public ActionResult UserSecurityTransactionLog()
        {
            // Result
            DataTable vDtData;

            // User Log Data
            DataTable vDtUserLog = _dbUserSecurityLog.vDTUserLog;
            if(vDtUserLog !=null)
            {
                vDtData = vDtUserLog;

            }
            else
            {
                // API Path
                string vPath = appAPIDirectory.vAPIUserSecurityLog;

                // Result
               vDtData = _clsAPI.funResultGet(vPath);
            }

            // Return View
            if (Request.IsAjaxRequest())
            {
                return PartialView(vDtData);
            }
            return View(vDtData);
        }

    }
}