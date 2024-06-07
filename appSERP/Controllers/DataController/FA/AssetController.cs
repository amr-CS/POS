using appSERP.appCode.dbCode.FA;
using appSERP.appCode.dbCode.FA.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.ExcelSetting;
using appSERP.appCode.Setting.GSetting;
using appSERP.appCode.Setting.ReportSetting;
using appSERP.appCode.SQL.QueryType;
using appSERP.Models.FA;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataController.FA
{
    public class AssetController : Controller
    {
        private IdbAsset _dbAsset;
        private IclsAPI _clsAPI;
        public AssetController(IdbAsset dbAsset, IclsAPI clsAPI)
        {
            _dbAsset = dbAsset;
            _clsAPI = clsAPI;
        }
        // GET: Asset
        public ActionResult Index()
        {
            // API Path
            string vPath = appAPIDirectory.vAPIAsset;
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
            AssetModel vAssetModel = new AssetModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPIAsset;
                string vParameters = "?pAssetId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vAssetModel.AssetId = Convert.ToInt32(vDtData.Rows[0]["AssetId"]);
                vAssetModel.AssetNameL1 = vDtData.Rows[0]["AssetNameL1"].ToString();
                vAssetModel.AssetNameL2 = vDtData.Rows[0]["AssetNameL2"].ToString();
                vAssetModel.AssetIsActive = Convert.ToBoolean(vDtData.Rows[0]["AssetIsActive"]);
                vAssetModel.AssetCode  = vDtData.Rows[0]["AssetCode"].ToString();
                vAssetModel.AssetQty  = Convert.ToInt32(vDtData.Rows[0]["AssetQty"].ToString());
                vAssetModel.AssetPurchasePrice  = Convert.ToDecimal(vDtData.Rows[0]["AssetPurchasePrice"].ToString());
                vAssetModel.CurrencyId  = Convert.ToInt32(vDtData.Rows[0]["CurrencyId"].ToString());
                vAssetModel.CurrencyValue  = Convert.ToDecimal(vDtData.Rows[0]["CurrencyValue"].ToString());
                vAssetModel.AssetPurchasePriceBase  = Convert.ToDecimal(vDtData.Rows[0]["AssetPurchasePriceBase"].ToString());
                vAssetModel.AssetBookValue  = Convert.ToDecimal(vDtData.Rows[0]["AssetBookValue"].ToString());
                vAssetModel.AssetBookValueBase  = Convert.ToDecimal(vDtData.Rows[0]["AssetBookValueBase"].ToString());
                vAssetModel.AssetPercent  = Convert.ToInt32(vDtData.Rows[0]["AssetPercent"].ToString());
                vAssetModel.AssetLastDepDate  = Convert.ToDateTime(vDtData.Rows[0]["AssetLastDepDate"].ToString());
                vAssetModel.PostDate  = Convert.ToDateTime(vDtData.Rows[0]["PostDate"].ToString());
                vAssetModel.AssetTotalDep  = Convert.ToInt32(vDtData.Rows[0]["AssetTotalDep"].ToString());
                vAssetModel.AssetTotalDepBase  = Convert.ToInt32(vDtData.Rows[0]["AssetTotalDepBase"].ToString());
                vAssetModel.BillNo  = Convert.ToInt32(vDtData.Rows[0]["BillNo"].ToString());
                vAssetModel.PurchaseNo  = Convert.ToInt32(vDtData.Rows[0]["PurchaseNo"].ToString());
                vAssetModel.PurchaseDate  = Convert.ToDateTime(vDtData.Rows[0]["PurchaseDate"].ToString());
                vAssetModel.IsAutoPost  = Convert.ToBoolean(vDtData.Rows[0]["IsAutoPost"].ToString());
                vAssetModel.IsPosted  = Convert.ToBoolean(vDtData.Rows[0]["IsPosted"].ToString());
                vAssetModel.AssetDebitAccount  = Convert.ToDecimal(vDtData.Rows[0]["AssetDebitAccount"].ToString());
                vAssetModel.AssetCreditAccount  = Convert.ToDecimal(vDtData.Rows[0]["AssetCreditAccount"].ToString());
                vAssetModel.AssetPurchaseAccount  = Convert.ToDecimal(vDtData.Rows[0]["AssetPurchaseAccount"].ToString());
                vAssetModel.AssetSalesAccount  = Convert.ToDecimal(vDtData.Rows[0]["AssetSalesAccount"].ToString());
                vAssetModel.AssetAccountId  = Convert.ToInt32(vDtData.Rows[0]["AssetAccountId"].ToString());
                vAssetModel.AssetSupplierId  = Convert.ToInt32(vDtData.Rows[0]["AssetSupplierId"].ToString());
                vAssetModel.AssetSupplierName  =vDtData.Rows[0]["AssetSupplierName"].ToString();
                vAssetModel.AssetMinPrice  = Convert.ToDecimal(vDtData.Rows[0]["AssetMinPrice"].ToString());
                vAssetModel.AssetMinPriceBase  = Convert.ToDecimal(vDtData.Rows[0]["AssetMinPriceBase"].ToString());
                vAssetModel.ProductPeriod  = Convert.ToInt32(vDtData.Rows[0]["ProductPeriod"].ToString());
                vAssetModel.InvItemId  = Convert.ToInt32(vDtData.Rows[0]["InvItemId"].ToString());
                vAssetModel.InvItemName  = vDtData.Rows[0]["InvItemName"].ToString();
                vAssetModel.FixedAssetMethodId  = Convert.ToInt32(vDtData.Rows[0]["FixedAssetMethodId"].ToString());
                vAssetModel.FixedAssetUnitId  = Convert.ToInt32(vDtData.Rows[0]["FixedAssetUnitId"].ToString());
                vAssetModel.DonorId  = Convert.ToInt32(vDtData.Rows[0]["DonorId"].ToString());
                vAssetModel.BuyGroupId  = Convert.ToInt32(vDtData.Rows[0]["BuyGroupId"].ToString());
                vAssetModel.FixedAssetCompanyId  = Convert.ToInt32(vDtData.Rows[0]["FixedAssetCompanyId"].ToString());
            }

            // Return Result
            return View(vAssetModel);
        }

        [HttpPost]
        public ActionResult DataModel(int? id = 0, AssetModel pAssetModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            string vPostDate = pAssetModel.PostDate.ToString("dd-MM-yyyy");
            string vPurchaseDate = pAssetModel.PurchaseDate.ToString("dd-MM-yyyy");
            string vAssetLastDepDate = pAssetModel.AssetLastDepDate.ToString("dd-MM-yyyy");
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete))
            {
                vQueryTypeId = clsQueryType.qDelete;
                  vPostDate = pAssetModel.PostDate.ToString();
                 vPurchaseDate = pAssetModel.PurchaseDate.ToString();
                 vAssetLastDepDate= pAssetModel.AssetLastDepDate.ToString();
            }
            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPIAsset;
                string vParameters =
                    "?pAssetId=" + id +
                    "&pAssetNameL1=" + pAssetModel.AssetNameL1 +
                    "&pAssetNameL2= " + pAssetModel.AssetNameL2 +
                    "&pAssetIsActive=" + pAssetModel.AssetIsActive +
                    "&pAssetCode=" + pAssetModel.AssetCode +
                    "&pAssetQty=" + pAssetModel.AssetQty +
                    "&pAssetPurchasePrice=" + pAssetModel +
                    "&pCurrencyId=" + pAssetModel.CurrencyId +
                    "&pCurrencyValue=" + pAssetModel.CurrencyValue +
                    "&pAssetPurchasePriceBase=" + pAssetModel.AssetPurchasePriceBase +
                    "&pAssetBookValue=" + pAssetModel.AssetBookValue +
                    "&pAssetBookValueBase=" + pAssetModel.AssetBookValueBase +
                    "&pAssetPercent=" + pAssetModel.AssetPercent +
                    "&pAssetLastDepDate=" + vAssetLastDepDate +
                    "&pPostDate=" + vPostDate +
                    "&pAssetTotalDep=" + pAssetModel.AssetTotalDep +
                    "&pAssetTotalDepBase=" + pAssetModel.AssetTotalDepBase +
                    "&pBillNo=" + pAssetModel.BillNo +
                    "&pPurchaseNo=" + pAssetModel.PurchaseNo +
                    "&pPurchaseDate=" + vPurchaseDate +
                    "&pIsAutoPost=" + pAssetModel.IsAutoPost +
                    "&pIsPosted=" + pAssetModel.IsPosted +
                    "&pAssetDebitAccount=" + pAssetModel.AssetDebitAccount +
                    "&pAssetCreditAccount=" + pAssetModel.AssetCreditAccount +
                    "&pAssetPurchaseAccount=" + pAssetModel.AssetPurchaseAccount +
                    "&pAssetSalesAccount=" + pAssetModel.AssetSalesAccount +
                    "&pAssetAccountId=" + pAssetModel.AssetAccountId +
                    "&pAssetSupplierId=" + pAssetModel.AssetSupplierId +
                    "&pAssetSupplierName=" + pAssetModel.AssetSupplierName +
                    "&pAssetMinPrice=" + pAssetModel.AssetMinPrice +
                    "&pAssetMinPriceBase=" + pAssetModel.AssetPurchasePriceBase +
                    "&pProductPeriod=" + pAssetModel.ProductPeriod +
                    "&pInvItemId=" + pAssetModel.InvItemId +
                    "&pInvItemName=" + pAssetModel.InvItemName +
                    "&pFixedAssetMethodId=" + pAssetModel.FixedAssetMethodId +
                    "&pFixedAssetUnitId=" + pAssetModel.FixedAssetUnitId +
                    "&pDonorId=" + pAssetModel.DonorId +
                    "&pBuyGroupId=" + pAssetModel.BuyGroupId +
                    "&pFixedAssetCompanyId=" + pAssetModel.FixedAssetCompanyId +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;
                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbAsset.vSQLResult = vDrwResult[0].ToString();
                _dbAsset.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

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
        // Asset Excel
        public ActionResult AssetExcel()
        {


            return View();
        }
        // Asset Excel File
        public ActionResult AssetExcelFile(HttpPostedFileBase pExcelFile = null)
        {
            // Check File [Image]
            if (pExcelFile != null)
            {
                // Set Model [Image Path] [Save and Get Path]
                string vExcelFile = Server.MapPath(clsFileSave.funFileSave(pExcelFile, "/dataFiles/Excel", ""));
                // Data Table
                DataTable vDtExcelData = clsExcel.funExcelToDataTable(vExcelFile);
                // ViewBag
                ViewBag.vbExcelData = vDtExcelData;
            }

            return View();
        }
        // Excel Save
        public string AssetExcelSave(
             string pAssetNameL1 = null,
                    string pAssetNameL2= null,
                     string pAssetCode = null,
                     string pAssetQty = null,
                    string pAssetPurchasePrice = null,
                   string pCurrencyNameL1 = null,
                   string pCurrencyValue = null,
                   string pAssetPurchasePriceBase = null,
                   string pAssetBookValue = null,
                    string pAssetBookValueBase = null,
                    string pAssetPercent = null,
                   string pAssetLastDepDate = null,
                    string pPostDate = null,
                    string pBillNo = null,
                    string pPurchaseNo = null,
                   string pPurchaseDate = null,
                   string pAssetSupplierName = null,
                   string pAssetMinPrice = null,
                    string pAssetMinPriceBase = null,
                    string pProductPeriod = null,
                     string pMainGroup = null,
                     string pGroup = null,
                     string pFixedAssetMethod = null,
                     string pDonor = null,
                   string pBuyGroup = null,
                   string pFixedAssetCompanyName = null
            )
        {
            try
            {
                int id = 0;
                string vPostDate = Convert.ToDateTime(pPostDate).ToString("dd-MM-yyyy");
                string vPurchaseDate = Convert.ToDateTime(pPurchaseDate).ToString("dd-MM-yyyy");
                string vAssetLastDepDate = Convert.ToDateTime(pAssetLastDepDate).ToString("dd-MM-yyyy");
                int vQueryTypeId = clsQueryType.qInsert;
                // API Path
                string vPath = appAPIDirectory.vAPIAssetExcelSave;

                string vParameters =
                    //"?pAssetId=" + id +
                    "?pAssetNameL1=" + pAssetNameL1 +
                    "&pAssetNameL2= " + pAssetNameL2 +
                    "&pAssetIsActive=" + true +
                    "&pAssetCode=" + pAssetCode +
                    "&pAssetQty=" + pAssetQty +
                    "&pAssetPurchasePrice=" + pAssetPurchasePrice +
                    "&pCurrencyNameL1=" + pCurrencyNameL1 +
                    "&pCurrencyValue=" + pCurrencyValue +
                    "&pAssetPurchasePriceBase=" + pAssetPurchasePriceBase +
                    "&pAssetBookValue=" + pAssetBookValue +
                    "&pAssetBookValueBase=" + pAssetBookValueBase +
                    "&pAssetPercent=" + pAssetPercent +
                    "&pAssetLastDepDate=" + pAssetLastDepDate +
                    "&pPostDate=" + pPostDate +
                    "&pBillNo=" + pBillNo +
                    "&pPurchaseNo=" + pPurchaseNo +
                    "&pPurchaseDate=" + pPurchaseDate +
                    "&pAssetSupplierName=" + pAssetSupplierName +
                    "&pAssetMinPrice=" + pAssetMinPrice +
                    "&pAssetMinPriceBase=" + pAssetMinPriceBase +
                    "&pProductPeriod=" + pProductPeriod +
                    "&pMainGroup= " + pMainGroup +
                    "&pGroup= " + pGroup +
                    "&pFixedAssetMethod= " + pFixedAssetMethod +
                    "&pDonor=" + pDonor +
                    "&pBuyGroup=" + pBuyGroup +
                    "&pFixedAssetCompanyName=" + pFixedAssetCompanyName;

                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbAsset.vSQLResult = vDrwResult[0].ToString();
                _dbAsset.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);


                return string.Empty;
            }
            catch (Exception e)
            {

                return string.Empty;
            }
            
        }
        // GET: Asset
        public ActionResult AssetForm()
        {
            // New Model
            AssetModel vAssetModel = new AssetModel();
            return View(vAssetModel);
        }



        // Master Detail For  Group
        public string AssetGET(int? id = 0, AssetModel pAssetModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            string vPostDate = pAssetModel.PostDate.ToString("dd-MM-yyyy");
            string vPurchaseDate = pAssetModel.PurchaseDate.ToString("dd-MM-yyyy");
            string vAssetLastDepDate = pAssetModel.AssetLastDepDate.ToString("dd-MM-yyyy");
            int vQueryTypeId = clsQueryType.qInsert;
            // Data
            string vResult = string.Empty;
            // GET Data
            string vPath = appAPIDirectory.vAPIAsset;
            // Praremeter
            string vParameters =
                    "?pAssetId=" + id +
                    "&pAssetNameL1=" + pAssetModel.AssetNameL1 +
                    "&pAssetNameL2=" + pAssetModel.AssetNameL2 +
                    "&pAssetIsActive=" + pAssetModel.AssetIsActive +
                    "&pAssetCode=" + pAssetModel.AssetCode +
                    "&pAssetQty=" + pAssetModel.AssetQty +
                     "&pSiteId=" + pAssetModel.SiteId +
                    "&pAssetPurchasePrice=" + pAssetModel.AssetPurchasePrice +
                    "&pCurrencyId=" + pAssetModel.CurrencyId +
                    "&pCurrencyValue=" + pAssetModel.CurrencyValue +
                    "&pAssetPurchasePriceBase=" + pAssetModel.AssetPurchasePriceBase +
                    "&pAssetBookValue=" + pAssetModel.AssetBookValue +
                    "&pAssetBookValueBase=" + pAssetModel.AssetBookValueBase +
                    "&pAssetPercent=" + pAssetModel.AssetPercent +
                    "&pAssetLastDepDate=" + vAssetLastDepDate +
                    "&pPostDate=" + vPostDate +
                    "&pAssetTotalDep=" + pAssetModel.AssetTotalDep +
                    "&pAssetTotalDepBase=" + pAssetModel.AssetTotalDepBase +
                    "&pBillNo=" + pAssetModel.BillNo +
                    "&pPurchaseNo=" + pAssetModel.PurchaseNo +
                    "&pPurchaseDate=" + vPurchaseDate +
                    "&pIsAutoPost=" + pAssetModel.IsAutoPost +
                    "&pIsPosted=" + pAssetModel.IsPosted +
                    "&pAssetDebitAccount=" + pAssetModel.AssetDebitAccount +
                    "&pAssetCreditAccount=" + pAssetModel.AssetCreditAccount +
                    "&pAssetPurchaseAccount=" + pAssetModel.AssetPurchaseAccount +
                    "&pAssetSalesAccount=" + pAssetModel.AssetSalesAccount +
                    "&pAssetAccountId=" + pAssetModel.AssetAccountId +
                    "&pAssetSupplierId=" + pAssetModel.AssetSupplierId +
                    "&pAssetSupplierName=" + pAssetModel.AssetSupplierName +
                    "&pAssetMinPrice=" + pAssetModel.AssetMinPrice +
                    "&pAssetMinPriceBase=" + pAssetModel.AssetPurchasePriceBase +
                    "&pProductPeriod=" + pAssetModel.ProductPeriod +
                    "&pInvItemId=" + pAssetModel.InvItemId +
                    "&pMainGroupId=" + pAssetModel.MainGroupId +
                    "&pGroupId=" + pAssetModel.GroupId+
                    "&pInvItemName=" + pAssetModel.InvItemName +
                    "&pFixedAssetMethodId=" + pAssetModel.FixedAssetMethodId +
                    "&pFixedAssetUnitId=" + pAssetModel.FixedAssetUnitId +
                    "&pDonorId=" + pAssetModel.DonorId +
                    "&pBuyGroupId=" + pAssetModel.BuyGroupId +
                    "&pFixedAssetCompanyId=" + pAssetModel.FixedAssetCompanyId +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;
            // Result
            DataRow vDtData = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
            _dbAsset.vSQLResult = vDtData[0].ToString();
            _dbAsset.vSQLResultTypeId = Convert.ToInt32(vDtData[1]);
            // JSON
            vResult = JsonConvert.SerializeObject(vDtData);

            // Return Result
            return vResult;
        }
        public string DeleteAsset(int? pAssetId = null )
        {
            // GET Data
            string vPath = appAPIDirectory.vAPIAsset;
            int vQueryTypeId = clsQueryType.qDelete;
            // Data
            string vResult = string.Empty;
            // Praremeter
            string vParameters =
                    "?pAssetId=" + pAssetId +
                    "&pIsDeleted=" + true +
                    "&pQueryTypeId=" + vQueryTypeId;
            string vJSONResult = _clsAPI.funResultGetJSON(vPath + vParameters);

            return vJSONResult;
 

        }
        public ActionResult AssetSearch()
        {

            return View();
        }
        public string FilterAsset(string pAssetCode = null, string pAssetNameL1 = null, string pAssetNameL2 = null,string pLstGroup = null, string pLstMethod = null,string pLstSupplier = null,string pLstBuyGroup = null)
        {

            string vAPIPath = "/APIAsset/AssetGET?pAssetCode=" + pAssetCode + "&&pAssetNameL1=" + pAssetNameL1 + "&&pAssetNameL2=" + pAssetNameL2 + "&&pLstGroup=" + pLstGroup + "&&pLstMethod=" + pLstMethod + "&&pLstSupplier=" + pLstSupplier + "&&pLstBuyGroup="+ pLstBuyGroup + "&&pQueryTypeId=" + 401;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }
        public string GetSelectedAsset(int? pAssetId = null, int? pQueryTypeId = null)
        {

            string vAPIPath = "/APIAsset/AssetGET?pAssetId=" + pAssetId + "&&pQueryTypeId=" + pQueryTypeId;
            string vJSONResult = _clsAPI.funResultGetJSON(vAPIPath);

            return vJSONResult;
        }

        public void ShowSimple()
        {

          
            DataTable DT = _dbAsset.funGetAssetReport();
            string vReportPath = Server.MapPath("~/Reports") + "//AssetReport.rpt";
            ClsReport.Printreport(DT, vReportPath);


        }
        public ActionResult AssetReport(int? pCompanyId = null)
        {
         
            return View();
        }

    }
}