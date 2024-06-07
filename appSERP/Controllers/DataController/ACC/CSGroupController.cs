using appSERP.appCode.dbCode.ACC;
using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.appCode.SQL.QueryType;
using appSERP.Models.ACC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataControllers.ACC
{///  AMR    22/1/2018
    [NoDirectAccess]
    [Authorize]
    public class CSGroupController : Controller
    {

        private IdbCustomerSupplierGroup _dbCustomerSupplierGroup;
        private IclsAPI _clsAPI;

        public CSGroupController(IdbCustomerSupplierGroup dbCustomerSupplierGroup, IclsAPI clsAPI)
        {
            _dbCustomerSupplierGroup = dbCustomerSupplierGroup;
            _clsAPI = clsAPI;
        }

        // GET: CustomerSupplierGroup
        public ActionResult Index()
        {
            // API Path
            string vPath = appAPIDirectory.vAPICustomerSupplierGroup;
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
            CustomerSupplierGroupModel vCSGroupModel = new CustomerSupplierGroupModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPICustomerSupplierGroup;
                string vParameters = "?pCSGroupId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vCSGroupModel.CSGroupId = Convert.ToInt32(vDtData.Rows[0]["CSGroupId"]);
                vCSGroupModel.CSGroupNameL1 = vDtData.Rows[0]["CSGroupNameL1"].ToString();
                vCSGroupModel.CSGroupNameL2 = vDtData.Rows[0]["CSGroupNameL2"].ToString();
                vCSGroupModel.CSGroupCreditLimit = Convert.ToInt32(vDtData.Rows[0]["CSGroupCreditLimit"].ToString());
                vCSGroupModel.CSGroupGracePeriodDays = Convert.ToInt32(vDtData.Rows[0]["CSGroupGracePeriodDays"].ToString());
                vCSGroupModel.CSGroupIsCustomerGroup = Convert.ToBoolean(vDtData.Rows[0]["CSGroupIsCustomerGroup"].ToString());
                vCSGroupModel.CSGroupIsDefault = Convert.ToBoolean(vDtData.Rows[0]["CSGroupIsDefault"].ToString());
                vCSGroupModel.CSGroupIsActive = Convert.ToBoolean(vDtData.Rows[0]["CSGroupIsActive"].ToString());
            }

            // Return Result
            return View(vCSGroupModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, CustomerSupplierGroupModel pCSGroupModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }
            try
            {

                // API Path
                string vPath = appAPIDirectory.vAPICustomerSupplierGroup;
                string vParameters =
                       "?pCSGroupId="+ id +
                       "&pCSGroupNameL1="+ pCSGroupModel.CSGroupNameL1+
                       "&pCSGroupNameL2="+ pCSGroupModel.CSGroupNameL2+
                       "&pCSGroupCreditLimit="+ pCSGroupModel.CSGroupCreditLimit+
                       "&pCSGroupGracePeriodDays="+ pCSGroupModel.CSGroupGracePeriodDays+
                       "&pCSGroupIsCustomerGroup="+ pCSGroupModel.CSGroupIsCustomerGroup+
                       "&pCSGroupIsDefault="+ pCSGroupModel.CSGroupIsDefault+
                       "&pCSGroupIsActive="+ pCSGroupModel.CSGroupIsActive+
                       "&pIsDeleted="+ pIsDelete +
                       "&pQueryTypeId=" + vQueryTypeId;
                        
               // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbCustomerSupplierGroup.vSQLResult = vDrwResult[0].ToString();
                _dbCustomerSupplierGroup.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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