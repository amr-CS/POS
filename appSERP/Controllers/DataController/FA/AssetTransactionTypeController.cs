using appSERP.appCode.dbCode.ACC;
using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.SQL.QueryType;
using appSERP.Models.ACC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataControllers.ACC
{   ///  AMR    22/1/2018
    public class AssetTransactionTypeController : Controller
    {
        

        private IdbAssetTransactionType _dbAssetTransactionType;
        private IclsAPI _clsAPI;
        public AssetTransactionTypeController(IdbAssetTransactionType dbAssetTransactionType, IclsAPI clsAPI)
        {
            _dbAssetTransactionType = dbAssetTransactionType;
            _clsAPI = clsAPI;
        }
        // GET: TransactionType
        public ActionResult Index()
        {
            // API Path
            string vPath = appAPIDirectory.vAPIAssetTransactionType;
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
            AssetTransactionTypeModel vAssetTransactionTypeModel = new AssetTransactionTypeModel();
      
            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPIAssetTransactionType;
                string vParameters = "?pTransactionTypeId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vAssetTransactionTypeModel.TransactionTypeId = Convert.ToInt32(vDtData.Rows[0]["TransactionTypeId"]);
                vAssetTransactionTypeModel.TransactionTypeCode = vDtData.Rows[0]["TransactionTypeCode"].ToString();
                vAssetTransactionTypeModel.TransactionTypeNameL1 = vDtData.Rows[0]["TransactionTypeNameL1"].ToString();
                vAssetTransactionTypeModel.TransactionTypeNameL2 = vDtData.Rows[0]["TransactionTypeNameL2"].ToString();
                vAssetTransactionTypeModel.TransactionTypeIsActive = Convert.ToBoolean(vDtData.Rows[0]["TransactionTypeIsActive"]);
            }

            // Return Result
            return View(vAssetTransactionTypeModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, AssetTransactionTypeModel pAssetTransactionTypeModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }
            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPIAssetTransactionType;
                string vParameters =
                    "?pTransactionTypeId=" + id +
                    "&pTransactionTypeCode=" + pAssetTransactionTypeModel.TransactionTypeCode +
                    "&pTransactionTypeNameL1=" + pAssetTransactionTypeModel.TransactionTypeNameL1 +
                    "&pTransactionTypeNameL2= " + pAssetTransactionTypeModel.TransactionTypeNameL2 +
                    "&pTransactionTypeIsActive=" + pAssetTransactionTypeModel.TransactionTypeIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;
                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbAssetTransactionType.vSQLResult = vDrwResult[0].ToString();
                _dbAssetTransactionType.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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