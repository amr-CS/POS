using appSERP.appCode.Setting.APISetting.APIDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using appSERP.appCode.Setting.APISetting;
using appSERP.Models.ACC;
using appSERP.appCode.SQL.QueryType;
using appSERP.appCode.dbCode.ACC;
using System.Globalization;
using appSERP.appCode.Setting.GSetting.NoDirectAccessAttr;
using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.Setting.APISetting.Abstract;

namespace appSERP.Controllers.DataControllers.ACC
{
    [NoDirectAccess]
    [Authorize]
    public class GLVoucherOldController : Controller
    {

        private IdbGLVoucherOld _dbGLVoucherOld;
        private IclsAPI _clsAPI;
        public GLVoucherOldController(IdbGLVoucherOld dbGLVoucherOld, IclsAPI clsAPI)
        {
            _dbGLVoucherOld = dbGLVoucherOld;
            _clsAPI = clsAPI;
        }

        // GET: GLVoucher
        public ActionResult Index()
        {
            // API Path
            string vPath = appAPIDirectory.vAPIGLVoucher;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);
            // Return View
            if (Request.IsAjaxRequest())
            {
                return PartialView(vDtData);
            }
            return View(vDtData);
        }

        public ActionResult DataModel(string id )
        {
            //API For DocNO To Get The First and The Last 
            string vPathDoc = appAPIDirectory.vAPIGLVoucherDtl+"?pQueryTypeId=" + clsQueryType.qSelectExtra;
            DataTable vDtDataDoc = _clsAPI.funResultGet(vPathDoc);
            ViewBag.vbFirst = vDtDataDoc.Rows[0]["MinDoc"].ToString();
            ViewBag.vbLast = vDtDataDoc.Rows[0]["MaxDoc"].ToString();

            // New Id For Voucher 
            _dbGLVoucherOld.vGLVoucherId = Guid.NewGuid();
            // New Model
            GLVoucherModel vGLVoucherModel = new GLVoucherModel();
            // Edit Case
            if (id != null)
            {

                // API Path
                string vPath = appAPIDirectory.vAPIGLVoucher;
                string vParameters = "?pGLVoucherId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vGLVoucherModel.GLVoucherId =vDtData.Rows[0]["GLVoucherId"].ToString();
                vGLVoucherModel.GLVoucherCode = vDtData.Rows[0]["GLVoucherCode"].ToString();
                vGLVoucherModel.GLVoucherNameL1 = vDtData.Rows[0]["GLVoucherNameL1"].ToString();
                vGLVoucherModel.GLVoucherNameL2 = vDtData.Rows[0]["GLVoucherNameL2"].ToString();
                vGLVoucherModel.GLVoucherNo=vDtData.Rows[0]["GLVoucherNo"].ToString();
                vGLVoucherModel.VoucherTypeId = Convert.ToInt32(vDtData.Rows[0]["VoucherTypeId"].ToString());
                vGLVoucherModel.FinancialYearId = Convert.ToInt32(vDtData.Rows[0]["FinancialYearId"]);
                vGLVoucherModel.CashDeskId = Convert.ToInt32(vDtData.Rows[0]["CashDeskId"].ToString());
            //    vGLVoucherModel.GLVoucherDate =Convert.ToDateTime(vDtData.Rows[0]["GLVoucherDate"]);
                // vGLVoucherModel.GLVoucherTime = TimeSpan.Parse(vDtData.Rows[0]["GLVoucherTime"].ToString());
                vGLVoucherModel.GLVoucherRef = Convert.ToInt32(vDtData.Rows[0]["GLVoucherRef"]);
               // vGLVoucherModel.GLVoucherRefDate = Convert.ToDateTime(vDtData.Rows[0]["GLVoucherRefDate"]);
                vGLVoucherModel.PaymentTypeId = Convert.ToInt32(vDtData.Rows[0]["PaymentTypeId"]);
                vGLVoucherModel.IsPosted = Convert.ToBoolean(vDtData.Rows[0]["IsPosted"].ToString());
                vGLVoucherModel.GLVoucherNote = vDtData.Rows[0]["GLVoucherNote"].ToString();
                vGLVoucherModel.DocIsCancelled = Convert.ToBoolean(vDtData.Rows[0]["DocIsCancelled"]);
                vGLVoucherModel.DocIsWait = Convert.ToBoolean(vDtData.Rows[0]["DocIsWait"].ToString());
                vGLVoucherModel.GLVoucherIsRepeated = Convert.ToBoolean(vDtData.Rows[0]["GLVoucherIsRepeated"]);
                vGLVoucherModel.GLIdPayType = Convert.ToInt32(vDtData.Rows[0]["GLIdPayType"].ToString());
                vGLVoucherModel.GLVoucherCategoryId = Convert.ToInt32(vDtData.Rows[0]["GLVoucherCategoryId"]);
                vGLVoucherModel.GLOppsVoucherValue = Convert.ToDecimal(vDtData.Rows[0]["GLOppsVoucherValue"].ToString());
                vGLVoucherModel.GLOppsVoucherId = Convert.ToInt32(vDtData.Rows[0]["GLOppsVoucherId"]);
                vGLVoucherModel.GLOppsVoucherYearId = Convert.ToInt32(vDtData.Rows[0]["GLOppsVoucherYearId"].ToString());
                vGLVoucherModel.StoreId = Convert.ToInt32(vDtData.Rows[0]["StoreId"]);
                vGLVoucherModel.InvTransactionTypeId = Convert.ToInt32(vDtData.Rows[0]["InvTransactionTypeId"].ToString());
                vGLVoucherModel.CSId = Convert.ToInt32(vDtData.Rows[0]["CSId"]);
                vGLVoucherModel.VoucherSeq = Convert.ToInt32(vDtData.Rows[0]["VoucherSeq"].ToString());
                vGLVoucherModel.GLVoucherIsActive = Convert.ToBoolean(vDtData.Rows[0]["GLVoucherIsActive"]);


                // API For Voucher Details
                string vPathD = appAPIDirectory.vAPIGLVoucherDtl;
                string vParameterD = "?pGLVoucherId=" + id;
                // Result
                DataTable vDtDataD = _clsAPI.funResultGet(vPathD + vParameterD);
                ViewBag.vbVoucherDtl = vDtDataD.AsDataView();
            }
            // Return Result
            return View(vGLVoucherModel);
        }

        [HttpPost]
        public int DataModel(int? id = 0, GLVoucherModel pGLVoucherModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            string vVoucherId = _dbGLVoucherOld.vGLVoucherId.ToString();
            int vQueryTypeId = clsQueryType.qInsert;
            if (pGLVoucherModel.GLVoucherId != null)
            {
                vQueryTypeId = clsQueryType.qUpdate;
                vVoucherId = pGLVoucherModel.GLVoucherId;
            }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            try
            {
               
                // API Path
                string vPath = appAPIDirectory.vAPIGLVoucher;
                string vParameters =
                 "?pGLVoucherId=" + vVoucherId +
                "&pGLVoucherCode=" + pGLVoucherModel.GLVoucherCode +
                "&pGLVoucherNameL1=" + pGLVoucherModel.GLVoucherNameL1 +
                "&pGLVoucherNameL2=" + pGLVoucherModel.GLVoucherNameL2 +
                "&pGLVoucherNo=" + pGLVoucherModel.GLVoucherNo +
                "&pVoucherTypeId=" + pGLVoucherModel.VoucherTypeId +
                "&pFinancialYearId=" + pGLVoucherModel.FinancialYearId +
                "&pCashDeskId=" + pGLVoucherModel.CashDeskId +
                "&pGLVoucherDate=" + DateTime.Parse(pGLVoucherModel.GLVoucherDate.ToString()) +
                //"&pGLVoucherTime=" + pGLVoucherModel.GLVoucherTime +
                "&pGLVoucherRef=" + pGLVoucherModel.GLVoucherRef +
                "&pGLVoucherRefDate=" + DateTime.Parse(pGLVoucherModel.GLVoucherRefDate.ToString()) +
                "&pPaymentTypeId=" + pGLVoucherModel.PaymentTypeId +
                "&pIsPosted=" + pGLVoucherModel.IsPosted +
                "&pIsIssued=" + pGLVoucherModel.IsIssued +
                "&pGLVoucherNote=" + pGLVoucherModel.GLVoucherNote +
                "&pDocIsCancelled=" + pGLVoucherModel.DocIsCancelled +
                "&pDocIsWait=" + pGLVoucherModel.DocIsWait +
                "&pGLVoucherIsRepeated=" + pGLVoucherModel.GLVoucherIsRepeated +
                "&pGLIdPayType=" + pGLVoucherModel.GLIdPayType +
                "&pGLVoucherCategoryId=" + pGLVoucherModel.GLVoucherCategoryId +
                "&pGLOppsVoucherValue=" + pGLVoucherModel.GLOppsVoucherValue +
                "&pGLOppsVoucherId=" + pGLVoucherModel.GLOppsVoucherId +
                "&pGLOppsVoucherYearId=" + pGLVoucherModel.GLOppsVoucherYearId +
                "&pStoreId=" + pGLVoucherModel.StoreId +
                "&pInvTransactionTypeId=" + pGLVoucherModel.InvTransactionTypeId +
                "&pCSId=" + pGLVoucherModel.CSId +
                "&pVoucherSeq=" + pGLVoucherModel.VoucherSeq +
                "&pGLVoucherIsActive=" + pGLVoucherModel.GLVoucherIsActive +
                "&pIsDeleted=" + pIsDelete +
                "&pQueryTypeId=" + vQueryTypeId;
                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbGLVoucherOld.vSQLResult = vDrwResult[0].ToString();
                _dbGLVoucherOld.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);
                // Go To Index
                return 1;
            }
            catch (Exception ex)
            {
                return 1;
            }
        }
        // Insert Details
        [HttpPost]
        public ActionResult funSaveVoucherDtl(int? id=0, GLVoucherDtlModel[] vGLVoucherDtl= null, bool? pIsDelete = false)
        { 
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
          
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }
            try
            {
                string vId = _dbGLVoucherOld.vGLVoucherId.ToString();
                foreach (var GLVoucherDtl in vGLVoucherDtl)
                {
                    if (GLVoucherDtl.GLVoucherDtlId != 0)
                    {
                        vQueryTypeId = clsQueryType.qUpdate;
                        id = GLVoucherDtl.GLVoucherDtlId;
                        vId = GLVoucherDtl.GLVoucherId.ToString();
                    }

                    // API Path
                    string vPath = appAPIDirectory.vAPIGLVoucherDtl;
                    string vParameters =
                        "?pGLVoucherDtlId=" + id +
                        "&pGLVoucherDtlNameL1=" + GLVoucherDtl.GLVoucherDtlNameL1 +
                        "&pGLVoucherId=" + vId +
                        "&pAccountId=" + GLVoucherDtl.AccountId +
                        "&pCashDeskId=" + GLVoucherDtl.CashDeskId +
                        "&pCurrencyId=" + GLVoucherDtl.CurrencyId +
                        "&pGLVoucherDtlDebit=" + GLVoucherDtl.GLVoucherDtlDebit +
                        "&pGLVoucherDtlCredit=" + GLVoucherDtl.GLVoucherDtlCredit +
                        "&pGLVoucherDtlDebitBase=" + GLVoucherDtl.GLVoucherDtlDebitBase +
                        "&pGLVoucherDtlCreditBase=" + GLVoucherDtl.GLVoucherDtlCreditBase +
                        "&pGLVoucherDtlPayDebit=" + GLVoucherDtl.GLVoucherDtlPayDebit+
                        "&pGLVoucherDtlPayCredit="+ GLVoucherDtl.GLVoucherDtlPayCredit+
                        "&pBaseCurrencyValue=" + GLVoucherDtl.BaseCurrencyValue +
                        "&pGLVoucherDtlTransSeq=" + GLVoucherDtl.GLVoucherDtlTransSeq +
                        "&pCostCenterId=" + GLVoucherDtl.CostCenterId +
                        "&pGLVoucherDtlNote=" + GLVoucherDtl.GLVoucherDtlNote +
                        "&pIsDeleted=" +pIsDelete+
                        "&pQueryTypeId=" + vQueryTypeId;
                    // SQL Result
                    DataRow vDrwResultV = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                    _dbGLVoucherOld.vSQLResult = vDrwResultV[0].ToString();
                    _dbGLVoucherOld.vSQLResultTypeId = Convert.ToInt32(vDrwResultV[1]);

                }
                // Go To Index
                return RedirectToAction("DataModel");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        // Posted 
        public bool funDocPosted()
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qDocPosted;
            string vVoucherId = _dbGLVoucherOld.vGLVoucherId.ToString();
            // API Path
            string vPath = appAPIDirectory.vAPIGLVoucher;
            string vParameters =
            "?pGLVoucherId=" + vVoucherId +
            "&pIsPosted=" + true +
            "&pQueryTypeId=" + vQueryTypeId;
            string vP = vPath + vParameters;
            // SQL Result
            DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
            _dbGLVoucherOld.vSQLResult = vDrwResult[0].ToString();
            _dbGLVoucherOld.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);
            return true;
        }
        // DocWait 
        public bool funDocWait()
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qDocWait;
            string vVoucherId = _dbGLVoucherOld.vGLVoucherId.ToString();
            // API Path
            string vPath = appAPIDirectory.vAPIGLVoucher;
            string vParameters =
            "?pGLVoucherId=" + vVoucherId +
            "&pDocIsWait=" + true +
            "&pQueryTypeId=" + vQueryTypeId;
            string vP = vPath + vParameters;
            // SQL Result
            DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
            _dbGLVoucherOld.vSQLResult = vDrwResult[0].ToString();
            _dbGLVoucherOld.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);
            return true;
        }
        // DocCanceled
        public bool funDocCancel()
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qDocCancel;
            string vVoucherId = _dbGLVoucherOld.vGLVoucherId.ToString();
            // API Path
            string vPath = appAPIDirectory.vAPIGLVoucher;
            string vParameters =
            "?pGLVoucherId=" + vVoucherId +
            "&pDocIsCancelled=" + true +
            "&pQueryTypeId=" + vQueryTypeId;
            string vP = vPath + vParameters;
            // SQL Result
            DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
            _dbGLVoucherOld.vSQLResult = vDrwResult[0].ToString();
            _dbGLVoucherOld.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);
            return true;
        }
        // DocIssued
        public bool funDocIssued()
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qDocIssued;
            string vVoucherId = _dbGLVoucherOld.vGLVoucherId.ToString();
            // API Path
            string vPath = appAPIDirectory.vAPIGLVoucher;
            string vParameters =
            "?pGLVoucherId=" + vVoucherId +
            "&pIsIssued=" + true +
            "&pQueryTypeId=" + vQueryTypeId;
            string vP = vPath + vParameters;
            // SQL Result
            DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
            _dbGLVoucherOld.vSQLResult = vDrwResult[0].ToString();
            _dbGLVoucherOld.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);
            return true;
        }

        public ActionResult SearchGLVoucher()
        {
            // API Path
            string vPath = appAPIDirectory.vAPIGLVoucher;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);
            ViewBag.vbGlVoucher = vDtData.AsDataView();
            return View();
        }



    }
}