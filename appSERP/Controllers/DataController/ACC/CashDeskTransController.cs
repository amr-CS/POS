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
{
    [NoDirectAccess]
    [Authorize]
    public class CashDeskTransController : Controller
    {
        private IdbGLVoucherOld _dbGLVoucherOld;
        private IdbCashDeskTrans _dbCashDeskTrans;
        private IclsAPI _clsAPI;
        public CashDeskTransController(IdbGLVoucherOld dbGLVoucherOld, IdbCashDeskTrans dbCashDeskTrans, IclsAPI clsAPI)
        {
            _dbGLVoucherOld = dbGLVoucherOld;
            _dbCashDeskTrans = dbCashDeskTrans;
            _clsAPI = clsAPI;
        }

        // GET: CashDeskTrans
        public ActionResult Index()
        {
            // API Path
            string vPath = appAPIDirectory.vAPICashDeskTrans;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);
            // Return View
            if (Request.IsAjaxRequest())
            {
                return PartialView(vDtData);
            }
            return View(vDtData);
        }

        public ActionResult DataModel(string id,string pIsCashDeskIn )
        {
            //API For DocNO To Get The First and The Last 
            string vPathDoc = appAPIDirectory.vAPICashDeskDtl + "?pQueryTypeId=" + clsQueryType.qSelectExtra;
            DataTable vDtDataDoc = _clsAPI.funResultGet(vPathDoc);
            ViewBag.vbFirst = vDtDataDoc.Rows[0]["MinDoc"].ToString();
            ViewBag.vbLast = vDtDataDoc.Rows[0]["MaxDoc"].ToString();
            // New Id For Voucher 
            _dbCashDeskTrans.vCashDeskTransId = Guid.NewGuid();
            // New Model
            CashDeskTransModel vCashDeskTransModel = new CashDeskTransModel();
            _dbCashDeskTrans.vIsCashDeskTransIn = Convert.ToBoolean(pIsCashDeskIn);
            // Edit Case
            if (id != null)
            {
                // API Path
                string vPath = appAPIDirectory.vAPICashDeskTrans;
                string vParameters = "?pCashDeskTransId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vCashDeskTransModel.CashDeskTransId = vDtData.Rows[0]["CashDeskTransId"].ToString();
                _dbCashDeskTrans.vCashDeskTransId = vDtData.Rows[0]["CashDeskTransId"].ToString();
                vCashDeskTransModel.CashDeskTransCode = vDtData.Rows[0]["CashDeskTransCode"].ToString();
                vCashDeskTransModel.CashDeskTransNameL1 = vDtData.Rows[0]["CashDeskTransNameL1"].ToString();
                vCashDeskTransModel.CashDeskTransNameL2 = vDtData.Rows[0]["CashDeskTransNameL2"].ToString();
                vCashDeskTransModel.CashDeskTransNo = vDtData.Rows[0]["CashDeskTransNo"].ToString();
                vCashDeskTransModel.VoucherTypeId = Convert.ToInt32(vDtData.Rows[0]["VoucherTypeId"].ToString());
                vCashDeskTransModel.FinancialYearId = Convert.ToInt32(vDtData.Rows[0]["FinancialYearId"]);
                vCashDeskTransModel.CashDeskId = Convert.ToInt32(vDtData.Rows[0]["CashDeskId"].ToString());
               // vCashDeskTransModel.CashDeskTransDate = Convert.ToDateTime(Convert.ToDateTime(vDtData.Rows[0]["CashDeskTransDate"]).ToString("yyyy-MM-dd")).Date;
               // vCashDeskTransModel.CashDeskTransTime = TimeSpan.Parse(vDtData.Rows[0]["CashDeskTransTime"].ToString());
                vCashDeskTransModel.CashDeskTransRef = Convert.ToInt32(vDtData.Rows[0]["CashDeskTransRef"]);
               // vCashDeskTransModel.CashDeskTransRefDate = DateTime.Parse(vDtData.Rows[0]["CashDeskTransRefDate"].ToString());
                vCashDeskTransModel.PaymentTypeId = Convert.ToInt32(vDtData.Rows[0]["PaymentTypeId"]);
                vCashDeskTransModel.IsPosted = Convert.ToBoolean(vDtData.Rows[0]["IsPosted"].ToString());
                vCashDeskTransModel.CashDeskTransNote = vDtData.Rows[0]["CashDeskTransNote"].ToString();
                vCashDeskTransModel.DocIsCancelled = Convert.ToBoolean(vDtData.Rows[0]["DocIsCancelled"]);
                vCashDeskTransModel.DocIsWait = Convert.ToBoolean(vDtData.Rows[0]["DocIsWait"].ToString());
                vCashDeskTransModel.IsIssued = Convert.ToBoolean(vDtData.Rows[0]["IsIssued"].ToString());
                vCashDeskTransModel.IsCashDeskIn = Convert.ToBoolean(vDtData.Rows[0]["IsCashDeskIn"].ToString());
                vCashDeskTransModel.CashDeskTransIsRepeated = Convert.ToBoolean(vDtData.Rows[0]["CashDeskTransIsRepeated"]);
                vCashDeskTransModel.GLIdPayType = Convert.ToInt32(vDtData.Rows[0]["GLIdPayType"].ToString());
                vCashDeskTransModel.CashDeskTransCategoryId = Convert.ToInt32(vDtData.Rows[0]["CashDeskTransCategoryId"]);
                vCashDeskTransModel.GLOppsVoucherValue = Convert.ToDecimal(vDtData.Rows[0]["GLOppsVoucherValue"].ToString());
                vCashDeskTransModel.GLOppsVoucherId = Convert.ToInt32(vDtData.Rows[0]["GLOppsVoucherId"]);
                vCashDeskTransModel.GLOppsVoucherYearId = Convert.ToInt32(vDtData.Rows[0]["GLOppsVoucherYearId"].ToString());
                vCashDeskTransModel.StoreId = Convert.ToInt32(vDtData.Rows[0]["StoreId"]);
                vCashDeskTransModel.InvTransactionTypeId = Convert.ToInt32(vDtData.Rows[0]["InvTransactionTypeId"].ToString());
                vCashDeskTransModel.CSId = Convert.ToInt32(vDtData.Rows[0]["CSId"]);
                vCashDeskTransModel.VoucherSeq = Convert.ToInt32(vDtData.Rows[0]["VoucherSeq"].ToString());
                vCashDeskTransModel.CashDeskTransIsActive = Convert.ToBoolean(vDtData.Rows[0]["CashDeskTransIsActive"]);
                // API For Voucher Details
                string vPathD = appAPIDirectory.vAPICashDeskDtl;
                string vParameterD = "?pCashDeskTransId=" + id;
                // Result
                DataTable vDtDataD = _clsAPI.funResultGet(vPathD + vParameterD);
                ViewBag.vbCashDeskDtl = vDtDataD.AsDataView();
            }
            // Return Result
            return View(vCashDeskTransModel);
        }

        [HttpPost]
        public int DataModel(int? id = 0, CashDeskTransModel pCashDeskTransModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            try
            {
                string vCashDeskTransId = _dbCashDeskTrans.vCashDeskTransId.ToString();
                bool vIsCashDeskTransIn = _dbCashDeskTrans.vIsCashDeskTransIn;
                // API Path
                string vPath = appAPIDirectory.vAPICashDeskTrans;
                string vParameters =
                "?pCashDeskTransId=" + vCashDeskTransId +
                "&pCashDeskTransCode=" + pCashDeskTransModel.CashDeskTransCode +
                "&pCashDeskTransNameL1=" + pCashDeskTransModel.CashDeskTransNameL1 +
                "&pCashDeskTransNameL2=" + pCashDeskTransModel.CashDeskTransNameL2 +
                "&pCashDeskTransNo=" + pCashDeskTransModel.CashDeskTransNo +
                "&pVoucherTypeId=" + pCashDeskTransModel.VoucherTypeId +
                "&pFinancialYearId=" + pCashDeskTransModel.FinancialYearId +
                "&pCashDeskId=" + pCashDeskTransModel.CashDeskId +
                "&pMainCashDeskId=" + pCashDeskTransModel.MainCashDeskId +
                "&pGLVoucherId=" + pCashDeskTransModel.GLVoucherId +
                "&pCashDeskTransDate=" + pCashDeskTransModel.CashDeskTransDate +
                "&pCashDeskTransTime=" + pCashDeskTransModel.CashDeskTransTime +
                "&pCashDeskTransRef=" + pCashDeskTransModel.CashDeskTransRef +
                "&pCashDeskTransRefDate=" + pCashDeskTransModel.CashDeskTransRefDate +
                "&pPaymentTypeId=" + pCashDeskTransModel.PaymentTypeId +
                "&pIsPosted=" + pCashDeskTransModel.IsPosted +
                "&pIsIssued=" + pCashDeskTransModel.IsIssued +
                "&pIsCashDeskIn=" + vIsCashDeskTransIn +
                "&pCashDeskTransNote=" + pCashDeskTransModel.CashDeskTransNote +
                "&pDocIsCancelled=" + pCashDeskTransModel.DocIsCancelled +
                "&pDocIsWait=" + pCashDeskTransModel.DocIsWait +
                "&pCashDeskTransIsRepeated=" + pCashDeskTransModel.CashDeskTransIsRepeated +
                "&pGLIdPayType=" + pCashDeskTransModel.GLIdPayType +
                "&pCashDeskTransCategoryId=" + pCashDeskTransModel.CashDeskTransCategoryId +
                "&pGLOppsVoucherValue=" + pCashDeskTransModel.GLOppsVoucherValue +
                "&pGLOppsVoucherId=" + pCashDeskTransModel.GLOppsVoucherId +
                "&pGLOppsVoucherYearId=" + pCashDeskTransModel.GLOppsVoucherYearId +
                "&pStoreId=" + pCashDeskTransModel.StoreId +
                "&pInvTransactionTypeId=" + pCashDeskTransModel.InvTransactionTypeId +
                "&pCSId=" + pCashDeskTransModel.CSId +
                "&pVoucherSeq=" + pCashDeskTransModel.VoucherSeq +
                "&pCashDeskTransIsActive=" + pCashDeskTransModel.CashDeskTransIsActive +
                "&pIsDeleted=" + pIsDelete +
                "&pQueryTypeId=" + vQueryTypeId;
                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbCashDeskTrans.vSQLResult = vDrwResult[0].ToString();
                _dbCashDeskTrans.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);
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
        public ActionResult funSaveCashDeskDtl(int? id = 0, CashDeskDtlModel[] vCashDeskDtl = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }
            try
            {
                string vId = _dbCashDeskTrans.vCashDeskTransId.ToString();
                foreach (var CashDeskDtl in vCashDeskDtl)
                {
                    // API Path
                    string vPath = appAPIDirectory.vAPICashDeskDtl;
                    string vParameters =
                        "?pCashDeskDtlId=" + id +
                        "&pCashDeskDtlNameL1=" + CashDeskDtl.CashDeskDtlNameL1 +
                        "&pCashDeskTransId=" + vId +
                        "&pAccountId=" + CashDeskDtl.AccountId +
                        "&pCashDeskId=" + CashDeskDtl.CashDeskId +
                        "&pCurrencyId=" + CashDeskDtl.CurrencyId +
                        "&pCashDeskDtlDebit=" + CashDeskDtl.CashDeskDtlDebit +
                        "&pCashDeskDtlCredit=" + CashDeskDtl.CashDeskDtlCredit +
                        "&pCashDeskDtlDebitBase=" + CashDeskDtl.CashDeskDtlDebitBase +
                        "&pCashDeskDtlCreditBase=" + CashDeskDtl.CashDeskDtlCreditBase +
                        "&pCashDeskDtlPayDebit=" + CashDeskDtl.CashDeskDtlPayDebit +
                        "&pCashDeskDtlPayCredit=" + CashDeskDtl.CashDeskDtlPayCredit +
                        "&pBaseCurrencyValue=" + CashDeskDtl.BaseCurrencyValue +
                        "&pCashDeskDtlTransSeq=" + CashDeskDtl.CashDeskDtlTransSeq +
                        "&pCashDeskDtlNote=" + CashDeskDtl.CashDeskDtlNote +
                        "&pCostCenter=" + CashDeskDtl.CostCenterId +
                        "&pIsDeleted=" + pIsDelete +
                        "&pQueryTypeId=" + vQueryTypeId;
                    // SQL Result
                    DataRow vDrwResultV = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                    _dbGLVoucherOld.vSQLResult = vDrwResultV[0].ToString();
                    _dbGLVoucherOld.vSQLResultTypeId = Convert.ToInt32(vDrwResultV[1]);

                }
                // Go To Index
                return null;
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
            string vVoucherId = _dbCashDeskTrans.vCashDeskTransId.ToString();
            // API Path
            string vPath = appAPIDirectory.vAPICashDeskTrans;
            string vParameters =
            "?pCashDeskTransId=" + vVoucherId +
            "&pIsPosted=" + true +
            "&pQueryTypeId=" + vQueryTypeId;
            string vP = vPath + vParameters;
            // SQL Result
            DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
            _dbCashDeskTrans.vSQLResult = vDrwResult[0].ToString();
            _dbCashDeskTrans.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);
            return true;
        }
        // DocWait 
        public bool funDocWait()
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qDocWait;
            string vVoucherId = _dbCashDeskTrans.vCashDeskTransId.ToString();
            // API Path
            string vPath = appAPIDirectory.vAPICashDeskTrans;
            string vParameters =
            "?pCashDeskTransId=" + vVoucherId +
            "&pDocIsWait=" + true +
            "&pQueryTypeId=" + vQueryTypeId;
            string vP = vPath + vParameters;
            // SQL Result
            DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
            _dbCashDeskTrans.vSQLResult = vDrwResult[0].ToString();
            _dbCashDeskTrans.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);
            return true;
        }
        // DocCanceled
        public bool funDocCancel()
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qDocCancel;
            string vVoucherId = _dbCashDeskTrans.vCashDeskTransId.ToString();
            // API Path
            string vPath = appAPIDirectory.vAPICashDeskTrans;
            string vParameters =
            "?pCashDeskTransId=" + vVoucherId +
            "&pDocIsCancelled=" + true +
            "&pQueryTypeId=" + vQueryTypeId;
            string vP = vPath + vParameters;
            // SQL Result
            DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
            _dbCashDeskTrans.vSQLResult = vDrwResult[0].ToString();
            _dbCashDeskTrans.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);
            return true;
        }
        // DocIssued
        public bool funDocIssued()
        {
            CashDeskTransModel vCashDeskTransModel = new CashDeskTransModel();
            
            // Check Operation
            int vQueryTypeId = clsQueryType.qDocIssued;
            string vVoucherId = _dbCashDeskTrans.vCashDeskTransId.ToString();
            // API Path
            string vPath = appAPIDirectory.vAPICashDeskTrans;
            string vParameters =
            "?pCashDeskTransId=" + vVoucherId +
            "&pIsIssued=" + true +
            "&pQueryTypeId=" + vQueryTypeId;
            string vP = vPath + vParameters;
            // SQL Result
            DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
            _dbCashDeskTrans.vSQLResult = vDrwResult[0].ToString();
            _dbCashDeskTrans.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);
            return true;
        }
        public ActionResult SearchCashDesk()
        {
            // API Path
            string vPath = appAPIDirectory.vAPICashDeskTrans;
            string vParmater = "?pIsCashDeskIn=" + _dbCashDeskTrans.vIsCashDeskTransIn;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath+ vParmater);
            ViewBag.vbCashDeskTrans = vDtData.AsDataView();
            return View();
        }
   
    }
}