using appSERP.appCode.dbCode.ACC;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.SQL.QueryType;
using appSERP.Models.ACC;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using appSERP.appCode.Setting.ReportSetting;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.Setting.APISetting.Abstract;

namespace appSERP.Controllers.DataControllers.ACC
{   ///  AMR    22/1/2018
    [NoDirectAccess]
    [Authorize]
    public class CostCenterController : Controller
    {
        private IdbCostCenter _dbCostCenter;
        private IclsAPI _clsAPI;
        public CostCenterController(IdbCostCenter dbCostCenter, IclsAPI clsAPI)
        {
            _dbCostCenter = dbCostCenter;
            _clsAPI = clsAPI;
        }

        // GET: CostCenter
        public ActionResult Index()
        {
            // API Path
            string vPath = appAPIDirectory.vAPICostCenter;
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
            CostCenterModel vCostCenterModel = new CostCenterModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPICostCenter;
                string vParameters = "?pCostCenterId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vCostCenterModel.CostCenterId = Convert.ToInt32(vDtData.Rows[0]["CostCenterId"]);
                vCostCenterModel.CostCenterCode = vDtData.Rows[0]["CostCenterCode"].ToString();
                vCostCenterModel.CostCenterNameL1 = vDtData.Rows[0]["CostCenterNameL1"].ToString();
                vCostCenterModel.CostCenterNameL2 = vDtData.Rows[0]["CostCenterNameL2"].ToString();
                vCostCenterModel.CostCenterParentId = Convert.ToInt32(vDtData.Rows[0]["CostCenterParentId"]);
                vCostCenterModel.CostCenterLevel = Convert.ToInt32(vDtData.Rows[0]["CostCenterLevel"].ToString());
                vCostCenterModel.CostCenterIsAccumulative = Convert.ToBoolean(vDtData.Rows[0]["CostCenterIsAccumulative"]);
                vCostCenterModel.CostCenterIsActive = Convert.ToBoolean(vDtData.Rows[0]["CostCenterIsActive"]);
            }

            // Return Result
            return View(vCostCenterModel);
        }


        [HttpPost]
        public ActionResult DataModel(int? id = 0, CostCenterModel pCostCenterModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPICostCenter;
                string vParameters =
                    "?pCostCenterId=" + id +
                    "&pCostCenterCode=" + pCostCenterModel.CostCenterCode +
                    "&pCostCenterNameL1=" + pCostCenterModel.CostCenterNameL1 +
                    "&pCostCenterNameL2= " + pCostCenterModel.CostCenterNameL2 +
                    "&pCostCenterParentId=" + pCostCenterModel.CostCenterParentId +
                    "&pCostCenterLevel= " + pCostCenterModel.CostCenterLevel +
                    "&pCostCenterIsAccumulative= " + pCostCenterModel.CostCenterIsAccumulative +
                    "&pCostCenterIsActive=" + pCostCenterModel.CostCenterIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;


                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbCostCenter.vSQLResult = vDrwResult[0].ToString();
                _dbCostCenter.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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

        [HttpPost]
        public ActionResult funSaveCostCenter(int? id = 0, int CostCenterLevel = 0, int ParentId = 0, CostCenterModel[] vCostCenter = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId;
            
            try
            {
                if (Convert.ToBoolean(pIsDelete))
                {
                    vQueryTypeId = clsQueryType.qDelete;
                    string vPath = appAPIDirectory.vAPICostCenter;
                    string vParameters =
                    "?pCostCenterId=" + id +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;
                    // SQL Result
                    DataRow vDrwResultV = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                    _dbCostCenter.vSQLResult = vDrwResultV[0].ToString();
                    _dbCostCenter.vSQLResultTypeId = Convert.ToInt32(vDrwResultV[1]);


                }
                else
                {
                    foreach (var pCostCenterModel in vCostCenter)
                    {
                        if (ParentId == 0)
                        {
                            CostCenterLevel = 0;
                        }

                        int? vCostCenterLevel = CostCenterLevel + 1;
                        if (pCostCenterModel.CostCenterId > 0) { vQueryTypeId = clsQueryType.qUpdate; }
                        else { vQueryTypeId = clsQueryType.qInsert; };
                        // API Path
                        string vPath = appAPIDirectory.vAPICostCenter;
                        string vParameters =
                        "?pCostCenterId=" + pCostCenterModel.CostCenterId +
                        "&pCostCenterCode=" + pCostCenterModel.CostCenterCode +
                        "&pCostCenterNameL1=" + pCostCenterModel.CostCenterNameL1 +
                        "&pCostCenterNameL2=" + pCostCenterModel.CostCenterNameL2 +
                         "&pCostCenterParentId=" + ParentId +
                        "&pCostCenterLevel=" + vCostCenterLevel +
                        "&pCostCenterIsAccumulative=" + pCostCenterModel.CostCenterIsAccumulative +
                        "&pCostCenterIsActive=" + pCostCenterModel.CostCenterIsActive +
                        "&pIsDeleted=" + pIsDelete +
                        "&pQueryTypeId=" + vQueryTypeId;
                        // SQL Result
                        DataRow vDrwResultV = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                        _dbCostCenter.vSQLResult = vDrwResultV[0].ToString();
                        _dbCostCenter.vSQLResultTypeId = Convert.ToInt32(vDrwResultV[1]);
                    }
                }
                // Go To Index
                return RedirectToAction("ChartsCostCenter");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult ChartsCostCenter(string id = "0", string CostCenterCode= null, int? CostCenterLevel = null, int ParentId = 0)
        {
            try
            {
                // Set Parent Id
                _dbCostCenter.vParentId = id;
                // API Path
                string vPath = appAPIDirectory.vAPICostCenter;
                string vParamChild = "?pQueryTypeId=" + 405 + "&pCostCenterId=" + id + "&pIsDeleted=" + false;


                if (id != "0")
                {
                    //GET CostCenter No From Parent
                    string vParent = "?pQueryTypeId=" + 403 + "&pCostCenterId=" + id;
                    DataTable vDTParent = _clsAPI.funResultGet(vPath + vParent);
                    if (vDTParent.Rows.Count > 0)
                    {
                        _dbCostCenter.vCostCenterCode = vDTParent.Rows[0]["CostCenterCode"].ToString();
                        _dbCostCenter.vCostCenterName = vDTParent.Rows[0]["CostCenterNameL1"].ToString();
                        _dbCostCenter.vCostCenterLevel = Convert.ToInt32(vDTParent.Rows[0]["CostCenterLevel"].ToString());
                        _dbCostCenter.vBranchId = vDTParent.Rows[0]["CompanyId"].ToString();
                        _dbCostCenter.vBranchName = vDTParent.Rows[0]["CompanyBranchNameL1"].ToString();

                    }
                }
                // Get All Childs
                DataTable vDtChilds = _clsAPI.funResultGet(vPath + vParamChild);
                // Return View

                return View(vDtChilds);
            }
            catch (Exception ex) {
                return null;
            }
        }

        public ActionResult CostCenter()
        {
   

            return View();
        }

        
        public ActionResult SearchCostCenter()
        {


            return View();
        }

        [HttpPost]
        public string GetTreeViewList()
        {
            // API Path
            string vPath = appAPIDirectory.vAPICostCenter;
            string vParameters = "?pQueryTypeId= 402";
            DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
            string vAccountJson = JsonConvert.SerializeObject(vDtData);
            return vAccountJson;
        }
        public void ShowSimpleCostCenterReport()
        {
            DataTable DT = _dbCostCenter.funCostCenterReportGET();
            string vFullPath = Server.MapPath("~/Reports") + "//CostCenterReport.rpt";
            ClsReport.Printreport(DT, vFullPath);
        }

        public ActionResult CostCenterReport()
        {

            //ViewBag.vbCostCenter = pGLVoucherId;
            //Session["SCostCenter"] = ViewBag.vbCostCenter;

            return View();
        }

        public string FilterCostCenters(string pCostCenterCode = null)
        {
            // API Path
            string vPath = appAPIDirectory.vAPICostCenter;
            string vParameters ="?pCostCenterCode=" + pCostCenterCode +
                "&pQueryTypeId=" + 406;

            string vJSONResult = _clsAPI.funResultGetJSON(vPath + vParameters);

            return vJSONResult;
        }
        public string SearchCostCenterByCode(string id = "1", int? pCostCenterCode = null)
        {
            // API Path
            string vPath = appAPIDirectory.vAPICostCenter;
            string vParameters = "?pCostCenterCode=" + pCostCenterCode +
                "&pQueryTypeId=" + 407;
            // Head
            string vJSONResult = _clsAPI.funResultGetJSON(vPath + vParameters);
            return vJSONResult;
            

        }
    }
}